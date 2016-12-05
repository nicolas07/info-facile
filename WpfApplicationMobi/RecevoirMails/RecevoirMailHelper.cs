using ImapX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplicationMobi.RecevoirMails
{
    public class RecevoirMailHelper
    {
        private static RecevoirMailHelper instance;
        private static string user = "infofacile.tech@gmail.com";
        private static string motDePasse = "pjR427B8My";

        private RecevoirMailHelper() { }

        public static RecevoirMailHelper getInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RecevoirMailHelper();
                }
                return instance;
            }
        }

        public List<ImapX.Message> RecupererMails() {

            List<ImapX.Message> liste = new List<ImapX.Message>();

            var client = new ImapClient("imap.gmail.com", true);

            if (client.Connect())
            {

                if (client.Login(user,motDePasse))
                {
                    liste = client.Folders.Inbox.Search().ToList();
                }
            }
            else
            {
                liste = null;
            }

            client.Logout();

            return liste;
        }

        public bool MarquerCommeLu(ImapX.Message m) {
            bool res = false;

            var client = new ImapClient("imap.gmail.com", true);

            if (client.Connect())
            {

                if (client.Login(user, motDePasse))
                {
                    
                    ImapX.Message tmp = client.Folders.Inbox.Search(string.Concat("UID ",m.UId)).First();
                    tmp.Seen = true;
                    res = true;
                }
            }

            client.Logout();

            return res;
        }
    }
}
