using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finders;
using System.IO;
using System.Windows;

namespace GeneratorPlaylisty
{
    class generator
    {
        public List<string> ext;
        public generator()
        {
            ext = new List<string>();
            AddMultimedia();
        }

        private void AddMultimedia()
        {
            ext.Add(".mp3");
            ext.Add(".ogg");
            ext.Add(".mpc");
            ext.Add(".wma");
            ext.Add(".mod");
            ext.Add(".pls");
            ext.Add(".m3u");
            ext.Add(".mp4");
            ext.Add(".flv");
            ext.Add(".avi");
            ext.Add(".midi");
        }
        public void AddToList(string a)
        {
            if (ext.Contains(a)) return;
            ext.Add(a);
        }



        public void szukaj(int p, string sciezka, string cel)
        {

            string[] result = new string[p];
            result = RandomSearcher.szukaj(sciezka, p, ext.ToArray());
            if (result == null) {
                MessageBox.Show("Nic nie znaleziono:(");
                return;
            }
            StreamWriter plik = new StreamWriter(cel, true);
            foreach (string a in result)
            {
                zapisz(a, plik);
            }
            plik.Close();
            MessageBox.Show("Zakończono generowanie");
        
        }

        private void zapisz(string a, StreamWriter plik)
        {
            if (a.Trim().Length > 0)
            {
                Console.WriteLine(a);
                plik.WriteLine(a);
            }
            else Console.Write("");
 
        }
    }
}
