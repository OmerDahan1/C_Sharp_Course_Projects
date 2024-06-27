using System;
using System.Linq;
using System.Text;

namespace Ex02
{
    internal class ComputerChoiceHandler
    {
        private string m_InputComputerChoice; 
        private string m_ComputerChoiceDisplay;
        private readonly int r_NumberOfCharsToSelectForComputerChoice;
        private bool m_ComputerChoiceIsRevealed;

       public ComputerChoiceHandler() 
        {
            this.m_ComputerChoiceIsRevealed = false;
            this.r_NumberOfCharsToSelectForComputerChoice = 4;
            this.m_InputComputerChoice = selectComputerChoiceRandomly();
            this.m_ComputerChoiceDisplay = this.getComputerChoiceDisplay(this.m_InputComputerChoice);
        }

        public string InputComputerChoice
        {
            get 
            { 
                return this.m_InputComputerChoice;
            }
        }

        public string ComputerChoiceDisplay
        {
            get 
            { 
                return this.m_ComputerChoiceDisplay;
            }
        }

        public void RevealAnswer()
        {
            this.m_ComputerChoiceIsRevealed = true;
            this.m_ComputerChoiceDisplay = this.getComputerChoiceDisplay(InputComputerChoice);
        }

        private string getComputerChoiceDisplay(string i_ComputerChoice)
        {
            bool computerChoiceIsValid = this.checkIfComputerChoiceIsValid(i_ComputerChoice);
            StringBuilder computerChoiceAsHashMarksSB = new StringBuilder(" ");

            if (computerChoiceIsValid && !m_ComputerChoiceIsRevealed)
            {
                foreach (char c in i_ComputerChoice)
                {
                    computerChoiceAsHashMarksSB.Append("# ");
                }
            }
            else if (m_ComputerChoiceIsRevealed)
            {
                foreach (char c in i_ComputerChoice)
                {
                    computerChoiceAsHashMarksSB.Append(c);
                    computerChoiceAsHashMarksSB.Append(' ');
                }
            }

            string computerChoiceAsHashMarks = computerChoiceAsHashMarksSB.ToString();
            
            return computerChoiceAsHashMarks;
        }

        private bool checkIfComputerChoiceIsValid(string i_ComputerChoice)
        {
            bool computerChoiceIsValid = i_ComputerChoice.Length == 4;
            
            if (computerChoiceIsValid) 
            {
                foreach (char c in i_ComputerChoice) 
                {
                    bool computerChoiceCharIsValid = Enum.IsDefined(typeof(eGuessChar), c.ToString());
                    if (!computerChoiceCharIsValid)
                    {
                        computerChoiceIsValid = false;  
                    }
                }
            }

            return computerChoiceIsValid;
        }

        private string selectComputerChoiceRandomly()
        {
            StringBuilder computerChoice = new StringBuilder(String.Empty);
            Random random = new Random();
            
            while (computerChoice.Length < r_NumberOfCharsToSelectForComputerChoice) 
            {
                char charToPickForComputerChoice = (char)random.Next('A', 'H' + 1);
                if (!computerChoice.ToString().Contains(charToPickForComputerChoice)) 
                {
                    computerChoice.Append(charToPickForComputerChoice);
                }
            }
            
            return computerChoice.ToString();
        }
    }
}