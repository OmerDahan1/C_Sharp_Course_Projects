using System;
using System.Text;
using Ex02.ConsoleUtils;

namespace Ex02
{
    internal class GameUI
    {
        private Board m_Board;
        private GameManager m_Logic;
        private bool m_IsPlaying = false;
    
        public void RunGame()
        {
            bool validNumberOfGuesses = false;
            Console.WriteLine("Please provide the number of guesses you would like to make. Your choice should be a number between 4 and 10.");
            string numberOfGuesses = string.Empty;
            int numberOfGuessesValue = 0;

            while (!validNumberOfGuesses && !this.m_IsPlaying)
            {
                numberOfGuesses = Console.ReadLine();
                bool validNumber = int.TryParse(numberOfGuesses, out numberOfGuessesValue);
                validNumberOfGuesses = Enum.IsDefined(typeof(eNumberOfGuesses), numberOfGuessesValue);
                if (validNumber && validNumberOfGuesses)
                {
                    m_IsPlaying = true;
                    Screen.Clear();
                }
                else if (validNumber)
                {
                    Screen.Clear();
                    Console.WriteLine("The provided number is not within the specified range. Please enter a valid number between 4 and 10: ");
                }
                else
                {
                    Screen.Clear();
                    Console.WriteLine("The provided input is not recognized as a number. Please enter a valid number between 4 and 10: ");
                }
            }

            this.m_Board = new Board(numberOfGuesses); 
            this.m_Logic = new GameManager();
            int guessIndex = 0;
            this.printBoardGuessesAndResults();
            Console.WriteLine("Please type your next guess <A B C D> or 'Q' to quit.");
            while (m_IsPlaying)
            {
                string inputGuess = Console.ReadLine();
                UserGuessHandler userGuess = new UserGuessHandler(inputGuess);

                if (userGuess.InputUserGuess == "Q")
                {
                    this.quitGame();
                }
                else if (!userGuess.IsValidGuess)
                {
                    Screen.Clear();
                    this.printBoardGuessesAndResults();

                    if (!userGuess.ValidateUserGuessLength(userGuess.InputUserGuess))
                    {
                        string invalidLength = string.Format("The input you've provided should have a length of 7 characters, including both spaces and English letters, or the letter 'Q'.{0}Please type your next guess <A B C D> or 'Q' to quit.", Environment.NewLine);
                        Console.WriteLine(invalidLength);
                    }
                    else if (!userGuess.VerifyUserGuessContainsEnglishCharsAndSpaces(userGuess.InputUserGuess))
                    {
                        string containsOnlySpacesAndEnglishChars = string.Format("The input you provided doesn't meet the requirement of only containing spaces and English characters.{0}Please type your next guess <A B C D> or 'Q' to quit.", Environment.NewLine);
                        Console.WriteLine(containsOnlySpacesAndEnglishChars);
                    }
                    else if (!userGuess.CheckUserGuessForValidCharRange(userGuess.InputUserGuess))
                    {
                        string invalidRange = string.Format("The provided input should exclusively consist of characters in the specified 'A' to 'H' range (uppercase only), with spaces between each letter.{0}Please type your next guess <A B C D> or 'Q' to quit.", Environment.NewLine);
                        Console.WriteLine(invalidRange);
                    }
                    else
                    {
                        string containDuplicatesEnglishLetters = string.Format("The provided input should not contain any repeated letters.{0}Please type your next guess <A B C D> or 'Q' to quit.", Environment.NewLine);
                        Console.WriteLine(containDuplicatesEnglishLetters);
                    }
                }
                else
                {
                    string parsedToResult = m_Logic.ParseGuessToResult(inputGuess);
                    Screen.Clear();
                    m_Board.UpdateBoardguesses(inputGuess, parsedToResult, guessIndex);
                    guessIndex++;
                    if (guessIndex == numberOfGuessesValue)
                    {
                        m_Logic.ComputerChoice.RevealAnswer();
                    }   
                    
                    Screen.Clear();
                    this.printBoardGuessesAndResults();

                    if (parsedToResult == "V V V V")
                    {
                        this.createWinGameMessage(guessIndex);
                        this.askUserForContinuation();
                    }
                    else if (guessIndex == numberOfGuessesValue)
                    {
                        Console.WriteLine("No more guesses allowed. You Lost.");
                        this.askUserForContinuation();
                    }
                    else
                    {
                        Console.WriteLine("Please type your next guess <A B C D> or 'Q' to quit.");
                    }
                }
            }
        }

