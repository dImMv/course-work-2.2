namespace VendingMachine.Patterns.AbstractFactory
{
    public interface IAbstractFizzyDrink : IProduct
    {
        string GetInformation();
        IAbstractFizzyDrink DeepCopy();
    }
}