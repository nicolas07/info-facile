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
    /// Logique d'interaction pour PageAjouterContact.xaml
    /// </summary>
    public partial class PageAjouterContact : Page
    {
        private bool erreur;

        private string cheminImage;
        public PageAjouterContact()
        {
            InitializeComponent();
        }

        private void button_ChoisirImage_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = "*.*";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                // Open document 
                cheminImage = dlg.FileName;
                string tmp = cheminImage.Substring(cheminImage.LastIndexOf("\\") + 1);
                textBox_Image.Text = tmp;
                image_Preview.Source = new BitmapImage(new Uri(cheminImage, UriKind.RelativeOrAbsolute));
            }
        }

        private void button_Ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_Email.Text.Length > 0 && textBox_Image.Text.Length > 0 && textBox_Email.Text.Length > 0 && textBox_Telephone.Text.Length > 0)
            {
                Contact c = new Contact();
                c.Nom = textBox_Nom.Text;
                c.Image = cheminImage;
                c.Email = textBox_Email.Text;
                c.NumeroTelephone = textBox_Telephone.Text;

                bool res = FileHelper.Instance.AjouterContact(c);
                c.estAjoute = res;

                //Maj liste contact
                NavigateContact.setContacts(FileHelper.Instance.LireFichierConfigContacts());

                NavigateContact.Navigate(this.NavigationService, new Uri("./Contacts/PageConfirmationAjouterContact.xaml", UriKind.Relative), c);

            }
            else {
                label_Erreur.Content = "Veuillez renseigner tous les champs";
                erreur = true;
            }
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var obj = sender;
            var evt = e;
            if (erreur) {
                label_Erreur.Content = "";
            }
           
        }
    }
}
