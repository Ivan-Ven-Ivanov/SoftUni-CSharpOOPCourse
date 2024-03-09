namespace _05.FootballTeamGenerator.Models
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
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
        public int Endurance
        {
            get => endurance;
            private set
            {
                ExceptionHandling.CheckIfStatIsInvalid(value, nameof(Endurance));

                endurance = value;
            }
        }
        public int Sprint
        {
            get => sprint;
            private set
            {
                ExceptionHandling.CheckIfStatIsInvalid(value, nameof(Sprint));

                sprint = value;
            }
        }
        public int Dribble
        {
            get => dribble;
            private set
            {
                ExceptionHandling.CheckIfStatIsInvalid(value, nameof(Dribble));

                dribble = value;
            }
        }
        public int Passing
        {
            get => passing;
            private set
            {
                ExceptionHandling.CheckIfStatIsInvalid(value, nameof(Passing));

                passing = value;
            }
        }
        public int Shooting
        {
            get => shooting;
            private set
            {
                ExceptionHandling.CheckIfStatIsInvalid(value, nameof(Shooting));

                shooting = value;
            }
        }

        public double SkillLevel => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;
    }
}
