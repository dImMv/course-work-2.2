using System;

namespace AbstractFactory
{

    public abstract class Product
    {
        protected Product(string name, string type, int price)
        {

            Name = name;
            Type = type;
            Price = price;
        }

        protected Product()
        { }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Price { get; set; }

    }



}