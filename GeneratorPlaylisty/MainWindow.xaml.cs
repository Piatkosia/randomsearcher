using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Finders;
using winchange;
namespace GeneratorPlaylisty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static bool isconsoleapplication = false;
        static generator pow;
        public MainWindow()
        {
                InitializeComponent();
                if (isconsoleapplication == false)
                    consolemanager.hideconsole();
                else this.Visibility = System.Windows.Visibility.Collapsed;
                pow = new generator();
                baza.Text += "\n";
                foreach (string a in pow.ext)
                {
                    baza.Text += (" " + a + ",");
                }
            }
        private void generate_Click(object sender, RoutedEventArgs e)
        {
            if (ile.NumValue < 0) MessageBox.Show("Tylu nie dam rady znaleźć.");
            else pow.szukaj(ile.NumValue, skad.Text, gdzie.Text);
            skad.Text = "";
            gdzie.Text = "";
            ile.NumValue = 0;
            Console.Clear();
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            consolemanager.showconsole();
        }
        private void checkBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            consolemanager.hideconsole();
        }
        private void papa(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            about okienko = new about();
            okienko.Show();
        }

        private void ext_Click(object sender, RoutedEventArgs e)
        {
            if (newext.Text.Length > 5)
            {
                MessageBox.Show("Nieprawidłowe rozszerzenie pliku multimedialnego!");
                newext.Text = "";
                return;
            }

            foreach (char c in newext.Text)
            {
                // Jeśli rozszerzenie zawiera znaki z poniższych zakresów (%^-; etc) zgłoś błąd
                if (((int)c < 48) || ((int)c > 57 && (int)c < 65) || ((int)c > 90 && (int)c < 97) || ((int)c > 122))
                {
                    MessageBox.Show("Rozszerzenie zawiera niedozwolone znaki.");
                    newext.Text = "";
                    return;
                }
            }

            pow.AddToList(newext.Text);
            baza.Text += " " + newext.Text;
            newext.Text = "";
          
        }

    }
}