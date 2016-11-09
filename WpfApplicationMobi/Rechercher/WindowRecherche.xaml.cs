using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WindowRecherche : Window
    {
        public WindowRecherche()
        {
            InitializeComponent();
            //On charge la page dans le frame de la Window
            FrameRecherche.NavigationService.Navigate(new Uri("./Rechercher/PageRechercher.xaml", UriKind.Relative));

        }

        private void ButtonRetour_Click(object sender, RoutedEventArgs e)
        {
            WindowAccueil winAccueil = new WindowAccueil();
            //Affichage de la page Accueil
            winAccueil.Show();
            //Fermeture de la WindowRecherche
            this.Close();
        }

        private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            WindowAccueil winAccueil = new WindowAccueil();
            //Affichage de la page Accueil
            winAccueil.Show();
            //Fermeture de la WindowRecherche
            this.Close();
        }
    }
}
