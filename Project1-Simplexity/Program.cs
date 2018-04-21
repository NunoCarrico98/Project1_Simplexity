using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Simplexity
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Renderer render = new Renderer();
            WinChecker winChecker = new WinChecker();
            Player player1 = new Player(Color.White);
            Player player2 = new Player(Color.Red);
            Coordinates lastPosPlayed = new Coordinates(0, 0);

            while (!winChecker.CheckDraw(player1, player2) && winChecker.Check(board, lastPosPlayed) == Color.None)
            {
                Color color = player1.Color;

                render.Render(board);

                if (color == player1.Color)
                {
                    lastPosPlayed = board.SetPiece(player1.GetColumn(), player1.GetShape());
                    color = player2.Color;
                }

                render.Render(board);

                if (color == player2.Color)
                {
                    lastPosPlayed = board.SetPiece(player2.GetColumn(), player2.GetShape());
                    color = player1.Color;
                }

            }

            render.Render(board);
            render.RenderResults(winChecker.Check(board, lastPosPlayed));
        }
    }
}
