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
    /// Logique d'interaction pour PageConfirmation.xaml
    /// </summary>
    public partial class PageConfirmation : Page
    {
        public PageConfirmation()
        {
            InitializeComponent();
            Mail mail = NavigateMail.GetNavigationData(this.NavigationService);
            if (mail.estEnvoye)
            {
                label_Fin.Foreground = System.Windows.Media.Brushes.Green;
                label_Fin.Content = "Message bien envoyé";
            }
            else
            {
                label_Fin.Foreground = System.Windows.Media.Brushes.Red;
                label_Fin.Content = "Mail non envoyé, une erreur s'est produite ! Merci de reessayer plus tard.";
            }

        }
    }
}
