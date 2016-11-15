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
using System.Windows.Shapes;
using WpfApplicationMobi.Contacts;
using WpfApplicationMobi.EnvoyerMail;
using WpfApplicationMobi.RecevoirMails;

namespace WpfApplicationMobi
{
    /// <summary>
    /// Logique d'interaction pour WindowSplashScreen.xaml
    /// </summary>
    public partial class WindowSplashScreen : Window
    {
        private readonly BackgroundWorker worker = new BackgroundWorker();

        private static List<MailRecu> liste_mail_test;

        private static List<Contact> liste_contacts;

        public WindowSplashScreen()
        {
            InitializeComponent();
            worker.DoWork += worker_DoWork;
            worker.WorkerReportsProgress = true;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
            if (e.ProgressPercentage == 10) {

                label_chargement.Content = "Recuperation des mails";
            }
            if (e.ProgressPercentage == 60)
            {
                label_chargement.Content = "Recuperation des contacts";
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            WindowAccueil win = new WindowAccueil();
            win.Show();
            this.Close();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            (sender as BackgroundWorker).ReportProgress(10, null);
            ReceptionMailHelper rc = new ReceptionMailHelper();
            liste_mail_test = rc.RecupererMails();
            foreach (MailRecu m in liste_mail_test)
            {
                bool test = BDDHelper.getInstance().TesterExistenceMail(m);
                if (!test)
                {
                    
                    BDDHelper.getInstance().AjouterMail(m);
                }

            }
            liste_mail_test = BDDHelper.getInstance().ObtenirMails();
            NavigateReceptionMail.setData(liste_mail_test);
            (sender as BackgroundWorker).ReportProgress(60, null);
            liste_contacts = BDDHelper.getInstance().ObtenirContacts();
            NavigateContact.setContacts(liste_contacts);
            (sender as BackgroundWorker).ReportProgress(90, null);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            worker.RunWorkerAsync();
        }
    }
}
