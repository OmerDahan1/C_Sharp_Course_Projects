using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private readonly eColor r_Color;
        private readonly eDoors r_NumberOfDoors;

        public enum eColor
        {
            Red,
            Black,
            White,
            Silver,
        }

        public enum eDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
        }

        public Car(Dictionary<string, string> i_CarProperties, Engine i_Engine)
            : base(i_CarProperties, i_Engine)
        {
            this.r_Color = ParsingAndValidation.ValidAndParseEnum<eColor>(i_CarProperties["Car's color:"], "Car color");
            this.r_NumberOfDoors = (eDoors)int.Parse(i_CarProperties["Car's number of doors:"]);
        }

        internal static List<string> GetCarProperties()
        {
            List<string> carProperties = GetVehicleDetails();

            carProperties.Add("Car's color:");
            carProperties.Add("Car's number of doors:");

            return carProperties;
        }

        public override string ToString()
        {
            string carProperties = string.Format(
@"{0}
{1}
Car's color: {2}
Car's number of doors: {3}",
this.GetVehicleProperties(),
this.Engine.ToString(),
this.r_Color,
this.r_NumberOfDoors);

            return carProperties;
        }
    }
}
