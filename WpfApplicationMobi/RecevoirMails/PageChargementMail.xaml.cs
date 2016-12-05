using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplicationMobi.EnvoyerMail;

namespace WpfApplicationMobi.RecevoirMails
{
    /// <summary>
    /// Logique d'interaction pour PageChargementMail.xaml
    /// </summary>
    public partial class PageChargementMail : Page
    {
        private readonly BackgroundWorker worker = new BackgroundWorker();

        private static List<ImapX.Message> liste_mail_test;

        public PageChargementMail()
        {
            InitializeComponent();
            worker.DoWork += worker_DoWork;
            worker.WorkerReportsProgress = true;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar.Value = (double)e.ProgressPercentage;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            NavigateReceptionMail.Navigate(this.NavigationService, new Uri("./RecevoirMails/PageListeMails.xaml", UriKind.Relative), liste_mail_test);
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            (sender as BackgroundWorker).ReportProgress(35, null);
            
            //ReceptionMailHelper rc = new ReceptionMailHelper();
            //liste_mail_test = rc.RecupererMails();
            //foreach (MailRecu m in liste_mail_test) {
            //    if (!(BDDHelper.getInstance().TesterExistenceMail(m))) {
            //        BDDHelper.getInstance().AjouterMail(m);
            //    }
               
            //}
            (sender as BackgroundWorker).ReportProgress(80, null);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            worker.RunWorkerAsync();
        }
    }
}
