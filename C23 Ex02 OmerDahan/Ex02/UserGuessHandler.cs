using System;
using System.Linq;
using System.Text;

namespace Ex02
{
    internal class UserGuessHandler
    {
        private string m_InputUserGuess;
        private bool m_IsValidGuess;
        
        public UserGuessHandler(string i_UserGuess) 
        {
            this.m_InputUserGuess = i_UserGuess;
            m_IsValidGuess = checkIfUserGuessIsValid(this.m_InputUserGuess);
        }
        
        public string InputUserGuess
        {
            get
            {
                return this.m_InputUserGuess;
            }
        }

        public bool IsValidGuess
        {
            get
            {
                return this.m_IsValidGuess;
            }
        }

        public bool ValidateUserGuessLength(string i_UserGuess)
        {
            bool isValidLength = i_UserGuess.Length == 7;

            return isValidLength;
        }

        public bool VerifyUserGuessContainsEnglishCharsAndSpaces(string i_UserGuess)
        {
            bool isValidEnglishChars = true;

            foreach (char c in i_UserGuess)
            {
                if (!char.IsLetter(c) && !(c == ' '))
                {
                    isValidEnglishChars = false;
                    break;
                }
            }

            return isValidEnglishChars;
        }

        public bool CheckUserGuessForValidCharRange(string i_UserGuess)
        {
            bool userGuessIsInRange = true;
            
            foreach (char c in i_UserGuess)
            {
                if (i_UserGuess.IndexOf(c) % 2 == 0)
                {
                    bool computerChoiceCharIsValid = Enum.IsDefined(typeof(eGuessChar), c.ToString());
                    if (!computerChoiceCharIsValid)
                    {
                        userGuessIsInRange = false;
                        break;
                    }
                }
                else
                {
                    if (c != ' ')
                    {
                        userGuessIsInRange = false;
                    }
                }
            }

            return userGuessIsInRange;
        }

        private bool CheckForDuplicateEnglishLettersInUserGuess(string i_UserGuess)
        {
            string userGuessWithoutSpaces = this.removeSpaces(i_UserGuess);
            bool userGuessHasDuplicateLetters = false;
            
            if (userGuessWithoutSpaces.Distinct().Count() < 4)
            {
                userGuessHasDuplicateLetters = true;
            }

            return userGuessHasDuplicateLetters;
        }

        private string removeSpaces(string i_UserGuess)
        {
            StringBuilder userGuessWithoutSpaces = new StringBuilder(String.Empty);
            
            foreach (char c in i_UserGuess)
            {
                if (c != ' ')
                {
                    userGuessWithoutSpaces.Append(c);
                }
            }

            return userGuessWithoutSpaces.ToString();
        }

        private bool checkIfUserGuessIsValid(string i_UserGuess)
        {
            bool userGuessIsValid = this.ValidateUserGuessLength(i_UserGuess);

            if (userGuessIsValid)
            {
                userGuessIsValid = this.CheckUserGuessForValidCharRange(i_UserGuess);
            }
            if (userGuessIsValid)
            {
                userGuessIsValid = !this.CheckForDuplicateEnglishLettersInUserGuess(i_UserGuess);
            }

            return userGuessIsValid;
        }
    }
}