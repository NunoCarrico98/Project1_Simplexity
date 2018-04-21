using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Simplexity
{
    class Player
    {
        public Color Color { get; }

        public int CubeNumber { get; private set; }
        public int CilinderNumber { get; private set; }
        
        public Player()
        {
        }
        
        public Player (Color color)
        {
            this.Color = color;
            this.CubeNumber = 11;
            this.CilinderNumber = 10;
        }

        public bool HavePieces()
        {
            if (CubeNumber > 0 && CilinderNumber > 0) return true;
            else return false;
        }

        public int GetColumn()
        {
            string read = "";
            int move = 0;

            Console.Write("Insert column: ");
            read = Console.ReadLine();
            Console.WriteLine();
            move = Convert.ToInt32(read);

            while (move > 7 || move < 1)
            {
                Console.WriteLine("Invalid Input!");
                Console.Write("Insert column: ");
                read = Console.ReadLine();
                Console.WriteLine();
                move = Convert.ToInt32(read);
            }

            return move;
        }

        public Piece GetShape()
        {
            string read = "";

            Console.WriteLine("What shape do you want to play?");
            Console.WriteLine($"1 - Cube({CubeNumber})\n2 - Cilinder({CilinderNumber})");
            Console.Write("Shape: ");
            read = Console.ReadLine();
            Console.WriteLine();

            return GetPlayerPiece(read); 
        }

        public Piece GetPlayerPiece(string read)
        {
            Piece playerPiece = Piece.None; 

            switch (read) 
            {
                case "1":
                    if (CubeNumber == 0)
                    {
                        Console.WriteLine("No Cubes left");
                        playerPiece = GetShape();
                    }
                    else
                    {
                        if (Color == Color.White)
                        {
                            playerPiece = Piece.WhiteCube;
                            CubeNumber--;
                        }
                        else
                        {
                            playerPiece = Piece.RedCube;
                            CubeNumber--;
                        }
                    }
                    break;
                case "2":
                    if (CilinderNumber == 0)
                    {
                        Console.WriteLine("No Cilinders left");
                        playerPiece = GetShape();
                    }
                    else
                    {
                        if (Color == Color.White)
                        {
                            playerPiece = Piece.WhiteCilinder;
                            CilinderNumber--;
                        }
                        else
                        {
                            playerPiece = Piece.RedCilinder;
                            CilinderNumber--;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    playerPiece = GetShape();
                    break;                                       
            }
            return playerPiece;
        }
    }
}
