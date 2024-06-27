using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal static class ParsingAndValidation
    {
        public static float ValidAndParsePositiveFloat(string i_StringForValidation)
        {
            float parsedFloat = 0;
            bool isFloat = float.TryParse(i_StringForValidation, out parsedFloat);

            if (!isFloat || parsedFloat < 0)
            {
                throw new FormatException("Invalid answer- only a positive number is allowed");
            }

            return parsedFloat;
        }

        public static void ValidAndParsePositiveIntCapacity(string i_StringForValidation)
        {
            int parsedInt = 0;
            bool isInt = int.TryParse(i_StringForValidation, out parsedInt);

            if (!isInt || parsedInt < 0)
            {
                throw new FormatException("Invalid motorcycle engine capacity- only a positive integer is allowed");
            }
        }

        public static void ValidRangeInput(float i_CurrentValue, float i_MaxAllowedValue)
        {
            bool isInRange = i_CurrentValue <= i_MaxAllowedValue;

            if (!isInRange)
            {
                throw new ValueOutOfRangeException(0, i_MaxAllowedValue, "amount of energy");
            }
        }

        public static T ValidAndParseEnum<T>(string i_UserInput, string i_EnumValue)
        {
            T inputAsEnum = default(T);
            bool isValid = false;

            foreach (string name in Enum.GetNames(typeof(T)))
            {
                if (name.Equals(i_UserInput, StringComparison.CurrentCultureIgnoreCase))
                {
                    inputAsEnum = (T)Enum.Parse(typeof(T), i_UserInput, true);
                    isValid = true;
                    break;
                }
            }

            if (!isValid)
            {
                throw new ArgumentException("unfortunately this garage does not repair this type of " + i_EnumValue);
            }

            return inputAsEnum;
        }

        public static void EnumValidation<T>(string i_UserResponse, string i_EnumName)
        {
            ValidAndParseEnum<T>(i_UserResponse, i_EnumName);
        }

        public static void ValidYesOrNoAnswer(string i_Answer)
        {
            if (!(i_Answer.ToLower() == "yes" || i_Answer.ToLower() == "no"))
            {
                throw new ArgumentException("Invalid answer, is the Truck carrying dangerous materials? yes/no");
            }
        }

        public static void ValidLicenseNumber(string i_LicenseNumber)
        {
            bool isValidLicenseNumber = true;

            foreach (char digit in i_LicenseNumber)
            {
                if (!char.IsDigit(digit))
                {
                    isValidLicenseNumber = false;
                    break;
                }
            }

            if (!isValidLicenseNumber || i_LicenseNumber.Length != 8)
            {
                throw new ArgumentException("Invalid license number, the number should be 8 digits only");
            }
        }

        public static void ValidNumberOfDoors(string i_UserAnswer)
        {
            i_UserAnswer.Replace(" ", string.Empty);
            if (!(i_UserAnswer.Equals("2") || i_UserAnswer.Equals("3") || i_UserAnswer.Equals("4") || i_UserAnswer.Equals("5")))
            {
                throw new ArgumentException("unfortunately this garage does not handle with this amount of doors, 2 - 5 only");
            }
        }
    }
}
