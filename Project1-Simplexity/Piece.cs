using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Simplexity
{
    class Piece
    {
        public Color Color { get;}
        public Shape Shape { get;}

        public Piece (Color color, Shape shape)
        {
            this.Color = color;
            this.Shape = shape;
        }
    }
}
