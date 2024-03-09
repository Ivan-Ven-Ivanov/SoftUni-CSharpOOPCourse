namespace _04.PizzaCalories.Models
{
    public class Topping
    {
        private const double BaseCalories = 2.0;

        private Dictionary<string, double> toppingCalories;

        private string toppingType;
        private int weight;

        public Topping(string toppingType, int weight)
        {
            toppingCalories = new Dictionary<string, double>
            {
                {"meat", 1.2 },
                {"veggies", 0.8 },
                { "cheese", 1.1},
                { "sauce", 0.9}
            };

            ToppingType = toppingType;
            Weight = weight;
        }

        public string ToppingType
        {
            get => toppingType;
            private set
            {
                ExceptionHandling.CheckIfToppingIsInvalid(value, toppingCalories);
                toppingType = value;
            }
        }
        public int Weight
        {
            get => weight;
            private set
            {
                ExceptionHandling.CheckIfToppingWeightIsInvalid(value, ToppingType);
                weight = value;
            }
        }
        public double Calories
        {
            get
            {
                return BaseCalories * Weight * toppingCalories[ToppingType.ToLower()];
            }
        }
    }
}
