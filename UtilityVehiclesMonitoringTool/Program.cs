using System.Threading.Channels;
using UtilityVehiclesMonitoringTool;

var _channel = Channel.CreateUnbounded<CurentFuelLevelMsg>();
var _utilityVehicleMaxTankCapacity = 15;
int _fuelTruckMaxFuelCapacity = 40;
int _fuelTruckReservedCapacity = 5;
int _utilityVehicleFuelThreshold = 3;
var _utilityVehicles = new List<UtilityVehicle>();
var _vehicleFuelNotificationProducer = new VehicleFuelNotificationProducer(_channel);
var _fuelTruckManager = new FuelTruckManager(_utilityVehicles, _fuelTruckMaxFuelCapacity, _fuelTruckReservedCapacity);
var _vehicleMonitor = new VehicleMonitor(_channel, _fuelTruckManager, _utilityVehicles, _utilityVehicleFuelThreshold);

//Create Truck
for (int i = 1; i <= 10; i++)
{
    var vehicle = new UtilityVehicle(i, _utilityVehicleMaxTankCapacity);
    _utilityVehicles.Add(vehicle);
    Task.Run(async () => await _vehicleFuelNotificationProducer.SendNotificationAsync(vehicle));
}

await _vehicleMonitor.Monitor();