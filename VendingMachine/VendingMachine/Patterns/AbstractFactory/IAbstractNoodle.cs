namespace VendingMachine
{
    public interface IAbstractNoodle : IProduct
    {
        string GetInformation();
        string GetSticks();
        public IAbstractNoodle DeepCopy();
    }
}