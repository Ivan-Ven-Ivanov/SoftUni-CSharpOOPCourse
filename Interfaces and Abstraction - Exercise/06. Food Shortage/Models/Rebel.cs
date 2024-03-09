using FoodShortage.Models.Interfaces;

namespace FoodShortage.Models
{
    public class Rebel : IAgeable, IBuyer
    {
        private const int DefaultFoodIncrement = 5;

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Name {  get; set; }

        public int Age { get; set; }
        public string Group { get; set; }

        public int Food { get; set; }

        public void BuyFood()
        {
            Food += DefaultFoodIncrement;
        }
    }
}
