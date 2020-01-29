using System;
using System.Collections.Generic;
using System.Text;

namespace Biblio
{
    class Livre
    {
        public Livre(string titre, int auteurID)
        {
            AuteurID = auteurID;
            this.Titre = titre;
        }

        public int AuteurID { get; set; }
        public string Titre { get; set; }

    }

    class Auteur
    {
        public Auteur(string nom, int iD )
        {
            ID = iD;
            Nom = nom;
        }

        public int ID { get; set; }
        public string Nom { get; set; }
    }
}
