using System;
using System.Threading.Channels;

namespace UtilityVehiclesMonitoringTool
{
    /// <summary>
    /// This class simulates diffferent Utility svehicle clients that produce messages (producer) 
    /// </summary>
    public class VehicleFuelNotificationProducer
    {
        private Channel<CurentFuelLevelMsg> _channel;
        public VehicleFuelNotificationProducer(Channel<CurentFuelLevelMsg> channel)
        {
            _channel = channel;
        }

        public async Task SendNotificationAsync(UtilityVehicle vehicle)
        {
            int randomThreshold = new Random().Next(3, 9);
            while (vehicle.CurrentFuelLevel> randomThreshold)
            {
                int randomWait = new Random().Next(1, 2);
                await Task.Delay(TimeSpan.FromSeconds(randomWait));
                vehicle.ConsumeFuel();
                var msg = new CurentFuelLevelMsg() { VehicleId = vehicle.Id, CurrentFuelLevel = vehicle.CurrentFuelLevel };
                await _channel.Writer.WriteAsync(msg);
            }
        }
    }

}
