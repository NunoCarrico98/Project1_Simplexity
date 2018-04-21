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
            Player player = new Player(Color.White);
            Player player2 = new Player(Color.Red);

            for (int i = 0; i < 50; i++)
            {   
                Color color = Color.White;
                
                render.Render(board);
 
                if (color == Color.White)
                {
                    board.SetPiece(player.GetColumn(), player.GetShape());
                    color = Color.Red;
                }

                render.Render(board);

                if (color == Color.Red)
                {
                    board.SetPiece(player2.GetColumn(), player2.GetShape());
                    color = Color.White;
                }

            }
        }
    }
}
