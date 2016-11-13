using mshtml;
using System;
using System.Collections.Generic;
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

        private int scroll = 0;
        private static MailRecu mail;
        public PageDetailMail()
        {
            InitializeComponent();
            MailRecu m = NavigateReceptionMailTest.GetNavigationData(this.NavigationService);
            mail = m;
            label_Date.Content = m.DateReception;
            label_Expediteur.Content = m.Expediteur;
            label_Subject.Content = m.Objet;
            //textBlock_Message.Text = m.Message;
            MainBrowser.NavigateToString(m.Message);

            m.estLu = true;
        }


        private static void HyperlinksSubscriptions(FlowDocument flowDocument)
        {
            if (flowDocument == null) return;
            GetVisualChildren(flowDocument).OfType<Hyperlink>().ToList()
                     .ForEach(i => i.RequestNavigate += HyperlinkNavigate);
        }

        private static IEnumerable<DependencyObject> GetVisualChildren(DependencyObject root)
        {
            foreach (var child in LogicalTreeHelper.GetChildren(root).OfType<DependencyObject>())
            {
                yield return child;
                foreach (var descendants in GetVisualChildren(child)) yield return descendants;
            }
        }

        private static void HyperlinkNavigate(object sender,
         System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void MainBrowser_LoadCompleted(object sender, NavigationEventArgs e)
        {
            //mshtml.HTMLDocument doc;
            //doc = (mshtml.HTMLDocument)MainBrowser.Document;
            //var toto = doc.links;
            //mshtml.HTMLDocumentEvents2_Event iEvent;
            //iEvent = (mshtml.HTMLDocumentEvents2_Event)doc;
            //iEvent.onclick += new mshtml.HTMLDocumentEvents2_onclickEventHandler(ClickEventHandler);

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
                string script = "document.documentElement.style.overflow ='hidden'";
                WebBrowser wb = (WebBrowser)sender;
                wb.InvokeScript("execScript", new Object[] { script, "JavaScript" });
            
        }
    }
}
