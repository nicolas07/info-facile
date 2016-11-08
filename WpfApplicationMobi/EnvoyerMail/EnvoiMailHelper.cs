using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplicationMobi.EnvoyerMail
{
    public class EnvoiMailHelper
    {

        private static EnvoiMailHelper instance;

        private EnvoiMailHelper() { }

        public static EnvoiMailHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnvoiMailHelper();
                }
                return instance;
            }
        }

        public bool EnvoyerMail(Mail m) {

            bool estEnvoye = false;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("infofacile.tech@gmail.com");
                foreach (string des in m.Destinataires) {
                    mail.To.Add(des);
                }
                
                mail.Subject = m.Objet;
                mail.Body = m.Message;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("infofacile.tech@gmail.com", "pjR427B8My");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                estEnvoye = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return estEnvoye;
        }
    }
}
