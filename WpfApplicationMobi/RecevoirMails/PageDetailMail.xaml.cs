using mshtml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplicationMobi.EnvoyerMail;

namespace WpfApplicationMobi.RecevoirMails
{
    /// <summary>
    /// Logique d'interaction pour PageDetailMail.xaml
    /// </summary>
    public partial class PageDetailMail : Page
    {
        private readonly BackgroundWorker worker = new BackgroundWorker();

        private int scroll = 0;
        private static MailRecu mail;
        public PageDetailMail()
        {
            InitializeComponent();

            worker.DoWork += worker_DoWork;
            MailRecu m = NavigateReceptionMailTest.GetNavigationData(this.NavigationService);
           
            mail = m;
            label_Date.Content = m.DateReception;
            label_Expediteur.Content = m.Expediteur;
            label_Subject.Text = m.Objet;
            MainBrowser.NavigateToString(m.Message);
            worker.RunWorkerAsync();
            m.estLu = true;
        }


        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            RecevoirMailHelper.getInstance.MarquerCommeLu(mail);
        }

        private void MainBrowser_LoadCompleted(object sender, NavigationEventArgs e)
        {

            HTMLDocument doc = (mshtml.HTMLDocument)this.MainBrowser.Document;

            foreach (IHTMLElement link in doc.links)
            {
                HTMLAnchorElement anchor = link as HTMLAnchorElement;
                if (anchor != null)
                {
                    HTMLAnchorEvents_Event handler = anchor as HTMLAnchorEvents_Event;
                    if (handler != null)
                    {
                        handler.onclick += new HTMLAnchorEvents_onclickEventHandler(delegate ()
                        {
                            Console.WriteLine("You clicks the link: " + anchor.href);
                            Process.Start(anchor.href);
                           // MainBrowser.NavigateToString(mail.Message);
                            return true;
                        });
                    }
                }

            }
            
        }

        private void button_Bas_Click(object sender, RoutedEventArgs e)
        {
            int i = scroll + 70;
            var html = MainBrowser.Document as mshtml.HTMLDocument;
            html.parentWindow.scroll(0, i);
            scroll = i;
        }

        private void button_Haut_Click(object sender, RoutedEventArgs e)
        {
            int i = scroll - 70;
            var html = MainBrowser.Document as mshtml.HTMLDocument;
            html.parentWindow.scroll(0, i);
            scroll = i;
        }

        private void MainBrowser_Loaded(object sender, RoutedEventArgs e)
        {
            mshtml.IHTMLDocument2 documentText = (IHTMLDocument2)MainBrowser.Document;
            //this will access the document properties 
            //documentText.body.parentElement.style.overflow = "hidden";
        }
    }
}
