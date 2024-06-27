using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Client> m_ClientByLicense;
        private readonly Dictionary<int, string> r_GarageServices = null;

        public Garage()
        {
            this.m_ClientByLicense = new Dictionary<string, Client>();
            this.r_GarageServices = new Dictionary<int, string>
            {
                { 1, "Add a new vehicle to the garage" },
                { 2, "Display all liscense numbers of the veicles in the garage by given status" },
                { 3, "Update a vehicle status" },
                { 4, "Inflate air to maximum capacity of given license number" },
                { 5, "Refuel a gas vehicle" },
                { 6, "Recharge an Electrical vehicle" },
                { 7, "Display full vehicle information" },
                { 8, "Leave the garage" },
            };
        }

        public Dictionary<int, string> GarageServices
        {
            get
            {
                return this.r_GarageServices;
            }
        }

        private Client getClientByLicense(string i_LicenseNumber)
        {
            if (!this.m_ClientByLicense.ContainsKey(i_LicenseNumber))
            {
                throw new ArgumentException("No such client in this garage");
            }

            return this.m_ClientByLicense[i_LicenseNumber];
        }

        private Vehicle getVehicleByLicense(string i_LicenseNumber)
        {
            return this.getClientByLicense(i_LicenseNumber).Vehicle;
        }

        public bool AddNewVehicle(Vehicle i_VehicleToAdd, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            bool isAlreadyInGarage = true;
            string currentClientLicense = i_VehicleToAdd.LicenseNumber;

            if (this.m_ClientByLicense.ContainsKey(currentClientLicense))
            {
                Client currentClient = this.m_ClientByLicense[i_VehicleToAdd.LicenseNumber];
                this.ChangeVehicleStatus(currentClientLicense, "1");
            }
            else
            {
                Client newClientToAdd = new Client(i_OwnerName, i_OwnerPhoneNumber, i_VehicleToAdd);
                this.m_ClientByLicense.Add(currentClientLicense, newClientToAdd);
                isAlreadyInGarage = false;
            }

            return isAlreadyInGarage;
        }

        private Dictionary<Client.eStatus, List<string>> getLicenseDictionaryByStatus()
        {
            Dictionary<Client.eStatus, List<string>> licenseDictionaryByStatus = new Dictionary<Client.eStatus, List<string>>();

            foreach (string licenseNumber in this.m_ClientByLicense.Keys)
            {
                Client.eStatus currentStatus = this.m_ClientByLicense[licenseNumber].CurrentVehicleStatus;
                if (!licenseDictionaryByStatus.ContainsKey(currentStatus))
                {
                    List<string> licenseNumbersByStatus = new List<string>();
                    licenseNumbersByStatus.Add(licenseNumber);
                    licenseDictionaryByStatus.Add(currentStatus, licenseNumbersByStatus);
                }
                else
                {
                    licenseDictionaryByStatus[currentStatus].Add(licenseNumber);
                }
            }

            return licenseDictionaryByStatus;
        }

        public List<string> GetLicenseNumberByStatusList(int i_Status)
        {
            Dictionary<Client.eStatus, List<string>> dictionaryToCheck = this.getLicenseDictionaryByStatus();
            List<string> listByStatus = new List<string>();
            Client.eStatus enumStatus;

            enumStatus = (Client.eStatus)i_Status;
            if (dictionaryToCheck.ContainsKey(enumStatus))
            {
                listByStatus = dictionaryToCheck[enumStatus];
            }

            return listByStatus;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, string i_NewStatus)
        {
            Client currentClient = this.getClientByLicense(i_LicenseNumber);
            int statusNumber = int.Parse(i_NewStatus);
            Client.eStatus newStatus = (Client.eStatus)statusNumber;

            currentClient.CurrentVehicleStatus = newStatus;
        }

        public void InflateWheelsToMaxCapacity(string i_LicenseNumber)
        {
            Vehicle currentVehicle = this.getVehicleByLicense(i_LicenseNumber);

            foreach (Wheel wheel in currentVehicle.WheelList)
            {
                wheel.InflateWheel(wheel.MaxAirPressure - wheel.CurrentAirPressure);
            }
        }

        public void FillGas(string i_LicenseNumber, string i_GasType, string i_AmountToAdd)
        {
            Vehicle currentVehicle = this.getVehicleByLicense(i_LicenseNumber);

            if (!(currentVehicle.Engine is GasEngine))
            {
                throw new AggregateException("Can not add gas to a non-gas engine vehicle");
            }
            else
            {
                float amountToAdd = ParsingAndValidation.ValidAndParsePositiveFloat(i_AmountToAdd);
                GasEngine.eGasType gasType = ParsingAndValidation.ValidAndParseEnum<GasEngine.eGasType>(Enum.GetName(typeof(GasEngine.eGasType), int.Parse(i_GasType)), "Gas");
                ((GasEngine)currentVehicle.Engine).AddGas(amountToAdd, gasType);
                currentVehicle.UpdateEnergyPrecentage();
            }
        }

        public void Recharge(string i_LicenseNumber, string i_AmountToAdd)
        {
            Vehicle currentVehicle = this.getVehicleByLicense(i_LicenseNumber);
            if (!(currentVehicle.Engine is ElectricalEngine))
            {
                throw new AggregateException("Can not charge a non-electrical engine vehicle");
            }
            else
            {
                float amountToAdd = ParsingAndValidation.ValidAndParsePositiveFloat(i_AmountToAdd);
                ((ElectricalEngine)currentVehicle.Engine).Recharge(amountToAdd);
                currentVehicle.UpdateEnergyPrecentage();
            }
        }

        public string DisplayFullVehicleDetails(string i_LicenseNumber)
        {
            Client currentClient = this.getClientByLicense(i_LicenseNumber);

            return currentClient.ToString();
        }
    }
}
