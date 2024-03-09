using _03.ShoppingSpree.Models;

namespace _03.ShoppingSpree
{
    public class StartUp
    {
        static void Main()
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] nameMoneyPairs = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            try
            {
                foreach (string pair in nameMoneyPairs)
                {
                    string[] nameMoney = pair.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string name = nameMoney[0];
                    decimal money = decimal.Parse(nameMoney[1]);

                    Person person = new(name, money);

                    people.Add(person);
                }

                string[] productNameCostPairs = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (string pair in productNameCostPairs)
                {
                    string[] productNameCost = pair.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string productName = productNameCost[0];
                    decimal cost = decimal.Parse(productNameCost[1]);

                    Product product = new(productName, cost);

                    products.Add(product);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] personProduct = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string personBuying = personProduct[0];
                string productToBuy = personProduct[1];

                Person person = people.FirstOrDefault(p => p.Name == personBuying);
                Product product = products.FirstOrDefault(p => p.Name == productToBuy);

                if (person != null && product != null)
                {
                    Console.WriteLine(person.BuyProduct(product));
                }
            }

            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}

