using System;

namespace Ex01_03
{
    internal class program
    {
        public static void Main(string[] args)
        {
            drawDynamicSandClock();
        }

        private static void drawDynamicSandClock()
        {
            checkIfInputIsValid();
        }

        private static void checkIfInputIsValid()
        {
            bool isValidNumber = false;
            int inputNumber = 0;

            Console.WriteLine("How many lines would you like for the star clock?");
            while (!isValidNumber)
            {
            string inputString = Console.ReadLine();
            isValidNumber = int.TryParse(inputString, out inputNumber);
                if (!isValidNumber)
                {
                    Console.WriteLine("Invalid Input. Please re-enter the number of lines you'd like for the star clock: ");
                }
                else if (inputNumber < 0)
                {
                    Console.WriteLine("The number you entered is negative. Please re-enter the number of lines you'd like for the star clock: ");
                    isValidNumber = false;
                }
                else if (inputNumber % 2 == 0)
                {
                    inputNumber++;
                    isValidNumber = true;
                }
            }

            Ex01_02.program.DrawSandClock(0, inputNumber);
        }
    }
}