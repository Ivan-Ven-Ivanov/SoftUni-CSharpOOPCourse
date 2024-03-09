using WildFarm.Factories.Interfaces;
using WildFarm.Models.Foods;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string type, int quantity)
        {
            switch (type)
            {
                case "Meat":
                    return new Meat(quantity);
                case "Vegetable":
                    return new Vegetable(quantity);
                case "Seeds":
                    return new Seeds(quantity);
                case "Fruit":
                    return new Fruit(quantity);
                default:
                    throw new ArgumentException("Invalid food");
            }
        }
    }
}
