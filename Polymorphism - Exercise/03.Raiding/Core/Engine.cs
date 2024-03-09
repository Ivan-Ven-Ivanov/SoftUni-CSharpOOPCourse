using Raiding.Core.Interfaces;
using Raiding.Factories.Interfaces;
using Raiding.IO.Interfaces;
using Raiding.Models.Interfaces;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IHeroFactory heroFactory;

        private readonly ICollection<IBaseHero> heroes;
        public Engine(IReader reader, IWriter writer, IHeroFactory heroFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.heroFactory = heroFactory;
            heroes = new List<IBaseHero>();
        }
        public void Run()
        {
            int heroCount = int.Parse(reader.ReadLine());

            while (heroes.Count < heroCount)
            {
                try
                {
                    heroes.Add(CreateHero());
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

            int bossPower = int.Parse(reader.ReadLine());

            foreach (IBaseHero hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            if (heroes.Sum(h => h.Power) >= bossPower)
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine("Defeat...");
            }
        }

        private IBaseHero CreateHero()
        {
            string heroName = reader.ReadLine();
            string heroType = reader.ReadLine();

            return heroFactory.CreateHero(heroType, heroName);
        }
    }
}
