using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA {
    class Knight : Piece {
        public Knight(Color color, int priority, int x, int y) : base(color, priority, x, y) {
            image = color == Color.White ? (Proiect_IA.Properties.Resources.knight_w) : (Proiect_IA.Properties.Resources.knight_b_d);
            priority = 350;
        }

        public override void enable() {
            image = color == Color.White ? (Proiect_IA.Properties.Resources.knight_w) : (Proiect_IA.Properties.Resources.knight_b);
        }
        public override void disable() {
            image = color == Color.White ? (Proiect_IA.Properties.Resources.knight_w_d) : (Proiect_IA.Properties.Resources.knight_b_d);
        }

        public override void Move(int Xcoord, int Ycoord, Box[,] board) {
            //upper right
            if (Xcoord - 2 >= 0 && Ycoord + 1 < boardSize)
                if (board[Xcoord - 2, Ycoord + 1].isOccupied == false) {
                    board[Xcoord - 2, Ycoord + 1].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord - 2, Ycoord + 1].nextLegalMove = true;
                }
                else
                    if (board[Xcoord - 2, Ycoord + 1].piece.color != color) {
                    board[Xcoord - 2, Ycoord + 1].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord - 2, Ycoord + 1].nextLegalMove = true;
                }

            //upper left
            if (Xcoord - 2 >= 0 && Ycoord - 1 >= 0)
                if (board[Xcoord - 2, Ycoord - 1].isOccupied == false) {
                    board[Xcoord - 2, Ycoord - 1].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord - 2, Ycoord - 1].nextLegalMove = true;
                }
                else
                    if (board[Xcoord - 2, Ycoord - 1].piece.color != color) {
                    board[Xcoord - 2, Ycoord - 1].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord - 2, Ycoord - 1].nextLegalMove = true;
                }

            //lower right
            if (Xcoord + 2 < boardSize && Ycoord + 1 < boardSize)
                if (board[Xcoord + 2, Ycoord + 1].isOccupied == false) {
                    board[Xcoord + 2, Ycoord + 1].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord + 2, Ycoord + 1].nextLegalMove = true;
                }
                else
                    if (board[Xcoord + 2, Ycoord + 1].piece.color != color) {
                    board[Xcoord + 2, Ycoord + 1].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord + 2, Ycoord + 1].nextLegalMove = true;
                }

            ///lower left
            if (Xcoord + 2 < boardSize && Ycoord - 1 >= 0)
                if (board[Xcoord + 2, Ycoord - 1].isOccupied == false) {
                    board[Xcoord + 2, Ycoord - 1].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord + 2, Ycoord - 1].nextLegalMove = true;
                }
                else
                    if (board[Xcoord + 2, Ycoord - 1].piece.color != color) {
                    board[Xcoord + 2, Ycoord - 1].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord + 2, Ycoord - 1].nextLegalMove = true;
                }

            //left upper
            if (Xcoord - 1 >= 0 && Ycoord - 2 >= 0)
                if (board[Xcoord - 1, Ycoord - 2].isOccupied == false) {
                    board[Xcoord - 1, Ycoord - 2].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord - 1, Ycoord - 2].nextLegalMove = true;
                }
                else
                      if (board[Xcoord - 1, Ycoord - 2].piece.color != color) {
                    board[Xcoord - 1, Ycoord - 2].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord - 1, Ycoord - 2].nextLegalMove = true;
                }


            //left down
            if (Xcoord + 1 < boardSize && Ycoord - 2 >= 0)
                if (board[Xcoord + 1, Ycoord - 2].isOccupied == false) {
                    board[Xcoord + 1, Ycoord - 2].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord + 1, Ycoord - 2].nextLegalMove = true;
                }
                else
                      if (board[Xcoord + 1, Ycoord - 2].piece.color != color) {
                    board[Xcoord + 1, Ycoord - 2].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord + 1, Ycoord - 2].nextLegalMove = true;
                }

            //right upper
            if (Xcoord - 1 >= 0 && Ycoord + 2 < boardSize)
                if (board[Xcoord - 1, Ycoord + 2].isOccupied == false) {
                    board[Xcoord - 1, Ycoord + 2].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord - 1, Ycoord + 2].nextLegalMove = true;
                }
                else
                      if (board[Xcoord - 1, Ycoord + 2].piece.color != color) {
                    board[Xcoord - 1, Ycoord + 2].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord - 1, Ycoord + 2].nextLegalMove = true;
                }

            //right down
            if (Xcoord + 1 < boardSize && Ycoord + 2 < boardSize)
                if (board[Xcoord + 1, Ycoord + 2].isOccupied == false) {
                    board[Xcoord + 1, Ycoord + 2].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord + 1, Ycoord + 2].nextLegalMove = true;
                }
                else
                      if (board[Xcoord + 1, Ycoord + 2].piece.color != color) {
                    board[Xcoord + 1, Ycoord + 2].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord + 1, Ycoord + 2].nextLegalMove = true;
                }

        }

        public override void canMove( Box[,] board) {
            int Xcoord = this.x, Ycoord = this.y;
            //upper right
            if (Xcoord - 2 >= 0 && Ycoord + 1 < boardSize)
                if (board[Xcoord - 2, Ycoord + 1].isOccupied == false) {
                    board[Xcoord - 2, Ycoord + 1].nextLegalMove = true;
                }
                else
                    if (board[Xcoord - 2, Ycoord + 1].piece.color != color) {
                    board[Xcoord - 2, Ycoord + 1].nextLegalMove = true;
                }

            //upper left
            if (Xcoord - 2 >= 0 && Ycoord - 1 >= 0)
                if (board[Xcoord - 2, Ycoord - 1].isOccupied == false) {
                    board[Xcoord - 2, Ycoord - 1].nextLegalMove = true;
                }
                else
                    if (board[Xcoord - 2, Ycoord - 1].piece.color != color) {
                    board[Xcoord - 2, Ycoord - 1].nextLegalMove = true;
                }

            //lower right
            if (Xcoord + 2 < boardSize && Ycoord + 1 < boardSize)
                if (board[Xcoord + 2, Ycoord + 1].isOccupied == false) {
                    board[Xcoord + 2, Ycoord + 1].nextLegalMove = true;
                }
                else
                    if (board[Xcoord + 2, Ycoord + 1].piece.color != color) {
                    board[Xcoord + 2, Ycoord + 1].nextLegalMove = true;
                }

            ///lower left
            if (Xcoord + 2 < boardSize && Ycoord - 1 >= 0)
                if (board[Xcoord + 2, Ycoord - 1].isOccupied == false) {
                    board[Xcoord + 2, Ycoord - 1].nextLegalMove = true;
                }
                else
                    if (board[Xcoord + 2, Ycoord - 1].piece.color != color) {
                    board[Xcoord + 2, Ycoord - 1].nextLegalMove = true;
                }

            //left upper
            if (Xcoord - 1 >= 0 && Ycoord - 2 >= 0)
                if (board[Xcoord - 1, Ycoord - 2].isOccupied == false) {
                    board[Xcoord - 1, Ycoord - 2].nextLegalMove = true;
                }
                else
                      if (board[Xcoord - 1, Ycoord - 2].piece.color != color) {
                    board[Xcoord - 1, Ycoord - 2].nextLegalMove = true;
                }


            //left down
            if (Xcoord + 1 < boardSize && Ycoord - 2 >= 0)
                if (board[Xcoord + 1, Ycoord - 2].isOccupied == false) {
                    board[Xcoord + 1, Ycoord - 2].nextLegalMove = true;
                }
                else
                      if (board[Xcoord + 1, Ycoord - 2].piece.color != color) {
                    board[Xcoord + 1, Ycoord - 2].nextLegalMove = true;
                }

            //right upper
            if (Xcoord - 1 >= 0 && Ycoord + 2 < boardSize)
                if (board[Xcoord - 1, Ycoord + 2].isOccupied == false) {
                    board[Xcoord - 1, Ycoord + 2].nextLegalMove = true;
                }
                else
                      if (board[Xcoord - 1, Ycoord + 2].piece.color != color) {
                    board[Xcoord - 1, Ycoord + 2].nextLegalMove = true;
                }

            //right down
            if (Xcoord + 1 < boardSize && Ycoord + 2 < boardSize)
                if (board[Xcoord + 1, Ycoord + 2].isOccupied == false) {
                    board[Xcoord + 1, Ycoord + 2].nextLegalMove = true;
                }
                else
                      if (board[Xcoord + 1, Ycoord + 2].piece.color != color) {
                    board[Xcoord + 1, Ycoord + 2].nextLegalMove = true;
                }

        }

        public override List<Box> getAvailableMoves(Box[,] board) {
            int Xcoord = this.x, Ycoord = this.y;
            List<Box> availableMoves = new List<Box>();

            //upper right
            if (Xcoord - 2 >= 0 && Ycoord + 1 < boardSize)
                if (board[Xcoord - 2, Ycoord + 1].isOccupied == false) {
                    availableMoves.Add(board[Xcoord - 2, Ycoord + 1]);
                } else
                    if (board[Xcoord - 2, Ycoord + 1].piece.color != color) {
                    availableMoves.Add(board[Xcoord - 2, Ycoord + 1]);
                }

            //upper left
            if (Xcoord - 2 >= 0 && Ycoord - 1 >= 0)
                if (board[Xcoord - 2, Ycoord - 1].isOccupied == false) {
                    availableMoves.Add(board[Xcoord - 2, Ycoord - 1]);
                } else
                    if (board[Xcoord - 2, Ycoord - 1].piece.color != color) {
                    availableMoves.Add(board[Xcoord - 2, Ycoord - 1]);
                }

            //lower right
            if (Xcoord + 2 < boardSize && Ycoord + 1 < boardSize)
                if (board[Xcoord + 2, Ycoord + 1].isOccupied == false) {
                    availableMoves.Add(board[Xcoord + 2, Ycoord + 1]);
                } else
                    if (board[Xcoord + 2, Ycoord + 1].piece.color != color) {
                    availableMoves.Add(board[Xcoord + 2, Ycoord + 1]);
                }

            ///lower left
            if (Xcoord + 2 < boardSize && Ycoord - 1 >= 0)
                if (board[Xcoord + 2, Ycoord - 1].isOccupied == false) {
                    availableMoves.Add(board[Xcoord + 2, Ycoord - 1]);
                } else
                    if (board[Xcoord + 2, Ycoord - 1].piece.color != color) {
                    availableMoves.Add(board[Xcoord + 2, Ycoord - 1]);
                }

            //left upper
            if (Xcoord - 1 >= 0 && Ycoord - 2 >= 0)
                if (board[Xcoord - 1, Ycoord - 2].isOccupied == false) {
                    availableMoves.Add(board[Xcoord - 1, Ycoord - 2]);
                } else
                      if (board[Xcoord - 1, Ycoord - 2].piece.color != color) {
                    availableMoves.Add(board[Xcoord - 1, Ycoord - 2]);
                }


            //left down
            if (Xcoord + 1 < boardSize && Ycoord - 2 >= 0)
                if (board[Xcoord + 1, Ycoord - 2].isOccupied == false) {
                    availableMoves.Add(board[Xcoord + 1, Ycoord - 2]);
                } else
                      if (board[Xcoord + 1, Ycoord - 2].piece.color != color) {
                    availableMoves.Add(board[Xcoord + 1, Ycoord - 2]);
                }

            //right upper
            if (Xcoord - 1 >= 0 && Ycoord + 2 < boardSize)
                if (board[Xcoord - 1, Ycoord + 2].isOccupied == false) {
                    availableMoves.Add(board[Xcoord - 1, Ycoord + 2]);
                } else
                      if (board[Xcoord - 1, Ycoord + 2].piece.color != color) {
                    availableMoves.Add(board[Xcoord - 1, Ycoord + 2]);
                }

            //right down
            if (Xcoord + 1 < boardSize && Ycoord + 2 < boardSize)
                if (board[Xcoord + 1, Ycoord + 2].isOccupied == false) {
                    availableMoves.Add(board[Xcoord + 1, Ycoord + 2]);
                } else
                      if (board[Xcoord + 1, Ycoord + 2].piece.color != color) {
                    availableMoves.Add(board[Xcoord + 1, Ycoord + 2]);
                }

            return availableMoves;
        }
    }
}
