using System;

namespace VendingMachine.Patterns.AbstractFactory
{
    internal class KoreanFactory : IVendingMachineFactory
    {
        public KoreanFactory(string owner, int price, int touchPoint)
        {
            Owner = owner;
            Price = price;
            TouchPoint = touchPoint;
        }

        public IAbstractNoodle CreateNoodle()
        {
            if (Owner == null)
            {
                Console.WriteLine("Operation is impossible!");
                return null;
            }

            Console.WriteLine("Enter name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter price");
            int.TryParse(Console.ReadLine(), out var price);
            var koreanNoodle = new KoreanNoodle(name, price);
            return koreanNoodle;
        }

        public IAbstractFizzyDrink CreateFizzyDrink()
        {
            if (Owner == null)
            {
                Console.WriteLine("Operation is impossible!");
                return null;
            }

            Console.WriteLine("Enter name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter price");
            int.TryParse(Console.ReadLine(), out var price);
            var koreanFizzyDrink = new KoreanFizzyDrink(name, price);
            return koreanFizzyDrink;
        }


        public string Owner { get; set; }
        public int Price { get; set; }
        public int TouchPoint { get; set; }
        public string GetVendorInformation()
        {
            return
                $"This goods offer vendor - {Owner}; \nHis price for delivering one item is - ${Price}; \nThe distance between the vending machine and location is - {TouchPoint}mil";
        }
    }
}