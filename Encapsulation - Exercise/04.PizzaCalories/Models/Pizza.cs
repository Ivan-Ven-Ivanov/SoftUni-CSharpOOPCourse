namespace _04.PizzaCalories.Models
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
        }

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            toppings = new List<Topping>();
        }

        public string Name 
        {
            get => name;
            private set
            {
                ExceptionHandling.CheckIfPizzaNameIsInvalid(value);
                name = value;
            }
        }
        public Dough Dough { get; set;}
        public int NumberOfToppings => toppings.Count;
        public double TotalCalories => Dough.Calories + toppings.Sum(t => t.Calories);

        public void AddTopping(Topping topping)
        {
            ExceptionHandling.CheckIfNumberOfToppingsIsInvalid(toppings);
            toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{Name} - {TotalCalories:F2} Calories.";
        }
    }
}
