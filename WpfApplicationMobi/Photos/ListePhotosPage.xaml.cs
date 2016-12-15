using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace WpfApplicationMobi.Photos
{
    

    public class CustomItem
    {
        public string parent { get; set; }
        public string nom { get; set; }

        public ObservableCollection<CustomItem> items { get; set; }

        public CustomItem()
        {
            this.items = new ObservableCollection<CustomItem>();
        }
    }

    public class CustomPicture
    {

        public string nomfichier { get; set; }

        public string parent { get; set; }

        public string nomdossier { get; set; }

        public string path { get; set; }

        public override string ToString()
        {
            return this.nomfichier;
        }

    }

    /// <summary>
    /// Logique d'interaction pour ListePhotosPage.xaml
    /// </summary>
    public partial class ListePhotosPage : Page
    {
        private static string rootFolder = "InfoFacile";

        private string dossierImage = null;

        private string dossierPhotosPerso = null;
        private string dossierPhotosTablette = null;

        public ListePhotosPage()
        {
            InitializeComponent();

            dossierImage = System.IO.Path.Combine(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), rootFolder), "Images");
            dossierPhotosPerso = System.IO.Path.Combine(System.IO.Path.Combine(System.IO.Path.Combine(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), rootFolder), "Images"), "Photos Perso"));
            dossierPhotosTablette = System.IO.Path.Combine(System.IO.Path.Combine(System.IO.Path.Combine(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), rootFolder), "Images"), "Photos Tablette"));


            SetTreeView();
            button_Precedent.Visibility = Visibility.Hidden;
            button_Suivante.Visibility = Visibility.Hidden;
            button_Supprimer.Visibility = Visibility.Hidden;
            button_Tablette.Visibility = Visibility.Hidden;
            image_fichier.Visibility = Visibility.Hidden;
        }


        private void listView_fichier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CustomPicture pic = listView_fichier.SelectedItem as CustomPicture;
            if (pic != null)
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                if (pic.parent != null)
                {
                    image.UriSource = new Uri(dossierImage +"\\"+ pic.parent + "\\" + pic.nomdossier + "\\" + pic.nomfichier);
                }
                else {
                    image.UriSource = new Uri(dossierImage + "\\" + pic.nomdossier + "\\" + pic.nomfichier);
                }
                
                image.EndInit();
                image_fichier.Source = image;

                string tmp = null;
                if (pic.nomdossier != null && !(pic.nomdossier.Equals("Photos Tablette")) && !(pic.nomdossier.Equals("Photos Perso"))) {
                    tmp = string.Concat(dossierPhotosTablette, "\\", pic.nomdossier, "\\", pic.nomfichier);
                } else
                {
                    tmp = string.Concat(dossierPhotosTablette, "\\", pic.nomfichier);
                }

                if (System.IO.File.Exists(tmp))
                {
                    button_Tablette.Content = "Supprimer du Dossier Tablette";
                }
                else
                {
                    button_Tablette.Content = "Ajouter au Dossier Tablette";
                }

            }

        }

        private void button_Suivante_Click(object sender, RoutedEventArgs e)
        {
            int index = listView_fichier.SelectedIndex;
            if (index < listView_fichier.Items.Count - 1)
            {
                listView_fichier.SelectedIndex = index + 1;
                listView_fichier.UpdateLayout(); // Pre-generates item containers 

                var listBoxItem = (ListBoxItem)listView_fichier
                    .ItemContainerGenerator
                    .ContainerFromIndex(index + 1);

                listBoxItem.Focus();
            }
        }

        private void button_Precedent_Click(object sender, RoutedEventArgs e)
        {
            int index = listView_fichier.SelectedIndex;
            if (index > 0)
            {
                listView_fichier.SelectedIndex = index - 1;
                listView_fichier.UpdateLayout(); // Pre-generates item containers 

                var listBoxItem = (ListBoxItem)listView_fichier
                    .ItemContainerGenerator
                    .ContainerFromIndex(index - 1);

                listBoxItem.Focus();
            }


        }

        private void button_Supprimer_Click(object sender, RoutedEventArgs e)
        {
            CustomPicture item = listView_fichier.SelectedItem as CustomPicture;

            if (System.IO.File.Exists(item.path))
            {
                System.IO.File.Delete(item.path);
            }

            List<CustomPicture> poet = listView_fichier.ItemsSource as List<CustomPicture>;
            poet.Remove(item);
            listView_fichier.ItemsSource = poet;
            listView_fichier.Items.Refresh();
        }

        private void button_Tablette_Click(object sender, RoutedEventArgs e)
        {
            CustomPicture item = listView_fichier.SelectedItem as CustomPicture;

            if (button_Tablette.Content.Equals("Supprimer du Dossier Tablette"))
            {
                System.IO.File.Delete(item.path);
            }
            else if (button_Tablette.Content.Equals("Ajouter au Dossier Tablette"))
            {
                System.IO.File.Copy(item.path,string.Concat(dossierPhotosTablette + "\\" + item.nomfichier) ,true);
            }

            SetTreeView();
            setFileListBox(item);
        }

        private void SetTreeView()
        {

            CustomItem root = new CustomItem() { nom = "Photos" };
            CustomItem item1 = new CustomItem() { nom = "Photos Tablette" };
            string[] folders = System.IO.Directory.GetDirectories(dossierImage+ "\\Photos Tablette\\", "*", System.IO.SearchOption.AllDirectories);

            foreach (string filename in folders)
            {
                FileInfo f = new FileInfo(filename);

                item1.items.Add(new CustomItem() { nom = f.Name, parent = "Photos Tablette" });


            }

            root.items.Add(item1);
            CustomItem item2 = new CustomItem() { nom = "Photos Perso" };
            string[] folders2 = System.IO.Directory.GetDirectories(dossierImage+ "\\Photos Perso\\", "*", System.IO.SearchOption.AllDirectories);

            foreach (string filename2 in folders2)
            {
                FileInfo f = new FileInfo(filename2);

                item2.items.Add(new CustomItem() { nom = f.Name, parent = "Photos Perso" });

            }
            root.items.Add(item2);
            treeView_dossier.ItemsSource = root.items;

        }

        private void setFileListBox(CustomPicture item)
        {
            string[] files = null;
            if (item.parent != null)
            {
                files = Directory.GetFiles(dossierImage + "\\" + item.parent + "\\" + item.nomdossier + "\\");
            }
            else
            {
                files = Directory.GetFiles(dossierImage + "\\" + item.nomdossier + "\\");
            }

            List<CustomPicture> tutu = new List<CustomPicture>();
            foreach (string file in files)
            {
                tutu.Add(new CustomPicture() { path = file, nomfichier = System.IO.Path.GetFileName(file), nomdossier = item.nomdossier, parent = item.parent });
            }
            listView_fichier.ItemsSource = tutu;
        }

        private void treeView_dossier_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var tree = sender as TreeView;

            CustomItem item = tree.SelectedItem as CustomItem;

            string[] files = null;
            if (item.parent != null)
            {
                files = Directory.GetFiles(dossierImage +"\\"+ item.parent + "\\" + item.nom + "\\", "*.jpg");
            }
            else
            {
                files = Directory.GetFiles(dossierImage + "\\" + item.nom + "\\", "*.jpg");
            }

            List<CustomPicture> tutu = new List<CustomPicture>();
            foreach (string file in files)
            {
                tutu.Add(new CustomPicture() { path = file, nomfichier = System.IO.Path.GetFileName(file), nomdossier = item.nom, parent = item.parent });
            }
            listView_fichier.ItemsSource = tutu;
            listView_fichier.SelectedIndex = 0;

            listView_fichier.Focus();

            button_Precedent.Visibility = Visibility.Visible;
            button_Suivante.Visibility = Visibility.Visible;
            button_Supprimer.Visibility = Visibility.Visible;
            button_Tablette.Visibility = Visibility.Visible;
            image_fichier.Visibility = Visibility.Visible;
        }
    }
}
