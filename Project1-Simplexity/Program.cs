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
            board.SetPiece(player.GetColumn(), player.GetShape());
            render.Render(board); 

        }
    }
}
