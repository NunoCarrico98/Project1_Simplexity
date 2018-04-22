using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Simplexity
{
    /// <summary>
    /// Class that checks if there is a win or draw.
    /// </summary>
    class WinChecker
    {
        /// <summary>
        /// Method that calls other methodsto check if there is a win for 
        /// shape or color.
        /// </summary>
        /// <param name="board"> Variable that contains the board of pieces. </param>
        /// <param name="lastPosPlayed"> Variable that contains the coordinates
        /// of the last piece played. </param>
        /// <returns> Returns a Color that indicates which player is the winner </returns>
        public Color Check(Board board, Coordinates lastPosPlayed)
        {
            /* Checks for victory condition according to shape
             * If cube is victorious player2 wins 
             * If cilinder is victorious player1 wins */
            if (CheckForWinShape(board, lastPosPlayed, Shape.Cube)) return Color.Red;
            if (CheckForWinShape(board, lastPosPlayed, Shape.Cilinder)) return Color.White;

            /* Checks for victory condition according to color
            * If color red is victorious player2 wins 
            * If color white is victorious player1 wins */
            if (CheckForWinColor(board, lastPosPlayed, Color.Red)) return Color.Red;
            if (CheckForWinColor(board, lastPosPlayed, Color.White)) return Color.White;

            /* If there is no win */
            return Color.None;
        }

        /// <summary>
        /// Method that check if there is a victory condition with a shape.
        /// </summary>
        /// <param name="board"> Variable that contains the board o pieces.</param>
        /// <param name="lastPosPlayed"> Variable that contains the coordinates
        /// of the last piece played. </param>
        /// <param name="shape"> Variable that contains the shape being searched. </param>
        /// <returns> Returns true if there is a victory condition. </returns>
        private bool CheckForWinShape(Board board, Coordinates lastPosPlayed, Shape shape)
        {
            /* Creates an array of coordinates holding several directions */
            Coordinates[] directionCheck = new Coordinates[4];
            /* North */
            directionCheck[0] = new Coordinates(0, -1); 
            /* Northeast */
            directionCheck[1] = new Coordinates(1, -1); 
             /* East */
            directionCheck[2] = new Coordinates(1, 0);
            /* Southeast */
            directionCheck[3] = new Coordinates(1, 1); 

            /* Cycles through the array of directions */
            foreach (Coordinates direction in directionCheck)
            {
                /* Creates a counter to check for matching shapes */
                int matchingShapes = 1;

                /* Multiply the direction by -1 and 1 giving both the direction
                 * created and the opposite direction */
                for (int dirUpDown = -1; dirUpDown <= 1; dirUpDown += 2)
                {
                    /* Creates a variable to hold both those directions */
                    int xDirCheck = direction.X * dirUpDown;
                    int yDirCheck = direction.Y * dirUpDown;

                    /* Cycles so the distance at which we check the board increases
                     * until we find a victory or finish the board */
                    for (int checkDistance = 1; checkDistance < 6; checkDistance++)
                    {
                        /* Creates variables to hold those increasing distances.
                         * Those keep going in the direction of the current analysed
                         * direction*/
                        int xCheck = lastPosPlayed.X + xDirCheck * checkDistance;
                        int yCheck = lastPosPlayed.Y + yDirCheck * checkDistance;
                        Coordinates coordCheck = new Coordinates(xCheck, yCheck);

                        /* If check coordinates are outside the board the cycle breaks */
                        if (IsOutsideBoard(coordCheck)) break;

                        /* If the check finds a shape equal to the one the
                         * method is looking for */
                        if (board.GetShape(coordCheck) == shape)
                        {
                            /* Increment 1 to the counter of matching shapes */
                            matchingShapes++;
                        }
                        /* If not break cycle breaks and the next direction is searched */
                        else break;

                        /* If 4 or more equal shapes are found */
                        if (matchingShapes >= 4)
                        {
                            /* We leave the method returning true */
                            return true;
                        }
                    }
                }
            }
            /* If we reach here it means no victory was found.
             * As such we return false */
            return false;
        }

        /// <summary>
        /// Method that check if there is a victory condition with a shape.
        /// </summary>
        /// <param name="board"> Variable that contains the board o pieces.</param>
        /// <param name="lastPosPlayed"> Variable that contains the coordinates
        /// of the last piece played. </param>
        /// <param name="color"> Variable that contains the Color being searched. </param>
        /// <returns> Returns true if there is a victory condition. </returns>
        private bool CheckForWinColor(Board board, Coordinates lastPosPlayed, Color color)
        {
            /* Creates an array of coordinates holding several directions */
            Coordinates[] directionCheck = new Coordinates[4];
            /* North */
            directionCheck[0] = new Coordinates(0, -1);
            /* Northeast */
            directionCheck[1] = new Coordinates(1, -1);
            /* East */
            directionCheck[2] = new Coordinates(1, 0);
            /* Southeast */
            directionCheck[3] = new Coordinates(1, 1);

            /* Cycles through the array of directions */
            foreach (Coordinates direction in directionCheck)
            {
                /* Creates a counter to check for matching shapes */
                int matchingColors = 1;

                /* Multiply the direction by -1 and 1 giving both the direction
                 * created and the opposite direction */
                for (int dirUpDown = -1; dirUpDown <= 1; dirUpDown += 2)
                {
                    /* Creates a variable to hold both those directions */
                    int xDirCheck = direction.X * dirUpDown;
                    int yDirCheck = direction.Y * dirUpDown;

                    /* Cycles so the distance at which we check the board increases
                     * until we find a victory or finish the board */
                    for (int checkDistance = 1; checkDistance < 6; checkDistance++)
                    {
                        /* Creates variables to hold those increasing distances.
                         * Those keep going in the direction of the current analysed
                         * direction*/
                        int xCheck = lastPosPlayed.X + direction.X * checkDistance;
                        int yCheck = lastPosPlayed.Y + direction.Y * checkDistance;
                        Coordinates coordCheck = new Coordinates(xCheck, yCheck);

                        /* If check coordinates are outside the board the cycle breaks */
                        if (IsOutsideBoard(coordCheck)) break;

                        /* If the check finds a shape equal to the one the
                         * method is looking for */
                        if (board.GetColor(coordCheck) == color)
                        {
                            /* Increment 1 to the counter of matching shapes */
                            matchingColors++;
                        }
                        /* If not break cycle breaks and the next direction is searched */
                        else break;

                        /* If 4 or more equal shapes are found */
                        if (matchingColors >= 6)
                        {
                            /* We leave the method returning true */
                            return true;
                        }
                    }
                }
            }

            /* If we reach here it means no victory was found.
             * As such we return false */
            return false;
        }

        /// <summary>
        /// Method that verifies if coordinates are outside board.
        /// </summary>
        /// <param name="coordinates"> Variable that contains certain position. </param>
        /// <returns> Returns true if coordinates are outside board. </returns>
        public bool IsOutsideBoard(Coordinates coordinates)
        {
            /* If any of the coordinates are outside the board */
            if (coordinates.X < 0 || coordinates.Y < 0 || coordinates.X > 6 || coordinates.Y > 6) return true;
            else return false;
        }

        /// <summary>
        /// Method that checks if there is a draw.
        /// </summary>
        /// <param name="player1"> Variable that contains player1 </param>
        /// <param name="player2"> Variable that contains player2 </param>
        /// <returns> Returns true if both players have no more pieces </returns>
        public bool CheckDraw(Player player1, Player player2)
        {
            /* If both players have no more pieces */
            if (!player1.HavePieces() && !player2.HavePieces()) return true;
            else return false;
        }
    }
}
