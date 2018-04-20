using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Simplexity
{
    class Board
    {
        private Piece[,] piece;

        public Board()
        {
            piece = new Piece[7, 7];
        }

        public Piece GetPiece(Coordinates coordinates)
        {
            return piece[coordinates.X, coordinates.Y];
        }

        public void SetPiece(int chosenColumn, Piece newPiece)
        {
            int checkX = 6;

            while (piece[checkX,chosenColumn] != Piece.None)
            {
                checkX--;
            }

            piece[checkX, chosenColumn] = newPiece;

        }
    }
}
