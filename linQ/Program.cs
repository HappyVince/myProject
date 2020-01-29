using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace linQ
{
    class Program
    {
        static void Main(string[] args)
        {
            /*            QueryInt();
                        QueryList();
                        QueryNames();
                        QuerySocks();*/

            // QueryJoin();

            // QueryJoinGroup();
            // QueryIntLb();

            QueryJoinLB();

        }

        private static void QueryJoinLB()
        {
            Chausette[] socks = new[]
                        {
                new Chausette(42, Sock_Color.Red,1),
                new Chausette(38, Sock_Color.Blue,2),
                new Chausette(28, Sock_Color.Black,1),
                new Chausette(39, Sock_Color.Green,3),
                new Chausette(54, Sock_Color.Red,2),
        };

            Owner[] owners = new[]
            {
                new Owner("Jean", 1),
                new Owner("Damien", 2),
                new Owner("Henri", 3),
        };

            var list = socks
                .Join(owners,
                chausette => chausette.Owner_ID,
                owner => owner.Id,
                (chausette, owner) => new
                {
                    OwnerName = owner.Name,
                    SockSize = chausette.size,
                    SockColor = chausette.color
                });

            foreach (var chausetteCurr in list)
            {
                Console.WriteLine("{0} possede une chaussete de taille {1} et de couleur {2}", chausetteCurr.OwnerName, chausetteCurr.SockSize, chausetteCurr.SockColor);
            }
        }

        private static void QueryIntLb()
        {
            int[] tab = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var numQuery = tab
                .Where(num => num % 2 == 0)
                .OrderByDescending(num => num);

            Console.WriteLine("Query even numbers:");
            foreach (int num in numQuery)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();
        }

        private static void QueryJoinGroup()
        {
            Chausette[] socks = new[]
                        {
                new Chausette(42, Sock_Color.Red,1),
                new Chausette(38, Sock_Color.Blue,2),
                new Chausette(28, Sock_Color.Black,1),
                new Chausette(39, Sock_Color.Green,3),
                new Chausette(54, Sock_Color.Red,2),
        };

            Owner[] owners = new[]
            {
                new Owner("Jean", 1),
                new Owner("Damien", 2),
                new Owner("Henri", 3),
        };
            var list = from owner in owners
                       join chausette in socks
                       on owner.Id
                       equals chausette.Owner_ID
                       into grouped
                       orderby owner.Name
                       select new
                       {
                           OwnerName = owner.Name,
                           Chausettes = from chausette in grouped
                                        orderby chausette.color
                                        select chausette
                       };

            foreach (var nameCurr in list)
            {
                Console.WriteLine(nameCurr.OwnerName);
                foreach (var chausetteCurr in nameCurr.Chausettes)
                {
                    Console.WriteLine("- couleur : {0} / Taille : {1}", chausetteCurr.color, chausetteCurr.size);
                }
            }
        }

        private static void QueryJoin()
        {
            Chausette[] socks = new[]
                        {
                new Chausette(42, Sock_Color.Red,1),
                new Chausette(38, Sock_Color.Blue,2),
                new Chausette(28, Sock_Color.Black,1),
                new Chausette(39, Sock_Color.Green,3),
                new Chausette(54, Sock_Color.Red,2),
        };

            Owner[] owners = new[]
            {
                new Owner("Jean", 1),
                new Owner("Damien", 2),
                new Owner("Henri", 3),
        };

            var list = from chausette2 in socks
                       join owner in owners on chausette2.Owner_ID
                       equals owner.Id
                       orderby owner.Name
                       select new
                       {
                           OwnerName = owner.Name,
                           SockSize = chausette2.size,
                           Sock_Color = chausette2.color
                       };

            foreach (var chausetteCurr in list)
            {
                Console.WriteLine("{0} possede une chaussete de taille {1} et de couleur {2}", chausetteCurr.OwnerName, chausetteCurr.SockSize, chausetteCurr.Sock_Color);
            }
        }

        private static void QuerySocks()
        {
            ArrayList socks = new ArrayList()
            {
                new Chausette(42, Sock_Color.Red),
                new Chausette(38, Sock_Color.Blue),
                new Chausette(28, Sock_Color.Black),
                new Chausette(39, Sock_Color.Green),
                new Chausette(54, Sock_Color.Red),
        };

            var chausettes =
                  from Chausette chausette in socks
                  where chausette.color != Sock_Color.Green
                  && chausette.size > 37
                  orderby chausette.size
                  select chausette;
            Console.WriteLine("Chausettes :");
            foreach (Chausette chausetteCurr in chausettes)
            {
                Console.WriteLine(chausetteCurr.size + " " + chausetteCurr.color);
            }
            Console.WriteLine();
        }

        private static void QueryNames()
        {
            List<string> list = new List<string>()
            {
                "Jean",
                "JCVD",
                "MyGuy",
                "ALittleBitTooMuch",
                "Tidus",
                "Bapt"
                };
            var names =
                  from prenom in list
                  where prenom[0] == 'B' || prenom[0] == 'b'
                  || prenom[^1] == 'S' || prenom[^1] == 's'
                  orderby prenom descending
                  select prenom;

            Console.WriteLine("Nom court :");
            foreach (string prenomCurr in names)
            {
                Console.WriteLine(prenomCurr);
            }
            Console.WriteLine();
        }

        private static void QueryList()
        {
            List<string> list = new List<string>()
            {
                "Jean",
                "JCVD",
                "MyGuy",
                "ALittleBitTooMuch",
                "Tidus"
                };


            var shortNames =
              from prenom in list
              where prenom.Length < 8
              orderby prenom descending
              select prenom;

            Console.WriteLine("Nom court :");
            foreach (string prenomCurr in shortNames)
            {
                Console.WriteLine(prenomCurr);
            }
            Console.WriteLine();
        }

        private static void QueryInt()
        {
            int[] tab = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var numQuery =
                from num in tab
                where (num % 2) == 0
                select num;

            Console.WriteLine("Query nombre paire :");
            foreach (int numCurr in numQuery)
            {
                Console.WriteLine(numCurr);
            }
            Console.WriteLine();
        }
    }
}
