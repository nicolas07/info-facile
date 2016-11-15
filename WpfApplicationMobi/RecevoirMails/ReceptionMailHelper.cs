using ActiveUp.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplicationMobi.EnvoyerMail;

namespace WpfApplicationMobi.RecevoirMails
{
    public class ReceptionMailHelper
    {
        private Imap4Client _client = null;

        public ReceptionMailHelper(string mailServer, int port, bool ssl, string login, string password)
        {
            if (ssl)
                Client.ConnectSsl(mailServer, port);
            else
                Client.Connect(mailServer, port);
            Client.Login(login, password);
        }

        public ReceptionMailHelper() { }

        public IEnumerable<Message> GetAllMails(string mailBox)
        {
            return GetMails(mailBox, "ALL").Cast<Message>();
        }

        public IEnumerable<Message> GetUnreadMails(string mailBox)
        {
            return GetMails(mailBox, "UNSEEN").Cast<Message>();
        }

        protected Imap4Client Client
        {
            get
            {
                if (_client == null)
                    _client = new Imap4Client();
                return _client;
            }
        }

        private MessageCollection GetMails(string mailBox, string searchPhrase)
        {
            Mailbox mails = Client.SelectMailbox(mailBox);
            MessageCollection messages = mails.SearchParse(searchPhrase);
            return messages;
        }

        public List<MailRecu> RecupererMails() {

            List<MailRecu> liste = new List<MailRecu>();

            ReceptionMailHelper rep = new ReceptionMailHelper("imap.gmail.com", 993, true, @"infofacile.tech@gmail.com", "pjR427B8My");

            foreach (Message email in rep.GetAllMails("inbox"))
            {
                string message = email.BodyHtml.Text.ToString();
                if (message.Equals(string.Empty)) {
                    message = email.BodyText.Text.ToString();
                }

                liste.Add(new MailRecu() { Expediteur = email.From.Email.ToString(), Message = message, Objet = email.Subject ,estLu =false,DateReception = Convert.ToDateTime(string.Concat(email.Date.Date.ToShortDateString()," ",email.Date.TimeOfDay.ToString()))});

            }

            return liste;
        }
    }
}

