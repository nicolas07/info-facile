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
using WpfApplicationMobi.RecevoirMails;

namespace WpfApplicationMobi
{
    /// <summary>
    /// Interaction logic for WindowReceptionMail.xaml
    /// </summary>
    public partial class WindowReceptionMail : Window
    {
        public WindowReceptionMail()
        {
            InitializeComponent();

            FrameReceptionMail.NavigationService.Navigate(new Uri("./RecevoirMails/PageListeMails.xaml", UriKind.Relative));
        }

        private void ButtonRetour_Click(object sender, RoutedEventArgs e)
        {
            string current_page = FrameReceptionMail.NavigationService.Content.GetType().Name.ToString();

            switch (current_page)
            {
                case "PageDetailMail":
                    NavigateReceptionMail.Navigate(FrameReceptionMail.NavigationService, new Uri("./RecevoirMails/PageListeMails.xaml", UriKind.Relative), NavigateReceptionMail.GetNavigationData(FrameReceptionMail.NavigationService));
                    break;

                default:
                    WindowAccueil winAccueil = new WindowAccueil();
                    //Affichage de la WindowAccueil
                    winAccueil.Show();
                    //Fermeture de la WindowEnvoyerMail
                    this.Close();
                    break;
            }
        }

        private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            WindowAccueil winAccueil = new WindowAccueil();
            //Affichage de la WindowAccueil
            winAccueil.Show();
            //Fermeture de la WindowEnvoyerMail
            this.Close();
        }
    }
}
