﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfApplicationMobi.RecevoirMails
{
    /// <summary>
    /// Logique d'interaction pour PageListeMails.xaml
    /// </summary>
    public partial class PageListeMails : Page
    {

        public PageListeMails()
        {
            InitializeComponent();
            
            listViewEmail.ItemsSource = NavigateReceptionMail.GetNavigationData(this.NavigationService);
        }
        
        private void ListViewItem_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                MailRecu obj = item.DataContext as MailRecu;
                BDDHelper.getInstance().ModifierEtatMail(obj);
                NavigateReceptionMailTest.Navigate(this.NavigationService, new Uri("./RecevoirMails/PageDetailMail.xaml", UriKind.Relative), obj);

            }
        }

        private void button_Suivant_Click(object sender, RoutedEventArgs e)
        {
            int index = listViewEmail.Items.IndexOf(listViewEmail.SelectedItem);
            listViewEmail.UpdateLayout(); // Pre-generates item containers 
            int next = index + 1;
            if (next < listViewEmail.Items.Count)
            {
                var newitem = listViewEmail.Items.GetItemAt(next);
                listViewEmail.SelectedIndex = next;
                var listBoxItem = (ListBoxItem)listViewEmail
                    .ItemContainerGenerator
                    .ContainerFromItem(newitem);

                listBoxItem.Focus();
            }
        }

        private void button_Precedent_Click(object sender, RoutedEventArgs e)
        {
            int index = listViewEmail.Items.IndexOf(listViewEmail.SelectedItem);
            listViewEmail.UpdateLayout(); // Pre-generates item containers 
            int next = index - 1;
            if (next > -1)
            {
                var newitem = listViewEmail.Items.GetItemAt(next);
                listViewEmail.SelectedIndex = next;
                var listBoxItem = (ListBoxItem)listViewEmail
                    .ItemContainerGenerator
                    .ContainerFromItem(newitem);

                listBoxItem.Focus();
            }
        }
    }
}
