using System;
using VendingMachine.Patterns.StrategyLogger;

namespace VendingMachine.Patterns.AbstractFactory
{
    public class UsFizzyDrink : IAbstractFizzyDrink
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
                var clone = (IAbstractFizzyDrink)MemberwiseClone();
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
}