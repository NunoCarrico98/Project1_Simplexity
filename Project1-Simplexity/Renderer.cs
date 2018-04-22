using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Simplexity
{
    /// <summary>
    /// Class that renders the board and results.
    /// </summary>
    class Renderer
    {
        /// <summary>
        /// Method that Draws the board.
        /// </summary>
        /// <param name="board"> Variable that contains the board. </param>
        public void Render(Board board)
        {
            /* Array to hold all the symbols of all the pieces */
            string[,] gamesymbols = new string[7, 7];

            /* Cycles through the array of pieces */
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    /* Save coordinates of every array position */
                    Coordinates coordinates = new Coordinates(i, j);

                    /* Get all the symbols on all positions of array of symbols */
                    /* Calls method that defines the symbol accordint to piece */
                    gamesymbols[i, j] = DefineGameSymbol(board.GetPiece(coordinates));

                    /* Draws all symbols on the console */
                    Console.Write($" {gamesymbols[i, j]}  ");
                }
                /* Goes to next line after first one has 7 symbols */
                Console.WriteLine();
            }

            Console.WriteLine();

            /* Sets the number of each column under the respective column */
            for (int i = 1; i < 8; i++)
            {
                Console.Write($"  {i}   ");
            }

            Console.WriteLine("\n");
        }

        /// <summary>
        /// Method that defines the symbol to draw on the console.
        /// </summary>
        /// <param name="piece"> Variable that contains the piece on 
        /// certain coordinates. </param>
        /// <returns> Returns the symbol to be drawn. </returns>
        public string DefineGameSymbol(Piece piece)
        {
            /* Variable to hold the symbol to return */
            string temp = "";

            switch (piece)
            {
                /* If piece is a RedCube */
                case Piece.RedCube:
                    /* Symbol to be drawn */
                    temp = " R ";
                    break;
                /* If piece is a WhiteCube */
                case Piece.WhiteCube:
                    /* Symbol to be drawn */
                    temp = " W ";
                    break;
                /* If piece is a RedCilinder */
                case Piece.RedCilinder:
                    /* Symbol to be drawn */
                    temp = " r ";
                    break;
                /* If piece is a WhiteCilinder */
                case Piece.WhiteCilinder:
                    /* Symbol to be drawn */
                    temp = " w ";
                    break;
                /* If there is no piece */
                default:
                    /* Symbol to be drawn */
                    temp = " | ";
                    break;

            }

            /* Return the game symbol to be drawn */
            return temp;
        }

        /// <summary>
        /// Method that renders the winner on console.
        /// </summary>
        /// <param name="winner"> Variable that contains the winner. </param>
        public void RenderResults(Color winner)
        {
            switch (winner)
            {
                /* If Player1 wins */
                case Color.White:
                    Console.WriteLine("Player 1 wins!!!\n");
                    break;
                /* If Player2 wins */
                case Color.Red:
                    Console.WriteLine("Player 2 wins!!!\n");
                    break;
                /* If it's a draw */
                case Color.None:
                    Console.WriteLine("It's a tie!");
                    break;
            }
        }
    }
}
