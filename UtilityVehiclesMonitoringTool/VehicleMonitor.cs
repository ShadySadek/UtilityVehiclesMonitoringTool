using System;
using System.Threading.Channels;

namespace UtilityVehiclesMonitoringTool
{
    /// <summary>
    /// This class monitor messages coming from different utility vehicles and display them on the screen and print the assignment plan (Consumer)
    /// </summary>
    public class VehicleMonitor
    {
        private Channel<CurentFuelLevelMsg> _channel;
        private readonly FuelTruckManager _fuelTruckManager;
        private readonly IEnumerable<UtilityVehicle> _vehicles;
        private readonly int _vehicleFuelThreshold;
        public VehicleMonitor(Channel<CurentFuelLevelMsg> channel, FuelTruckManager fuelTruckManager, IEnumerable<UtilityVehicle> vehicles, int vehicleFuelThreshold)
        {
            _channel = channel;
            _vehicleFuelThreshold = vehicleFuelThreshold;
            _fuelTruckManager = fuelTruckManager;
            _vehicles = vehicles;
        }

        public async Task Monitor()
        {
            await foreach (var recivedMsg in _channel.Reader.ReadAllAsync())
            { 
                var vehicle = _vehicles.SingleOrDefault(v => v.Id == recivedMsg.VehicleId);
                var msg = $"[{DateTime.Now}] Message Recevied: Vehicle Id: {vehicle.Id}, Current Fuel: {vehicle.CurrentFuelLevel} gallons, Fuel Needed: {vehicle.NeededFuel} gallons.";
                Console.WriteLine(msg);
                if (recivedMsg.CurrentFuelLevel <= _vehicleFuelThreshold)
                {
                    _fuelTruckManager.CreatePlan();
                    _fuelTruckManager.PrintPlan();
                    break;
                }
            }
        }
    }
}
