using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicenseNumber;
        private float m_EnergyPercentage;
        private readonly int r_NumberOfWheels;
        private readonly Engine r_Engine;
        private readonly List<Wheel> r_WheelsList = new List<Wheel>();
        private readonly Dictionary<string, string> r_VehicleProperties;

        public Vehicle(Dictionary<string, string> i_VehicleDetails, Engine i_Engine)
        {
            this.r_VehicleProperties = i_VehicleDetails;
            this.r_ModelName = i_VehicleDetails["Model name:"];
            this.r_LicenseNumber = i_VehicleDetails["License number:"];
            this.r_Engine = i_Engine;
            this.m_EnergyPercentage = (i_Engine.CurrentEnergy / i_Engine.MaxEnergy) * 100;
            this.r_NumberOfWheels = int.Parse(i_VehicleDetails["Number of wheels:"]);
            this.buildWheelsList();
        }

        private void buildWheelsList()
        {
            for (int i = 0; i < this.r_NumberOfWheels; i++)
            {
                this.r_WheelsList.Add(new Wheel(this.r_VehicleProperties));
            }
        }

        public Engine Engine
        {
            get
            {
                return this.r_Engine;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return this.r_LicenseNumber;
            }
        }

        public List<Wheel> WheelList
        {
            get
            {
                return this.r_WheelsList;
            }
        }

        public void UpdateEnergyPrecentage()
        {
            this.m_EnergyPercentage = (this.r_Engine.CurrentEnergy / this.r_Engine.MaxEnergy) * 100;
        }

        internal static List<string> GetVehicleDetails()
        {
            List<string> vehicleProperties = new List<string>();

            vehicleProperties.Add("Model name:");
            vehicleProperties.Add("License number:");
            vehicleProperties.AddRange(Wheel.GetWheelProperties());

            return vehicleProperties;
        }

        public virtual string GetVehicleProperties()
        {
            string vehicleProperties = string.Format(
@"Vehicle properties:
License number: {0}
Model name: {1}
Energy status: {2}%
{3}
",
this.r_LicenseNumber,
this.r_ModelName,
this.m_EnergyPercentage,
this.r_WheelsList[0].ToString());

            return vehicleProperties;
        }
    }
}
