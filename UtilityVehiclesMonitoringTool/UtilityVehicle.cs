using System;

namespace UtilityVehiclesMonitoringTool
{
    /// <summary>
    ///  Utility vehicle class to captures utility vehicles on a worker site.
    /// </summary>
    public class UtilityVehicle : Vehicle
    {
        public UtilityVehicle (int id, int maxTankCapacity) : base (id, maxTankCapacity, maxTankCapacity)
        {
        }
      
    }
}
