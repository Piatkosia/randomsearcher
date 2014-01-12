using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Collections;
using System.Security.AccessControl;
namespace Finders
{
    public class RandomSearcher
    {
        static Random R = new Random();
        static string[] wyniki = null;
        static List<string> rgFiles = null;
        static bool wylosowano = false;
        static void generuj(string path)
        {
            if (wylosowano == false)
            {
                rgFiles = new List<string>(Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories));
                wylosowano = true;
            }
        }
        public static string szukaj(string path)
        {
            string file = null;
            bool bylo = false;
            generuj(path);
            try
            {
                if (rgFiles.Count == 0) return null;
                else
                {
                    int i = R.Next(0, rgFiles.Count);
                    file = rgFiles[i];
                    rgFiles.RemoveAt(i);
                    if (rgFiles.Count == 0 && bylo == true)
                    {
                        wylosowano = false;
                        bylo = true;
                        generuj(path);
                    }
                    else if (bylo == true) {
                        if (rgFiles.Count == 0) {
                            return null; 
                        }
                        else bylo = false;
                    }
                }

            }
            catch (UnauthorizedAccessException) {
                rgFiles.Clear();
                rgFiles = new List<string>(Directory.EnumerateFiles(path, "*.*", SearchOption.TopDirectoryOnly));
                if (rgFiles.Count == 0) throw new FileNotFoundException();
            }
            return file;
        }

        public static string about() {
            return "Random path searching by Piatkosia:)";
        }

        public static string[] szukaj(string path, int count)
        {
            if (count < 1)
            {
                MessageBox.Show("Nie mam tu czego szukać");
                return null;
            }
            else
            {
                wyniki = new string[count];
                for (int i = 0; i < count; i++)
                {
                    wyniki[i] = szukaj(path);
                    if (wyniki[i] == null) { wyniki[i] = null; break; }
                }
                return wyniki;
            }
        }
        /// <summary>
        /// Ta funkcja zakłada że szukanymi są ścieżki i wyszukuje tylko takich, które mają dany typ. Przykład typu ".txt"
        /// </summary>
        /// <param name="path">ścieżka dostępu</param>
        /// <param name="count">ile ma zwrócić </param>
        /// <param name="kryterium">Lista rozszerzeń</param>
        /// <returns>Zwraca wynik wyszukiwania</returns>
        public static string[] szukaj(string path, int count, string[] kryterium)
        {
            if (count < 1) {
                MessageBox.Show("Nie mam tu czego szukać");
                return null;
            }
            wyniki = new string[count];
            try
            {
                for (int i = 0; i < count; i++)
                {
                    do
                    {
                        wyniki[i] = szukaj(path);
                        if (wyniki[i] == null) break;

                    } while (nalezy(wyniki[i], kryterium) == false);
                    if (wyniki[i] == null)
                    {
                        throw new FileNotFoundException();
                    }
                }
                return wyniki;
            }
            catch (FileNotFoundException) {
                return null;
            }
        }
        private static bool nalezy(string p, string[] kryterium)
        {
            string tmp = Path.GetExtension(p);
            bool wtf = false;
            foreach (string a in kryterium)
            {
                if (tmp == null) break;
                if (a == tmp) wtf = true;
            }
            return wtf;
        }
}}
