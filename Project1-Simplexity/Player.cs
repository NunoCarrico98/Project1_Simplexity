using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Simplexity
{
    /// <summary>
    /// Class that manages all Player Inputs.
    /// </summary>
    class Player
    {
        /* Property that defines Player Color */
        public Color Color { get; }

        /* Properties that save Cube and Cilinder numbers */
        public int CubeNumber { get; private set; }
        public int CilinderNumber { get; private set; }
        
        /// <summary>
        /// Constructur Method that instantiates a Player.
        /// </summary>
        public Player()
        {
        }
        
        /// <summary>
        /// Constructor Method that instantiate Players Color, Cube and Cilinder
        /// number. 
        /// </summary>
        /// <param name="color"> Variable that contains Player Color (White/Red) </param>
        public Player (Color color)
        {
            /* Initializes number of Cubes and Cilinders for each defined Color */
            this.Color = color;
            this.CubeNumber = 11;
            this.CilinderNumber = 10;
        }

        /// <summary>
        /// Method that checks if the player has pieces.
        /// </summary>
        /// <returns> Returns Yes or No </returns>
        public bool HavePieces()
        {
            /* Condition that checks if player has pieces*/
            if (CubeNumber > 0 && CilinderNumber > 0) return true;
            else return false;
        }

        /// <summary>
        /// Method that asks for Column.
        /// </summary>
        /// <returns> Returns Column </returns>
        public int GetColumn()
        {
            /* Variables that save Player Input (Column) */
            string read = "";
            int move = 0;

            /* Ask and Save user Input (Column) */
            Console.Write("Insert column: ");
            read = Console.ReadLine();
            Console.WriteLine();
            move = Convert.ToInt32(read);

            /* Performs cycle while Input is invalid */
            while (move > 7 || move < 1)
            {
                /* Reask User Input */
                Console.WriteLine(">>>>> Invalid Input! <<<<<");
                Console.Write("Insert column: ");
                read = Console.ReadLine();
                Console.WriteLine();
                move = Convert.ToInt32(read);
            }

            /* Returns Column number */
            return move;
        }

        /// <summary>
        /// Method that asks for Player piece shape.
        /// </summary>
        /// <returns> Returns Piece </returns>
        public Piece GetShape()
        {
            /* Variable that saves Player Input (Shape) */
            string read = "";

            /* Ask and Save User Input (Shape) */
            Console.WriteLine("What shape do you want to play?");
            /* Show Cube and Cilinder number */
            Console.WriteLine($"1 - Cube({CubeNumber})");
            Console.WriteLine($"2 - Cilinder({CilinderNumber})");
            Console.Write("Shape: ");
            read = Console.ReadLine();
            Console.WriteLine();

            /* Calls GetPlayerPiece() and Returns Piece */
            return GetPlayerPiece(read); 
        }

        /// <summary>
        /// Method that defines Player Piece
        /// </summary>
        /// <param name="read"> Variable that contains Player Input </param>
        /// <returns> Returns Player Piece </returns>
        public Piece GetPlayerPiece(string read)
        {
            /* Initializes Player Piece */
            Piece playerPiece = Piece.None; 

            switch (read) 
            {
                /* If Player chooses Cube */
                case "1":
                    /* If Player does not have Cubes */
                    if (CubeNumber == 0)
                    {
                        /* Asks for a new shape */
                        Console.WriteLine(">>>>> No Cubes left <<<<<");
                        playerPiece = GetShape();
                    }
                    /* If Player has Cubes */
                    else
                    {
                        /* If Player1 is playing */
                        if (Color == Color.White)
                        {
                            /* Sets Player Piece to return */
                            playerPiece = Piece.WhiteCube;
                            /* Decreases to the number of cubes */
                            CubeNumber--;
                        }
                        /* If Player2 is Playing */
                        else
                        {
                            /* Sets Player Piece to return */
                            playerPiece = Piece.RedCube;
                            /* Decreases to the number of cubes */
                            CubeNumber--;
                        }
                    }
                    break;
                /* If Player chooses Cilinder */
                case "2":
                    /* If Player does not have Cilinders */
                    if (CilinderNumber == 0)
                    {
                        /* Asks for a new shape */
                        Console.WriteLine(">>>>> No Cilinders left <<<<<");
                        playerPiece = GetShape();
                    }
                    /* If Player has Cilinders */ 
                    else
                    {
                        /* If Player1 is playing */
                        if (Color == Color.White)
                        {
                            /* Sets Player Piece to return */
                            playerPiece = Piece.WhiteCilinder;
                            /* Decreases to the number of cilinders */
                            CilinderNumber--;
                        }
                        /* If player2 is playing */
                        else
                        {
                            /* Sets Player Piece to return */
                            playerPiece = Piece.RedCilinder;
                            /* Decreases to the number of cilinders */
                            CilinderNumber--;
                        }
                    }
                    break;
                /* If input is Invalid */
                default:
                    /* Asks for a new shape */
                    Console.WriteLine(">>>>> Invalid Input! <<<<<");
                    playerPiece = GetShape();
                    break;                                       
            }
            /* Returns Player Piece */
            return playerPiece;
        }
    }
}
