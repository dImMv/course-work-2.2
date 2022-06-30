namespace VendingMachine.Patterns.AbstractFactory
{
    public class KoreanNoodle : IAbstractNoodle
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
            var clone = (IAbstractNoodle)MemberwiseClone();
            clone.Name = Name;
            clone.Type = Type;
            clone.Price = Price;
            return clone;
        }
    }
}