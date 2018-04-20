using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Simplexity
{
    class Player
    {
        public int GetColumn()
        {
            string read = "";
            int move = 0;

            Console.WriteLine("Insert column:");
            read = Console.ReadLine();
            move = Convert.ToInt32(read);
            return move;
        }

        
    }
}
