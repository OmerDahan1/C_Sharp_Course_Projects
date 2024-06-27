using System;
using System.Collections.Generic;
using System.Drawing;

namespace Ex05
{
    internal class ComputerChoiceHandler
    {
        private readonly List<Color> r_ColorsList;
        private  readonly List<Color> r_ComputerChoice;
        private readonly int r_NumberOfColorsToSelectForComputerChoice;

        internal ComputerChoiceHandler(int i_NumberOfColorsForComputerGuess)
        {
            this.r_NumberOfColorsToSelectForComputerChoice = i_NumberOfColorsForComputerGuess;
            r_ColorsList = initializeColorsList();
            r_ComputerChoice = selectComputerChoiceRandomly();
        }

        internal List<Color> ComputerChoice
        {
            get 
            { 
                return r_ComputerChoice; 
            }
        }

        internal List<Color> ColorsList
        {
            get
            {
                return r_ColorsList;
            }
        }

        private List<Color> initializeColorsList()
        {
            List<Color> colors = new List<Color>
            {
                Color.Purple, 
                Color.Red, 
                Color.LawnGreen, 
                Color.LightSkyBlue, 
                Color.Blue, 
                Color.Yellow, 
                Color.Brown, 
                Color.White
            };

            return colors;
        }

        private List<Color> selectComputerChoiceRandomly()
        {
            Random random = new Random();
            List<Color> computerChoice = new List<Color>(this.r_NumberOfColorsToSelectForComputerChoice);

            while (computerChoice.Count < this.r_NumberOfColorsToSelectForComputerChoice)
            {
                int randomIndexForComputerChoice = random.Next(this.r_ColorsList.Count);
                Color colorToChoose = this.r_ColorsList[randomIndexForComputerChoice];
                if (!computerChoice.Contains(colorToChoose))
                {
                    computerChoice.Add(colorToChoose);
                }
            }

            return computerChoice;
        }
    }
}    

