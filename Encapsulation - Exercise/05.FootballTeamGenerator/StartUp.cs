using _05.FootballTeamGenerator.Models;
using System.Reflection;

namespace _05.FootballTeamGenerator
{
    public class StartUp
    {
        static void Main()
        {
            List<Team> teams = new List<Team>();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] inputTokens = command.Split(";");

                try
                {
                    switch (inputTokens[0])
                    {
                        case "Team":

                            Team team = new(inputTokens[1]);
                            teams.Add(team);
                            break;
                        case "Add":

                            string teamName = inputTokens[1];
                            string playerName = inputTokens[2];
                            int endurance = int.Parse(inputTokens[3]);
                            int sprint = int.Parse(inputTokens[4]);
                            int dribble = int.Parse(inputTokens[5]);
                            int passing = int.Parse(inputTokens[6]);
                            int shooting = int.Parse(inputTokens[7]);



                            AddPlayer(playerName, endurance, sprint, dribble, passing, shooting, teamName, teams);
                            break;
                        case "Remove":

                            string teamFromWhichToRemove = inputTokens[1];
                            string playerNameToRemove = inputTokens[2];

                            RemovePlayer(teamFromWhichToRemove, playerNameToRemove, teams);
                            break;
                        case "Rating":

                            string teamToRate = new(inputTokens[1]);
                            PrintRating(teamToRate, teams);

                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }

        public static void AddPlayer(string playerName, int endurance, int sprint, int dribble, int passing,
            int shooting, string teamName, List<Team> teams)
        {
            Team currentTeam = teams.FirstOrDefault(p => p.Name == teamName);
            ExceptionHandling.CheckIfTeamNameExists(currentTeam, teamName);
            Player player = new(playerName, endurance, sprint, dribble, passing, shooting);

            currentTeam.AddPlayer(player);
        }
        public static void RemovePlayer(string teamName, string playerName, List<Team> teams)
        {
            Team currentTeam = teams.FirstOrDefault(p => p.Name == teamName);
            ExceptionHandling.CheckIfTeamNameExists(currentTeam, teamName);
            currentTeam.RemovePlayer(playerName);
        }
        public static void PrintRating(string teamName, List<Team> teams)
        {
            Team currentTeam = teams.FirstOrDefault(p => p.Name == teamName);
            ExceptionHandling.CheckIfTeamNameExists(currentTeam, teamName);

            Console.WriteLine($"{teamName} - {currentTeam.Rating():F0}");
        }
    }
}