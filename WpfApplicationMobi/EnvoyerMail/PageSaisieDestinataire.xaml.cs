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
using WpfApplicationMobi.Contacts;

namespace WpfApplicationMobi.EnvoyerMail
{
    /// <summary>
    /// Logique d'interaction pour PageSaisieDestinataire.xaml
    /// </summary>
    public partial class PageSaisieDestinataire : Page
    {

        //TO DO : Verifier format adresse mail saisie

        public PageSaisieDestinataire()
        {
            InitializeComponent();

            listViewContacts.ItemsSource = FileHelper.Instance.LireFichierConfigContacts();
            int count = listViewContacts.Items.Count;
            if (count == 0)
            {
                listViewContacts.Visibility = Visibility.Hidden;
                button_Suivant.Visibility = Visibility.Hidden;
                button_Precedent.Visibility = Visibility.Hidden;
                label_listevide.Visibility = Visibility.Visible;
                label_listevide.Content = "Aucun contact enregistré trouvé";
            }
            else
            {
                listViewContacts.Visibility = Visibility.Visible;
                button_Suivant.Visibility = Visibility.Visible;
                button_Precedent.Visibility = Visibility.Visible;
                label_listevide.Visibility = Visibility.Hidden;


                //Selection du premier contact de liste
                listViewContacts.SelectedIndex = 0;
                listViewContacts.Focus();

            }

            Mail m = NavigateMail.GetNavigationData(this.NavigationService);
            string dest = "";
            if ( m != null && m.Destinataires != null && m.Destinataires.Count > 0 ) {
                
                foreach (string des in m.Destinataires) {
                    if (dest != "")
                    {
                        dest = string.Concat(dest, ",", des);
                    }
                    else {
                        dest = des;
                    }
                    
                }
            }

            textBox_Destinataire.Text = dest;
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

        private void ListViewItem_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            label_Erreur.Content = "";
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                Contact obj = item.DataContext as Contact;

                if (textBox_Destinataire.Text.Length > 0)
                {
                    textBox_Destinataire.Text = string.Concat(textBox_Destinataire.Text, ",", obj.Email);
                }
                else
                {
                    textBox_Destinataire.Text = obj.Email;
                }

            }
        }

        private void button_Suivant_Etape_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_Destinataire.Text.Length > 0)
            {
                string[] tokens = textBox_Destinataire.Text.Split(',');
                Mail mail = new Mail();
                List<string> liste_destinataires = new List<string>();
                for (int i = 0; i < tokens.Length; i++)
                {
                    liste_destinataires.Add(tokens[i]);
                }
                mail.Destinataires = liste_destinataires;

                NavigateMail.Navigate(this.NavigationService, new Uri("./EnvoyerMail/PageSaisieObjet.xaml", UriKind.Relative), mail);

            }
            else
            {
                label_Erreur.Content = "Veuillez saisir l'adresse mail du destinataire !";
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            label_Erreur.Content = "";
        }
    }
}
