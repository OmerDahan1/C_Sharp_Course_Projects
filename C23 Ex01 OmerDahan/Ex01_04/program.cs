using System;

namespace Ex01_04
{
    internal class program
    {
        public static void Main(string[] args)
        {
            analyzeString();
        }

        private static void analyzeString() 
        {
            Console.WriteLine("please enter a string of size 8: ");
            string inputString = Console.ReadLine();
            bool inputStringIsValid = checkIfInputIsValid(inputString);

            if (inputStringIsValid)
            {
                bool isPalindrome = checkIfStringIsPalindrome(inputString);
                if (isPalindrome)
                {
                    string palindrome = string.Format("The input string '{0}' is a palindrome.", inputString);
                    Console.WriteLine(palindrome);
                }
                else
                {
                    string notPalindrome = string.Format("The input string '{0}' is not a palindrome.", inputString);
                    Console.WriteLine(notPalindrome);
                }
                
                bool isNumber = checkIfStringIsNumber(inputString);
                if (isNumber)
                {
                    bool isDivisibleBy4_2 = checkIfStringNumberIsDivisibleBy4(inputString);
                    if (isDivisibleBy4_2)
                    {
                        string divisibleBy4_2 = string.Format("The input string '{0}' is a number divisible by 4.", inputString);
                        Console.WriteLine(divisibleBy4_2);
                    }
                    else
                    {
                        string notDivisibleBy4_2 = string.Format("The input string '{0}' is not a number divisible by 4.", inputString);
                        Console.WriteLine(notDivisibleBy4_2);
                    }
                }

                bool isContainsOnlyLetters = checkIfStringContainsOnlyLetters(inputString);
                if (isContainsOnlyLetters)
                {
                    int numberOfUpperCaseLetters = countNumberOfUpperCaseLettersInString(inputString);
                    string numberOfUpperCaseLettersInString = string.Format("The input string '{0}' contains {1} uppercase letters.", inputString, numberOfUpperCaseLetters);
                    Console.WriteLine(numberOfUpperCaseLettersInString);
                }
            }
        }

        private static bool checkIfStringIsPalindrome(string i_InputString)
        {
            bool isPalindrome = false;
            bool firstAndLastCharEquals = false;

            if (i_InputString.Length == 1 || i_InputString.Length == 0)
            {
                isPalindrome = true;
            }
            else if (i_InputString[0] == i_InputString[i_InputString.Length - 1])
            {
                firstAndLastCharEquals = true;
            }

            isPalindrome = isPalindrome || (firstAndLastCharEquals && checkIfStringIsPalindrome(i_InputString.Substring(1, i_InputString.Length - 2)));

            return isPalindrome;
        }

        private static bool checkIfStringIsNumber(string i_InputString)
        {
            bool isNumber = true;

            foreach (char c in i_InputString)
            {
                if (!char.IsDigit(c))
                {
                    isNumber = false;
                }
            } 

            return isNumber;
        }

        private static bool checkIfStringNumberIsDivisibleBy4(string i_InputString)
        {
            int.TryParse(i_InputString, out int parsedNumber);
            bool numberIsDivisibleBy4 = parsedNumber % 4 == 0;

            return numberIsDivisibleBy4;
        }

        private static bool checkIfStringIsNegativeNumber(string i_InputString)
        {
            bool isNegativeNumber = false;
            int.TryParse(i_InputString, out int parsedNumber);

            if(parsedNumber < 0)
            {
                isNegativeNumber = true;
            }

            return isNegativeNumber;
        }
        private static bool checkIfStringContainsOnlyLetters(string i_InputString)
        {
            bool containsOnlyLetters = true;

            foreach (char c in i_InputString)
            {
                if (!char.IsLetter(c))
                {
                    containsOnlyLetters = false;
                }
            }

            return containsOnlyLetters;
        }

        private static int countNumberOfUpperCaseLettersInString(string i_InputString)
        {
            int countUpperCaseLetters = 0;

            foreach (char c in i_InputString)
            {
                if (char.IsUpper(c))
                {
                    countUpperCaseLetters++;
                }
            }

            return countUpperCaseLetters;
        }

        private static bool checkIfInputIsValid(string i_InputString)
        {
            bool inputStringIsValid = true;
            bool inputStringLengthAsExpected = i_InputString.Length == 8;
            bool inputStringIsNumber = checkIfStringIsNumber(i_InputString);
            bool inputStringContainsOnlyLetters = checkIfStringContainsOnlyLetters(i_InputString);
            bool inputStringIsNegativeNumber = checkIfStringIsNegativeNumber(i_InputString);

            if (!inputStringLengthAsExpected)
            { 
                Console.WriteLine("Invalid input. The string you entered is not of the required length.");
                inputStringIsValid = false;
            }
            else if (inputStringIsNegativeNumber)
            {
                Console.WriteLine("Invalid input.The string you provided is a negative number.");
                inputStringIsValid = false;
            }
            else if (!inputStringIsNumber && !inputStringContainsOnlyLetters)
            {
                Console.WriteLine("Invalid input. The string you provided is not a valid number or not contain only letters.");
                inputStringIsValid = false;
            }
            
            return inputStringIsValid;
        }
    }
}