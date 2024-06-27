using System;
using System.Collections.Generic;
using System.Drawing;

namespace Ex05
{
    internal class UserGuessHandler
    {
        private readonly List<Color> r_Result;

        internal UserGuessHandler(List<Color> i_UserGuess, List<Color> i_ComputerChoice)
        {
            this.r_Result = parseGuessToResult(i_UserGuess, i_ComputerChoice);
        }

        internal List<Color> Result
        {
            get
            {
                return this.r_Result;
            }
        }

        private List<Color> parseGuessToResult(List<Color> i_UserGuess, List<Color> i_ComputerChoice)
        {
            List<Color> result = new List<Color>();
            Dictionary<Color, int> ComputerChoiceCount = new Dictionary<Color, int>();
            Dictionary<Color, int> userGuessCount = new Dictionary<Color, int>();

            foreach (Color color in i_ComputerChoice)
            {
                if (!ComputerChoiceCount.ContainsKey(color))
                {
                    ComputerChoiceCount[color] = 0;

                }

                ComputerChoiceCount[color]++;
            }

            foreach (Color color in i_UserGuess)
            {
                if (!userGuessCount.ContainsKey(color))
                {
                    userGuessCount[color] = 0;
                }

                userGuessCount[color]++;
            }

            for (int i = 0; i < i_ComputerChoice.Count; i++)
            {
                Color color = i_ComputerChoice[i];
                if (i_UserGuess[i] == color)
                {
                    result.Add(Color.Black);
                    ComputerChoiceCount[color]--;
                    userGuessCount[color]--;
                }
            }

            foreach (KeyValuePair<Color, int> colorCountPair in userGuessCount)
            {
                Color color = colorCountPair.Key;
                int userCount = colorCountPair.Value;
                if (ComputerChoiceCount.ContainsKey(color))
                {
                    int minCount = Math.Min(userCount, ComputerChoiceCount[color]);
                    for (int i = 0; i < minCount; i++)
                    {
                        result.Add(Color.Yellow);
                    }
                }
            }

            return result;
        }
    }
}
