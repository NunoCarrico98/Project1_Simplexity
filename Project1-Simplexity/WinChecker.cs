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
            if(CheckForWinShape(board, lastPosPlayed, Shape.Cube)) return Color.Red;
            else if(CheckForWinShape(board, lastPosPlayed, Shape.Cilinder)) return Color.Red;

        }

        public bool CheckForWinShape(Board board, Coordinates lastPosPlayed, Shape shape)
        {
            Coordinates[] directionCheck = new Coordinates[4];
            directionCheck[0] = new Coordinates(0, -1);
            directionCheck[1] = new Coordinates(1, -1);
            directionCheck[2] = new Coordinates(1, 0);
            directionCheck[3] = new Coordinates(1, 1);

            foreach(Coordinates direction in directionCheck)
            {
                int matchingShapes = 1;

                for (int dirUpDown = -1; dirUpDown <= 1; dirUpDown += 2)
                {
                    Coordinates DirCheck = new Coordinates(direction.X * dirUpDown, direction.Y * dirUpDown);

                    for (int checkDistance = 1; checkDistance < 6; checkDistance++)
                    {
                        int xCheck = lastPosPlayed.X + DirCheck.X * checkDistance;
                        int yCheck = lastPosPlayed.Y + DirCheck.Y * checkDistance;
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
