using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Simplexity
{
    /// <summary>
    /// Class that runs the game
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main function.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /* Variables to initialize game */
            Board board = new Board();
            Renderer render = new Renderer();
            WinChecker winChecker = new WinChecker();
            Game game = new Game();
            Coordinates lastPosPlayed;

            /* GameLoop. Returns last coordinates played. */
            lastPosPlayed = game.GameLoop(board, render);

            /* Last board render */
            render.Render(board);
            /* Render the winnner according to verification */
            render.RenderResults(winChecker.Check(board, lastPosPlayed));
        }
    }
}
