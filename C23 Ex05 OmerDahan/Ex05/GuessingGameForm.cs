using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05
{
    public class GuessingGameForm : Form
    {
        private readonly int r_CellWidth = 30;
        private readonly int r_CellHeight = 30;
        private readonly int r_CellMargin = 5;
        private readonly int r_WindowPadding = 12;
        private readonly int r_MarginBetweenComputerChoiceAndUserGuesses = 28;
        private readonly int r_GuessLength;
        private readonly int r_NumberOfGuesses;
        private ComputerChoiceLine m_ComputerChoiceLine;
        private List<UserGuessLine> m_UserGuessLines;

        public GuessingGameForm(int i_NumberOfGuesses, int i_GuessLength)
        {
            r_GuessLength = i_GuessLength;
            r_NumberOfGuesses = i_NumberOfGuesses;

            initializeGame();
        }

        public event Action<List<Color>> UserGuessed;

        public void EnableNextGuess(int i_NumberOfGuess)
        {
            if (i_NumberOfGuess >= 0 && i_NumberOfGuess < m_UserGuessLines.Count)
            {
                m_UserGuessLines[i_NumberOfGuess].EnableColorButtons();
            }
        }

        internal void ShowComputerChoiceLine(List<Color> i_ComputerChoiceLine)
        {
            for (int i = 0; i < i_ComputerChoiceLine.Count; i++)
            {
                m_ComputerChoiceLine.SolutionCells[i].BackColor = i_ComputerChoiceLine[i];
            }
        }

        public void ShowResultButtons(int i_NumberOfGuessLine, List<Color> i_Result)
        {
            for (int i = 0; i < i_Result.Count; i++)
            {
                m_UserGuessLines[i_NumberOfGuessLine - 1].ResultButtons[i].BackColor = i_Result[i];
            }
        }

        private void initializeGame()
        {
            int windowWidth = (r_CellWidth * (r_GuessLength + 2)) + (r_CellMargin * (r_GuessLength + 1)) + (2 * r_WindowPadding);
            int windowHeight = (r_CellHeight * (r_NumberOfGuesses + 1)) + (r_CellMargin * r_NumberOfGuesses) + r_MarginBetweenComputerChoiceAndUserGuesses + (2 * r_WindowPadding);

            Text = "Bool Pgia";
            ClientSize = new Size(windowWidth, windowHeight);
            StartPosition = FormStartPosition.CenterScreen;
            m_ComputerChoiceLine = new ComputerChoiceLine(r_WindowPadding, r_WindowPadding, r_CellWidth, r_CellWidth, r_CellMargin, r_GuessLength);
            addSolutionCellsToControls();
            m_UserGuessLines = createAndAddUserGuessLines();
            enableColorButtonsForFirstGuessRow();
        }

        private void addSolutionCellsToControls()
        {
            foreach (ColorButton solutionCell in m_ComputerChoiceLine.SolutionCells)
            {
                Controls.Add(solutionCell);
            }
        }

        private List<UserGuessLine> createAndAddUserGuessLines()
        {
            List<UserGuessLine> userGuessLines = new List<UserGuessLine>();

            for (int i = 1; i <= r_NumberOfGuesses; i++)
            {
                int userGuessLineTop = (i * (r_CellWidth + r_CellMargin)) + r_MarginBetweenComputerChoiceAndUserGuesses;

                UserGuessLine userGuessLine = new UserGuessLine(userGuessLineTop, r_WindowPadding, r_CellWidth, r_CellWidth, r_CellMargin, r_GuessLength);
                userGuessLine.SubmitButtonClicked += UserGuessLine_SubmitButtonClicked;
                userGuessLines.Add(userGuessLine);

                addColorButtonsToControls(userGuessLine.ColorButtons);
                Controls.Add(userGuessLine.SubmitButton);
                addResultButtonsToControls(userGuessLine.ResultButtons);
            }

            return userGuessLines;
        }

        private void enableColorButtonsForFirstGuessRow()
        {
            if (m_UserGuessLines.Count > 0)
            {
                m_UserGuessLines[0].EnableColorButtons();
            }
        }

        private void addColorButtonsToControls(List<ColorButton> i_ColorButtons)
        {
            foreach (ColorButton colorButton in i_ColorButtons)
            {
                Controls.Add(colorButton);
            }
        }

        private void addResultButtonsToControls(List<ResultButton> i_ResultButtons)
        {
            foreach (ResultButton resultButton in i_ResultButtons)
            {
                Controls.Add(resultButton);
            }
        }

        protected virtual void OnUserGuessed(List<Color> i_UserGuess)
        {
            UserGuessed?.Invoke(i_UserGuess);
        }

        private void UserGuessLine_SubmitButtonClicked(List<Color> i_UserGuess)
        {
            OnUserGuessed(i_UserGuess);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GuessingGameForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "GuessingGameForm";
            this.Load += new System.EventHandler(this.GuessingGameForm_Load);
            this.ResumeLayout(false);

        }

        private void GuessingGameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
