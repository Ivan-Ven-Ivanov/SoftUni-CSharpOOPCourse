using FoodShortage.Models.Interfaces;

namespace FoodShortage.Models
{
    public class Citizen : IAgeable, IIdentifiable, IBirthable, IBuyer
    {
        private const int DefaultFoodIncrement = 10;
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public int Food {  get; private set; }

        public void BuyFood()
        {
            Food += DefaultFoodIncrement;
        }
    }
}
