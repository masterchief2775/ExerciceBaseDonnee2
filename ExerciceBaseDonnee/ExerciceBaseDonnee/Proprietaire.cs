using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceBaseDonnee
{
    internal class Proprietaire
    {
        int id_proprietaire;
        string nom, prenom;

        public Proprietaire()
        {
            id_proprietaire = 0;
            nom = "Doe";
            prenom = "John";
        }
        public Proprietaire(int id_proprietaire, string nom, string prenom)
        {
            this.id_proprietaire = id_proprietaire;
            this.nom = nom;
            this.prenom = prenom;
        }

        public int Id_proprietaire { get => id_proprietaire; set => id_proprietaire = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }

        public override bool Equals(object obj)
        {
            return obj is Proprietaire proprietaire &&
                   id_proprietaire == proprietaire.id_proprietaire &&
                   nom == proprietaire.nom &&
                   prenom == proprietaire.prenom &&
                   Id_proprietaire == proprietaire.Id_proprietaire &&
                   Nom == proprietaire.Nom &&
                   Prenom == proprietaire.Prenom;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id_proprietaire, nom, prenom, Id_proprietaire, Nom, Prenom);
        }

        public override string ToString()
        {
            return $"Id_propriétaire = {id_proprietaire} Nom = {nom} Prenom = {prenom}";
        }
    }
}
