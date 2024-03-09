namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings strings = new StackOfStrings();
            strings.Push("Hello");
            strings.Push("Ivan");
            strings.Push("Maria");

            if (!strings.IsEmpty())
            {
                string[] arr = new string[2]
                {
                    "Hi",
                    "Again"
                };

                Stack<string> newStack = strings.AddRange(arr);
            }
        }
    }
}