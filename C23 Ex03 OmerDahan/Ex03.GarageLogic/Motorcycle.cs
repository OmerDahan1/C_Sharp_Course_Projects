using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        private readonly eTypeOfLicense r_TypeOfLicense;
        private readonly int r_EngineCapacity;

        public enum eTypeOfLicense
        {
            A,
            A1,
            AA,
            B,
        }

        public Motorcycle(Dictionary<string, string> i_MotorcycleProperties, Engine i_Engine)
            : base(i_MotorcycleProperties, i_Engine)
        {
            this.r_TypeOfLicense = ParsingAndValidation.ValidAndParseEnum<eTypeOfLicense>(i_MotorcycleProperties["Motorcycle's type of license:"], "Motorcycle's type of license");
            this.r_EngineCapacity = int.Parse(i_MotorcycleProperties["Motorcycle's engine capacity:"]);
        }

        internal static List<string> GetMotorcycleProperties()
        {
            List<string> motorcycleProperties = GetVehicleDetails();

            motorcycleProperties.Add("Motorcycle's type of license:");
            motorcycleProperties.Add("Motorcycle's engine capacity:");

            return motorcycleProperties;
        }

        public override string ToString()
        {
            string motorCycleProperties = string.Format(
@"{0}
{1}
Motorcycle type of license: {2}
Motorcycle engine capacity: {3}",
this.GetVehicleProperties(),
this.Engine.ToString(),
this.r_TypeOfLicense,
this.r_EngineCapacity);

            return motorCycleProperties;
        }
    }
}
