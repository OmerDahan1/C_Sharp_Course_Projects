using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal static class VehicleFieldsValidation
    {
        public static void ValidEngine(string i_CurrentEnergyAmount, string i_MaxEnergyAmount)
        {
            float maxEnergyAmount = ParsingAndValidation.ValidAndParsePositiveFloat(i_MaxEnergyAmount);

            try
            {
                float currentEnergyAmount = ParsingAndValidation.ValidAndParsePositiveFloat(i_CurrentEnergyAmount);
                ParsingAndValidation.ValidRangeInput(currentEnergyAmount, maxEnergyAmount);
            }
            catch (Exception ecxeption)
            {
                throw new ArgumentException(ecxeption.Message);
            }
        }

        public static void ValidFuelEngineFields(Dictionary<string, string> i_GasEngineInfo)
        {
            ValidEngine(i_GasEngineInfo["Current amount of gas:"], i_GasEngineInfo["Maximal gas capacity:"]);
            ParsingAndValidation.EnumValidation<GasEngine.eGasType>(i_GasEngineInfo["Gas type:"], "Gas");
        }

        public static void ValidMotorcycleFields(Dictionary<string, string> i_MotorcycleInfo)
        {
            ParsingAndValidation.ValidLicenseNumber(i_MotorcycleInfo["License number:"]);
            ParsingAndValidation.EnumValidation<Motorcycle.eTypeOfLicense>(i_MotorcycleInfo["Motorcycle's type of license:"], "license only A/A1/AA/B");
            ParsingAndValidation.ValidAndParsePositiveIntCapacity(i_MotorcycleInfo["Motorcycle's engine capacity:"]);
        }

        public static void ValidCarFields(Dictionary<string, string> i_CarInfo)
        {
            ParsingAndValidation.ValidLicenseNumber(i_CarInfo["License number:"]);
            ParsingAndValidation.EnumValidation<Car.eColor>(i_CarInfo["Car's color:"], "Car's color only Red/White/Black/Silver");
            ParsingAndValidation.ValidNumberOfDoors(i_CarInfo["Car's number of doors:"]);
        }

        public static void ValidaTruckFields(Dictionary<string, string> i_TruckInfo)
        {
            ParsingAndValidation.ValidLicenseNumber(i_TruckInfo["License number:"]);
            ParsingAndValidation.ValidYesOrNoAnswer(i_TruckInfo["The truck is carrying dangerous materials:"]);
            ParsingAndValidation.ValidAndParsePositiveFloat(i_TruckInfo["Truck luggage capacity:"]);
        }

        public static void ValidWheelsFields(Dictionary<string, string> i_VehicleInfo)
        {
            float maximalAirPressure = ParsingAndValidation.ValidAndParsePositiveFloat(i_VehicleInfo["Maximal wheel air pressure:"]);

            try
            {
                float currentAirPressure = ParsingAndValidation.ValidAndParsePositiveFloat(i_VehicleInfo["Current wheel air pressure:"]);
                ParsingAndValidation.ValidRangeInput(currentAirPressure, maximalAirPressure);
            }
            catch (Exception ecxeption)
            {
                throw new ArgumentException("Impossible current wheel air pressure. " + ecxeption.Message);
            }
        }
    }
}
