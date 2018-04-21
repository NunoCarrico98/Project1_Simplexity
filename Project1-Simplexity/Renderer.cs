using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Simplexity
{
    class Renderer
    {
        public void Render(Board board)
        {

            string[,] gamesymbols = new string[7, 7];


            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Coordinates coordinates = new Coordinates(i, j);
                    gamesymbols[i, j] = DefineGameSymbol(board.GetPiece(coordinates));

                    Console.Write($" {gamesymbols[i, j]}  ");
                }
                Console.WriteLine();
            }
        }

        public string DefineGameSymbol(Piece piece)
        {
            string temp = "";

            switch (piece)
            {
                case Piece.RedCube:
                    temp = " R ";
                    break;
                case Piece.WhiteCube:
                    temp = " W ";
                    break;
                case Piece.RedCilinder:
                    temp = " r ";
                    break;
                case Piece.WhiteCilinder:
                    temp = " w ";
                    break;
                default:
                    temp = " | ";
                    break;

            }
            return temp;
        }

        public void RenderResults(Color winner)
        {
            switch (winner)
            {
                case Color.White:
                    Console.WriteLine("Player 1 wins!!!\n");
                    break;
                case Color.Red:
                    Console.WriteLine("Player 2 wins!!!\n");
                    break;
                case Color.None:
                    Console.WriteLine("It's a tie!");
                    break;
            }
        }
    }
}
