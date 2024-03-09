namespace _05.FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get => name;
            private set
            {
                ExceptionHandling.CheckIfNameIsInvalid(value);

                name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            Player currentPlayer = players.FirstOrDefault(p => p.Name == playerName);

            ExceptionHandling.CheckIfPlayerExistsInATeam(currentPlayer, playerName, Name);

            players.Remove(currentPlayer);
        }

        public double Rating()
        {
            if (players.Any())
            {
                return players.Average((p => p.SkillLevel));
            }

            return 0;
        }
    }

}
