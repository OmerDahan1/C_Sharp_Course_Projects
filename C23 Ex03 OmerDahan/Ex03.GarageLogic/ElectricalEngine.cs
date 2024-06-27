using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricalEngine : Engine
    {
        public ElectricalEngine(Dictionary<string, string> i_VehicelProperties)
            : base(i_VehicelProperties["Maximal battery time in hours:"], i_VehicelProperties["number of hours left in battery:"])
        {
        }

        public void Recharge(float i_HoursToCharge)
        {
            AddEnergy(i_HoursToCharge, "amount of hours for battery");
        }

        public static List<string> GetElectricalProperties()
        {
            List<string> electricProperties = new List<string>();
            electricProperties.Add("number of hours left in battery:");

            return electricProperties;
        }

        public override string ToString()
        {
            return string.Format("Electrical Engine: the battery has {0} more hours", this.CurrentEnergy);
        }
    }
}
