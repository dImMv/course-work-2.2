namespace VendingMachine.Patterns.AbstractFactory
{
    public class KoreanFizzyDrink : IAbstractFizzyDrink
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }

        public KoreanFizzyDrink(string name, int price)
        {
            Name = name;
            Price = price;
            Type = "Korean_Fizzy_Drink";
        }

        public string GetInformation()
        {
            return $"The Korean fizzy drink {Name} costs {Price}";
        }

        public IAbstractFizzyDrink DeepCopy()
        {
            var clone = (IAbstractFizzyDrink)MemberwiseClone();
            clone.Name = Name;
            clone.Type = Type;
            clone.Price = Price;
            return clone;
        }
    }
}