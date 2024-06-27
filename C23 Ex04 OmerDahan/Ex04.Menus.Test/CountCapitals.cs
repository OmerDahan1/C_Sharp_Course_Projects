using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    internal class CountCapitals : IMenuAction
    {
        public void PreformAction()
        {
            int numberOfCapitalLetters = 0;

            Console.WriteLine("Please enter your sentence:");
            string inputSentence = Console.ReadLine();
            foreach (char c in inputSentence) 
            {
                if (char.IsUpper(c))
                {
                    numberOfCapitalLetters++;
                }
            }

            Console.WriteLine("There are {0} capitals in your sentence.", numberOfCapitalLetters);
        }
    }
}
