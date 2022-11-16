using System;
using System.Text;


namespace UtilityVehiclesMonitoringTool
{
    /// <summary>
    /// This class captures the assignments of utility vehicle to fuel truck.
    /// </summary>
    public class FuelTruckAssignment
    {
        private readonly FuelTruck _fuelTruck;
        private readonly IList<UtilityVehicle> _vehicles;
        public FuelTruckAssignment(FuelTruck fuelTruck)
        {
            _vehicles = new List<UtilityVehicle>();
            _fuelTruck = fuelTruck;
        }

        public bool CanAssignVehicle(UtilityVehicle v)
        {
            return v.NeededFuel <= _fuelTruck.NeededFuel;
        }
        public void AssignVehicle(UtilityVehicle v)
        {
           if(CanAssignVehicle(v))
            {
                _fuelTruck.AddFuel(v.NeededFuel);
                _vehicles.Add(v);
            }
        }
        public string PrintAssignment()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Fuel Truck Id {_fuelTruck.Id} is going out with {_fuelTruck.CurrentFuelLevel} gallons of fuel for the following vehicles:");
            foreach (var vehicle in _vehicles)
            { 
                sb.Append(Environment.NewLine);
                sb.Append($"        Vehicle Id: {vehicle.Id}, Current Fuel: {vehicle.CurrentFuelLevel} gallons, Fuel Needed: {vehicle.NeededFuel} gallons.");

            }
            return sb.ToString();
        }

    }
}
