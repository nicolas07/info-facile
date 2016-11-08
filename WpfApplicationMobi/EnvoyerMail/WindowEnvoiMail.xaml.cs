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
using WpfApplicationMobi.EnvoyerMail;

namespace WpfApplicationMobi
{
    /// <summary>
    /// Interaction logic for WindowEnvoiMail.xaml
    /// </summary>
    public partial class WindowEnvoiMail : Window
    {
        public WindowEnvoiMail()
        {
            InitializeComponent();
            //On charge la page dans le frame de la Window
            NavigateMail.Navigate(FrameEnvoiMail.NavigationService, new Uri("./EnvoyerMail/PageSaisieDestinataire.xaml", UriKind.Relative), new Mail());
            //FrameEnvoiMail.NavigationService.Navigate(new Uri("./EnvoyerMail/PageSaisieDestinataire.xaml", UriKind.Relative));
        }

        public WindowEnvoiMail(Uri uri, Mail m) {
            InitializeComponent();
            NavigateMail.Navigate(FrameEnvoiMail.NavigationService,uri, m);
        }

        private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            WindowAccueil winAccueil = new WindowAccueil();
            //Affichage de la WindowAccueil
            winAccueil.Show();
            //Fermeture de la WindowEnvoyerMail
            this.Close();
        }

        private void ButtonRetour_Click(object sender, RoutedEventArgs e)
        {
            //TO DO : Coder gestion du boutons retour
            string current_page = FrameEnvoiMail.NavigationService.Content.GetType().Name.ToString();

            switch (current_page) {
                case "PageSaisieObjet":
                    NavigateMail.Navigate(FrameEnvoiMail.NavigationService, new Uri("./EnvoyerMail/PageSaisieDestinataire.xaml", UriKind.Relative), NavigateMail.GetNavigationData(FrameEnvoiMail.NavigationService));
                    break;

                case "PageSaisieMessage":
                    NavigateMail.Navigate(FrameEnvoiMail.NavigationService, new Uri("./EnvoyerMail/PageSaisieObjet.xaml", UriKind.Relative), NavigateMail.GetNavigationData(FrameEnvoiMail.NavigationService));
                    break;
                default :
                    WindowAccueil winAccueil = new WindowAccueil();
                    //Affichage de la WindowAccueil
                    winAccueil.Show();
                    //Fermeture de la WindowEnvoyerMail
                    this.Close();
                    break;
            }
        }
    }
}
