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
using System.Windows.Shapes;

namespace GeneratorPlaylisty
{
    /// <summary>
    /// Interaction logic for about.xaml
    /// </summary>
    public partial class about : Window
    {
        public about()
        {
            InitializeComponent();
            textBlock3.Text =
             "• Nikow & pr0t (zgłoszenia błędów, betatesterzy)" + System.Environment.NewLine +
             "• Społecznościom: stackoverflow.com, www.codeproject.com oraz www.codeplex.com" + System.Environment.NewLine +
             "• Społeczności #listekklonu";
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
