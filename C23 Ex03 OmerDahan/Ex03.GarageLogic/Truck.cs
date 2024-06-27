using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private readonly bool r_IsDrivingDangerousMaterials;
        private readonly float r_LuggageCapacity;

        public Truck(Dictionary<string, string> i_TruckProperties, Engine i_Engine)
            : base(i_TruckProperties, i_Engine)
        {
            this.r_IsDrivingDangerousMaterials = i_TruckProperties["The truck is carrying dangerous materials:"].ToLower().Equals("yes");
            this.r_LuggageCapacity = float.Parse(i_TruckProperties["Truck luggage capacity:"]);
        }

        public static List<string> GetTruckProperties()
        {
            List<string> truckProperties = GetVehicleDetails();

            truckProperties.Add("The truck is carrying dangerous materials:");
            truckProperties.Add("Truck luggage capacity:");

            return truckProperties;
        }

        public override string ToString()
        {
            string truckProperties = string.Format(
@"{0}
{1}
The truck is carrying dangerous materials: {2}
Truck luggage capacity: {3}",
this.GetVehicleProperties(),
this.Engine.ToString(),
this.r_IsDrivingDangerousMaterials,
this.r_LuggageCapacity);

            return truckProperties;
        }
    }
}
