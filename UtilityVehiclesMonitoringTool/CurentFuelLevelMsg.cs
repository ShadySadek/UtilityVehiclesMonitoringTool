using System;

namespace UtilityVehiclesMonitoringTool
{
    /// <summary>
    /// This class captures the message the will be used between producer and consumer communication.
    /// </summary>
    public class CurentFuelLevelMsg
    {
        public int VehicleId { get; set; }
        public int CurrentFuelLevel { get; set; }
    }
}
