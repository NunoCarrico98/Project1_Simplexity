using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Simplexity
{
    class Game
    {

        public Coordinates GameLoop(Board board, Renderer render)
        {
            WinChecker winChecker = new WinChecker();
            Player player1 = new Player(Color.White);
            Player player2 = new Player(Color.Red);
            Coordinates lastPosPlayed = new Coordinates(0, 0);

            do
            {
                Color color = player1.Color;

                render.Render(board);

                if (color == player1.Color)
                {
                    if (!player1.HavePieces())
                    {
                        Console.WriteLine("I'm Sorry... You have no more pieces.");
                        continue;
                    }
                    Console.WriteLine("White Player, it's your turn!\n");
                    lastPosPlayed = board.SetPiece(player1.GetColumn(), player1.GetShape());
                    color = player2.Color;
                }

                render.Render(board);

                if (color == player2.Color)
                {
                    if (!player2.HavePieces())
                    {
                        Console.WriteLine("I'm Sorry... You have no more pieces.");
                        continue;
                    }
                    Console.WriteLine("Red Player, it's your turn!\n");
                    lastPosPlayed = board.SetPiece(player2.GetColumn(), player2.GetShape());
                    color = player1.Color;
                }

            } while (!winChecker.CheckDraw(player1, player2) && winChecker.Check(board, lastPosPlayed) == Color.None);

            return lastPosPlayed;
        }
    }
}
