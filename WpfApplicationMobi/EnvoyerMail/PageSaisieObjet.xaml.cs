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
    /// Logique d'interaction pour PageSaisieObjet.xaml
    /// </summary>
    public partial class PageSaisieObjet : Page
    {
        public PageSaisieObjet()
        {
            InitializeComponent();
            Mail m = NavigateMail.GetNavigationData(this.NavigationService);
            if (m != null && m.Objet != null && m.Objet.Length > 0)
            {
                textBox_Objet.Text = m.Objet;
            }
            
        }

        private void button_Suivant_Etape_Click(object sender, RoutedEventArgs e)
        {
            Mail mail = NavigateMail.GetNavigationData(this.NavigationService);
            if (textBox_Objet.Text.Length > 0)
            {
                mail.Objet = textBox_Objet.Text;

                NavigateMail.Navigate(this.NavigationService, new Uri("./EnvoyerMail/PageSaisieMessage.xaml", UriKind.Relative), mail);
            }
            else {
                label_Erreur.Content = "Veuillez saisir un objet";
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            label_Erreur.Content = "";
        }
    }
}
