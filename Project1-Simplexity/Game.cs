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
            /* Instantiates new objects for the game */
            WinChecker winChecker = new WinChecker();
            Player player1 = new Player(Color.White);
            Player player2 = new Player(Color.Red);
            Coordinates lastPosPlayed = new Coordinates(0, 0);

            /* Performs cycle while there is no win or draw */
            do
            {
                /* Variables to hold player chosen column and Piece */
                int column = 0;
                Piece playerPiece = Piece.None;

                /* Renders the board on the console */
                render.Render(board);

                /* Player 1 chooses his move */
                if (board.NextPlayer == player1.Color)
                {
                    /* If player1 has no more pieces */
                    if (!player1.HavePieces())
                    {
                        Console.WriteLine(">>>>> No pieces available <<<<<");
                        continue;
                    }
                    Console.WriteLine("White Player, it's your turn!\n");

                    /* Calls method to ask for column and shape */
                    column = player1.GetColumn();
                    playerPiece = player1.GetShape();
                }

                /* Player 2 chooses his move */
                if (board.NextPlayer == player2.Color)
                {
                    /* If player2 has no more pieces */
                    if (!player2.HavePieces())
                    {
                        Console.WriteLine(">>>>> No pieces available <<<<<");
                        continue;
                    }
                    Console.WriteLine("Red Player, it's your turn!\n");

                    /* Calls method to ask for column and shape */
                    column = player2.GetColumn();
                    playerPiece = player2.GetShape();
                }

                /* Sets Piece on board */
                lastPosPlayed = board.SetPiece(column, playerPiece);

            } while (!winChecker.CheckDraw(player1, player2) && winChecker.Check(board, lastPosPlayed) == Color.None);

            /* Returns the coordinates of the last piece played */
            return lastPosPlayed;
        }
    }
}
