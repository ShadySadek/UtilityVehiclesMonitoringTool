using System;

namespace UtilityVehiclesMonitoringTool
{
    /// <summary>
    /// Fuel truck class to refuell utility vehicles.
    /// </summary>
    public class FuelTruck : Vehicle
    {
        /// <summary>
        /// Captures a reserve capacity of fuel more than what is known to be needed to refill the utility vehicles.
        /// </summary>
        public int ReservedFuelCapacity { get; private set; }
        public FuelTruck(int id, int maxTankCapacity, int reservedFuelCapacity = 5) : base(id, maxTankCapacity, 0)
        {
            ReservedFuelCapacity = reservedFuelCapacity;
            AddFuel(reservedFuelCapacity);
        }

    }
}
