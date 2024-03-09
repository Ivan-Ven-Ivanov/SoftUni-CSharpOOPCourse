using System.Text;

namespace _03.ShoppingSpree.Models
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionHandling.NameException);
                }

                name = value;
            }
        }
        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionHandling.MoneyException);
                }

                money = value;
            }
        }

        public string BuyProduct(Product product)
        {
            if (Money >= product.Cost)
            {
                bagOfProducts.Add(product);
                Money -= product.Cost;

                return $"{Name} bought {product.Name}";
            }
            else
            {
                return $"{Name} can't afford {product.Name}";
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Name} - ");

            if (bagOfProducts.Count > 0)
            {
                sb.Append(string.Join(", ", bagOfProducts.Select(p => p.Name)));
            }
            else
            {
                sb.Append("Nothing bought");
            }

            return sb.ToString();
        }
    }
}
