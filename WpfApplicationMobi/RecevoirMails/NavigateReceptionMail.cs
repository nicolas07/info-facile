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
        //private static List<ImapX.Message> Data;

        //public static void Navigate(NavigationService navigationService,
        //                            Uri source, List<ImapX.Message> data)
        //{
        //    Data = data;
        //    navigationService.Navigate(source);
        //}

        //public static List<ImapX.Message> GetNavigationData(NavigationService service)
        //{
        //    return Data;
        //}

        //public static void setData(List<ImapX.Message> data) {
        //    Data = data;
        //}

        private static List<EnvoyerMail.MailRecu> Data;

        public static void Navigate(NavigationService navigationService,
                                    Uri source, List<EnvoyerMail.MailRecu> data)
        {
            Data = data;
            navigationService.Navigate(source);
        }

        public static List<EnvoyerMail.MailRecu> GetNavigationData(NavigationService service)
        {
            return Data;
        }

        public static void setData(List<EnvoyerMail.MailRecu> data)
        {
            Data = data;
        }
    }
}
