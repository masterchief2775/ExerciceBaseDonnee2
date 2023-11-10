using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceBaseDonnee
{
    class Maison
    {
        int id;
        string categorie, ville;
        decimal prix;

        public Maison()
        {
            id = 0;
            categorie = "categorie";
            ville = "ville";
            prix = 0;
        }
        public Maison(int id, string categorie, string ville, decimal prix)
        {
            this.id = id;
            this.categorie = categorie;
            this.ville = ville;
            this.prix = prix;
        }

        public int Id { get => id; set => id = value; }
        public string Categorie { get => categorie; set => categorie = value; }
        public string Ville { get => ville; set => ville = value; }
        public decimal Prix { get => prix; set => prix = value; }

        public override bool Equals(object obj)
        {
            return obj is Maison maison &&
                   id == maison.id &&
                   categorie == maison.categorie &&
                   ville == maison.ville &&
                   prix == maison.prix &&
                   Id == maison.Id &&
                   Categorie == maison.Categorie &&
                   Ville == maison.Ville &&
                   Prix == maison.Prix;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id, categorie, ville, prix, Id, Categorie, Ville, Prix);
        }

        public override string ToString()
        {
            return $"Id = {id} Catégorie = {categorie} Ville = {ville} Prix = {prix}";
        }
    }
}
