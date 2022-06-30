using CourseWork;

namespace VendingMachine.Patterns.AbstractFactory
{
    internal interface IVendingMachineFactory
    {
        IAbstractNoodle CreateNoodle();
        IAbstractFizzyDrink CreateFizzyDrink();

        string Owner { get; set; }

        int Price { get; set; }
        int TouchPoint { get; set; }

        public string GetVendorInformation();

    }
}