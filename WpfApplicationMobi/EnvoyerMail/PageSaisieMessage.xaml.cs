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

namespace WpfApplicationMobi.EnvoyerMail
{
    /// <summary>
    /// Logique d'interaction pour PageSaisieMessage.xaml
    /// </summary>
    public partial class PageSaisieMessage : Page
    {
        public PageSaisieMessage()
        {
            InitializeComponent();
        }

        private void button_Envoyer_Click(object sender, RoutedEventArgs e)
        {
            Mail mail = NavigateMail.GetNavigationData(this.NavigationService);
            if (textBox_Message.Text.Length > 0)
            {
                mail.Message = textBox_Message.Text;

                bool res = new EnvoiMailHelper().EnvoyerMail(mail);

                mail.estEnvoye = res;

                NavigateMail.Navigate(this.NavigationService, new Uri("./EnvoyerMail/PageConfirmation.xaml", UriKind.Relative), mail);
            }
            else
            {
                label_Erreur.Content = "Veuillez saisir un message";
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            label_Erreur.Content = "";
        }
    }
}
