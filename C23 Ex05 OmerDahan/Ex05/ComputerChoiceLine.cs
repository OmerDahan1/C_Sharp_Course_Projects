using System.Collections.Generic;
using System.Drawing;

namespace Ex05
{
    public class ComputerChoiceLine
    {
        private List<ColorButton> m_ComputerChoiceButtons;

        public ComputerChoiceLine(int i_Top, int i_Left, int i_Width, int i_Height, int i_Margin, int i_GuessLength)
        {
            this.initializeComputerChoiceLine(i_Top, i_Left, i_Width, i_Height, i_Margin, i_GuessLength);
        }

        public List<ColorButton> SolutionCells
        {
            get 
            { 
                return this.m_ComputerChoiceButtons; 
            }
        }

        private void initializeComputerChoiceLine(int i_Top, int i_Left, int i_Width, int i_Height, int i_Margin, int i_GuessLength)
        {
            m_ComputerChoiceButtons = new List<ColorButton>(i_GuessLength);

            for (int i = 0; i < i_GuessLength; i++)
            {
                int computerChoicebuttonLeft = i_Left + (i * (i_Width + i_Margin));
                ColorButton computerChoiceButton = new ColorButton(i_Top, computerChoicebuttonLeft, i_Width, i_Height, true);
                computerChoiceButton.BackColor = Color.Black;
                m_ComputerChoiceButtons.Add(computerChoiceButton);
            }
        }
    }
}
