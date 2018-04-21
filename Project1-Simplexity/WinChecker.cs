using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Simplexity
{
    class WinChecker
    {
        public bool CheckDraw(Player player1, Player player2)
        {
            if (!player1.HavePieces() && !player2.HavePieces()) return true;
            else return false;
        }
    }
}
