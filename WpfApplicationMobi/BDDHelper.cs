using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplicationMobi.Contacts;
using WpfApplicationMobi.EnvoyerMail;

namespace WpfApplicationMobi
{
    public class BDDHelper
    {
        private static BDDHelper instance;
        private static string source = "mysql-walterwhite.alwaysdata.net";
        private static string base_name = "walterwhite_gp";
        private static string utilisateur = "129581";
        private static string mot_de_passe = "pjR427B8My";
        private static string nom_table = "gp_Contacts";
        private static string nom_table_mails = "gp_Mails";
        private BDDHelper()
        { }

        public static BDDHelper getInstance()
        {
            if (instance == null)
            {
                instance = new BDDHelper();
            }
            return instance;
        }

        public MySqlConnection CreerConnexion() {
            
            //Objet de connexion à la base de donnée
            MySqlConnection cnx = new MySqlConnection();
            // Chaine de Connexion
            cnx.ConnectionString = "Server="+source+";Database="+base_name+";Uid="+utilisateur+";Pwd="+mot_de_passe+";";

            
            return cnx;
        }

        public List<Contact> ObtenirContacts()
        {
            List<Contact> listeContacts = new List<Contact>();
            try
            {
                // Objet de commande
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT * FROM "+nom_table;
                cmd.Connection = CreerConnexion(); 

                // Déclaration DataReader
                MySqlDataReader dr = null;

                //Ouverture de Connexion MySql
                cmd.Connection.Open();

                // Liaison DataReader avec la Commande (requete)
                dr = cmd.ExecuteReader();

                // Tant qu'il y'a des lignes d'enregistrement        
                while (dr.Read())
                {
                    listeContacts.Add(new Contact() { Nom = dr["Nom"].ToString(), Email = dr["Email"].ToString(), NumeroTelephone = dr["NumeroTelephone"].ToString(), Image = System.IO.Path.Combine(FileHelper.Instance.lienimagefolder,dr["LienImage"].ToString())});       
                }

                // Fermeture de la connexion MySql
                cmd.Connection.Close();

            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }

            return listeContacts;
        }

        public bool AjouterContact(Contact c)
        {
            bool estAjoute = false;
            try
            {
                // Objet de commande
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "INSERT INTO "+nom_table+" (Nom, Email,NumeroTelephone,LienImage) VALUES (@Nom,@Email,@NumeroTelephone,@LienImage)";
                cmd.Connection = CreerConnexion();
                cmd.Parameters.AddWithValue("@Nom", c.Nom);
                cmd.Parameters.AddWithValue("@Email", c.Email);
                cmd.Parameters.AddWithValue("@NumeroTelephone", c.NumeroTelephone);
                cmd.Parameters.AddWithValue("@LienImage", c.Image);
                //Ouverture de Connexion MySql
                cmd.Connection.Open();

                // Liaison DataReader avec la Commande (requete)
                cmd.ExecuteNonQuery();

                // Fermeture de la connexion MySql
                cmd.Connection.Close();
                estAjoute = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return estAjoute;
        }

        public List<MailRecu> ObtenirMails()
        {
            List<MailRecu> listeMails = new List<MailRecu>();
            try
            {
                // Objet de commande
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT * FROM " + nom_table_mails;
                cmd.Connection = CreerConnexion();

                // Déclaration DataReader
                MySqlDataReader dr = null;

                //Ouverture de Connexion MySql
                cmd.Connection.Open();

                // Liaison DataReader avec la Commande (requete)
                dr = cmd.ExecuteReader();

                // Tant qu'il y'a des lignes d'enregistrement        
                while (dr.Read())
                {
                    listeMails.Add(new MailRecu() { Expediteur = dr["Expediteur"].ToString(), Objet = dr["Objet"].ToString(), Message = dr["Message"].ToString(), DateReception = (DateTime) dr["DateReception"], estLu = (bool) dr["estLu"]});
                }

                // Fermeture de la connexion MySql
                cmd.Connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return listeMails;
        }

        public bool AjouterMail(MailRecu m)
        {
            bool estAjoute = false;
            try
            {
                // Objet de commande
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "INSERT INTO " + nom_table_mails + " (Expediteur, DateReception, Objet, Message, EstLu) VALUES (@Expediteur,@DateReception,@Objet,@Message,@EstLu)";
                cmd.Connection = CreerConnexion();
                cmd.Parameters.AddWithValue("@Expediteur", m.Expediteur);
                cmd.Parameters.AddWithValue("@DateReception", m.DateReception);
                cmd.Parameters.AddWithValue("@Objet", m.Objet);
                cmd.Parameters.AddWithValue("@Message", m.Message);
                cmd.Parameters.AddWithValue("@EstLu", m.estLu);
                //Ouverture de Connexion MySql
                cmd.Connection.Open();

                // Liaison DataReader avec la Commande (requete)
                cmd.ExecuteNonQuery();

                // Fermeture de la connexion MySql
                cmd.Connection.Close();
                estAjoute = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return estAjoute;
        }

        public bool ModifierEtatMail(Mail m) {

            bool estModifie = false;
            try
            {
                // Objet de commande
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "UPDATE " + nom_table_mails + " SET (EstLu) VALUES (@EstLu) WHERE Expediteur=@Expediteur,DateReception=@DateReception";
                cmd.Connection = CreerConnexion();
                cmd.Parameters.AddWithValue("@Expediteur", m.Expediteur);
                cmd.Parameters.AddWithValue("@DateReception", m.DateReception);
                cmd.Parameters.AddWithValue("@EstLu", !(m.estLu));
                //Ouverture de Connexion MySql
                cmd.Connection.Open();

                // Liaison DataReader avec la Commande (requete)
                cmd.ExecuteNonQuery();

                // Fermeture de la connexion MySql
                cmd.Connection.Close();
                estModifie = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return estModifie;
        }

        public bool TesterExistenceMail(MailRecu m) {
          

            bool existe = false;
            try
            {
                // Objet de commande
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT *  FROM " + nom_table_mails + " WHERE Expediteur=@expediteur AND DateReception=@dateReception" ;
                cmd.Connection = CreerConnexion();
                cmd.Parameters.AddWithValue("@expediteur", m.Expediteur);
                cmd.Parameters.AddWithValue("@dateReception", string.Concat(m.DateReception.Year, "-", m.DateReception.Month, "-", m.DateReception.Day, " ", m.DateReception.Hour, ":", m.DateReception.Minute, ":", m.DateReception.Second));

                //Ouverture de Connexion MySql
                cmd.Connection.Open();

                // Liaison DataReader avec la Commande (requete)
                int count = (int) cmd.ExecuteScalar();
                
                if (count > 1) {
                    existe = true;
                }

                // Fermeture de la connexion MySql
                cmd.Connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return existe;

        }


    }
}
