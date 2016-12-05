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
    /// Interaction logic for WindowPhotos.xaml
    /// </summary>
    public partial class WindowPhotos : Window
    {
        public WindowPhotos()
        {
            InitializeComponent();

            FramePhotos.NavigationService.Navigate(new Uri("./Photos/ListePhotosPage.xaml", UriKind.Relative));
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
            WindowAccueil winAccueil = new WindowAccueil();
            //Affichage de la WindowAccueil
            winAccueil.Show();
            //Fermeture de la WindowEnvoyerMail
            this.Close();
        }
    }
}
