using _05.FootballTeamGenerator.Models;
using System.Xml.Linq;

namespace _05.FootballTeamGenerator
{
    public static class ExceptionHandling
    {
        private const string InvalidStatsMessage = "{0} should be between 0 and 100.";
        private const string InvalidNameMessage = "A name should not be empty.";
        private const string NotExisitingTeamMessage = "Team {0} does not exist.";
        private const string PlayerNotInTeamMessage = "Player {0} is not in {1} team.";
        public static void CheckIfStatIsInvalid(int statValue, string statName)
        {
            if (statValue < 0 || statValue > 100)
            {
                throw new ArgumentException(string.Format(InvalidStatsMessage, statName));
            }
        }
        public static void CheckIfNameIsInvalid(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(InvalidNameMessage);
            }
        }

        public static void CheckIfTeamNameExists(Team team,string teamName)
        {
            if (team == null)
            {
                throw new ArgumentException(string.Format(NotExisitingTeamMessage, teamName));
            }
        }

        public static void CheckIfPlayerExistsInATeam(Player player, string playerName, string teamName)
        { 
            if (player == null)
            {
                throw new ArgumentException(string.Format(PlayerNotInTeamMessage, playerName, teamName));
            }
        }
    }
}
