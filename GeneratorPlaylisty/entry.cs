using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Threading;
using CommandLine;
using CommandLine.Text;
namespace GeneratorPlaylisty
{
    class entry
    {
        static private void DisplayFormThread()
        {
            MainWindow ObjMain = null;
            try
            {
                ObjMain = new MainWindow();
                ObjMain.Show();
                ObjMain.Closed += (s, e) => System.Windows.Threading.Dispatcher.ExitAllFrames();
                System.Windows.Threading.Dispatcher.Run();
            }
            catch (Exception) {
            }
        }
        static void Main(params string[] args) {
            if (args.Length == 0)
            {
                Console.In.Close();
                var thread = new Thread(new ThreadStart(DisplayFormThread));
                thread.ApartmentState = ApartmentState.STA;
                thread.Start();
            }
            else
            {
                ObslugaZcmd(args);
                Console.ReadKey();
            }
        }

        private static void ObslugaZcmd(string[] args)
        {
            var opcje = new cmdOpt();
            CommandLine.Parser parser = new CommandLine.Parser();
            string zrodlo, cel;
            int ilosc = 0;
            parser.ParseArguments(args, opcje);
            if (opcje.pomocy) { pomoc(); Environment.Exit(0); }
            zrodlo = (opcje.Source != null) ? opcje.Source : pobierz("folder źródłowy.");
            cel = (opcje.Dest != null) ? opcje.Dest : pobierz("plik do którego mam zapisać listę.");
            if (opcje.Count < 1)
            {
                try{
                    ilosc = Int32.Parse(pobierz("ilość elementów w liście"));
                }
                catch(Exception){
                    MessageBox.Show("Nieprawidłowa ilość elementów");
                    Environment.Exit(1);
                }

            }
            else ilosc = opcje.Count;
            generator gen = new generator();
            gen.szukaj(ilosc, zrodlo, cel);
        }
        private static void pomoc()
        {
            Console.WriteLine("\nGenerator playlisty by Piatkosia");
            Console.WriteLine("Sposób użycia:");
            Console.WriteLine("Wywołanie bez parametrów powoduje wyświetlenie GUI");
            Console.WriteLine("-h lub --help : ten plik pomocy");
            Console.WriteLine("-s lub --source : folder źródłowy (skąd brać elementy)");
            Console.WriteLine("-d lub --saveas : plik.m3u do którego zapisać playlistę");
            Console.WriteLine("-c lub --count : ile elementów w liście ma być");
        }

        private static string pobierz(string co)
        {
            Console.WriteLine();
            Console.WriteLine("Podaj {0}", co);
            return Console.ReadLine().Trim();
        }
    }
}
