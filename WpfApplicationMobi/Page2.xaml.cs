using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplicationMobi
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            List<Dossier> listdos = new List<Dossier>();
            listdos.Add(new Dossier("tutu"));
            listdos.Add(new Dossier("toto"));
            listdos.Add(new Dossier("tata"));
            listView.ItemsSource = listdos;

        }

        private void scrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
            System.Diagnostics.Debug.WriteLine(scrollBar.Value);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            scrollBar.Visibility = Visibility.Hidden;
            double totot = this.scrollBar.Value;
            double t = totot + 0.1;
            scrollBar.Value = t;
            System.Diagnostics.Debug.WriteLine(scrollBar.Value);
            System.Diagnostics.Debug.WriteLine(scrollBar.Maximum);
            System.Diagnostics.Debug.WriteLine(scrollBar.Minimum);
            double size = scrollBar.Maximum - scrollBar.Minimum;
            System.Diagnostics.Debug.WriteLine(size);
        }

        private void button_Click_bas(object sender, RoutedEventArgs e)
        {
            scrollBar.Visibility = Visibility.Hidden;
            double totot = this.scrollBar.Value;
            double t = totot - 0.1;
            scrollBar.Value = t;
            System.Diagnostics.Debug.WriteLine(scrollBar.Value);
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public class Dossier {

            private string Nom { get; set; }

            public Dossier(string nom) {
                this.Nom = nom;
            }
        }
    }
}
