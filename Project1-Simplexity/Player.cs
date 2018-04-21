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

        public Player (Color color)
        {
            this.Color = color;
        }

        public int GetColumn()
        {
            string read = "";
            int move = 0;

            Console.WriteLine("Insert column:");
            read = Console.ReadLine();
            move = Convert.ToInt32(read);
            return move;
        }

        public Piece GetShape()
        {
            string read = "";

            Console.WriteLine("What Shape do you want to play? 1:Cube  2:Cilinder");
            read = Console.ReadLine();

            return GetPlayerPiece(read); 
           


        }

        public Piece GetPlayerPiece(string read)
        {
            Piece playerPiece = Piece.None; 

            switch (read) 
            {
                case "1":
                    if (Color == Color.White)
                    {
                        playerPiece = Piece.WhiteCube;
                    }
                    else
                    {
                        playerPiece = Piece.RedCube;
                    }
                    break;

                case "2":
                    if (Color == Color.White)
                    {
                        playerPiece = Piece.WhiteCilinder;
                    }
                    else
                    {
                        playerPiece = Piece.RedCilinder;
                    }
                    break;
                default:
                    GetShape();
                    break;
                    
                    
            }
            return playerPiece;

        }


    }
}
