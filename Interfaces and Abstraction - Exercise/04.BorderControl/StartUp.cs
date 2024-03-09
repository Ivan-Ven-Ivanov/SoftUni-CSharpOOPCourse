﻿using BorderControl.Core.Interfaces;
using BorderControl.Core;
using BorderControl.IO;

namespace BorderControl
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