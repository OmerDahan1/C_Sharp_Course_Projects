using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Ex05
{
    public class GameManager
    {
        private int m_CurrentNumberOfGuesses;
        private int m_NumberOfGuesses;
        private List<Color> m_CurrentUserGuess;
        private int m_NumberOfColorsToGuess;
        private ComputerChoiceHandler m_ComputerChoiceHandler;
        private List<UserGuessHandler> m_UserGuesses;
        private GuessingGameForm m_GameForm;

        public GameManager()
        {
            initializeGame();
        }

        private void initializeGame()
        {
            this.getNumberOfGuesses(4, 10);
            this.m_NumberOfColorsToGuess = 4;
            this.m_GameForm = new GuessingGameForm(this.m_NumberOfGuesses, this.m_NumberOfColorsToGuess);
            this.m_ComputerChoiceHandler = new ComputerChoiceHandler(m_NumberOfColorsToGuess);
            this.m_UserGuesses = new List<UserGuessHandler>(m_NumberOfGuesses);
            this.m_CurrentNumberOfGuesses = 0;
        }

        public void Play()
        {
            if (this.m_NumberOfGuesses > 0)
            {
                this.m_GameForm.UserGuessed += m_GameForm_UserGuessed;
                this.m_GameForm.ShowDialog();
            }
        }

        private void getNumberOfGuesses(int i_MinimalNumberOfGuesses, int i_MaximalNumberOfGuesses)
        {
            GuessCounterForm guessCounterWindow = new GuessCounterForm(i_MinimalNumberOfGuesses, i_MaximalNumberOfGuesses);

            if (guessCounterWindow.ShowDialog() == DialogResult.OK)
            {
                this.m_NumberOfGuesses = guessCounterWindow.CurrentNumberOfGuesses;
            }
        }

        private bool areColorsInGuessDuplicated(List<Color> i_UserGuess)
        {
            return i_UserGuess.Distinct().Count() != i_UserGuess.Count;
        }

        private void addUserGuess(List<Color> i_UserGuess)
        {
            this.m_UserGuesses.Add(new UserGuessHandler(i_UserGuess, m_ComputerChoiceHandler.ComputerChoice));
            this.m_CurrentUserGuess = i_UserGuess;
            this.m_CurrentNumberOfGuesses++;
        }

        private bool isUserGuessedExactly()
        {
            return this.m_ComputerChoiceHandler.ComputerChoice.SequenceEqual(m_CurrentUserGuess);
        }

        private void showInvalidGuessWarning()
        {
            MessageBox.Show("Please choose distinct colors for each position!", "Invalid Guess", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool showGameOutcome(bool i_UserGuessIsCorrect)
        {
            string message = "Do you want to play again?";
            string caption = i_UserGuessIsCorrect ? "You won!" : "You lost!";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Information;
            DialogResult result = MessageBox.Show(message, caption, buttons, icon);

            return result == DialogResult.Yes;
        }

        private void m_GameForm_UserGuessed(List<Color> i_UserGuess)
        {
            if (areColorsInGuessDuplicated(i_UserGuess))
            {
                this.showInvalidGuessWarning();
            }
            else
            {
                this.addUserGuess(i_UserGuess);
                List<Color> result = this.m_UserGuesses.Last().Result;
                this.m_GameForm.ShowResultButtons(this.m_CurrentNumberOfGuesses, result);

                bool userGuessIsCorrect = this.isUserGuessedExactly();
                bool gameOver = this.m_CurrentNumberOfGuesses == this.m_NumberOfGuesses;
                if (userGuessIsCorrect || gameOver)
                {
                    this.m_GameForm.ShowComputerChoiceLine(this.m_ComputerChoiceHandler.ComputerChoice);
                    bool isWantToPlayNewGame = this.showGameOutcome(userGuessIsCorrect);
                    if (isWantToPlayNewGame)
                    {
                        this.m_GameForm.DialogResult = DialogResult.OK;
                        this.m_GameForm.Close();
                        GameManager gameManager = new GameManager();
                        gameManager.Play();
                    }
                }
                else
                {
                    this.m_GameForm.EnableNextGuess(this.m_CurrentNumberOfGuesses);
                }
            }
        }
    }
}