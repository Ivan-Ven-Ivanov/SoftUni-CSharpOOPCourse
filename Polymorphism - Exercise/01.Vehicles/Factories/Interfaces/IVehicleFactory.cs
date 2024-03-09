using Vehicles.Models.Interfaces;

namespace Vehicles.Factories.Interfaces
{
    public interface IVehicleFactory
    {
        IVehicle Create(string typeName, double fuelQuantity, double fuelConsumption, double tankCapacity);
    }
}
