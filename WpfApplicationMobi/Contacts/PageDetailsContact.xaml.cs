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
            image_Contact.Source = new BitmapImage(new Uri(contact.Image, UriKind.Relative));
        }
    }
}
