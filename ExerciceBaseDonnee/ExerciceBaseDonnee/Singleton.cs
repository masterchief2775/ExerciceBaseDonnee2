using Microsoft.WindowsAppSDK.Runtime.Packages;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Protection.PlayReady;

namespace ExerciceBaseDonnee
{
    class Singleton
    {
        static Singleton instance = null;
        MySqlConnection con;
        ObservableCollection<Maison> liste;

        public Singleton()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=2266983-gabriel-bélair;Uid=2266983;Pwd=2266983;");
            liste = new ObservableCollection<Maison>();
        }

        public static Singleton getInstance()
        {
            if (instance == null)
                instance = new Singleton();

            return instance;
        }

        public ObservableCollection<Maison> GetListeMaisons()
        {
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "SELECT * FROM maisons";
                con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    int id = (int)r["id"];
                    string categorie = (string)r["categorie"];
                    string ville = (string)r["ville"];
                    decimal prix = (decimal)r["prix"];

                    Maison maison = new Maison(id ,categorie, ville, prix);

                    liste.Add( maison);
                }

                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                con.Close();
            }

            return liste;
        }

        public Maison getMaison(int position)
        {
            return liste[position];
        }

        public void ajouter(Maison maison)
        {
            int id = 0;
            string categorie = maison.Categorie;
            string ville = maison.Ville;
            decimal prix = maison.Prix;
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "INSERT INTO maisons VALUES(@id, @categorie, @ville, @prix)";

                commande.Parameters.AddWithValue("@id", id);
                commande.Parameters.AddWithValue("@categorie", categorie);
                commande.Parameters.AddWithValue("@ville", ville);
                commande.Parameters.AddWithValue("@prix", prix);

                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }

            liste.Add(maison);
        }

        public void modifier(int position, Maison maison)
        {
            liste[position] = maison;
        }

        public void supprimer(int position)
        {
            liste.RemoveAt(position);
        }



    }
}
