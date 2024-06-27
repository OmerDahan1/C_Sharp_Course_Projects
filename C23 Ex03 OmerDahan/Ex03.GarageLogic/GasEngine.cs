using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class GasEngine : Engine
    {
        private readonly eGasType r_GasType;

        public enum eGasType
        {
            Soler = 1,
            Octan95 = 2,
            Octan96 = 3,
            Octan98 = 4,
        }

        public GasEngine(Dictionary<string, string> i_GasProperties)
            : base(i_GasProperties["Maximal gas capacity:"], i_GasProperties["Current amount of gas:"])
        {
            this.r_GasType = ParsingAndValidation.ValidAndParseEnum<eGasType>(i_GasProperties["Gas type:"], "Gas type");
        }

        public void AddGas(float i_GasAmountToAdd, eGasType i_GasType)
        {
            if (i_GasType == this.r_GasType)
            {
                this.AddEnergy(i_GasAmountToAdd, "Gas Amount");
            }
            else
            {
                throw new ArgumentException("Invalid gas type");
            }
        }

        public static List<string> GetGasProperties()
        {
            List<string> fuelProperties = new List<string>();

            fuelProperties.Add("Current amount of gas:");

            return fuelProperties;
        }

        public override string ToString()
        {
            return string.Format(
@"Gas engine:
Gas type: {0}
Current amount of gas is: {1}",
this.r_GasType,
this.CurrentEnergy);
        }
    }
}
