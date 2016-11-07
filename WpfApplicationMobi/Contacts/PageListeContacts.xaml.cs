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
    /// Logique d'interaction pour PageListeContacts.xaml
    /// </summary>
    public partial class PageListeContacts : Page
    {
        public PageListeContacts()
        {
            InitializeComponent();

            //Creation d'une liste de contacts factices.
            List<Contact> listeContacts = new List<Contact>();
            for (int i = 0; i < 20; i++) {
                string nom = "Nom Test " + i;
                string email = "toto@gmail.com " + i;
                string telephone = "0606060606 " + i;
                Contact item = new Contact() {Nom = nom, Email = email, NumeroTelephone = telephone, Image = "/Ressources/Icones/contactdefaut128.png" };
                listeContacts.Add(item);
            }
            listViewContacts.ItemsSource = listeContacts;

            //Selection du premier contact de liste
            listViewContacts.SelectedIndex = 0;
            listViewContacts.Focus();

            //Affichage details 1er contact
            Contact contact = listViewContacts.Items.GetItemAt(0) as Contact;
            labelEmail.Content = contact.Email;
            labelNom.Content = contact.Nom;
            labelTelephone.Content = contact.NumeroTelephone;
            image_Contact.Source = new BitmapImage(new Uri(contact.Image, UriKind.Relative ));

        }

        private void button_Precedent_Click(object sender, RoutedEventArgs e)
        {
            int index = listViewContacts.Items.IndexOf(listViewContacts.SelectedItem);
            listViewContacts.UpdateLayout(); // Pre-generates item containers 
            int next = index - 1;
            if (next > -1)
            {
                var newitem = listViewContacts.Items.GetItemAt(next);
                listViewContacts.SelectedIndex = next;
                var listBoxItem = (ListBoxItem)listViewContacts
                    .ItemContainerGenerator
                    .ContainerFromItem(newitem);

                listBoxItem.Focus();
            }
        }

        private void button_Suivant_Click(object sender, RoutedEventArgs e)
        {
            int index = listViewContacts.Items.IndexOf(listViewContacts.SelectedItem);
            listViewContacts.UpdateLayout(); // Pre-generates item containers 
            int next = index + 1;
            if (next < listViewContacts.Items.Count)
            {
                var newitem = listViewContacts.Items.GetItemAt(next);
                listViewContacts.SelectedIndex = next;
                var listBoxItem = (ListBoxItem)listViewContacts
                    .ItemContainerGenerator
                    .ContainerFromItem(newitem);

                listBoxItem.Focus();
            }
        }

        private void listViewContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact contact = listViewContacts.Items.GetItemAt(listViewContacts.SelectedIndex) as Contact;
            labelEmail.Content = contact.Email;
            labelNom.Content = contact.Nom;
            labelTelephone.Content = contact.NumeroTelephone;
            image_Contact.Source = new BitmapImage(new Uri(contact.Image, UriKind.Relative));
        }
    }
}
