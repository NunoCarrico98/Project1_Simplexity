using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Simplexity
{
    class State
    {
        private Color color;
        private Shape shape;

        public State (Color color, Shape shape)
        {
            this.color = color;
            this.shape = shape;
        }
    }
}
