using WildFarm.Models.Animals.Interfaces;

namespace WildFarm.Factories.Interfaces
{
    public interface IAnimalFactory
    {
        IAnimal CreateAnimal(string[] animalTokens);
    }
}
