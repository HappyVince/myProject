using System;
using System.Collections.Generic;
using System.Text;

namespace linQ
{
    enum Sock_Color{
        Red,
        Blue,
        Green,
        Black
    }
    class Chausette
    {
        public Chausette(int size, Sock_Color color)
        {
            this.size = size;
            this.color = color;
        }

        public Chausette(int size, Sock_Color color, int owner_ID)
        {
            this.size = size;
            this.color = color;
            this.Owner_ID = owner_ID;
        }

        public int size { get; set; }
        public  Sock_Color color { get; set; }

        public int Owner_ID { get; set; }

    }

    class Owner
    {
        public string Name { get; set; }

        public int Id { get; set; }
        public Owner(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
}
