using System;

namespace ProjectTab
{
    class Program
    {
        static void Main(string[] args)
        {
                int iBis = 0;
            int[] tab = new int[4];


            Console.WriteLine("Rentrer 4 chiffres dans le tab");
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = Convert.ToInt32(Console.ReadLine());
            }

            Array.Sort(tab);

            foreach (var valeur in tab)
            {
                Console.Write(valeur);
                if (iBis != (tab.Length - 1) )
                {

                    Console.Write("/");
                    iBis++;

                }
            }
        }
    }
}
