
using System;

namespace _008
{
    public class Card
    {
        public Card()
        {
        }
        public Card(Random rnd)
        {
            Name = Models[rnd.Next(Models.Length)];
            Brand = Brands[rnd.Next(Brands.Length)];
            MaxSpeed = 100 + ((rnd.Next(16)) * 10);
            Weight = 900 + ((rnd.Next(17)) * 100);
            Price = 4000000 + ((rnd.Next(60)) * 500000);
            Engine = 800 + ((rnd.Next(37)) * 200);
        }
        private static string[] Models = new string[]{
            "Berlingo",
            "Fiesta",
            "Polo",
            "Rio"
        };
        private static string[] Brands = new string[]{
            "Fiat",
            "Ford",
            "Renault",
            "Volkswagen"
        };
        public string Name { get; set; }
        public string Brand { get; set; }
        public int MaxSpeed { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }
        public int Engine { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
