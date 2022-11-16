using System;

namespace UtilityVehiclesMonitoringTool
{
    /// <summary>
    /// This class represents a base class for different types of vehicle.
    /// </summary>
    public class Vehicle
    {
        public int Id { get; }
        public int CurrentFuelLevel { get; private set; }
        public int MaxTankCapacity { get; }
        public int NeededFuel { get { return MaxTankCapacity - CurrentFuelLevel; } }
        public Vehicle(int id, int maxTankCapacity, int currentFuelLevel)
        {
            Id = id;
            MaxTankCapacity = maxTankCapacity;
            CurrentFuelLevel = currentFuelLevel;
        }
       
        public void ConsumeFuel()
        {
            if (CurrentFuelLevel > 0)
                CurrentFuelLevel--;
        }

        public void AddFuel(int capacity)
        {
            if (CurrentFuelLevel <= MaxTankCapacity)
                CurrentFuelLevel+= capacity;
        }
    }
}
