using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using WpfApplicationMobi.EnvoyerMail;

namespace WpfApplicationMobi.RecevoirMails
{
    public class NavigateReceptionMailTest
    {
        private static MailRecu Data;

        public static void Navigate(NavigationService navigationService,
                                    Uri source, MailRecu data)
        {
            Data = data;
            navigationService.Navigate(source);
        }

        public static MailRecu GetNavigationData(NavigationService service)
        {
            return Data;
        }
    }
}
