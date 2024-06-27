using System;

namespace Ex01_01
{
    internal class program
    {
        public static void Main()
        {
            runBinarySeries();   
        }
        
        private static void runBinarySeries()
        {
            int numberOfZeroesInBinaryString = 0;
            int numberOfOnesInBinaryString = 0;
            int ammountOfNumbersThatPowersOf2 = 0;
            int numbersWithDigitsInStrictlyAscendingOrder = 0;
            int greatestNumber = 0;
            int smallestNumber = int.MaxValue;
            int numberOfValidBinaryStrings = 0;
            int numberOfInputsToAccept = 3;
            int[] decimalNumbers = new int[numberOfInputsToAccept];

            Console.WriteLine("Please enter 3 non-negative numbers here. Make sure that each one of them consists of exactly 7 binary digits: ");
            while (numberOfValidBinaryStrings < numberOfInputsToAccept)
            {
                string inputBinaryString = Console.ReadLine();
                if (checkIfInputIsValidBinaryString(inputBinaryString))
                {
                    numberOfZeroesInBinaryString += countZeroesInBinaryString(inputBinaryString);
                    numberOfOnesInBinaryString += countOnesInBinaryString(inputBinaryString);
                    int decimalNumber = convertBinaryStringToDecimalNumber(inputBinaryString);
                    if (checkIfDecimalNumberIsPowerOf2(decimalNumber))
                    {
                        ammountOfNumbersThatPowersOf2++;
                    }

                    if (checkIfNumberDigitsAreInStrictlyAscendingOrder(decimalNumber))
                    {
                        numbersWithDigitsInStrictlyAscendingOrder++;
                    }

                    greatestNumber = Math.Max(greatestNumber, decimalNumber);
                    smallestNumber = Math.Min(smallestNumber, decimalNumber);
                    decimalNumbers[numberOfValidBinaryStrings] = decimalNumber;
                    numberOfValidBinaryStrings++;
                }
                else
                {
                    Console.WriteLine("The input you provided is not a 7 digits binary string. Please type again: ");
                }
            }
            
            for (int i = 0; i < decimalNumbers.Length ; i++)
            {
                string decimalNumberString = string.Format("Input number {0} is: {1}", i + 1, decimalNumbers[i]);
                Console.WriteLine(decimalNumberString);
            }

            float averageNumberOfZeroesInBinaryStrings = numberOfZeroesInBinaryString / (float) numberOfInputsToAccept;
            float averageNumberOfOnesInBinaryStrings = numberOfOnesInBinaryString / (float) numberOfInputsToAccept;
            string averageNumberOfZeroesString = string.Format("Average count of zeroes in these binary strings is: {0}", averageNumberOfZeroesInBinaryStrings);
            Console.WriteLine(averageNumberOfZeroesString);
            string averageNumberOfOnesString = string.Format("Average count of ones in these binary strings is: {0}", averageNumberOfOnesInBinaryStrings);
            Console.WriteLine(averageNumberOfOnesString);
            string ammountOfPowersOf2String = string.Format("Amount of binary strings representing a power of 2 number is: {0}", ammountOfNumbersThatPowersOf2);
            Console.WriteLine(ammountOfPowersOf2String);
            string numberWithAscendingOrderDigitsString = string.Format("Amount of binary strings with strictly ascending digits order: {0}", numbersWithDigitsInStrictlyAscendingOrder);
            Console.WriteLine(numberWithAscendingOrderDigitsString);
            string greatestNumberString = string.Format("The greatest number is: {0}", greatestNumber);
            Console.WriteLine(greatestNumberString);
            string smallestNumberString = string.Format("The smallest number is: {0}", smallestNumber);
            Console.WriteLine(smallestNumberString);
        }

        private static bool checkIfInputIsValidBinaryString(string i_InputBinaryString)
        {
            bool inputIsValidBinaryString = true;

            if (i_InputBinaryString.Length != 7)
            {
                inputIsValidBinaryString = false;
            }
            else { 
                foreach (char c in i_InputBinaryString)
                {
                    if (c != '1' && c != '0')
                    {
                        inputIsValidBinaryString = false;
                    }
                }
            }

            return inputIsValidBinaryString;
        }

        private static int countZeroesInBinaryString(string i_InputBinaryString)
        {
            int zeroesCounterInBinaryString = 0;

            foreach (char c in i_InputBinaryString)
            {
                if (c == '0')
                {
                    zeroesCounterInBinaryString++;
                }
            }

            return zeroesCounterInBinaryString;
        }

        private static int countOnesInBinaryString(string i_InputBinaryString)
        {
            int zeroesCounterInBinaryString = 0;

            foreach (char c in i_InputBinaryString)
            {
                if (c == '1')
                {
                    zeroesCounterInBinaryString++;
                }
            }

            return zeroesCounterInBinaryString;
        }

        private static int convertBinaryStringToDecimalNumber(string i_InputBinaryString)
        {
            int decimalNumber = 0;

            foreach(char c in i_InputBinaryString)
            {
                decimalNumber *= 2;
                if (c == '1')
                {
                    decimalNumber++;
                }
            }

            return decimalNumber;
        }

        private static bool checkIfDecimalNumberIsPowerOf2(int i_DecimalNumber)
        {
            bool checkIfPowerOf2 = (i_DecimalNumber != 0) && ((i_DecimalNumber & (i_DecimalNumber -1)) == 0);

            return checkIfPowerOf2;
        }

        private static bool checkIfNumberDigitsAreInStrictlyAscendingOrder(int i_DecimalNumber)
        {
            bool digitsAreInStrictlyAscendingOrder = true;
            
            if (i_DecimalNumber == 0)
            {
                digitsAreInStrictlyAscendingOrder = false;
            }

            while (i_DecimalNumber > 0)
            {
                if (0 < i_DecimalNumber && i_DecimalNumber < 10)
                {
                    i_DecimalNumber = i_DecimalNumber / 10;
                }
                else
                {
                    int onesDigit = i_DecimalNumber % 10;
                    i_DecimalNumber = i_DecimalNumber / 10;
                    int tensDigit = i_DecimalNumber % 10;
                    if (onesDigit <= tensDigit)
                    {
                        digitsAreInStrictlyAscendingOrder = false;
                    }
                }
            }

                return digitsAreInStrictlyAscendingOrder;
        }
    }
}