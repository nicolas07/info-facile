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
    }
}
