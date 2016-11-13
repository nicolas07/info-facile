using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfApplicationMobi.EnvoyerMail
{
    public class Mail
    {
        public List<string> Destinataires { get; set; }
        public string Objet { get; set; }
        public string Message { get; set; }
        public bool estEnvoye { get; set; }

        public bool estLu { get; set; }

        public string Expediteur { get; set; }

        public string DateReception { get; set; }
        }
}
