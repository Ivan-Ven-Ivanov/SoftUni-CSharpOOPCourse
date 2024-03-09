using BirthdayCelebrations.IO.Interfaces;

namespace BorderControl.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
