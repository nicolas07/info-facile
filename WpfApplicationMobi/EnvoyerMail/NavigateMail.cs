using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace WpfApplicationMobi.EnvoyerMail
{
    public class NavigateMail
    {
        private static Mail Data;

        public static void Navigate(NavigationService navigationService,
                                    Uri source, Mail data)
        {
            Data = data;
            navigationService.Navigate(source);
        }

        public static Mail GetNavigationData(NavigationService service)
        {
            return Data;
        }
    }
}
