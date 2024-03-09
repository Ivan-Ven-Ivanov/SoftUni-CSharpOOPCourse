using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoulMaster soulMaster = new("Test", 10);

            Console.WriteLine(soulMaster);
        }
    }
}