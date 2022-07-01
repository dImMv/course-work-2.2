using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace VendingMachine
{

    // The Handler interface declares a method for building the chain of
    // handlers. It also declares a method for executing a request.
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);

        object Handle(int requestPrice, int requestAmount);
    }

    // The default chaining behavior can be implemented inside a base handler
    // class.
    abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        private AbstractHandler[] _handlers;

        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }

        public virtual object Handle(int requestPrice, int requestAmount)
        {
            if (_nextHandler != null)
            {
                return _nextHandler.Handle(requestPrice, requestAmount);
            }
            else
            {
                return null;
            }
        }

        private AbstractHandler[] GetValues()
        {
            _handlers = new AbstractHandler[10];
            _handlers[0] = null;
            _handlers[1] = new NoodleHandler();
            _handlers[2] = new NoodleHandler();
            _handlers[3] = new NoodleHandler();
            _handlers[4] = new FizzyDrinkHandler();
            _handlers[5] = new FizzyDrinkHandler();
            _handlers[6] = new FizzyDrinkHandler();
            _handlers[7] = null;
            _handlers[8] = null;
            _handlers[9] = null;
            return _handlers;
        }

        public List<AbstractHandler> GetChainOfResponsibilities(int[] order)
        {
            var basicHandlers = GetValues();
            var chainOfResponsibilities = new List<AbstractHandler>();
            for (var i = 0; i < order.Length; i++)
            {
                var currentOrder = order[i];
                if (currentOrder > 9) continue;
                if (basicHandlers[currentOrder] is null) continue;
                chainOfResponsibilities.Add(basicHandlers[currentOrder]);
            }

            for (var i = 0; i < chainOfResponsibilities.Count - 1; i++)
            {
                chainOfResponsibilities[i].SetNext(chainOfResponsibilities[i + 1]);
            }
            return chainOfResponsibilities;

        }


    }

    class FizzyDrinkHandler : AbstractHandler
    {
        public override object Handle(int requestPrice, int requestAmount)
        {
            if (requestPrice >= 10 && requestAmount != 0)
            {
                return $"Noodle Successfully pushed";
            }
            else
            {
                return base.Handle(requestPrice, requestAmount);
            }
        }
    }

    class NoodleHandler : AbstractHandler
    {
        public override object Handle(int requestPrice, int requestAmount)
        {
            if (requestPrice >= 10 && requestAmount != 0)
            {
                return $"Noodle Successfully pushed";
            }
            else
            {
                return base.Handle(requestPrice, requestAmount);
            }
        }
    }





    class Client
    {
        // The client code is usually suited to work with a single handler. In
        // most cases, it is not even aware that the handler is part of a chain.
        public static void ClientCode(AbstractHandler handler, string input, List<>)
        {

            foreach (var food in new List<string> { "Nut", "Banana", "Cup of coffee" })
            {
                Console.WriteLine($"Client: Who wants a {food}?");

                var result = handler.Handle(food);

                if (result != null)
                {
                    Console.Write($"   {result}");
                }
                else
                {
                    Console.WriteLine($"   {food} was left untouched.");
                }
            }
        }

        public static List<int> GetOrder()
        {
            Console.WriteLine("Enter your order");
            var input = Console.ReadLine();
            if (input is null) return null;
            var inputArr = input.Split(' ');
            var order = new List<int>();
            foreach (var item in inputArr)
            {
                var isNum = int.TryParse(item, out var dig);
                if (!isNum)
                {
                    return null;
                }
                order.Add(dig);
            }
            return order;
        }
    }







    public class Program
    {


        static void ProcessWork()
        {
            bool user;
            int id;
            do
            {
                Console.WriteLine("welcome! \nSelect user: 1 - admin 2 - simple user");
                var userInp = Console.ReadLine();
                user = int.TryParse(userInp, out id);
            } while (user);

            if (id == 1)
            {
                do
                {
                    try
                    {
                        Console.WriteLine("Welcome! \nenter the product you want to add [TYPE] [name] [price] \n" +
                                          "possible types: USN, KON, USF, KOF");
                        var userInp = Console.ReadLine()?.Split(' ');
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    while

            }
        }


            private static void Main(string[] args)
            {
                ProcessWork();
                // The other part of the client code constructs the actual chain.
                /*  var monkey = new MonkeyHandler();
                  var squirrel = new SquirrelHandler();
                  var dog = new DogHandler();

                  monkey.SetNext(squirrel).SetNext(dog);

                  // The client should be able to send a request to any handler, not
                  // just the first one in the chain.
                  Console.WriteLine("Chain: Monkey > Squirrel > Dog\n");
                  Client.ClientCode(monkey);
                  Console.WriteLine();

                  Console.WriteLine("Subchain: Squirrel > Dog\n");
                  Client.ClientCode(squirrel);*/

            }
        }





    }
