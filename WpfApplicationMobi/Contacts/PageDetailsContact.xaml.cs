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
using WpfApplicationMobi.EnvoyerMail;

namespace WpfApplicationMobi.Contacts
{
    /// <summary>
    /// Logique d'interaction pour PageDetailsContact.xaml
    /// </summary>
    public partial class PageDetailsContact : Page
    {
        public PageDetailsContact()
        {
            InitializeComponent();
            Contact contact = NavigateContact.GetNavigationData(this.NavigationService);
            labelEmail.Content = contact.Email;
            labelNom.Content = contact.Nom;
            labelTelephone.Content = contact.NumeroTelephone;
            image_Contact.Source = new BitmapImage(new Uri(contact.Image, UriKind.RelativeOrAbsolute));
        }

        private void button_Appeler_Click(object sender, RoutedEventArgs e)
        {
            //TO DO : Lancer appel sur telephone.
        }

        private void button_EnvoyerEmail_Click(object sender, RoutedEventArgs e)
        {
            //TO DO : REdirection vers la cinématique d'envoi de mail mais uniquement saisie message et siasie PJ
            Mail mail = new Mail();
            mail.Destinataires = new List<string>() { labelEmail.Content.ToString() };
            Uri uri = new Uri("./EnvoyerMail/PageSaisieObjet.xaml", UriKind.Relative);

            WindowEnvoiMail winEnvoiMail = new WindowEnvoiMail(uri, mail);
            //Affichage de la WindowAccueil
            winEnvoiMail.Show();
            //Fermeture de la WindowContact
            var window = Window.GetWindow(this);
            ((WindowContacts)window).Close();

            //NavigateMail.Navigate(this.NavigationService, new Uri("./EnvoyerMail/PageSaisieObjet.xaml", UriKind.Relative), mail);
        }
    }
}
