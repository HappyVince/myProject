using System;
using System.Collections.Generic;

namespace JeuConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //    BougerCurseurConsoleSet();

            int x = 0;
            int y = 0;
            string skin = "A"; 
            Console.CursorVisible = false;
            var keyname = Console.ReadKey();


            while (Convert.ToString(keyname.Key) != "Escape")
            {
            string lignePos = "";

                if (Convert.ToString(keyname.Key) == "UpArrow" && y > 0)
                {
                    y -= 1;

                }


                if (Convert.ToString(keyname.Key) == "DownArrow" && y < Console.WindowHeight - 1)
                {
                    y += 1;
                }


                if (Convert.ToString(keyname.Key) == "LeftArrow" && x > 0)
                {
                    x -= 1;
                }


                if (Convert.ToString(keyname.Key) == "RightArrow" && x < Console.WindowWidth - 1)
                {
                    x += 1;
                }

                for (int i = 0; i < y; i++)
                {
                    lignePos+= "\n";
                }

                for (int i = 0; i < x; i++)
                {
                    lignePos += " ";
                }
                lignePos += skin;
                Console.Write(lignePos);
                keyname = Console.ReadKey();
                Console.Clear();
            }

            }

        private static void BougerCurseurConsoleSet()
        {
            int x = 0;
            int y = 0;
            var keyname = Console.ReadKey();

            while (Convert.ToString(keyname.Key) != "Escape")
            {

                if (Convert.ToString(keyname.Key) == "UpArrow" && y > 0)
                {
                    y -= 1;

                }
                if (Convert.ToString(keyname.Key) == "DownArrow" && y < Console.WindowHeight - 1)
                {
                    y += 1;
                }
                if (Convert.ToString(keyname.Key) == "LeftArrow" && x > 0)
                {
                    x -= 1;
                }
                if (Convert.ToString(keyname.Key) == "RightArrow" && x < Console.WindowWidth - 1)
                {
                    x += 1;
                }
                Console.SetCursorPosition(x, y);
                keyname = Console.ReadKey();
            }
        }
    }
}
