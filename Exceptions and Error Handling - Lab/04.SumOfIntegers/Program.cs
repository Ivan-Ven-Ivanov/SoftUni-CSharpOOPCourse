namespace _04.SumOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string element in input)
            {
                try
                {
                    int currentNumber = int.Parse(element);
                    checked
                    {
                        sum += currentNumber;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{element}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }

                Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}