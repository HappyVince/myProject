using System;

namespace Exeception
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExecptionProf();

            // ExeceptionInt();
            //ExeceptionIntRecu();
            //ExceptionCreer();
            int inputIntUtilisateur;
            int inputIntUtilisateur2;
            string inputOpUtilisateur;
            



            try
            {
             inputIntUtilisateur = inputUtilInt();

            }
            catch (Exception e)
            {
                Console.WriteLine("Vous n'avez pas saisie un Int pour la premiere valeur!");
                inputIntUtilisateur = inputUtilInt();
            }




            try
            {
                inputIntUtilisateur2 = inputUtilInt();
            }
            catch (Exception)
            {
                Console.WriteLine("Vous n'avez pas saisie un Int pour la seconde valeur!");
                inputIntUtilisateur2 = inputUtilInt();
            }




            try
            {
                inputOpUtilisateur = inputUtilOp();

            }
            catch (Exception)
            {
                Console.WriteLine("Operateur non valable");
                inputOpUtilisateur = inputUtilOp();

            }


            switch (inputOpUtilisateur)
            {
                case "+":
                    Console.WriteLine(inputIntUtilisateur + inputIntUtilisateur2);
                    break;
                case "-":
                    Console.WriteLine(inputIntUtilisateur - inputIntUtilisateur2);
                    break;
                case "*":
                    Console.WriteLine(inputIntUtilisateur * inputIntUtilisateur2);
                    break;
                default:
                    Console.WriteLine("Mauvais operateur");
                    break;
            }

        }

        private static string inputUtilOp()
        {
            string opValable = "+-*";
            string inputOpUtilisateur;
            try
            {
            Console.WriteLine("Entrée un operateur(+/-/*)");
            inputOpUtilisateur = Console.ReadLine();
                if (!opValable.Contains(inputOpUtilisateur))
                {
                    throw new Exception();
                }
                return inputOpUtilisateur;

            }
            catch (Exception)
            {
                inputOpUtilisateur = inputUtilOp();
                return inputOpUtilisateur;
            }
        }

        private static int inputUtilInt()
        {
            int inputIntUtilisateur;
            try
            {
            Console.WriteLine("Entrée un chiffre");
            inputIntUtilisateur = Convert.ToInt32(Console.ReadLine());
            return inputIntUtilisateur;

            }
            catch (Exception e)
            {
                inputIntUtilisateur = inputUtilInt();
                return inputIntUtilisateur;

            }
        }

        private static void ExceptionCreer()
        {
            try
            {
                new Chausette(70, Sock_Color.Black);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        private static void ExeceptionIntRecu()
        {
            int inputUtilisateur;


            try
            {
                Console.WriteLine("Saisir un Int");
                inputUtilisateur = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Vous avez saisie : " + inputUtilisateur);
            }
            catch (Exception e)
            {

                Console.WriteLine("Vous vous etes trompe ! Ce n'etait pas un int");
                ExeceptionIntRecu();
            }
        }

        private static void ExeceptionInt()
        {
            int inputUtilisateur;

            Boolean isInt = false;
            while (isInt == false)
            {

                try
                {
                    Console.WriteLine("Saisir un Int");
                    inputUtilisateur = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Vous avez saisie : " + inputUtilisateur);
                    isInt = true;
                }
                catch (Exception e)
                {

                    Console.WriteLine("Vous vous etes trompe ! Ce n'etait pas un int");

                }

            }
        }

        private static void ExecptionProf()
        {
            int a = 5;
            int b = 0;

            try
            {
                Console.WriteLine(a / b);
            }
            catch (Exception e)
            {
                Console.WriteLine("Infi");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

            }
        }
    }
}
