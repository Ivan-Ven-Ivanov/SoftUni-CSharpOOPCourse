using FoodShortage.Core.Interfaces;
using FoodShortage.IO.Interfaces;
using FoodShortage.Models;
using FoodShortage.Models.Interfaces;
using System.ComponentModel.Design;

namespace FoodShortage.Core
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
            int peopleCount = int.Parse(reader.ReadLine());

            List<IBuyer> buyers = new List<IBuyer>();

            IBuyer buyer;
            for (int i = 0; i < peopleCount; i++)
            {
                string[] buyersTokens = reader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (buyersTokens.Length == 4)
                {
                    string name = buyersTokens[0];
                    int age = int.Parse(buyersTokens[1]);
                    string id = buyersTokens[2];
                    string birthdate = buyersTokens[3];

                    buyer = new Citizen(name, age, id, birthdate);
                }
                else
                {
                    string name = buyersTokens[0];
                    int age = int.Parse(buyersTokens[1]);
                    string group = buyersTokens[2];

                    buyer = new Rebel(name, age, group);
                }

                buyers.Add(buyer);
            }

            string buyerName;

            while ((buyerName = reader.ReadLine()) != "End")
            {
                buyers.FirstOrDefault(b => b.Name == buyerName)?.BuyFood();
            }

            writer.WriteLine(buyers.Sum(b => b.Food).ToString());
        }
    }
}
