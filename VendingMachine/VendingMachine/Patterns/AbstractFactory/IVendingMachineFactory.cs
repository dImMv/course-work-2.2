

namespace VendingMachine.Patterns.AbstractFactory
{
    public interface IVendingMachineFactory
    {
        IAbstractNoodle CreateNoodle();
        IAbstractFizzyDrink CreateFizzyDrink();

        string Owner { get; set; }

        int Price { get; set; }
        int TouchPoint { get; set; }

        public string GetVendorInformation();

    }
}