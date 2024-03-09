using _04.PizzaCalories.Models;

namespace _04.PizzaCalories
{
    public class StartUp
    {
        static void Main()
        {
            string[] pizzaInput = Console.ReadLine()
                .Split();

            string[] doughInput = Console.ReadLine()
                .Split();

            try
            {
                Dough dough = new(doughInput[1], doughInput[2], int.Parse(doughInput[3]));
                Pizza pizza = new(pizzaInput[1], dough);

                string input;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] toppingsInput = input.Split();

                    Topping topping = new(toppingsInput[1], int.Parse(toppingsInput[2]));

                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}