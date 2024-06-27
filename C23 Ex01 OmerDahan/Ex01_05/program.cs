using System;

namespace Ex01_05
{
    internal class program
    {
        public static void Main(string[] args)
        {
            analyzeNumberStatistics();
        }

        private static void analyzeNumberStatistics()
        {
            Console.WriteLine("Please enter your number here. Make sure that the number is composed of 6 digits: ");
            bool isValid = false;
            int parsedNumber = 0;

            while (!isValid)
            {
                string inputString = Console.ReadLine();
                isValid = checkIfInputIsValid(inputString);
                int.TryParse(inputString, out parsedNumber);
            }

            printNumberOfDigitsGreaterThanOnes(parsedNumber);
            printSmallestDigitInNumber(parsedNumber);
            printNumberOfDigitsDivisibleBy3(parsedNumber);
            printAverageOfDigits(parsedNumber);
        }
        
        private static bool checkIfInputIsValid(string i_InputString)
        {
            bool isValid = false;
            bool isValidNumber = int.TryParse(i_InputString, out int parsedNumber);
            bool isValidLength = i_InputString.Length == 6;

            if (isValidNumber && isValidLength)
            {
            bool isNegative = parsedNumber < 0;
            if (isNegative)
            {
                Console.WriteLine("The input you provided is a negative number. Please type another input here: ");
            }
            else
            {
                isValid = true;
            }
            }
            else
            {
                Console.WriteLine("The input you provided is not a 6-digit integer. Please type another input here: ");
            }
                
            return isValid;
        }

        private static void printNumberOfDigitsGreaterThanOnes(int i_ParsedNumber)
        {
            int countDigits = 0;
            int onesDigit = i_ParsedNumber % 10;

            while (i_ParsedNumber > 0)
            {
                i_ParsedNumber = i_ParsedNumber / 10;
                int otherDigit = i_ParsedNumber % 10;
                if (otherDigit > onesDigit)
                {
                    countDigits++;
                }
            }

            string numberOfDigitsGreaterThanTheOnes = string.Format("Amount of digits greater than the ones: {0}", countDigits);
            Console.WriteLine(numberOfDigitsGreaterThanTheOnes);
        }

        private static void printSmallestDigitInNumber(int i_ParsedNumber) 
        {
            int smallestDigit = i_ParsedNumber % 10;
            bool haveLeadingZeroes = i_ParsedNumber < 100000;

            if (haveLeadingZeroes)
            {
                smallestDigit = 0;
            }

            i_ParsedNumber = i_ParsedNumber / 10;
            while (i_ParsedNumber > 0) 
            {
                int nextDigit = i_ParsedNumber % 10;
                smallestDigit = Math.Min(smallestDigit, nextDigit);
                i_ParsedNumber = i_ParsedNumber / 10;
            }

            string smallestDigitInNumber = string.Format("Smallest digit in the number: {0}", smallestDigit);
            Console.WriteLine(smallestDigitInNumber);
        }

        private static void printNumberOfDigitsDivisibleBy3(int i_ParsedNumber)
        {
            int onesDigit = i_ParsedNumber % 10;
            int counterOfDigitsDivisibleBy3 = 0;

            while(i_ParsedNumber > 0)
            {
                if (onesDigit % 3 == 0)
                {
                    counterOfDigitsDivisibleBy3++;
                }

                i_ParsedNumber = i_ParsedNumber / 10;
                onesDigit = i_ParsedNumber % 10;
            }

            string numberOfDigitsDivisibleBy3 = string.Format("Amount of digits divisible by 3: {0}", counterOfDigitsDivisibleBy3);
            Console.WriteLine(numberOfDigitsDivisibleBy3);
        }

        private static void printAverageOfDigits(int i_ParsedNumber)
        {
            int counterOfDigits = 0;
            int numberOfDigits = 6;

            while (i_ParsedNumber > 0)
            {
                counterOfDigits += i_ParsedNumber % 10;
                i_ParsedNumber = i_ParsedNumber / 10;
            }

            float averageOfDigits = counterOfDigits / (float) numberOfDigits;
            string averageOfDigitsInNumber = string.Format("Average of digits in number: {0}", averageOfDigits);
            Console.WriteLine(averageOfDigitsInNumber);
        }
    }
}