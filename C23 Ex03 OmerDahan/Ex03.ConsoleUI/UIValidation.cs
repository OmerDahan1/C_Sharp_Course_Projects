using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal static class UIValidation
    {
        public static void GetValidChoiceNumberInRange(int i_LowerBoundOfChoice, int i_UpperBoundOfChoice, out int o_ChoiceNumber)
        {
            string chosenService = Console.ReadLine();
            bool isValidNumber = int.TryParse(chosenService, out o_ChoiceNumber);

            while (!isValidNumber || o_ChoiceNumber < i_LowerBoundOfChoice || o_ChoiceNumber > i_UpperBoundOfChoice)
            {
                Console.WriteLine("invalid choice. please choose a number between {0} to {1} from the options above", i_LowerBoundOfChoice, i_UpperBoundOfChoice);
                chosenService = Console.ReadLine();
                isValidNumber = int.TryParse(chosenService, out o_ChoiceNumber);
            }
        }

        private static bool strIsOnlyDigits(string i_UserAnswer)
        {
            bool isNumeric = true;

            foreach (char c in i_UserAnswer)
            {
                if (!char.IsDigit(c))
                {
                    isNumeric = false;
                    break;
                }
            }

            return isNumeric;
        }

        public static void GetAndValidNumberSequence(out string o_PhoneNumber, int i_Length)
        {
            o_PhoneNumber = Console.ReadLine();
            bool isOnlyDigits = strIsOnlyDigits(o_PhoneNumber);

            while (!isOnlyDigits || o_PhoneNumber.Length != i_Length)
            {
                Console.WriteLine("invalid number. please enter {0} digits only:", i_Length);
                o_PhoneNumber = Console.ReadLine();
                isOnlyDigits = strIsOnlyDigits(o_PhoneNumber);
            }
        }

        public static void GetAndValidNameFormat(out string o_FullName)
        {
            o_FullName = Console.ReadLine();
            bool isValidName = isLegalName(o_FullName);

            while (!isValidName)
            {
                Console.WriteLine("please enter a valid name");
                o_FullName = Console.ReadLine();
                isValidName = isLegalName(o_FullName);
            }
        }

        private static bool isLegalName(string i_CustomerResponse)
        {
            int countNonSpaceChars = 0;
            bool isLegalName = true;

            foreach (char c in i_CustomerResponse)
            {
                if (!(char.IsLetter(c) || c == ' '))
                {
                    isLegalName = false;
                    break;
                }

                if (c != ' ')
                {
                    countNonSpaceChars += 1;
                }
            }

            return isLegalName && countNonSpaceChars > 0;
        }
    }
}
