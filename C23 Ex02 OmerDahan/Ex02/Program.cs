using System;

namespace Ex02
{
    internal class Program
    {
        public static void Main(string[] args) 
        {
            GameUI gameRunning = new GameUI();
            gameRunning.RunGame();
            Console.ReadLine();
        }
    }
}
