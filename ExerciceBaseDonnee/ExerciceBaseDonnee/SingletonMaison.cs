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
    class SingletonMaison
    {
        static SingletonMaison instance = null;
        MySqlConnection con;
        ObservableCollection<Maison> liste;

        public SingletonMaison()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=2266983-gabriel-bélair;Uid=2266983;Pwd=2266983;");
            liste = new ObservableCollection<Maison>();
        }

        public static SingletonMaison getInstance()
        {
            if (instance == null)
                instance = new SingletonMaison();

            return instance;
        }

        public ObservableCollection<Maison> GetListeMaisons()
        {
            liste.Clear();
            try
            {
                MySqlCommand commande = new MySqlCommand("p_afficher_maisons");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {
                    int id = (int)r["id"];
                    string categorie = (string)r["categorie"];
                    string ville = (string)r["ville"];
                    decimal prix = (decimal)r["prix"];
                    int id_proprietaire = (int)r["id_proprietaire"];

                    Maison maison = new Maison(id ,categorie, prix, ville, id_proprietaire);

                    liste.Add(maison);
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
            string categorie = maison.Categorie;
            decimal prix = maison.Prix;
            string ville = maison.Ville;
            int id_proprietaire = maison.Id_proprietaire;
            try
            {
                MySqlCommand commande = new MySqlCommand("p_ajouter_maison");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("categorie", categorie);
                commande.Parameters.AddWithValue("prix", prix);
                commande.Parameters.AddWithValue("ville", ville);
                commande.Parameters.AddWithValue("id_proprietaire", id_proprietaire);

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
