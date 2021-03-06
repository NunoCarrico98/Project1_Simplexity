﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Simplexity
{
    /// <summary>
    /// Class that defines a coordinate
    /// </summary>
    class Coordinates
    {
        /// <summary>
        /// Property that defines the Coordinate X.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Property that defines the Coordinate Y.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Constructor Method that instantiates a new Coordinate
        /// </summary>
        /// <param name="x"> Variable that contains x coordinate </param>
        /// <param name="y"> Variable that contains y coordinate </param>
        public Coordinates(int x, int y)
        {
            /* Initializes x and y properties */
            this.X = x;
            this.Y = y;
        }
    }
}
