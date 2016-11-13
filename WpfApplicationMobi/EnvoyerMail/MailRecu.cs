using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplicationMobi.EnvoyerMail
{
    public class MailRecu
    {

        public bool estLu { get; set; }

        public string Expediteur { get; set; }

        public DateTime DateReception { get; set; }

        public string Objet { get; set; }

        public string Message { get; set; }
    }
}
