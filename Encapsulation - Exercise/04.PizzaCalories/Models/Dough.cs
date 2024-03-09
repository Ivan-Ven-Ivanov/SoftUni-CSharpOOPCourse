namespace _04.PizzaCalories.Models
{
    public class Dough
    {
        private const double BaseCalories = 2.0;

        private Dictionary<string, double> flourTypeCalories;
        private Dictionary<string, double> bakingTechniqueCalories;

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            flourTypeCalories = new Dictionary<string, double>
            {
                {"white", 1.5 },
                {"wholegrain", 1.0 }
            };
            bakingTechniqueCalories = new Dictionary<string, double>
            {
                {"crispy", 0.9 },
                {"chewy", 1.1 },
                {"homemade", 1.0 }
            };

            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get => flourType;
            private set
            {
                ExceptionHandling.CheckIfDoughIsInvalid(value, flourTypeCalories);
                flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                ExceptionHandling.CheckIfDoughIsInvalid(value, bakingTechniqueCalories);
                bakingTechnique = value;
            }
        }
        public int Weight
        {
            get => weight;
            private set
            {
                ExceptionHandling.CheckIfDoughWeightIsInvalid(value);
                weight = value;
            }
        }

        public double Calories
        {
            get
            {
                return BaseCalories * Weight * flourTypeCalories[FlourType.ToLower()] * bakingTechniqueCalories[BakingTechnique.ToLower()];
            }
        }
    }
}
