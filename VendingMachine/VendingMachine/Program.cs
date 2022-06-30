using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using CourseWork;
using VendingMachine.Patterns.AbstractFactory;

namespace VendingMachine
{
    public interface IAbstractNoodle : IProduct
    {
        string GetInformation();
        string GetSticks();
        public IAbstractNoodle DeepCopy();
    }

    public class KoreanNoodle :  IAbstractNoodle 
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }

        public KoreanNoodle(string name, int price)
        {
            Name = name;
            Price = price;
            Type = "Korean_Noodle";
        }
        
        public virtual string GetInformation()
        {
            return $"The Korean noodle {Name} costs {Price}";
        }

        public virtual string GetSticks()
        {
            return "Take your metal sticks from bottom";
        }

        public IAbstractNoodle DeepCopy()
        {
            var clone = (IAbstractNoodle)this.MemberwiseClone();
            clone.Name = Name;
            clone.Type = Type;
            clone.Price = Price;
            return clone;
        }
    }


    public class UsFizzyDrink :  IAbstractFizzyDrink
    {

        private readonly Logger _logger;
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }

        public UsFizzyDrink(string name, int price)
        {
            Name = name;
            Price = price;
            Type = "US_Fizzy_Drink";
            _logger = new Logger(new AuditLog());
        }

        public string GetInformation()
        {
            return $"The US fizzy drink {Name} costs {Price}";
        }

        public IAbstractFizzyDrink DeepCopy()
        {
            try
            {
                var clone = (IAbstractFizzyDrink) MemberwiseClone();
                clone.Name = Name;
                clone.Type = Type;
                clone.Price = Price;

                return clone;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }


    }


    public class Client
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



    public interface IBillStrategy
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

        public string Get()
        {
            throw new NotImplementedException();
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
