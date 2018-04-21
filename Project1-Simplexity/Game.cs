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
                int column = 0;
                Piece playerPiece = Piece.None;

                render.Render(board);

                if (board.NextPlayer == player1.Color)
                {
                    if (!player1.HavePieces())
                    {
                        Console.WriteLine("I'm Sorry... You have no more pieces.");
                        continue;
                    }
                    Console.WriteLine("White Player, it's your turn!\n");
                    column = player1.GetColumn();
                    playerPiece = player1.GetShape();
                }

                if (board.NextPlayer == player2.Color)
                {
                    if (!player2.HavePieces())
                    {
                        Console.WriteLine("I'm Sorry... You have no more pieces.");
                        continue;
                    }
                    Console.WriteLine("Red Player, it's your turn!\n");
                    column = player2.GetColumn();
                    playerPiece = player2.GetShape();
                }

                lastPosPlayed = board.SetPiece(column, playerPiece);

            } while (!winChecker.CheckDraw(player1, player2) && winChecker.Check(board, lastPosPlayed) == Color.None);

            return lastPosPlayed;
        }
    }
}
