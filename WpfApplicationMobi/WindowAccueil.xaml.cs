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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplicationMobi
{
    /// <summary>
    /// Interaction logic for WindowAccueil.xaml
    /// </summary>
    public partial class WindowAccueil : Window
    {
        public WindowAccueil()
        {
            InitializeComponent();
            FileHelper.Instance.CreerDossierRacine();
        }
        
        private void Button_Click_Recherche(object sender, RoutedEventArgs e)
        {
            WindowRecherche win = new WindowRecherche();
            win.Show();
            this.Close();
        }

        private void Button_Click_Envoi_Mail(object sender, RoutedEventArgs e)
        {
            WindowEnvoiMail win = new WindowEnvoiMail();
            win.Show();
            this.Close();
        }

        private void Button_Click_Reception_Mail(object sender, RoutedEventArgs e)
        {
            WindowReceptionMail win = new WindowReceptionMail();
            win.Show();
            this.Close();
        }

        private void Button_Click_Photos(object sender, RoutedEventArgs e)
        {
            WindowPhotos win = new WindowPhotos();
            win.Show();
            this.Close();

        }

        private void Button_Click_Contact(object sender, RoutedEventArgs e)
        {
            WindowContacts win = new WindowContacts();
            win.Show();
            this.Close();

        }
    }
}
