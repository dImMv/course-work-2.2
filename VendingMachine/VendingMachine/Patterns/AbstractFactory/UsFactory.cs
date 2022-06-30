using System;

namespace VendingMachine.Patterns.AbstractFactory
{
    internal class UsFactory : IVendingMachineFactory
    {


        public string Owner { get; set; }
        public int Price { get; set; }
        public int TouchPoint { get; set; }

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
            var usNoodle = new UsNoodle(name, price);
            return usNoodle;
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
            var usFizzyDrink = new UsFizzyDrink(name, price);
            return usFizzyDrink;
        }

        public string GetVendorInformation()
        {
            return
                $"This goods offer vendor - {Owner}; \nHis price for delivering one item is - ${Price}; \nThe distance between the vending machine and location is - {TouchPoint}mil";
        }
    }
}