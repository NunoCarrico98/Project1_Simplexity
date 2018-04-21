using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Simplexity
{
    class WinChecker
    {
        public Color Check(Board board, Coordinates lastPosPlayed)
        {
            if (CheckForWinShape(board, lastPosPlayed, Shape.Cube)) return Color.Red;
            if (CheckForWinShape(board, lastPosPlayed, Shape.Cilinder)) return Color.White;
            if (CheckForWinColor(board, lastPosPlayed, Color.Red)) return Color.Red;
            if (CheckForWinColor(board, lastPosPlayed, Color.White)) return Color.White;
            return Color.None;

        }

        private bool CheckForWinShape(Board board, Coordinates lastPosPlayed, Shape shape)
        {
            Coordinates[] directionCheck = new Coordinates[4];
            directionCheck[0] = new Coordinates(0, -1); // North
            directionCheck[1] = new Coordinates(1, -1); // Northeast
            directionCheck[2] = new Coordinates(1, 0); // East
            directionCheck[3] = new Coordinates(1, 1); // Southeast

            foreach (Coordinates direction in directionCheck)
            {
                int matchingShapes = 1;

                for (int dirUpDown = -1; dirUpDown <= 1; dirUpDown += 2)
                {
                    int xDirCheck = direction.X * dirUpDown;
                    int yDirCheck = direction.Y * dirUpDown;

                    for (int checkDistance = 1; checkDistance < 6; checkDistance++)
                    {
                        int xCheck = lastPosPlayed.X + xDirCheck * checkDistance;
                        int yCheck = lastPosPlayed.Y + yDirCheck * checkDistance;
                        Coordinates coordCheck = new Coordinates(xCheck, yCheck);

                        if (IsOutsideBoard(coordCheck)) break;

                        if (board.GetShape(coordCheck) == shape)
                        {
                            matchingShapes++;
                        }
                        else break;
                    }

                    if (matchingShapes >= 4)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckForWinColor(Board board, Coordinates lastPosPlayed, Color color)
        {
            Coordinates[] directionCheck = new Coordinates[4];
            directionCheck[0] = new Coordinates(0, -1); // North
            directionCheck[1] = new Coordinates(1, -1); // Northeast
            directionCheck[2] = new Coordinates(1, 0); // East
            directionCheck[3] = new Coordinates(1, 1); // Southeast

            foreach (Coordinates direction in directionCheck)
            {
                int matchingColors = 1;

                for (int dirUpDown = -1; dirUpDown <= 1; dirUpDown += 2)
                {
                    int xDirCheck = direction.X * dirUpDown;
                    int yDirCheck = direction.Y * dirUpDown;

                    for (int checkDistance = 1; checkDistance < 6; checkDistance++)
                    {
                        int xCheck = lastPosPlayed.X + direction.X * checkDistance;
                        int yCheck = lastPosPlayed.Y + direction.Y * checkDistance;
                        Coordinates coordCheck = new Coordinates(xCheck, yCheck);

                        if (IsOutsideBoard(coordCheck)) break;

                        if (board.GetColor(coordCheck) == color)
                        {
                            matchingColors++;
                        }
                        else break;
                    }

                    if (matchingColors >= 6)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsOutsideBoard(Coordinates coordinates)
        {
            if (coordinates.X < 0 || coordinates.Y < 0 || coordinates.X > 6 || coordinates.Y > 6) return true;
            else return false;
        }

        public bool CheckDraw(Player player1, Player player2)
        {
            if (!player1.HavePieces() && !player2.HavePieces()) return true;
            else return false;
        }
    }
}
