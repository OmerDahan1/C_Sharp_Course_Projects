using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleCreator
    {
        public enum eVehicleType
        {
            GasMotorcycle = 1,
            ElectricMotorcycle = 2,
            GasCar = 3,
            ElectricCar = 4,
            Truck = 5,
        }

        public Dictionary<string, string> CreateVehicleDictionaryByType(eVehicleType i_VechileType)
        {
            Dictionary<string, string> vehicleDictionary = new Dictionary<string, string>();
            List<string> vehiclePropertiesList = new List<string>();

            switch (i_VechileType)
            {
                case eVehicleType.GasMotorcycle:
                    vehiclePropertiesList = GasEngine.GetGasProperties();
                    vehiclePropertiesList.AddRange(Motorcycle.GetMotorcycleProperties());
                    break;
                case eVehicleType.ElectricMotorcycle:
                    vehiclePropertiesList = ElectricalEngine.GetElectricalProperties();
                    vehiclePropertiesList.AddRange(Motorcycle.GetMotorcycleProperties());
                    break;
                case eVehicleType.GasCar:
                    vehiclePropertiesList = GasEngine.GetGasProperties();
                    vehiclePropertiesList.AddRange(Car.GetCarProperties());
                    break;
                case eVehicleType.ElectricCar:
                    vehiclePropertiesList = ElectricalEngine.GetElectricalProperties();
                    vehiclePropertiesList.AddRange(Car.GetCarProperties());
                    break;
                case eVehicleType.Truck:
                    vehiclePropertiesList = GasEngine.GetGasProperties();
                    vehiclePropertiesList.AddRange(Truck.GetTruckProperties());
                    break;
            }

            foreach (string key in vehiclePropertiesList)
            {
                vehicleDictionary.Add(key, string.Empty);
            }

            return vehicleDictionary;
        }

        private Motorcycle createNewFuelMotorcycle(Dictionary<string, string> i_VehicleDictionary)
        {
            i_VehicleDictionary.Add("Number of wheels:", "2");
            i_VehicleDictionary.Add("Maximal wheel air pressure:", "30");
            i_VehicleDictionary.Add("Gas type:", "Octan95");
            i_VehicleDictionary.Add("Maximal gas capacity:", "7");
            VehicleFieldsValidation.ValidMotorcycleFields(i_VehicleDictionary);
            VehicleFieldsValidation.ValidFuelEngineFields(i_VehicleDictionary);
            VehicleFieldsValidation.ValidWheelsFields(i_VehicleDictionary);
            GasEngine GasEngine = new GasEngine(i_VehicleDictionary);
            Motorcycle fueledMotorcycle = new Motorcycle(i_VehicleDictionary, GasEngine);

            return fueledMotorcycle;
        }

        private Motorcycle createNewElectricMotorcycle(Dictionary<string, string> i_VehicleDictionary)
        {
            i_VehicleDictionary.Add("Number of wheels:", "2");
            i_VehicleDictionary.Add("Maximal wheel air pressure:", "30");
            i_VehicleDictionary.Add("Maximal battery time in hours:", "1.2");
            VehicleFieldsValidation.ValidMotorcycleFields(i_VehicleDictionary);
            VehicleFieldsValidation.ValidEngine(i_VehicleDictionary["number of hours left in battery:"], i_VehicleDictionary["Maximal battery time in hours:"]);
            VehicleFieldsValidation.ValidWheelsFields(i_VehicleDictionary);
            ElectricalEngine electricEngine = new ElectricalEngine(i_VehicleDictionary);
            Motorcycle electricMotorcycle = new Motorcycle(i_VehicleDictionary, electricEngine);

            return electricMotorcycle;
        }

        private Car createNewGasCar(Dictionary<string, string> i_VehicleDictionary)
        {
            i_VehicleDictionary.Add("Number of wheels:", "4");
            i_VehicleDictionary.Add("Maximal wheel air pressure:", "32");
            i_VehicleDictionary.Add("Gas type:", "Octan96");
            i_VehicleDictionary.Add("Maximal gas capacity:", "60");
            VehicleFieldsValidation.ValidCarFields(i_VehicleDictionary);
            VehicleFieldsValidation.ValidFuelEngineFields(i_VehicleDictionary);
            VehicleFieldsValidation.ValidWheelsFields(i_VehicleDictionary);
            GasEngine fuelEngine = new GasEngine(i_VehicleDictionary);
            Car fueledCar = new Car(i_VehicleDictionary, fuelEngine);

            return fueledCar;
        }

        private Car createNewElectricCar(Dictionary<string, string> i_VehicleDictionary)
        {
            i_VehicleDictionary.Add("Number of wheels:", "4");
            i_VehicleDictionary.Add("Maximal wheel air pressure:", "32");
            i_VehicleDictionary.Add("Maximal battery time in hours:", "2.1");
            VehicleFieldsValidation.ValidCarFields(i_VehicleDictionary);
            VehicleFieldsValidation.ValidEngine(i_VehicleDictionary["number of hours left in battery:"], i_VehicleDictionary["Maximal battery time in hours:"]);
            VehicleFieldsValidation.ValidWheelsFields(i_VehicleDictionary);
            ElectricalEngine electricEngine = new ElectricalEngine(i_VehicleDictionary);
            Car electricCar = new Car(i_VehicleDictionary, electricEngine);

            return electricCar;
        }

        private Truck createNewTruck(Dictionary<string, string> i_VehicleDictionary)
        {
            i_VehicleDictionary.Add("Number of wheels:", "16");
            i_VehicleDictionary.Add("Maximal wheel air pressure:", "28");
            i_VehicleDictionary.Add("Gas type:", "Soler");
            i_VehicleDictionary.Add("Maximal gas capacity:", "120");
            VehicleFieldsValidation.ValidaTruckFields(i_VehicleDictionary);
            VehicleFieldsValidation.ValidFuelEngineFields(i_VehicleDictionary);
            VehicleFieldsValidation.ValidWheelsFields(i_VehicleDictionary);
            GasEngine gasEngine = new GasEngine(i_VehicleDictionary);
            Truck fueledTruck = new Truck(i_VehicleDictionary, gasEngine);

            return fueledTruck;
        }

        public Vehicle CreateNewVehicle(eVehicleType i_VechileType, Dictionary<string, string> i_VehicleDictionary)
        {
            Vehicle newVehicle = null;

            switch (i_VechileType)
            {
                case eVehicleType.GasMotorcycle:
                    newVehicle = this.createNewFuelMotorcycle(i_VehicleDictionary);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    newVehicle = this.createNewElectricMotorcycle(i_VehicleDictionary);
                    break;
                case eVehicleType.GasCar:
                    newVehicle = this.createNewGasCar(i_VehicleDictionary);
                    break;
                case eVehicleType.ElectricCar:
                    newVehicle = this.createNewElectricCar(i_VehicleDictionary);
                    break;
                case eVehicleType.Truck:
                    newVehicle = this.createNewTruck(i_VehicleDictionary);
                    break;
            }

            return newVehicle;
        }
    }
}