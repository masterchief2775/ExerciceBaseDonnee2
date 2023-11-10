using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceBaseDonnee
{
    class Maison
    {
        int id, id_proprietaire;
        string categorie, ville;
        decimal prix;

        public Maison()
        {
            id = 0;
            categorie = "categorie";
            ville = "ville";
            prix = 0;
            id_proprietaire = 0;
        }
        public Maison(int id, string categorie, string ville, decimal prix, int id_proprietaire)
        {
            this.id = id;
            this.categorie = categorie;
            this.ville = ville;
            this.prix = prix;
            this.id_proprietaire = id_proprietaire;
        }

        public int Id { get => id; set => id = value; }
        public string Categorie { get => categorie; set => categorie = value; }
        public string Ville { get => ville; set => ville = value; }
        public decimal Prix { get => prix; set => prix = value; }
        public int Id_proprietaire { get => id_proprietaire; set => id_proprietaire = value; }

        public override bool Equals(object obj)
        {
            return obj is Maison maison &&
                   id == maison.id &&
                   id_proprietaire == maison.id_proprietaire &&
                   categorie == maison.categorie &&
                   ville == maison.ville &&
                   prix == maison.prix &&
                   Id == maison.Id &&
                   Categorie == maison.Categorie &&
                   Ville == maison.Ville &&
                   Prix == maison.Prix &&
                   Id_proprietaire == maison.Id_proprietaire;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(id);
            hash.Add(id_proprietaire);
            hash.Add(categorie);
            hash.Add(ville);
            hash.Add(prix);
            hash.Add(Id);
            hash.Add(Categorie);
            hash.Add(Ville);
            hash.Add(Prix);
            hash.Add(Id_proprietaire);
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return $"Id = {id} Catégorie = {categorie} Ville = {ville} Prix = {prix} Id_propriétaire = {id_proprietaire}";
        }
    }
}
