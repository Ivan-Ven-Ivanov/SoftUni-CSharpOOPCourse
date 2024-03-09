namespace _02.EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            int start = 1;
            int end = 100;

            while (numbers.Count < 10)
            {
                try
                {
                    int number = ReadNumber(start, end);

                    start = number;
                    numbers.Add(number);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (ArgumentException aex)
                {
                    Console.WriteLine(aex.Message);
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static int ReadNumber(int start, int end)
        {
            bool isNumber = int.TryParse(Console.ReadLine(), out int currentNumber);

            if (!isNumber)
            {
                throw new FormatException("Invalid Number!");
            }

            if (currentNumber <= start || currentNumber >= end)
            {
                throw new ArgumentException($"Your number is not in range {start} - 100!");
            }

            return currentNumber;
        }
    }
}