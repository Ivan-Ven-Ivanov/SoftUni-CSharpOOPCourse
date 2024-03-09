using BirthdayCelebrations.Core.Interfaces;
using BirthdayCelebrations.IO.Interfaces;
using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;
using BorderControl.Models;

namespace BirthdayCelebrations.Core
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

            List<IBirthable> birthables = new List<IBirthable>();
            while ((input = reader.ReadLine()) != "End")
            {
                string[] inhabitantTokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (inhabitantTokens[0])
                {
                    case "Citizen":

                        string name = inhabitantTokens[1];
                        int age = int.Parse(inhabitantTokens[2]);
                        string id = inhabitantTokens[3];
                        string birthdate = inhabitantTokens[4];

                        IBirthable citizen = new Citizen(name, age, id, birthdate);
                        birthables.Add(citizen);

                        break;
                    case "Pet":

                        string petName = inhabitantTokens[1];
                        string petBirthdate = inhabitantTokens[2];

                        IBirthable Pet = new Pet(petName, petBirthdate);
                        birthables.Add(Pet);

                        break;
                }
            }

            string birthYear = reader.ReadLine();

            foreach (IBirthable birthable in birthables)
            {
                if (birthable.Birthdate.EndsWith(birthYear))
                {
                    writer.WriteLine(birthable.Birthdate);
                }
            }
        }
    }
}
