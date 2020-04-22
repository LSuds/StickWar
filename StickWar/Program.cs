using System;
using System.Diagnostics;
using System.Threading;

namespace StickWar
{
    class Program
    {
        public static int TickCounter = 3500;
        static void Main()
        {
            GetPlayerNames();
            PlayGame();
        }

        private static void PlayGame()
        {
            Console.Clear();
            var stopwatch = new Stopwatch();
            int gameResult = 0;

            gameResult = GameBoard.ReDraw();
            while (gameResult==0)
            {
                stopwatch.Start();
                while (stopwatch.ElapsedMilliseconds < TickCounter)
                {
                    int input = Reader.ReadLine(TickCounter - (int)stopwatch.ElapsedMilliseconds);
                    GameBoard.CreateUnit(input);
                }
                stopwatch.Stop();
                stopwatch.Reset();
                gameResult = GameBoard.ReDraw();
            }
            EndGame(gameResult);

        }
        private static void EndGame(int result)
        {
            switch (result)
            {
                case 1:
                    Console.WriteLine(Player1.name + "Wins!");
                    break;
                case 2:
                    Console.WriteLine(Player2.name + "Wins!");
                    break;
                case 3:
                    Console.WriteLine("Its A Tie!!!");
                    break;
            }
        }
        private static void GetPlayerNames()
        {
            Console.WriteLine("Player 1 Name:");
            Player1.name = Console.ReadLine();
            Player1.name = Player1.name + ":";

            Console.WriteLine("Player 2 Name:");
            Player2.name = Console.ReadLine();
            Player2.name = Player2.name + ":";
        }
    }
}
