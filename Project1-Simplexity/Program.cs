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
            Game game = new Game();
            Coordinates lastPosPlayed;

            lastPosPlayed = game.GameLoop(board, render);

            render.Render(board);
            render.RenderResults(winChecker.Check(board, lastPosPlayed));
        }
    }
}
