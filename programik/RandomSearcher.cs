using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Collections;
using System.Security.AccessControl;
namespace RandomSearcher
{
    class RandomSearcher
    {
        static Random R = new Random();
        static string[] wyniki = null;
        public static string szukaj(string path)
        {
            string file = null;
            List<string> rgFiles = null;
            if (path.Length > 4) {
                 rgFiles = new List<string>(Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories));
            }
            else  rgFiles = new List<string>(Directory.EnumerateFiles(path, "*.*", SearchOption.TopDirectoryOnly)); 
            try
            {
                file = rgFiles[R.Next(0, rgFiles.Count)] ;
            }
            catch (UnauthorizedAccessException e) {
                rgFiles.Clear();
                rgFiles = new List<string>(Directory.EnumerateFiles(path, "*.*", SearchOption.TopDirectoryOnly));
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("Nie mogę znaleźć:(\n" + e.Message + e.Source + e.GetType(), "Ups...", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return file;
        }

        public static string about() {
            return "Random path searching by Piatkosia:)";
        }

        public static string[] szukaj(string path, int count)
        {
            string[] wyniki = new string[count];
            for (int i = 0; i < count; i++)
            {
                wyniki[i] = szukaj(path);
            }
            return wyniki;
        }
        /// <summary>
        /// Ta funkcja zakłada że szukanymi są ścieżki i wyszukuje tylko takich, które mają dany typ. Przykład typu ".txt"
        /// </summary>
        /// <param name="path">ścieżka dostępu</param>
        /// <param name="count">ile ma zwrócić </param>
        /// <param name="kryterium">Lista rozszerzeń</param>
        /// <returns></returns>
        public static string[] szukaj(string path, int count, string[] kryterium)
        {
            string[] wyniki = new string[count];
            for (int i = 0; i < count; i++)
            {
                wyniki[i] = szukaj(path);
                if (nalezy(wyniki[i], kryterium) == false)
                {
                    i--; // bo pomiarów będzie więcej
                    continue;
                }
                
            }
            return wyniki;
        }

        private static bool nalezy(string p, string[] kryterium)
        {
            string tmp = Path.GetExtension(p);
            foreach (string a in kryterium) {
                if ( a == p) return true;
            }
            return false;
        }

    }
}
