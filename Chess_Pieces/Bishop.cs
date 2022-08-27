using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA {
    internal class Bishop : Piece {
        public Bishop(Color color, int priority, int x, int y) : base(color, priority, x, y) {
            image = color == Color.White ? (Proiect_IA.Properties.Resources.bishop_w) : (Proiect_IA.Properties.Resources.bishop_b_d);
            priority = 350;
        }

        public override void enable() {
            image = color == Color.White ? (Proiect_IA.Properties.Resources.bishop_w) : (Proiect_IA.Properties.Resources.bishop_b);
        }
        public override void disable() {
            image = color == Color.White ? (Proiect_IA.Properties.Resources.bishop_w_d) : (Proiect_IA.Properties.Resources.bishop_b_d);
        }

        public override void Move(int Xcoord, int Ycoord, Box[,] board) {
            //down right move
            for (int i = 1; i < boardSize; i++)
                if (Xcoord + i < boardSize && Ycoord + i < boardSize)
                    if (board[Xcoord + i, Ycoord + i].isOccupied == false) {
                        board[Xcoord + i, Ycoord + i].panel.BackColor = Color.DarkSeaGreen;
                        board[Xcoord + i, Ycoord + i].nextLegalMove = true;
                    }
                    else
                        if (board[Xcoord + i, Ycoord + i].piece.color != color) {
                        board[Xcoord + i, Ycoord + i].panel.BackColor = Color.DarkSeaGreen;
                        board[Xcoord + i, Ycoord + i].nextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;


            //upper right move
            for (int i = 1; i < boardSize; i++)
                if (Xcoord - i >= 0 && Ycoord + i < boardSize)
                    if (board[Xcoord - i, Ycoord + i].isOccupied == false) {
                        board[Xcoord - i, Ycoord + i].panel.BackColor = Color.DarkSeaGreen;
                        board[Xcoord - i, Ycoord + i].nextLegalMove = true;
                    }
                    else
                        if (board[Xcoord - i, Ycoord + i].piece.color != color) {
                        board[Xcoord - i, Ycoord + i].panel.BackColor = Color.DarkSeaGreen;
                        board[Xcoord - i, Ycoord + i].nextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;


            //down left move
            for (int i = 1; i < boardSize; i++)
                if (Xcoord + i < boardSize && Ycoord - i >= 0)
                    if (board[Xcoord + i, Ycoord - i].isOccupied == false) {
                        board[Xcoord + i, Ycoord - i].panel.BackColor = Color.DarkSeaGreen;
                        board[Xcoord + i, Ycoord - i].nextLegalMove = true;
                    } else if (board[Xcoord + i, Ycoord - i].piece.color != color) {
                        board[Xcoord + i, Ycoord - i].panel.BackColor = Color.DarkSeaGreen;
                        board[Xcoord + i, Ycoord - i].nextLegalMove = true;
                        break;
                    } 
                    else
                        break;
                else
                    break;


            //upper left move
            for (int i = 1; i < boardSize; i++)
                if (Xcoord - i >= 0 && Ycoord - i >= 0)
                    if (board[Xcoord - i, Ycoord - i].isOccupied == false) {
                        board[Xcoord - i, Ycoord - i].panel.BackColor = Color.DarkSeaGreen;
                        board[Xcoord - i, Ycoord - i].nextLegalMove = true;
                    }
                    else
                        if (board[Xcoord - i, Ycoord - i].piece.color != color) {
                        board[Xcoord - i, Ycoord - i].panel.BackColor = Color.DarkSeaGreen;
                        board[Xcoord - i, Ycoord - i].nextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;



        }

        public override void canMove( Box[,] board) {
            int Xcoord = this.x, Ycoord = this.y;
            //down right move
            for (int i = 1; i < boardSize; i++)
                if (Xcoord + i < boardSize && Ycoord + i < boardSize)
                    if (board[Xcoord + i, Ycoord + i].isOccupied == false) {
                        board[Xcoord + i, Ycoord + i].nextLegalMove = true;
                    }
                    else
                        if (board[Xcoord + i, Ycoord + i].piece.color != color) {
                        board[Xcoord + i, Ycoord + i].nextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;


            //upper right move
            for (int i = 1; i < boardSize; i++)
                if (Xcoord - i >= 0 && Ycoord + i < boardSize)
                    if (board[Xcoord - i, Ycoord + i].isOccupied == false) {
                        board[Xcoord - i, Ycoord + i].nextLegalMove = true;
                    }
                    else
                        if (board[Xcoord - i, Ycoord + i].piece.color != color) {
                        board[Xcoord - i, Ycoord + i].nextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;


            //down left move
            for (int i = 1; i < boardSize; i++)
                if (Xcoord + i < boardSize && Ycoord - i >= 0)
                    if (board[Xcoord + i, Ycoord - i].isOccupied == false) {
                        board[Xcoord + i, Ycoord - i].nextLegalMove = true;
                    }
                    else if (board[Xcoord + i, Ycoord - i].piece.color != color) {
                        board[Xcoord + i, Ycoord - i].nextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;


            //upper left move
            for (int i = 1; i < boardSize; i++)
                if (Xcoord - i >= 0 && Ycoord - i >= 0)
                    if (board[Xcoord - i, Ycoord - i].isOccupied == false) {
                        board[Xcoord - i, Ycoord - i].nextLegalMove = true;
                    }
                    else
                        if (board[Xcoord - i, Ycoord - i].piece.color != color) {
                        board[Xcoord - i, Ycoord - i].nextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;
        }


        public override List<Box> getAvailableMoves(Box[,] board) {
            int Xcoord = this.x, Ycoord = this.y;
            List<Box> availableMoves = new List<Box>();

            //down right move
            for (int i = 1; i < boardSize; i++)
                if (Xcoord + i < boardSize && Ycoord + i < boardSize)
                    if (board[Xcoord + i, Ycoord + i].isOccupied == false) {
                        availableMoves.Add(board[Xcoord + i, Ycoord + i]);
                    } else
                        if (board[Xcoord + i, Ycoord + i].piece.color != color) {
                        availableMoves.Add(board[Xcoord + i, Ycoord + i]);
                        break;
                    } else
                        break;
                else
                    break;


            //upper right move
            for (int i = 1; i < boardSize; i++)
                if (Xcoord - i >= 0 && Ycoord + i < boardSize)
                    if (board[Xcoord - i, Ycoord + i].isOccupied == false) {
                        availableMoves.Add(board[Xcoord - i, Ycoord + i]);
                    } else
                        if (board[Xcoord - i, Ycoord + i].piece.color != color) {
                        availableMoves.Add(board[Xcoord - i, Ycoord + i]);
                        break;
                    } else
                        break;
                else
                    break;


            //down left move
            for (int i = 1; i < boardSize; i++)
                if (Xcoord + i < boardSize && Ycoord - i >= 0)
                    if (board[Xcoord + i, Ycoord - i].isOccupied == false) {
                        availableMoves.Add(board[Xcoord + i, Ycoord - i]);
                    } else if (board[Xcoord + i, Ycoord - i].piece.color != color) {
                        availableMoves.Add(board[Xcoord + i, Ycoord - i]);
                        break;
                    } else
                        break;
                else
                    break;


            //upper left move
            for (int i = 1; i < boardSize; i++)
                if (Xcoord - i >= 0 && Ycoord - i >= 0)
                    if (board[Xcoord - i, Ycoord - i].isOccupied == false) {
                        availableMoves.Add(board[Xcoord - i, Ycoord - i]);
                    } else
                        if (board[Xcoord - i, Ycoord - i].piece.color != color) {
                        availableMoves.Add(board[Xcoord - i, Ycoord - i]);
                        break;
                    } else
                        break;
                else
                    break;

            return availableMoves;
        }
    }
}
