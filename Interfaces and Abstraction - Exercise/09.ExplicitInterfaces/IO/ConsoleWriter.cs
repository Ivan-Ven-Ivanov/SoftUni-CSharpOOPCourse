using ExplicitInterfaces.IO.Interfaces;

namespace ExplicitInterfaces.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
