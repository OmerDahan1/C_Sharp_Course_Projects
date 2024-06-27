using Ex05;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Ex05
{
    public class UserGuessLine
    {
        private List<ColorButton> m_ColorButtons;
        private SubmitButton m_SubmitButton;
        private List<ResultButton> m_ResultButtons;

        public UserGuessLine(int i_Top, int i_Left, int i_Width, int i_Height, int i_Margin, int i_GuessLength)
        {
            initializeUserGuessLine(i_Top, i_Left, i_Width, i_Height, i_Margin, i_GuessLength);
        }

        public event Action<List<Color>> SubmitButtonClicked;

        public List<ColorButton> ColorButtons
        {
            get 
            { 
                return this.m_ColorButtons; 
            }
        }

        public SubmitButton SubmitButton
        {
            get 
            { 
                return this.m_SubmitButton; 
            }
        }

        public List<ResultButton> ResultButtons
        {
            get 
            { 
                return this.m_ResultButtons; 
            }
        }

        public void EnableColorButtons()
        {
            foreach (ColorButton colorButton in m_ColorButtons)
            {
                colorButton.Enabled = true;
            }
        }

        private void disableColorButtons()
        {
            foreach (ColorButton colorButton in m_ColorButtons)
            {
                colorButton.Enabled = false;
            }
        }

        private bool areColorsInGuessDuplicated()
        {
            List<Color> selectedColors = new List<Color>();
            foreach (ColorButton button in m_ColorButtons)
            {
                selectedColors.Add(button.BackColor);
            }

            bool hasDuplicates = selectedColors.Count != selectedColors.Distinct().Count();

            return hasDuplicates;
        }

        private void initializeUserGuessLine(int i_Top, int i_Left, int i_Width, int i_Height, int i_Margin, int i_GuessLength)
        {
            int submitButtonLeft = i_Left + (i_GuessLength * (i_Width + i_Margin));
            int submitButtonHeight = i_Width / 2;
            int resultButtonsLeft = i_Left + ((i_GuessLength + 1) * (i_Width + i_Margin));

            this.initializeColorButtons(i_Top, i_Left, i_Width, i_Height, i_Margin, i_GuessLength);
            m_SubmitButton = new SubmitButton(i_Top, submitButtonLeft, i_Width, submitButtonHeight);
            m_SubmitButton.Click += m_SubmitButton_Click;
            this.initializeResultButtons(i_Top, resultButtonsLeft, i_Width, i_Height, i_GuessLength);
        }

        private void initializeColorButtons(int i_Top, int i_Left, int i_Width, int i_Height, int i_Margin, int i_GuessLength)
        {
            m_ColorButtons = new List<ColorButton>(i_GuessLength);

            for (int i = 0; i < i_GuessLength; i++)
            {
                int ColorButtonLeft = i_Left + (i * (i_Width + i_Margin));
                ColorButton colorButtonToAdd = new ColorButton(i_Top, ColorButtonLeft, i_Width, i_Height, false);
                colorButtonToAdd.ColorPicked += m_ColorButton_ColorChangeClick;
                m_ColorButtons.Add(colorButtonToAdd);
            }
        }

        private void initializeResultButtons(int i_Top, int i_Left, int i_Width, int i_Height, int i_GuessLength)
        {
            int resultButtonsWidth = (int)(i_Width / 2) + 1;
            int resultButtonsHeight = (int)(i_Height / 2) + 1;
            int resultButtonMargin = i_Width / 2;
            int bottomButtonsTop = i_Top + resultButtonMargin;
            int rightButtonsLeft = i_Left + resultButtonMargin;

            m_ResultButtons = new List<ResultButton>(i_GuessLength);
            ResultButton topLeftButton = new ResultButton(i_Top, i_Left, resultButtonsWidth, resultButtonsHeight);
            ResultButton topRightButton = new ResultButton(i_Top, rightButtonsLeft, resultButtonsWidth, resultButtonsHeight);
            ResultButton bottomLeftButton = new ResultButton(bottomButtonsTop, i_Left, resultButtonsWidth, resultButtonsHeight);
            ResultButton bottomRightButton = new ResultButton(bottomButtonsTop, rightButtonsLeft, resultButtonsWidth, resultButtonsHeight);
            m_ResultButtons.Add(topLeftButton);
            m_ResultButtons.Add(topRightButton);
            m_ResultButtons.Add(bottomLeftButton);
            m_ResultButtons.Add(bottomRightButton);
        }

        private List<Color> getUserGuessColors()
        {
            List<Color> userGuessColors = new List<Color>();

            foreach (ColorButton colorButton in m_ColorButtons)
            {
                userGuessColors.Add(colorButton.BackColor);
            }

            return userGuessColors;
        }

        private void m_ColorButton_ColorChangeClick()
        {
            bool allColorsPicked = true;

            foreach (ColorButton colorButton in m_ColorButtons)
            {
                if (colorButton.IsPicked == false)
                {
                    allColorsPicked = false;
                    break;
                }
            }

            m_SubmitButton.Enabled = allColorsPicked;
        }

        protected virtual void m_SubmitButton_Click(object sender, EventArgs e)
        {
            m_SubmitButton.Enabled = false;
            SubmitButtonClicked?.Invoke(getUserGuessColors());
            if (!areColorsInGuessDuplicated())
            {
                this.disableColorButtons();
            }
        }
    }
}