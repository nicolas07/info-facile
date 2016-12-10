using ImapX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
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

        public List<EnvoyerMail.MailRecu> RecupererMails() {

            List<ImapX.Message> liste = new List<ImapX.Message>();

            List<EnvoyerMail.MailRecu> liste_test = new List<EnvoyerMail.MailRecu>();

            var client = new ImapClient("imap.gmail.com", true);

            if (client.Connect())
            {

                if (client.Login(user,motDePasse))
                {
                    liste = client.Folders.Inbox.Search("ALL",ImapX.Enums.MessageFetchMode.Minimal | ImapX.Enums.MessageFetchMode.Body).ToList();
                }
            }
            else
            {
                liste = null;
            }

            client.Logout();

            string message = null;
            foreach (ImapX.Message m in liste) {
                if (m.Body.HasHtml)
                {
                    message = m.Body.Html;
                }
                else if (m.Body.HasText)
                {
                    message = m.Body.Text;

                }
                else {
                    message = string.Empty;
                }


                liste_test.Add(new EnvoyerMail.MailRecu() { Expediteur = m.From.Address, estLu = m.Seen, Message = message, Objet = m.Subject, DateReception = m.Date.Value });
            }

            return liste_test;
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
