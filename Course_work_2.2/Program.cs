using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using static System.Int32;

namespace CourseWork
{

    internal interface IVendingMachineFactory
    {
        IAbstractNoodle CreateNoodle();
        IAbstractFizzyDrink CreateFizzyDrink();

        string Owner { get; set; }

        int Price { get; set; }
        int TouchPoint { get; set; }

        public string GetVendorInformation();

    }


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
            TryParse(Console.ReadLine(), out var price);
            var koreanNoodle = new KoreanNoodle( name, price);
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
            TryParse(Console.ReadLine(), out var price);
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
    

    internal class UsFactory : IVendingMachineFactory
    {
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
            TryParse(Console.ReadLine(), out var price);
            var  usNoodle = new UsNoodle(name, price);
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
            TryParse(Console.ReadLine(), out var price);
            var usFizzyDrink = new UsFizzyDrink(name, price);
            return usFizzyDrink;
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

    internal interface IAbstractNoodle : IProduct
    {
        string GetInformation();

        string GetSticks();

        public IAbstractNoodle DeepCopy();


    }
    internal class KoreanNoodle :  IAbstractNoodle 
    {
        public KoreanNoodle(string name, int price)
        {
            this.Name = name;
            this.Price = price;
            this.Type = "Korean_Noodle";
        }
        
        public virtual string GetInformation()
        {
            return $"The Korean noodle {Name} costs {Price}";
        }

        public virtual string GetSticks()
        {
            return "Take your metal sticks from bottom";
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }

        public IAbstractNoodle DeepCopy()
        {
            var clone = (IAbstractNoodle)this.MemberwiseClone();
            clone.Name = Name;
            clone.Type = Type;
            clone.Price = Price;
            return clone;
        }

    }

    internal class UsNoodle :  IAbstractNoodle
    {
        public UsNoodle(string name, int price)
        {
            this.Name = name;
            this.Price = price;
            this.Type = "US_Noodle";
        }
        public virtual string GetInformation()
        {
            return $"The US noodle {Name} costs {Price}";
        }

        public virtual string GetSticks()
        {
            return "Take your wooden sticks from bottom";
        }

        public IAbstractNoodle DeepCopy()
        {
            var clone = (IAbstractNoodle)this.MemberwiseClone();
            clone.Name = Name;
            clone.Type = Type;
            clone.Price = Price;
            return clone;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
    }


    internal interface IAbstractFizzyDrink : IProduct
    {
        string GetInformation();

        public IAbstractFizzyDrink DeepCopy();
    }

    internal class KoreanFizzyDrink :  IAbstractFizzyDrink
    {
        public KoreanFizzyDrink(string name, int price)
        {
            this.Name = name;
            this.Price = price;
            this.Type = "Korean_Fizzy_Drink";
        }
        public string GetInformation()
        {
            return $"The Korean fizzy drink {Name} costs {Price}";
        }

        public IAbstractFizzyDrink DeepCopy()
        {
            var clone = (IAbstractFizzyDrink)this.MemberwiseClone();
            clone.Name = Name;
            clone.Type = Type;
            clone.Price = Price;
            return clone;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
    }

    internal class UsFizzyDrink :  IAbstractFizzyDrink
    {
        public UsFizzyDrink(string name, int price)
        {
            this.Name = name;
            this.Price = price;
            this.Type = "US_Fizzy_Drink";
        }
        public string GetInformation()
        {
            return $"The US fizzy drink {Name} costs {Price}";
        }

        public IAbstractFizzyDrink DeepCopy()
        {
            var clone = (IAbstractFizzyDrink)this.MemberwiseClone();
            clone.Name = Name;
            clone.Type = Type;
            clone.Price = Price;
            return clone;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
    }


    internal class Client
    {
        public void Main()
        {
            // The client code can work with any concrete factory class.
            Console.WriteLine("Client: Testing client code with the first factory type...");
            //ClientMethod(new ConcreteFactory1());
            Console.WriteLine();

            Console.WriteLine("Client: Testing the same client code with the second factory type...");
            //ClientMethod(new ConcreteFactory2());
        }

        /*public void ClientMethod(IAbstractFactory factory)
        {
            var productA = factory.CreateProductA();
            var productB = factory.CreateProductB();

            Console.WriteLine(productB.UsefulFunctionB());
            Console.WriteLine(productB.AnotherUsefulFunctionB(productA));
        }*/
    }



    internal interface IBillStrategy
    {

        public string Get();
    }


    public enum PaymentStatus
    {
        Successfully,
        Canceled
    }



    public class PrintBillStrategy : IBillStrategy
    {
       
        public PrintBillStrategy()
        {
            
        }


        private void PrintDict()
        {
            System.Console.WriteLine("Cash:");
            foreach (KeyValuePair<int, int> pair in this.bnDict)
            {
                if (pair.Value != 0)
                    System.Console.WriteLine($"{pair.Key}x{pair.Value}");
            }
        }

        public void GiveCash(double amount)
        {
            if (amount < 0)
                throw new Exception("Amount can not be negative");
            try
            {
                this.handler.GetBankNotes(amount, this.bnDict);
                this.PrintDict();
                this.FillDict();
            }
            catch (Exception)
            {

            }
        }

        public PaymentStatus OnPaymentProces()
        {
            while (true)
            {
                Console.WriteLine("Enter amount");
                string amount = Console.ReadLine();

                if (amount == "cancel")
                    return PaymentStatus.Canceled;

                bool isParsed = int.TryParse(amount, out int intAmount);

                if (!isParsed)
                {
                    Console.WriteLine("Incorrect entered amount, try again");
                    continue;
                }
                else
                {
                    if (intAmount < IBillStrategy.ticketPrice)
                    {
                        Console.WriteLine("Not enough money, try again");
                        continue;
                    }
                    else
                    {
                        GiveCash(intAmount - IBillStrategy.ticketPrice);
                        break;
                    }

                }
            }
            return PaymentStatus.Successfully;
        }
    }


    public class SmsPaymentStrategy : IBillStrategy
    {
        public PaymentStatus OnPaymentProces()
        {
            return GetCardNumber();
        }

        private PaymentStatus GetCardNumber()
        {
            while (true)
            {
                Console.WriteLine("Enter your card number");
                string cardNumber = Console.ReadLine();

                if (cardNumber == "cancel")
                    return PaymentStatus.Canceled;

                if (IsValidCardNumber(cardNumber))
                    return PaymentStatus.Successfully;
                else
                    Console.WriteLine("Wrong entered card number, try again");
            }
        }

        private bool IsValidCardNumber(string cardNumber)
        {
            return (cardNumber.Trim().Length == 16 && long.TryParse(cardNumber, out long n));
        }
    }













    internal class Program
    {





        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }





}
