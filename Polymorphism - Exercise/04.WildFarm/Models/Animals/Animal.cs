using WildFarm.Models.Animals.Interfaces;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        protected abstract IReadOnlyCollection<Type> PreferredFoodTypes { get; }

        protected abstract double WeightMultiplier { get; }

        public void Eat(IFood food)
        {
            if (!PreferredFoodTypes.Any(t => t.Name == food.GetType().Name))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            Weight += food.Quantity * WeightMultiplier;

            FoodEaten += food.Quantity;
        }

        public abstract string ProduceSound();

        public override string ToString()
            => $"{this.GetType().Name} [{Name}, ";
    }
}
