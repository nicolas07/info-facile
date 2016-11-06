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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplicationMobi
{
    /// <summary>
    /// Logique d'interaction pour PageRechercher.xaml
    /// </summary>
    public partial class PageRechercher : Page
    {
        public PageRechercher()
        {
            InitializeComponent();
        }

        private void buttonRechercher_Click(object sender, RoutedEventArgs e)
        {
            string texte = textBoxRecherche.Text;
            //On teste si la textbox est vide ou non
            if (texte.Length != 0)
            {
                Process.Start("http://google.fr/search?q=" + texte);
            }
            else {
                //Affichage msg d'erreur dans le label de la page
                labelErreurRecherche.Content = "Veuillez saisir un mot clé pour la recherche !";
            }
        }

        private void textBoxRecherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            //On efface le message d'erreur lors de la detection d'une saisie
            labelErreurRecherche.Content = "";
        }
    }
}
