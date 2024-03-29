﻿using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double CatWeightMultiplier = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override IReadOnlyCollection<Type> PreferredFoodTypes
            => new HashSet<Type>() { typeof(Meat), typeof(Vegetable) };

        protected override double WeightMultiplier => CatWeightMultiplier;

        public override string ProduceSound()
            => "Meow";
    }
}
