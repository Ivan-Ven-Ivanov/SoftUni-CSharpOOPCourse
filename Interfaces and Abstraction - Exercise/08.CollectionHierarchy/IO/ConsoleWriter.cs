using CollectionHierarchy.IO.Interfaces;

namespace CollectionHierarchy.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
