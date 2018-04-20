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
    }
}