        private void printBoardGuessesAndResults()
        {
            string dividerBetweenLines = "|=========|=======|";

            Console.WriteLine("Current board status:");
            string firstLine = string.Format("{0}|Pins:    |Result:|", Environment.NewLine);
            Console.WriteLine(firstLine);
            Console.WriteLine(dividerBetweenLines);
            string computerGuessLine = string.Format("|{0}|       |", m_Logic.ComputerChoice.ComputerChoiceDisplay);
            Console.WriteLine(computerGuessLine);
            Console.WriteLine(dividerBetweenLines);
            for (int i = 0; i < this.m_Board.BoardSize; i++)
            {
                StringBuilder printGuess = new StringBuilder("| ");
                for (int j = 0; j < m_Board.NumberOfCharsInRow; j++)
                {
                    if (m_Board.BoardGuesses[i, j] == eGuessChar.None)
                    {
                        printGuess.Append(' ');
                    }
                    else
                    {
                        printGuess.Append((char)m_Board.BoardGuesses[i, j]); 
                    }

                    printGuess.Append(' ');
                }

                printGuess.Append("|");
                StringBuilder printResult = new StringBuilder(String.Empty);
                for (int j = 0; j < m_Board.NumberOfCharsInRow; j++)
                {
                    bool isNotInTheLastChar = j != m_Board.NumberOfCharsInRow - 1;
                    if (isNotInTheLastChar)
                    {
                        if (m_Board.BoardResults[i, j] == eResults.None)
                        {
                            printResult.Append(' ');
                        }
                        else
                        {
                            printResult.Append((char)m_Board.BoardResults[i, j]);
                        }

                        printResult.Append(' ');
                    }
                    else
                    {
                        if (m_Board.BoardResults[i, j] == eResults.None)
                        {
                            printResult.Append(' ');
                        }
                        else
                        {
                            printResult.Append((char)m_Board.BoardResults[i, j]);
                        }
                    }
                }

                printResult.Append("|");
                printGuess.Append(printResult.ToString());
                Console.WriteLine(printGuess.ToString());
                Console.WriteLine(dividerBetweenLines);
            }
        }
      
        private void askUserForContinuation()
        {
            bool userAnswerIsValid = false;
            
            Console.WriteLine("Would you like to start a new game? Y/N.");
            while (!userAnswerIsValid)
            {
                string userAnswer = Console.ReadLine();
                if (userAnswer == "N")
                {
                    userAnswerIsValid = true;
                    this.quitGame();
                }
                else
                {
                    Screen.Clear();
                    if (userAnswer == "Y")
                    {
                        userAnswerIsValid = true;
                        m_IsPlaying = false;
                        this.RunGame();
                    }
                    else
                    {
                        this.printBoardGuessesAndResults();
                        string invalidAnswer = string.Format("The answer you provided is invalid. Please provide a Y/N answer.", Environment.NewLine);
                        Console.WriteLine(invalidAnswer);
                    }
                }
            }
        }

        private void createWinGameMessage(int i_NumberOfGuesses)
        {
            string winningMessage = string.Format("You guessed after {0} steps!", i_NumberOfGuesses);

            Console.WriteLine(winningMessage);
        }

        private void quitGame()
        {
                m_IsPlaying = false;
                Screen.Clear();
                string quitGame = string.Format(@"Thank you for playing with us ""Bulls and Cows"".");
                Console.WriteLine(quitGame);
        }
    }
}