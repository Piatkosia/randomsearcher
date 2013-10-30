using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Finders;
namespace Programik
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] result;
            string sciezka = null;
            Console.Write("Gdzie szukać?  ");
            sciezka = Console.ReadLine();
            int ilosc;
            try
            {
                if (args.Length > 0) ilosc = int.Parse(args[0]);
                else ilosc = 5;
                result = new string[ilosc];
                result = RandomSearcher.szukaj(sciezka.Trim(), ilosc);
                konsolowo(result);
                if (args.Length> 1) {
                    plikowo(args, result);
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Coś nie wyszło:(\n" + e.Message + e.Source + e.GetType());
                Console.ReadLine();
            }
        }

        private static void plikowo(string[] args, string[] result)
        {
            if (result == null) Console.WriteLine("Nic nie znaleziono. Plik nie został stworzony.");
            if (result != null)
            {
                StreamWriter plik = new StreamWriter(args[1], true);
                plik.WriteLine("********************************Nowe wyszukiwanie********************************");
                foreach (string a in result)
                {
                    plik.WriteLine(a);
                };
                plik.WriteLine("*********************************************************************************\n");
                plik.Close();
            }
        }

        private static void konsolowo(string[] result)
        {
            if (result == null) Console.WriteLine("Nic nie znaleziono.");
            else
            {
                foreach (string a in result)
                {
                    Console.WriteLine(a);
                };
            }
            Console.ReadLine();
        }

    }
}
