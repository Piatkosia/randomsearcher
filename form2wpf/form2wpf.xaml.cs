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
namespace form2wpf
{
    /// <summary>
    /// Interaction logic for form2wpf.xaml
    /// </summary>
    public partial class form2wpf : UserControl
    {
        public System.Windows.Forms.Integration.WindowsFormsHost host = null;
        public form2wpf()
        {
            InitializeComponent();
            host = new System.Windows.Forms.Integration.WindowsFormsHost();
            alocator.Children.Add(host);
        }

        public void addItem(System.Windows.Forms.Control dodany ) {
            host.Child = dodany;
        }
    }
}
