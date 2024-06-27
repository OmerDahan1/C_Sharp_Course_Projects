using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufacturerName;
        private readonly float r_MaxAirPressure;
        private float m_CurrentAirPressure;

        public Wheel(Dictionary<string, string> i_VehicleProperties)
        {
            this.r_ManufacturerName = i_VehicleProperties["Wheel manifacturer name:"];
            this.r_MaxAirPressure = float.Parse(i_VehicleProperties["Maximal wheel air pressure:"]);
            this.m_CurrentAirPressure = float.Parse(i_VehicleProperties["Current wheel air pressure:"]);
        }

        public string ManufacturerName
        {
            get
            {
                return this.r_ManufacturerName;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return this.r_MaxAirPressure;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return this.m_CurrentAirPressure;
            }
        }

        public void InflateWheel(float i_AirToAdd)
        {
            float newAirPressure = this.m_CurrentAirPressure + i_AirToAdd;

            if (newAirPressure <= this.r_MaxAirPressure)
            {
                this.m_CurrentAirPressure = newAirPressure;
            }
            else
            {
                throw new ValueOutOfRangeException(0, this.r_MaxAirPressure - this.m_CurrentAirPressure, "amount of air pressure");
            }
        }

        public override string ToString()
        {
            return string.Format(
@"Wheel manifacturer name: {0}
Maximal wheel air pressure:{1}
Current wheel air pressure:{2}",
this.r_ManufacturerName,
this.r_MaxAirPressure,
this.m_CurrentAirPressure);
        }

        public static List<string> GetWheelProperties()
        {
            List<string> wheelProperties = new List<string>();

            wheelProperties.Add("Wheel manifacturer name:");
            wheelProperties.Add("Current wheel air pressure:");

            return wheelProperties;
        }
    }
}
