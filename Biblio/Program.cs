using System;
using System.Linq;

namespace Biblio
{
    class Program
    {
        static void Main(string[] args)
        {

            Livre[] livres = new[]
                        {
                new Livre("Luulul",1),
                new Livre("QASASA",2),
                new Livre("PMPMPM",1),
                new Livre("NBVNBVNB",3),
                new Livre("WXWXWX",2),
        };

            Auteur[] auteurs = new[]
            {
                new Auteur("Jean", 1),
                new Auteur("Damien", 2),
                new Auteur("Henri", 3),
        };




            var list = from auteur in auteurs
                       join livre in livres
                       on auteur.ID
                       equals livre.AuteurID
                       into grouped
                       orderby auteur.Nom
                       select new
                       {
                           AuteurNom = auteur.Nom,
                           livres = from livre in grouped
                                        orderby livre.Titre
                                        select livre
                       };

            foreach (var nomCurr in list)
            {
                Console.WriteLine(nomCurr.AuteurNom);
                foreach (var livreCurr in nomCurr.livres)
                {
                    Console.WriteLine("- titre : {0}", livreCurr.Titre);
                }
            }
        }
    }
}
