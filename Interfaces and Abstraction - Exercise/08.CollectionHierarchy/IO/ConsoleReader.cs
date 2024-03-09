using CollectionHierarchy.IO.Interfaces;

namespace CollectionHierarchy.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
