using System;
using System.Text;

namespace Ex01_02
{
    public class program
    {
        public static void Main(string[] args)
        {
            DrawSandClock(0,5);
        }
        
        private static void drawLine(int i_NumberOfSpacesInRow, int i_NumberOfAsterisks)
        {
            StringBuilder sandClockToDraw = new StringBuilder(string.Empty);

            for (int i = 0; i < (i_NumberOfSpacesInRow / 2); i++)
            {
                sandClockToDraw.Append(' ');
            }

            for (int j = 0; j < i_NumberOfAsterisks; j++)
            {
                sandClockToDraw.Append('*');
            }

            for(int i = 0; i < (i_NumberOfSpacesInRow / 2); i++)
            {
                sandClockToDraw.Append(' ');
            }

            Console.WriteLine(sandClockToDraw.ToString());
            sandClockToDraw.AppendLine();
        }

        public static void DrawSandClock(int i_NumberOfSpacesInRow, int i_NumberOfAsterisksInRow)
        {
            if(i_NumberOfAsterisksInRow == 1)
            {
                drawLine(i_NumberOfSpacesInRow, i_NumberOfAsterisksInRow);
            }
            else
            {
                drawLine(i_NumberOfSpacesInRow, i_NumberOfAsterisksInRow);
                DrawSandClock(i_NumberOfSpacesInRow + 2, i_NumberOfAsterisksInRow - 2);
                drawLine(i_NumberOfSpacesInRow, i_NumberOfAsterisksInRow);
            }
        }
    }
}