using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal class UserInterface
    {
        private readonly GarageLogic.Garage r_Garage;
        private bool m_IsWorkingGarage;

        public UserInterface()
        {
            this.m_IsWorkingGarage = true;
            this.r_Garage = new GarageLogic.Garage();
        }

        public void GarageLoop()
        {
            while (this.m_IsWorkingGarage)
            {
                Console.WriteLine("Welcome to the garage! which service do you need?");
                foreach (KeyValuePair<int, string> service in this.r_Garage.GarageServices)
                {
                    Console.WriteLine("If you want to {0} insert: {1}", service.Value, service.Key);
                }

                int chosenService;
                UIValidation.GetValidChoiceNumberInRange(1, this.r_Garage.GarageServices.Count, out chosenService);
                this.performService(chosenService);
                Console.WriteLine();
                Console.Clear();
            }
        }

        private void performService(int i_ChosenService)
        {
            switch (i_ChosenService)
            {
                case 1:
                    this.addNewVehicleToGarage();
                    break;
                case 2:
                    this.displayLicneseNumberListOfAllCarsInGarage();
                    break;
                case 3:
                    this.changingVeichleStatus();
                    break;
                case 4:
                    this.inflateWheelsToMaxAirPressureInVehicle();
                    break;
                case 5:
                    this.addGas();
                    break;
                case 6:
                    this.chargeElectricCar();
                    break;
                case 7:
                    this.displayAllReleventDataOfGivenVehicle();
                    break;
                case 8:
                    this.m_IsWorkingGarage = false;
                    Console.WriteLine("Thank you, bye bye");
                    Environment.Exit(0);
                    break;
            }
        }

        private void addNewVehicleToGarage()
        {
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.WriteLine("Please Enter your full Name:");
                string clientFullName;
                UIValidation.GetAndValidNameFormat(out clientFullName);
                Console.WriteLine("Please Enter your phone Number:");
                string clientPhoneNumber;
                UIValidation.GetAndValidNumberSequence(out clientPhoneNumber, 10);
                Console.WriteLine("What is the type of your vehicle?");
                Console.WriteLine(@"For gas motorcycle insert: 1
For electric motorcycle insert: 2
For gas car insert: 3
For electric car insert: 4
For truck insert: 5");

                int choiceNumber = 0;
                isValidInput = true;
                try
                {
                    int numOfVehiclesTypesGarageHandles = Enum.GetNames(typeof(GarageLogic.VehicleCreator.eVehicleType)).Length;
                    UIValidation.GetValidChoiceNumberInRange(1, numOfVehiclesTypesGarageHandles, out choiceNumber);
                    GarageLogic.VehicleCreator.eVehicleType vehicleType = (GarageLogic.VehicleCreator.eVehicleType)choiceNumber;
                    GarageLogic.VehicleCreator vehicleCreator = new GarageLogic.VehicleCreator();
                    Dictionary<string, string> vehicleDictionary = vehicleCreator.CreateVehicleDictionaryByType(vehicleType);
                    this.updateDictionary(vehicleDictionary);
                    GarageLogic.Vehicle clientVehicle = vehicleCreator.CreateNewVehicle(vehicleType, vehicleDictionary);
                    bool isAlreadyInGarage = this.r_Garage.AddNewVehicle(clientVehicle, clientFullName, clientPhoneNumber);
                    if (!isAlreadyInGarage)
                    {
                        Console.WriteLine("Your vehicle has been added to the garage!");
                    }
                    else
                    {
                        Console.WriteLine("Your vehicle already exists in this garage, current status to: In Repair");
                    }
                }
                catch (FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                    isValidInput = false;
                }
                catch (GarageLogic.ValueOutOfRangeException exception)
                {
                    Console.WriteLine(exception.Message);
                    isValidInput = false;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                    isValidInput = false;
                }

                Console.ReadLine();
                Console.Clear();
            }
        }

        private void displayLicneseNumberListOfAllCarsInGarage()
        {
            Console.WriteLine("Would you like to see a specific status of cars? choose from options below:");
            Console.WriteLine(@"For in repair vehicles: insert 1
For repaired and unpaid: insert 2
For repaired and paid: insert 3
For all vehicles: insert 4");
            try
            {
                int userAnswer;
                List<string> licenseNumbertoDisplay = new List<string>();
                UIValidation.GetValidChoiceNumberInRange(1, 4, out userAnswer);
                if (userAnswer == 4)
                {
                    for (int i = 1; i < 4; i++)
                    {
                        licenseNumbertoDisplay.AddRange(this.r_Garage.GetLicenseNumberByStatusList(i));
                    }
                }
                else
                {
                    licenseNumbertoDisplay = this.r_Garage.GetLicenseNumberByStatusList(userAnswer);
                }

                if (licenseNumbertoDisplay.Count == 0 && userAnswer == 4)
                {
                    Console.WriteLine("No vehicles in the garage at the moment!");
                }
                else if (licenseNumbertoDisplay.Count == 0)
                {
                    Console.WriteLine("No vehicles with this status in the garage at the moment!");
                }
                else
                {
                    licenseNumbertoDisplay.ForEach(Console.WriteLine);
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.ReadLine();
        }

        private void changingVeichleStatus()
        {
            string customerLicenceNumber = this.getClientLicense();

            Console.WriteLine("Enter your desired status to update. choose from options below:");
            Console.WriteLine(@"For in repair vehicles: insert 1
For repaired and unpaid: insert 2
For repaired and paid: insert 3");
            try
            {
                int userAnswer;
                UIValidation.GetValidChoiceNumberInRange(1, 3, out userAnswer);
                this.r_Garage.ChangeVehicleStatus(customerLicenceNumber, userAnswer.ToString());
                Console.WriteLine(@"Status updated as your request!");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.ReadLine();
        }

        private void inflateWheelsToMaxAirPressureInVehicle()
        {
            string clientLicenceNumber = this.getClientLicense();

            try
            {
                this.r_Garage.InflateWheelsToMaxCapacity(clientLicenceNumber);
                Console.WriteLine("All wheels inflated to max pressure!");
            }
            catch (GarageLogic.ValueOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.ReadLine();
        }

        private void addGas()
        {
            string customerLicenceNumber = this.getClientLicense();
            Console.WriteLine("Which type of gas do you want? choose from options below:");
            Console.WriteLine(@"For soler: insert 1
For octan95: insert 2
For octan96: insert 3
For octan98: insert 4");
            try
            {
                int userAnswer;
                UIValidation.GetValidChoiceNumberInRange(1, 4, out userAnswer);
                Console.WriteLine("How much gas do you want to fill?");
                string amountOfFuel = Console.ReadLine();
                this.r_Garage.FillGas(customerLicenceNumber, userAnswer.ToString(), amountOfFuel);
                Console.WriteLine("Gas added successfully!");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (GarageLogic.ValueOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.ReadLine();
        }

        private void chargeElectricCar()
        {
            string customerLicenceNumber = this.getClientLicense();
            Console.WriteLine("Please enter number of hours you'd like to charge:");
            string minutesToCharge = Console.ReadLine();

            try
            {
                this.r_Garage.Recharge(customerLicenceNumber, minutesToCharge);
                Console.WriteLine("Recharged successfully!");
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.ReadLine();
        }

        private void displayAllReleventDataOfGivenVehicle()
        {
            string customerLicenceNumber = this.getClientLicense();

            try
            {
                Console.WriteLine(this.r_Garage.DisplayFullVehicleDetails(customerLicenceNumber));
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.ReadLine();
        }

        private void updateDictionary(Dictionary<string, string> io_VehicleDictionary)
        {
            foreach (string key in io_VehicleDictionary.Keys.ToList())
            {
                Console.WriteLine(string.Format("Please enter {0}", key));
                io_VehicleDictionary[key] = Console.ReadLine();
            }
        }

        private string getClientLicense()
        {
            Console.WriteLine("Please enter your license number, 8 digits:");
            string clientLicense;
            UIValidation.GetAndValidNumberSequence(out clientLicense, 8);

            return clientLicense;
        }
    }
}
