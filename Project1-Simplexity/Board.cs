using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Simplexity
{
    /// <summary>
    /// Class that manages the board.
    /// </summary>
    class Board
    {
        /* Instance Variable that creates board */
        private Piece[,] piece;

        /* Property that dictates Next Player */
        public Color NextPlayer { get; private set; }

        public Board()
        {
            /* Instantiate board of pieces */
            piece = new Piece[7, 7];
            /* Initiaizes Next Player as White */
            NextPlayer = Color.White;
        }

        /// <summary>
        /// Method to get Piece on certain coordinates.
        /// </summary>
        /// <param name="coordinates"> Variabe that contains coordinates to search. </param>
        /// <returns> Returns Piece on coordinates. </returns>
        public Piece GetPiece(Coordinates coordinates)
        {
            /* Returns Piece on certain Position */
            return piece[coordinates.X, coordinates.Y];
        }

        /// <summary>
        /// Method to get Shape of a piece on certain coordinates.
        /// </summary>
        /// <param name="coordinates"> Variabe that contains coordinates to search. </param>
        /// <returns> Returns Shape of Piece on coordinates. </returns>
        public Shape GetShape(Coordinates coordinates)
        {
            /* If Piece is a Cube */
            if (GetPiece(coordinates) == Piece.RedCube ||
                GetPiece(coordinates) == Piece.WhiteCube) return Shape.Cube;

            /* If Piece is a Cilinder */
            else if (GetPiece(coordinates) == Piece.RedCilinder ||
                     GetPiece(coordinates) == Piece.WhiteCilinder) return Shape.Cilinder;

            /* If there is no Piece */
            else return Shape.None;
        }

        /// <summary>
        /// Method to get Color of a piece on certain coordinates.
        /// </summary>
        /// <param name="coordinates"> Variabe that contains coordinates to search. </param>
        /// <returns> Returns Color of Piece on coordinates. </returns>
        public Color GetColor(Coordinates coordinates)
        {
            /* If Piece is Red */
            if (GetPiece(coordinates) == Piece.RedCube || 
                GetPiece(coordinates) == Piece.RedCilinder) return Color.Red;

            /* If Piece is White */
            else if (GetPiece(coordinates) == Piece.WhiteCube || 
                     GetPiece(coordinates) == Piece.WhiteCilinder) return Color.White;

            /* If there is no Piece */
            else return Color.None;
        }

        /// <summary>
        /// Method to Set Piece on Board.
        /// </summary>
        /// <param name="playerMove"> Variable that contains the column the 
        /// player chose. </param>
        /// <param name="newPiece"> Variable that contains the Piece to set 
        /// on board. </param>
        /// <returns></returns>
        public Coordinates SetPiece(int playerMove, Piece newPiece)
        {
            /* Variable to check column */
            int checkX = 6;
            /* Variable to hold column the player chose */
            int chosenColumn = playerMove - 1;

            /* Performs cycle while there is a piece */
            while (piece[checkX, chosenColumn] != Piece.None)
            {
                /* Variable to check column goes up */
                checkX--;

                /* If column is full */
                if (checkX < 0)
                {
                    /* Ask for a new Column */
                    Console.WriteLine(">>>>> Unavailable Column <<<<<");
                    Player CheckInput = new Player();
                    chosenColumn = CheckInput.GetColumn() - 1;

                    /* Start checking column at the bottom of new column */
                    checkX = 6;
                }
            }

            /* Set on chosen column in available X */
            piece[checkX, chosenColumn] = newPiece;

            /* Calls function to switch turn */
            SwitchTurn();

            /* Returns the Coordinates od the Piece */
            return new Coordinates(checkX, chosenColumn);
        }

        /// <summary>
        /// Method to switch turn.
        /// </summary>
        public void SwitchTurn()
        {
            /* If Player1 plays */
            if (NextPlayer == Color.White)
            {
                /* Next turn is Player2 */
                NextPlayer = Color.Red;
            }
            /* If Player2 plays */
            else
            {
                /* Next turn is Player1 */
                NextPlayer = Color.White;
            }
        }
    }
}
