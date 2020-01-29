using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfNetFramework.ServiceReference1;

namespace WcfNetFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ServiceReference1.Service1Client();
            //somme(client);

            int inputUtilisateur = -1;
            string clef = "";

            while (inputUtilisateur != 0)
            {

                Console.WriteLine();
                Console.WriteLine("Bonjour Utilisateur !");
                Console.WriteLine("Que souhaitez vous faire ?");
                Console.WriteLine("1 - Creer un message");
                Console.WriteLine("2 - Lire un message");
                Console.WriteLine("0 - Pour quitter");
                Console.WriteLine();
                inputUtilisateur = Convert.ToInt32(Console.ReadLine());
                switch (inputUtilisateur)
                {
                    case 1:
                        Console.WriteLine("Entrer la clef du message");
                        clef = Console.ReadLine();
                        if (client.read(clef) == null)
                        {
                        Console.WriteLine("Entrer le contenu du message");
                        string contenu = Console.ReadLine();
                        Console.WriteLine("Creation d'un message");
                        client.create(clef, contenu);
                        Console.WriteLine("Fin de la creation d'un message");
                        }
                        else
                        {
                            Console.WriteLine("La clef est deja presente dans la bd!");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Entrer la clef du message");
                        clef = Console.ReadLine();
                        Console.WriteLine("Recherche du message avec clef  = {0}", clef);
                        if (client.read(clef) == null)
                        {
                            Console.WriteLine("La clef n'existe pas dans la bd");
                        }
                        else
                        {
                            Console.WriteLine("Contenu = " + client.read(clef));
                            client.remove(clef);
                        }
                        break;
                    default:
                        break;
                }

            }
            client.Close();
        }

        private static void somme(Service1Client client)
        {
            Console.WriteLine("Enter 2 int");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(client.somme(a, b));

            Console.ReadLine();
        }
    }
}
