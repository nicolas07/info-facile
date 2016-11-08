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

namespace WpfApplicationMobi.Contacts
{
    /// <summary>
    /// Logique d'interaction pour PageConfirmationAjouterContact.xaml
    /// </summary>
    public partial class PageConfirmationAjouterContact : Page
    {
        public PageConfirmationAjouterContact()
        {
            InitializeComponent();
            Contact c = NavigateContact.GetNavigationData(this.NavigationService);
            if (c.estAjoute)
            {
                label_Fin.Foreground = System.Windows.Media.Brushes.Green;
                label_Fin.Content = "Contact bien ajouté";
            }
            else
            {
                label_Fin.Foreground = System.Windows.Media.Brushes.Red;
                label_Fin.Content = "Contact non ajouté, une erreur s'est produite ! Merci de reessayer plus tard.";
            }
        }

        private void button_Retour_Click(object sender, RoutedEventArgs e)
        {
            WindowAccueil winAccueil = new WindowAccueil();
            //Affichage de la WindowAccueil
            winAccueil.Show();
            //Fermeture de la WindowContact
            var window = Window.GetWindow(this);
            ((WindowContacts)window).Close();
        }
    }
}
