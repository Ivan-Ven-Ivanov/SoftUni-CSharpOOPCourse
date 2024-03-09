namespace _03.ShoppingSpree.Models
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
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
        public decimal Cost 
        {
            get => cost; 
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionHandling.MoneyException);
                }

                cost = value; 
            }
        }
    }
}
