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

        public Shape GetShape(Coordinates coordinates)
        {
            if (GetPiece(coordinates) == Piece.RedCube || GetPiece(coordinates) == Piece.WhiteCube) return Shape.Cube;
            if (GetPiece(coordinates) == Piece.RedCilinder || GetPiece(coordinates) == Piece.WhiteCilinder) return Shape.Cilinder;
            else return Shape.None;
        }

        public Color GetColor(Coordinates coordinates)
        {
            if (GetPiece(coordinates) == Piece.RedCube || GetPiece(coordinates) == Piece.RedCilinder) return Color.Red;
            if (GetPiece(coordinates) == Piece.WhiteCube || GetPiece(coordinates) == Piece.WhiteCilinder) return Color.White;
            else return Color.None;
        }

        public void SetPiece(int playerMove, Piece newPiece)
        {
            int checkX = 6;
            int chosenColumn = playerMove - 1;

            while (piece[checkX,chosenColumn] != Piece.None)
            {
                checkX--;
                if(checkX < 0) 
                {
                    Player CheckInput = new Player();
                    chosenColumn = CheckInput.GetColumn() - 1;
                    checkX = 6;
                }
            }

            piece[checkX, chosenColumn] = newPiece;

        }
    }
}
