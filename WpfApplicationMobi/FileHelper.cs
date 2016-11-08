using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplicationMobi.Contacts;

namespace WpfApplicationMobi
{
    public class FileHelper
    {
        private static FileHelper instance;
        private static string rootFolder = "InfoFacile";
        private static string fileName = "listeContacts.txt";

        private FileHelper() { }

        public static FileHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FileHelper();
                }
                return instance;
            }

        }

        public void CreerDossierRacine()
        {
            //Création du dossier InfoFacile dans c:/Users/User/Appdata
            try
            {
                string ProgramFiles = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string MyNewPath = Path.Combine(ProgramFiles, rootFolder);
                if (!Directory.Exists(MyNewPath))
                {
                    Directory.CreateDirectory(MyNewPath);
                }
                CreerDossierContacts();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public void CreerDossierContacts()
        {
            //Création du dossier Contacts dans c:/Users/User/Appdata/Infofacile
            try
            {
                string ProgramFiles = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string MyNewPath = Path.Combine(Path.Combine(ProgramFiles, rootFolder), "Contacts");
                if (!Directory.Exists(MyNewPath))
                {
                    Directory.CreateDirectory(MyNewPath);
                }
                CreerFichierConfigContacts();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public void CreerFichierConfigContacts()
        {
            try
            {
                string ProgramFiles = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string MyNewPath = Path.Combine(Path.Combine(Path.Combine(ProgramFiles, rootFolder), "Contacts"), fileName);
                if (!File.Exists(MyNewPath))
                {
                    File.Create(MyNewPath).Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public List<Contact> LireFichierConfigContacts()
        {

            List<Contact> list = new List<Contact>();
            string ProgramFiles = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string path = Path.Combine(Path.Combine(Path.Combine(ProgramFiles, rootFolder), "Contacts"), fileName);
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(',');
                    if (words.Length == 4) {
                        //Si contact ok
                        list.Add(new Contact() { Nom = words[0], Image = words[1], Email = words[2], NumeroTelephone = words[3] }); // Add to list.
                        Console.WriteLine(line); // Write to console.
                    }

                }
            }

            return list;
        }

        public bool AjouterContact(Contact c) {

            bool ok = true;

            try
            {
                string ProgramFiles = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string path = Path.Combine(Path.Combine(Path.Combine(ProgramFiles, rootFolder), "Contacts"), fileName);

                StreamWriter file2 = new StreamWriter(path, true);

                string line = String.Concat(c.Nom, ",", c.Image, ",", c.Email, ",", c.NumeroTelephone);

                // Write the string to a file.
                file2.WriteLine(line);

                file2.Close();
            }
            catch (Exception e) {
                Debug.WriteLine(e.ToString());
                ok = false;
            }

            return ok;
            
        }





    }
}
