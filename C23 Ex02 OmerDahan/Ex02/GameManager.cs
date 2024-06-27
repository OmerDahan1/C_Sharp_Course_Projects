using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02
{
    internal class GameManager
    {
        private ComputerChoiceHandler m_ComputerChoice;
        private readonly int r_NumberOfCharsInResultString;

        public GameManager()
        {
            this.m_ComputerChoice = new ComputerChoiceHandler();
            r_NumberOfCharsInResultString = 4;
        }

        public ComputerChoiceHandler ComputerChoice
        {
            get
            {
                return this.m_ComputerChoice;
            }
        }

        public string ParseGuessToResult(string i_CurrentGuess)
        {
            StringBuilder parsedString = new StringBuilder(String.Empty);
            UserGuessHandler userGuess = new UserGuessHandler(i_CurrentGuess);

            if (userGuess.IsValidGuess)
            {
                for (int i = 0; i < userGuess.InputUserGuess.Length; i++)
                {
                    if (userGuess.InputUserGuess[i] == ' ')
                    {
                        continue;
                    }

                    bool guessedCorrectly = m_ComputerChoice.InputComputerChoice.Contains(userGuess.InputUserGuess[i]);
                    if (guessedCorrectly)
                    {
                        bool guessedExactly = m_ComputerChoice.InputComputerChoice.IndexOf(userGuess.InputUserGuess[i]) == i / 2;
                        if (guessedExactly)
                        {
                            parsedString.Append("V");
                        }
                        else
                        {
                            parsedString.Append("X");
                        }
                    }
                }    
            }

            string sortedParsedString = this.sortParsedString(parsedString);
            int numberOfSpacesToAdd = this.r_NumberOfCharsInResultString - sortedParsedString.Length;
            string paddedSortedParsedString = sortedParsedString.PadRight(numberOfSpacesToAdd + sortedParsedString.Length);
            string sortedParsedStringCharDividedBySpaces = addSpaces(paddedSortedParsedString);

            return sortedParsedStringCharDividedBySpaces;
        }

        private string addSpaces(string i_ParsedString)
        {
            List<char> charListOfParsedString = i_ParsedString.ToList();
            String ParsedStringWithSpaces = string.Join(" ", charListOfParsedString.ToArray());
            
            return ParsedStringWithSpaces;
        }

        private string sortParsedString(StringBuilder i_ParsedString)
        {
            List<char> charListOfParsedString = i_ParsedString.ToString().ToList();
            charListOfParsedString.Sort();
            string sortedParsedString = new string(charListOfParsedString.ToArray());
            
            return sortedParsedString;
        }
    }
}