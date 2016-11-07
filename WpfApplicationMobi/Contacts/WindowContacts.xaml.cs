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
using System.Windows.Shapes;

namespace WpfApplicationMobi
{
    /// <summary>
    /// Interaction logic for WindowContacts.xaml
    /// </summary>
    public partial class WindowContacts : Window
    {
        public WindowContacts()
        {
            InitializeComponent();
            //On charge la page dans le frame de la Window
            FrameContacts.NavigationService.Navigate(new Uri("./Contacts/PageListeContacts.xaml", UriKind.Relative));
        }

        private void ButtonRetour_Click(object sender, RoutedEventArgs e)
        {
           //TO DO : GEstion de bouton annuler en fonction de la page affichée
        }

        private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            WindowAccueil winAccueil = new WindowAccueil();
            //Affichage de la page Accueil
            winAccueil.Show();
            //Fermeture de la WindowContacts
            this.Close();
        }
    }
}
