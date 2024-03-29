﻿using WildFarm.Core.Interfaces;
using WildFarm.Factories.Interfaces;
using WildFarm.IO.Interfaces;
using WildFarm.Models.Animals.Interfaces;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IAnimalFactory animalFactory;
        private readonly IFoodFactory foodFactory;

        private readonly ICollection<IAnimal> animals;

        public Engine(IReader reader, IWriter writer, IAnimalFactory animalFactory, IFoodFactory foodFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;

            animals = new List<IAnimal>();
        }
        public void Run()
        {
            string input;
            while ((input = reader.ReadLine()) != "End")
            {
                IAnimal animal = null;

                try
                {
                    animal = CreateAnimal(input);

                    IFood food = CreateFood();

                    writer.WriteLine(animal.ProduceSound());
                    animal.Eat(food);
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }

                if (animal != null)
                {
                    animals.Add(animal);
                }
            }

            foreach (IAnimal animal in animals)
            {
                writer.WriteLine(animal.ToString());
            }
        }

        private IFood CreateFood()
        {
            string[] foodTokens = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string foodType = foodTokens[0];
            int quantity = int.Parse(foodTokens[1]);

            return foodFactory.CreateFood(foodType, quantity);
        }

        private IAnimal CreateAnimal(string input)
        {
            string[] animalTokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return animalFactory.CreateAnimal(animalTokens);
        }
    }
}
