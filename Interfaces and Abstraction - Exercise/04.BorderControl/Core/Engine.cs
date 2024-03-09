using BorderControl.Core.Interfaces;
using BorderControl.IO.Interfaces;
using BorderControl.Models;
using BorderControl.Models.Interfaces;

namespace BorderControl.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            string input;
            IIdentifiable identifiable;

            List<IIdentifiable> inhabitants = new List<IIdentifiable>();
            while ((input = reader.ReadLine()) != "End")
            {
                string[] inhabitantTokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (inhabitantTokens.Length == 3)
                {
                    string name = inhabitantTokens[0];
                    int age = int.Parse(inhabitantTokens[1]);
                    string id = inhabitantTokens[2];

                    identifiable = new Citizen(name, age, id);
                }
                else
                {
                    string model = inhabitantTokens[0];
                    string id = inhabitantTokens[1];

                    identifiable = new Robot(model, id);
                }

                inhabitants.Add(identifiable);
            }

            string fakeIdDigits = reader.ReadLine();

            foreach(IIdentifiable inhabitant in inhabitants)
            {
                if (inhabitant.Id.EndsWith(fakeIdDigits))
                {
                    writer.WriteLine(inhabitant.Id);
                }
            }

        }
    }
}
