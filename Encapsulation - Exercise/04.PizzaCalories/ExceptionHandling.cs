using _04.PizzaCalories.Models;

namespace _04.PizzaCalories
{
    public static class ExceptionHandling
    {
        private const string InvalidFlourType = "Invalid type of dough.";
        private const string InvalidDoughWeight = "Dough weight should be in the range [1..200].";
        private const string InvalidToppingType = "Cannot place {0} on top of your pizza.";
        private const string InvalidToppingWeight = "{0} weight should be in the range [1..50].";
        private const string InvalidPizzaName = "Pizza name should be between 1 and 15 symbols.";
        private const string InvalidNumberOfToppings = "Number of toppings should be in range [0..10].";

        public static void CheckIfDoughIsInvalid(string input, Dictionary<string, double> collection)
        {
            if (string.IsNullOrWhiteSpace(input) || !collection.ContainsKey(input.ToLower()))
            {
                throw new ArgumentException(InvalidFlourType);
            }
        }
        public static void CheckIfToppingIsInvalid(string input, Dictionary<string, double> collection)
        {
            if (string.IsNullOrWhiteSpace(input) || !collection.ContainsKey(input.ToLower()))
            {
                throw new ArgumentException(string.Format(InvalidToppingType, input));
            }
        }

        public static void CheckIfDoughWeightIsInvalid(int input)
        {
            if (input < 1 || input > 200)
            {
                throw new ArgumentException(InvalidDoughWeight);
            }
        }
        public static void CheckIfToppingWeightIsInvalid(int input, string toppingType)
        {
            if (input < 1 || input > 50)
            {
                throw new ArgumentException(string.Format(InvalidToppingWeight, toppingType));
            }
        }
        public static void CheckIfPizzaNameIsInvalid(string input)
        {
            if (input.Length < 1 || input.Length > 15)
            {
                throw new ArgumentException(InvalidPizzaName);
            }
        }
        public static void CheckIfNumberOfToppingsIsInvalid(List<Topping> toppings)
        {
            if (toppings.Count < 0 || toppings.Count > 10)
            {
                throw new ArgumentException(InvalidNumberOfToppings);
            }
        }
    }
}
