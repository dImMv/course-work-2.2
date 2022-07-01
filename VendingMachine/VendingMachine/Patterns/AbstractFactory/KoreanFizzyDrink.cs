using System;

using VendingMachine.Patterns.StrategyLogger;

namespace VendingMachine.Patterns.AbstractFactory
{
    public class KoreanFizzyDrink : IAbstractFizzyDrink
    {
        private readonly Logger _logger;

        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }

        public KoreanFizzyDrink(string name, int price)
        {
            Name = name;
            Price = price;
            _logger = new Logger(new AuditLog());
            Type = "Korean_Fizzy_Drink";
        }

        public string GetInformation()
        {
            return $"The Korean fizzy drink {Name} costs {Price}";
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
}