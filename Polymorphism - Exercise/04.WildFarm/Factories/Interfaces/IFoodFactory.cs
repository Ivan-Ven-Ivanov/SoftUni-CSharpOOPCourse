using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Factories.Interfaces
{
    public interface IFoodFactory
    {
        IFood CreateFood(string type, int quantity);
    }
}
