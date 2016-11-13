using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using WpfApplicationMobi.EnvoyerMail;

namespace WpfApplicationMobi.RecevoirMails
{
    public class NavigateReceptionMail
    {
        private static List<MailRecu> Data;

        public static void Navigate(NavigationService navigationService,
                                    Uri source, List<MailRecu> data)
        {
            Data = data;
            navigationService.Navigate(source);
        }

        public static List<MailRecu> GetNavigationData(NavigationService service)
        {
            return Data;
        }
    }
}
