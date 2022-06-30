using System;
using CourseWork;

namespace VendingMachine.Patterns.AbstractFactory
{
    internal class UsNoodle : IAbstractNoodle
    {
        private readonly Logger _logger;

        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }

        public UsNoodle(string name, int price)
        {
            Name = name;
            Price = price;
            Type = "US_Noodle";
            _logger = new Logger(new AuditLog());
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
            try
            {
                var clone = (IAbstractNoodle)MemberwiseClone();
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