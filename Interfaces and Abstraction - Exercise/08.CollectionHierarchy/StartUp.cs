using CollectionHierarchy.Core.Interfaces;
using CollectionHierarchy.IO;
using CollectionHierarchy.Core;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());
            engine.Run();
        }
    }
}