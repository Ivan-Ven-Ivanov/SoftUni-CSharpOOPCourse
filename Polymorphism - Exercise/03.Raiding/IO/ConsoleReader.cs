﻿using Raiding.IO.Interfaces;

namespace Raiding.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
