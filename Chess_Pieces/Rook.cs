using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA {
    class Rook : Piece {
        public Rook(Color color, int priority, int x, int y) : base(color, priority, x, y ) {
            moved = false;
            image = color == Color.White ? (Proiect_IA.Properties.Resources.rook_w) : (Proiect_IA.Properties.Resources.rook_b_d);
            priority = 525;
        }

        public override void enable() {
            image = color == Color.White ? (Proiect_IA.Properties.Resources.rook_w) : (Proiect_IA.Properties.Resources.rook_b);
        }
        public override void disable() {
            image = color == Color.White ? (Proiect_IA.Properties.Resources.rook_w_d) : (Proiect_IA.Properties.Resources.rook_b_d);
        }

        public override void Move(int Xcoord, int Ycoord, Box[,] board) {
            //collum possible move under the rook
            for (int i = 1; i < boardSize; i++)
                if (Xcoord + i < boardSize)
                    if (board[Xcoord + i, Ycoord].isOccupied == false) {
                        board[Xcoord + i, Ycoord].panel.BackColor = Color.DarkSeaGreen;
                        board[Xcoord + i, Ycoord].nextLegalMove = true;
                    }
                    else if (board[Xcoord + i, Ycoord].piece.color != color) {
                        board[Xcoord + i, Ycoord].panel.BackColor = Color.DarkSeaGreen;
                        board[Xcoord + i, Ycoord].nextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;


            //raw possible move to the right of the rook
            for (int i = 1; i < boardSize; i++)
                if (Ycoord + i < boardSize)
                    if (board[Xcoord, Ycoord + i].isOccupied == false) {
                        board[Xcoord, Ycoord + i].panel.BackColor = Color.DarkSeaGreen;
                        board[Xcoord, Ycoord + i].nextLegalMove = true;
                    }
                    else if (board[Xcoord, Ycoord + i].piece.color != color) {
                        board[Xcoord, Ycoord + i].panel.BackColor = Color.DarkSeaGreen;
                        board[Xcoord, Ycoord + i].nextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;

            //collum possible move above the rook
            for (int i = 1; i < boardSize; i++)
                if (Xcoord - i >= 0)
                    if (board[Xcoord - i, Ycoord].isOccupied == false) {
                        board[Xcoord - i, Ycoord].panel.BackColor = Color.DarkSeaGreen;
                        board[Xcoord - i, Ycoord].nextLegalMove = true;
                    }
                    else if (board[Xcoord - i, Ycoord].piece.color != color) {
                        board[Xcoord - i, Ycoord].panel.BackColor = Color.DarkSeaGreen;
                        board[Xcoord - i, Ycoord].nextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;

            //possible move to the left of the rook
            for (int i = 1; i < boardSize; i++)
                if (Ycoord - i >= 0)
                    if (board[Xcoord, Ycoord - i].isOccupied == false) {
                        board[Xcoord, Ycoord - i].panel.BackColor = Color.DarkSeaGreen;
                        board[Xcoord, Ycoord - i].nextLegalMove = true;
                    }
                    else if (board[Xcoord, Ycoord - i].piece.color != color) {
                        board[Xcoord, Ycoord - i].panel.BackColor = Color.DarkSeaGreen;
                        board[Xcoord, Ycoord - i].nextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;


        }

        public override void canMove( Box[,] board) {
            int Xcoord = this.x, Ycoord = this.y;
            //collum possible move under the rook
            for (int i = 1; i < boardSize; i++)
                if (Xcoord + i < boardSize)
                    if (board[Xcoord + i, Ycoord].isOccupied == false) {
                        board[Xcoord + i, Ycoord].nextLegalMove = true;
                    }
                    else if (board[Xcoord + i, Ycoord].piece.color != color) {
                        board[Xcoord + i, Ycoord].nextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;


            //raw possible move to the right of the rook
            for (int i = 1; i < boardSize; i++)
                if (Ycoord + i < boardSize)
                    if (board[Xcoord, Ycoord + i].isOccupied == false) {
                        board[Xcoord, Ycoord + i].nextLegalMove = true;
                    }
                    else if (board[Xcoord, Ycoord + i].piece.color != color) {
                        board[Xcoord, Ycoord + i].nextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;

            //collum possible move above the rook
            for (int i = 1; i < boardSize; i++)
                if (Xcoord - i >= 0)
                    if (board[Xcoord - i, Ycoord].isOccupied == false) {
                        board[Xcoord - i, Ycoord].nextLegalMove = true;
                    }
                    else if (board[Xcoord - i, Ycoord].piece.color != color) {
                        board[Xcoord - i, Ycoord].nextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;

            //possible move to the left of the rook
            for (int i = 1; i < boardSize; i++)
                if (Ycoord - i >= 0)
                    if (board[Xcoord, Ycoord - i].isOccupied == false) {
                        board[Xcoord, Ycoord - i].nextLegalMove = true;
                    }
                    else if (board[Xcoord, Ycoord - i].piece.color != color) {
                        board[Xcoord, Ycoord - i].nextLegalMove = true;
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

            //collum possible move under the rook
            for (int i = 1; i < boardSize; i++)
                if (Xcoord + i < boardSize)
                    if (board[Xcoord + i, Ycoord].isOccupied == false) {
                        availableMoves.Add(board[Xcoord + i, Ycoord]);
                    } else if (board[Xcoord + i, Ycoord].piece.color != color) {
                        availableMoves.Add(board[Xcoord + i, Ycoord]);
                        break;
                    } else
                        break;
                else
                    break;


            //raw possible move to the right of the rook
            for (int i = 1; i < boardSize; i++)
                if (Ycoord + i < boardSize)
                    if (board[Xcoord, Ycoord + i].isOccupied == false) {
                        availableMoves.Add(board[Xcoord, Ycoord + i]);
                    } else if (board[Xcoord, Ycoord + i].piece.color != color) {
                        availableMoves.Add(board[Xcoord, Ycoord + i]);
                        break;
                    } else
                        break;
                else
                    break;

            //collum possible move above the rook
            for (int i = 1; i < boardSize; i++)
                if (Xcoord - i >= 0)
                    if (board[Xcoord - i, Ycoord].isOccupied == false) {
                        availableMoves.Add(board[Xcoord - i, Ycoord]);
                    } else if (board[Xcoord - i, Ycoord].piece.color != color) {
                        availableMoves.Add(board[Xcoord - i, Ycoord]);
                        break;
                    } else
                        break;
                else
                    break;

            //possible move to the left of the rook
            for (int i = 1; i < boardSize; i++)
                if (Ycoord - i >= 0)
                    if (board[Xcoord, Ycoord - i].isOccupied == false) {
                        availableMoves.Add(board[Xcoord, Ycoord - i]);
                    } else if (board[Xcoord, Ycoord - i].piece.color != color) {
                        availableMoves.Add(board[Xcoord, Ycoord - i]);
                        break;
                    } else
                        break;
                else
                    break;

            return availableMoves;
        }


    }
}
