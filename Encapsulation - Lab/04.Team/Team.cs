using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            Name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public string Name { get; set; }

        public IReadOnlyCollection<Person> FirstTeam => firstTeam.AsReadOnly();

        public IReadOnlyCollection<Person> ReserveTeam => reserveTeam.AsReadOnly();

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }

        public override string ToString()
        {
            return $"First team has {FirstTeam.Count} players.{Environment.NewLine}" +
                $"Reserve team has {ReserveTeam.Count} players.";
        }
    }
}
