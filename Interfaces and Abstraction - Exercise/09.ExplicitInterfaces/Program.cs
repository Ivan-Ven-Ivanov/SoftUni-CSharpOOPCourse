using ExplicitInterfaces.Core;
using ExplicitInterfaces.Core.Interfaces;
using ExplicitInterfaces.IO;

namespace ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());

            engine.Run();
        }
    }
}