using System;


namespace UtilityVehiclesMonitoringTool
{
    /// <summary>
    /// This class creates assignment plan to send fuel truck to refuel utility vehicles 
    /// </summary>
    public class FuelTruckManager
    {
        private readonly IEnumerable<UtilityVehicle>  _vehicles;
        private readonly IList<FuelTruckAssignment>  _plan;
        private readonly int _truckMaxFuelCapacity;
        private readonly int _truckReservedFuelCapacity;
        public FuelTruckManager(IEnumerable<UtilityVehicle> vehicles,int truckMaxFuelCapacity, int truckReservedFuelCapacity)
        {
            _vehicles = vehicles;
            _plan = new List<FuelTruckAssignment>();
            _truckMaxFuelCapacity = truckMaxFuelCapacity;
            _truckReservedFuelCapacity = truckReservedFuelCapacity;
        }

        public IEnumerable<FuelTruckAssignment> CreatePlan()
        {
            int i = 1;
            foreach (var vehicle in _vehicles)
            {
                var truckAssignment = _plan.FirstOrDefault(a => a.CanAssignVehicle(vehicle));
                if (truckAssignment == null)
                {
                    truckAssignment = new FuelTruckAssignment(new FuelTruck(i++, _truckMaxFuelCapacity, _truckReservedFuelCapacity));
                    _plan.Add(truckAssignment);
                }

                truckAssignment.AssignVehicle(vehicle);
            }
            return _plan;
        }

        public void PrintPlan()
        {
            foreach(var item in _plan)
            {
                Console.WriteLine(item.PrintAssignment());
            }
        }

    }
}
