using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new Model1();
            var users = model.Users;


            model.SaveChanges();


            int inputUtilisateur = -1;
            string login = "";
            string password = "";
            int age = 0;
            User utiliCurr;
            while (inputUtilisateur != 0)
            {


                Console.WriteLine("Bonjour Utilisateur !");
                Console.WriteLine("Que souhaitez vous faire ?");
                Console.WriteLine("1 - Login");
                Console.WriteLine("2 - Creer un compte");
                Console.WriteLine("0 - Pour quitter");
                inputUtilisateur = Convert.ToInt32(Console.ReadLine());
                switch (inputUtilisateur)
                {
                    case 1:
                        utiliCurr = seLogin(users, out login, out password);
                        if (utiliCurr != null)
                        {
                        inputUtilisateur = followUp(inputUtilisateur, login, utiliCurr, users, model);
                        }
                        else
                        {
                            Console.WriteLine("Cet utilisateur n'existe pas !");
                        }
                        break;
                    case 2:
                        utiliCurr = creerCompte(users, out login, out password, out age);
                        model.SaveChanges();
                        inputUtilisateur = followUp(inputUtilisateur, login, utiliCurr, users, model);
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
            }
        }

        private static int followUp(int inputUtilisateur, string login, User utiliCurr, DbSet<User> users, Model1 model)
        {
            while (inputUtilisateur != 0)
            {
            string destinataireStr = "";
            string mail = "";
            int i = 0;
            EntityFramework.User destinataireObj = null;
                Console.WriteLine("Bonjour " + login);
                Console.WriteLine("Que souhaitez vous faire ?");
                Console.WriteLine("1 - Lire mails");
                Console.WriteLine("2 - Ecrire mail");
                Console.WriteLine("0 - Pour quitter");
                inputUtilisateur = Convert.ToInt32(Console.ReadLine());
                switch (inputUtilisateur)
                {
                    case 1:
                        var mails = utiliCurr.mails.Split('¤');
                        foreach (var mailCurr in mails)
                        {
                            i++;
                            Console.WriteLine("Email {0} : " + mailCurr, i);
                        }
                        break;
                    case 2:
                        Console.WriteLine("A qui voulez vous envoyer votre mail?");
                        destinataireStr = Console.ReadLine();
                        Console.WriteLine("Ecriver votre mail");
                        mail = Console.ReadLine();
                        foreach (var user in users)
                        {
                            if (user.Login == destinataireStr)
                            {
                                destinataireObj = user;
                            }
                        }
                        if (destinataireObj.mails == null)
                        {
                            destinataireObj.mails = mail;
                        }
                        else
                        {
                            destinataireObj.mails += "¤" + mail;
                        }
                        model.SaveChanges();
                        Console.ReadLine();


                        break;
                    default:
                        break;
                }
            }

            return inputUtilisateur;
        }

        private static User seLogin(DbSet<User> users, out string login, out string password)
        {
            User utiliCurr = null;
            Console.WriteLine("Rentrer votre nom d'utilisateur");
            login = Console.ReadLine();
            Console.WriteLine("Rentrer votre mot de passe");
            password = Console.ReadLine();
            var numQuery =
            from user in users
            select user;
            foreach (var user in users)
            {
                if (user.Login == login && user.Password == password)
                {
                    utiliCurr = user;
                    Console.WriteLine("Vous etes connecte en tant que " + login);
                }
            }
            return utiliCurr;
        }

        private static User creerCompte(DbSet<User> users, out string login, out string password, out int age)
        {
            User utiliCurr = null;
            Console.WriteLine("Rentrer votre nom d'utilisateur");
            login = Console.ReadLine();
            Console.WriteLine("Rentrer votre mot de passe");
            password = Console.ReadLine();
            Console.WriteLine("Rentrer votre age");
            age = Convert.ToInt32(Console.ReadLine());
            utiliCurr = new User(login, password, age);
            users.Add(utiliCurr);
            return utiliCurr;
        }
    }
}
