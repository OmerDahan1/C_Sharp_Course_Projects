namespace Ex02
{
    internal class Board
    {
        private readonly int r_BoardSize;
        private readonly int r_NumberOfCharsInRow;
        private eGuessChar[,] m_BoardGuesses;
        private eResults[,] m_BoardResults;
        
        public Board(string i_NumberOfGuesses) 
        {
            int.TryParse(i_NumberOfGuesses, out r_BoardSize);
            this.r_NumberOfCharsInRow = 4;
            this.m_BoardGuesses = new eGuessChar[r_BoardSize, r_NumberOfCharsInRow];
            this.m_BoardResults = new eResults[r_BoardSize, r_NumberOfCharsInRow];
            this.initializeBoardsWithDesiredNumberOfGuesses();
        }

        public int NumberOfCharsInRow
        {
            get 
            {
                return this.r_NumberOfCharsInRow; 
            }
        }

        public eGuessChar[,] BoardGuesses
        {
            get 
            { 
                return this.m_BoardGuesses; 
            }
        }

        public eResults[,] BoardResults
        {
            get
            {
                return this.m_BoardResults;
            }
        }

        public int BoardSize
        {
            get
            {
                return this.r_BoardSize;
            }
        }
        
        private void initializeBoardsWithDesiredNumberOfGuesses()
        {
            for (int i = 0; i < this.r_BoardSize; i++)
            {
                for (int j = 0; j < r_NumberOfCharsInRow; j++)
                {
                    this.m_BoardGuesses[i, j] = eGuessChar.None;
                    this.m_BoardResults[i, j] = eResults.None;
                }
            }
        }

        public void UpdateBoardguesses(string i_UserGuess, string i_ParsedGuessToResult, int i_NumberOfRow)
        {
            for (int i = 0; i < this.r_NumberOfCharsInRow; i++)
            {
                m_BoardGuesses[i_NumberOfRow, i] = (eGuessChar)i_UserGuess[2 * i];
                m_BoardResults[i_NumberOfRow, i] = (eResults)i_ParsedGuessToResult[2 * i];
            }
        }
    }
}