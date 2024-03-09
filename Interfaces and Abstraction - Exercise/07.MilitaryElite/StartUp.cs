using MilitaryElite.Core;
using MilitaryElite.Core.Interfaces;
using MilitaryElite.IO;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine(new ConsoleReader(), new  ConsoleWriter());
            engine.Run();
        }
    }
}