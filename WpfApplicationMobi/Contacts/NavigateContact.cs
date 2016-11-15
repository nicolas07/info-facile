using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace WpfApplicationMobi.Contacts
{
    public static class NavigateContact
    {
        private static Contact Data;
        private static List<Contact> liste;
        
        public static void Navigate(NavigationService navigationService,
                                    Uri source, Contact data)
        {
            Data = data;
            navigationService.Navigate(source);
        }
        
        public static Contact GetNavigationData(NavigationService service)
        {
            return Data;
        }

        public static void setContacts(List<Contact> lc) {
            liste = lc;
        }

        public static List<Contact> getContacts()
        {
            return liste;
        }

    }
}
