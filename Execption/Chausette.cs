using System;
using System.Collections.Generic;
using System.Text;

namespace Exeception
{

    enum Sock_Color
    {
        Red,
        Blue,
        Green,
        Black
    }
    class Chausette
    {
        public int size { get; set; }
        public Sock_Color color { get; set; }

        public Chausette(int size, Sock_Color color)
        {
            if (size>50)
            {
                throw new IncorrectSockSizeException();
            }
            this.size = size;
            this.color = color;
        }
    }


    class IncorrectSockSizeException : Exception
    {
        public IncorrectSockSizeException() :
            base("La taille de vos chausettes est indécente")
        {

        }

    }
}
