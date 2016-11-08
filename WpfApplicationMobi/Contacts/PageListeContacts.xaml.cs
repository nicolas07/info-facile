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
            
            listViewContacts.ItemsSource = FileHelper.Instance.LireFichierConfigContacts();
            int count = listViewContacts.Items.Count;
            if (count == 0) {
                listViewContacts.Visibility = Visibility.Hidden;
                button_Suivant.Visibility = Visibility.Hidden;
                button_Precedent.Visibility = Visibility.Hidden;
                label_listevide.Visibility = Visibility.Visible;
                label_listevide.Content = "Aucun contact enregistré trouvé";
            } else
            {
                listViewContacts.Visibility = Visibility.Visible;
                button_Suivant.Visibility = Visibility.Visible;
                button_Precedent.Visibility = Visibility.Visible;
                label_listevide.Visibility = Visibility.Hidden;


                //Selection du premier contact de liste
                listViewContacts.SelectedIndex = 0;
                listViewContacts.Focus();

            }


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
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                Contact obj = item.DataContext as Contact;
                NavigateContact.Navigate(this.NavigationService, new Uri("./Contacts/PageDetailsContact.xaml", UriKind.Relative), obj);

            }
        }

        private void button_Ajouter_Click(object sender, RoutedEventArgs e)
        {
            NavigateContact.Navigate(this.NavigationService, new Uri("./Contacts/PageAjouterContact.xaml", UriKind.Relative), null);
        }
    }
}
