using MilitaryElite.Core.Interfaces;
using MilitaryElite.Enums;
using MilitaryElite.IO.Interfaces;
using MilitaryElite.Models;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private Dictionary<int, ISoldier> soldiers;
        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            soldiers = new Dictionary<int, ISoldier>();
        }
        public void Run()
        {
            string input;
            while ((input = reader.ReadLine()) != "End")
            {
                string[] soldierTokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    writer.WriteLine(ProcessInput(soldierTokens));
                }
                catch (Exception ex){ }
            }
        }

        private string ProcessInput(string[] soldierTokens)
        {
            string soldierType = soldierTokens[0];
            int id = int.Parse(soldierTokens[1]);
            string firstName = soldierTokens[2];
            string lastName = soldierTokens[3];

            ISoldier soldier = null;

            switch (soldierType)
            {
                case "Private":
                    soldier = GetPrivate(id, firstName, lastName, decimal.Parse(soldierTokens[4]));
                    break;
                case "LieutenantGeneral":
                    soldier = GetLieutenantGeneral(id, firstName, lastName, soldierTokens);
                    break;
                case "Engineer":
                    soldier = GetEngineer(id, firstName, lastName, soldierTokens);
                    break;
                case "Commando":
                    soldier = GetCommando(id, firstName, lastName, soldierTokens);
                    break;
                case "Spy":
                    soldier = GetSpy(id, firstName, lastName, int.Parse(soldierTokens[4]));
                    break;
            }

            soldiers.Add(id, soldier);

            return soldier.ToString();
        }

        private ISoldier GetSpy(int id, string firstName, string lastName, int codeNumber)
            => new Spy(id, firstName, lastName, codeNumber);

        private ISoldier GetCommando(int id, string firstName, string lastName, string[] soldierTokens)
        {
            decimal salary = decimal.Parse(soldierTokens[4]);

            bool isValidCorps = Enum.TryParse<Corps>(soldierTokens[5], out Corps corps);

            if (!isValidCorps)
            {
                throw new Exception();
            }

            List<IMission> missions = new();

            for (int i = 6; i < soldierTokens.Length; i += 2)
            {

                string codeName = soldierTokens[i];
                string missionState = soldierTokens[i + 1];

                bool isValidState = Enum.TryParse<MissionState>(missionState, out MissionState state);

                if (!isValidState)
                {
                    continue;
                }

                missions.Add(new Mission(codeName, state));
            }

            return new Commando(id, firstName, lastName, salary, corps, missions);
        }

        private ISoldier GetEngineer(int id, string firstName, string lastName, string[] soldierTokens)
        {
            decimal salary = decimal.Parse(soldierTokens[4]);

            bool isValidCorps = Enum.TryParse<Corps>(soldierTokens[5], out Corps corps);

            if (!isValidCorps)
            {
                throw new Exception();
            }

            List<IRepair> repairs = new();

            for (int i = 6; i < soldierTokens.Length; i += 2)
            {
                string partName = soldierTokens[i];
                int hoursWorked = int.Parse(soldierTokens[i + 1]);
                repairs.Add(new Repair(partName, hoursWorked));
            }

            return new Engineer(id, firstName, lastName, salary, corps, repairs);
        }

        private ISoldier GetLieutenantGeneral(int id, string firstName, string lastName, string[] soldierTokens)
        {
            decimal salary = decimal.Parse(soldierTokens[4]);

            List<IPrivate> privates = new();

            for (int i = 5; i < soldierTokens.Length; i++)
            {
                int soldierId = int.Parse(soldierTokens[i]);
                privates.Add((IPrivate)soldiers[soldierId]);
            }

            return new LieutenantGeneral(id, firstName, lastName, salary, privates);
        }

        private ISoldier GetPrivate(int id, string firstName, string lastName, decimal salary)
            => new Private(id, firstName, lastName, salary);
    }
}
