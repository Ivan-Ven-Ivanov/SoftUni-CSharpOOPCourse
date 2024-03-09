namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double IncreasedConsumption = 1.6;
        private const double RefuelPercentage = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, IncreasedConsumption, tankCapacity)
        {
        }
        public override void Refuel(double amount)
        {
            if (TankCapacity - FuelQuantity < amount)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }

            base.Refuel(amount * RefuelPercentage);
        }
    }
}
