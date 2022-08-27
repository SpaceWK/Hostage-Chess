using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_IA {
    internal class King : Piece {
        public King(Color color, int priority, int x, int y) : base(color, priority, x, y) {
            moved = false;
            image = color == Color.White ? (Proiect_IA.Properties.Resources.king_w) : (Proiect_IA.Properties.Resources.king_b_d);
            priority = 10000;
        }

        public override void enable() {
            image = color == Color.White ? (Proiect_IA.Properties.Resources.king_w) : (Proiect_IA.Properties.Resources.king_b);
        }
        public override void disable() {
            image = color == Color.White ? (Proiect_IA.Properties.Resources.king_w_d) : (Proiect_IA.Properties.Resources.king_b_d);
        }

        public override void Move(int Xcoord, int Ycoord, Box[,] board) {
            // Rocada mica
            if (moved == false) {
                if (board[Xcoord, Ycoord - 1].isOccupied == false && board[Xcoord, Ycoord - 2].isOccupied == false) {
                    board[Xcoord, Ycoord - 3].nextLegalMove = true;
                    board[Xcoord, Ycoord - 3].panel.BackColor = Color.DarkSeaGreen;
                }
            }

            // Rocada mare
            if (moved == false) {
                if (board[Xcoord, Ycoord + 1].isOccupied == false && board[Xcoord, Ycoord + 2].isOccupied == false && board[Xcoord, Ycoord + 3].isOccupied == false) {
                    board[Xcoord, Ycoord + 4].nextLegalMove = true;
                    board[Xcoord, Ycoord + 4].panel.BackColor = Color.DarkSeaGreen;
                }
            }

            //down move
            if (Xcoord + 1 < boardSize)
                if (board[Xcoord + 1, Ycoord].isOccupied == false) {
                    board[Xcoord + 1, Ycoord].nextLegalMove = true;
                    board[Xcoord + 1, Ycoord].panel.BackColor = Color.DarkSeaGreen;

                }
                else if (board[Xcoord + 1, Ycoord].piece.color != color) {
                    board[Xcoord + 1, Ycoord].nextLegalMove = true;
                    board[Xcoord + 1, Ycoord].panel.BackColor = Color.DarkSeaGreen;

                }


            //upper move
            if (Xcoord - 1 >= 0)
                if (board[Xcoord - 1, Ycoord].isOccupied == false) {
                    board[Xcoord - 1, Ycoord].nextLegalMove = true;
                    board[Xcoord - 1, Ycoord].panel.BackColor = Color.DarkSeaGreen;

                }
                else if (board[Xcoord - 1, Ycoord].piece.color != color) {
                    board[Xcoord - 1, Ycoord].nextLegalMove = true;
                    board[Xcoord - 1, Ycoord].panel.BackColor = Color.DarkSeaGreen;

                }


            //right move
            if (Ycoord + 1 < boardSize)
                if (board[Xcoord, Ycoord + 1].isOccupied == false) {
                    board[Xcoord, Ycoord + 1].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord, Ycoord + 1].nextLegalMove = true;

                }
                else if (board[Xcoord, Ycoord + 1].piece.color != color) {
                    board[Xcoord, Ycoord + 1].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord, Ycoord + 1].nextLegalMove = true;

                }


            //left move
            if (Ycoord - 1 >= 0)
                if (board[Xcoord, Ycoord - 1].isOccupied == false) {
                    board[Xcoord, Ycoord - 1].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord, Ycoord - 1].nextLegalMove = true;

                }
                else if (board[Xcoord, Ycoord - 1].piece.color != color) {
                    board[Xcoord, Ycoord - 1].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord, Ycoord - 1].nextLegalMove = true;

                }


            //down right move
            if (Xcoord + 1 < boardSize && Ycoord + 1 < boardSize)
                if (board[Xcoord + 1, Ycoord + 1].isOccupied == false) {
                    board[Xcoord + 1, Ycoord + 1].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord + 1, Ycoord + 1].nextLegalMove = true;

                }
                else if (board[Xcoord + 1, Ycoord + 1].piece.color != color) {
                    board[Xcoord + 1, Ycoord + 1].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord + 1, Ycoord + 1].nextLegalMove = true;

                }


            //upper right move
            if (Xcoord - 1 >= 0 && Ycoord + 1 < boardSize)
                if (board[Xcoord - 1, Ycoord + 1].isOccupied == false) {
                    board[Xcoord - 1, Ycoord + 1].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord - 1, Ycoord + 1].nextLegalMove = true;

                }
                else if (board[Xcoord - 1, Ycoord + 1].piece.color != color) {
                    board[Xcoord - 1, Ycoord + 1].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord - 1, Ycoord + 1].nextLegalMove = true;

                }


            //down left move
            if (Xcoord + 1 < boardSize && Ycoord - 1 >= 0)
                if (board[Xcoord + 1, Ycoord - 1].isOccupied == false) {
                    board[Xcoord + 1, Ycoord - 1].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord + 1, Ycoord - 1].nextLegalMove = true;

                }
                else  if (board[Xcoord + 1, Ycoord - 1].piece.color != color) {
                    board[Xcoord + 1, Ycoord - 1].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord + 1, Ycoord - 1].nextLegalMove = true;

                }

            //upper left move
            if (Xcoord - 1 >= 0 && Ycoord - 1 >= 0)
                if (board[Xcoord - 1, Ycoord - 1].isOccupied == false) {
                    board[Xcoord - 1, Ycoord - 1].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord - 1, Ycoord - 1].nextLegalMove = true;

                }
                else  if (board[Xcoord - 1, Ycoord - 1].piece.color != color) {
                    board[Xcoord - 1, Ycoord - 1].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord - 1, Ycoord - 1].nextLegalMove = true;

                }

        }

        public override void canMove( Box[,] board) {
            int Xcoord = this.x, Ycoord = this.y;
            //down move
            if (Xcoord + 1 < boardSize)
                if (board[Xcoord + 1, Ycoord].isOccupied == false) {
                    board[Xcoord + 1, Ycoord].nextLegalMove = true;

                }
                else if (board[Xcoord + 1, Ycoord].piece.color != color) {
                    board[Xcoord + 1, Ycoord].nextLegalMove = true;

                }


            //upper move
            if (Xcoord - 1 >= 0)
                if (board[Xcoord - 1, Ycoord].isOccupied == false) {
                    board[Xcoord - 1, Ycoord].nextLegalMove = true;

                }
                else if (board[Xcoord - 1, Ycoord].piece.color != color) {
                    board[Xcoord - 1, Ycoord].nextLegalMove = true;

                }


            //right move
            if (Ycoord + 1 < boardSize)
                if (board[Xcoord, Ycoord + 1].isOccupied == false) {
                    board[Xcoord, Ycoord + 1].nextLegalMove = true;

                }
                else if (board[Xcoord, Ycoord + 1].piece.color != color) {
                    board[Xcoord, Ycoord + 1].nextLegalMove = true;

                }


            //left move
            if (Ycoord - 1 >= 0)
                if (board[Xcoord, Ycoord - 1].isOccupied == false) {
                    board[Xcoord, Ycoord - 1].nextLegalMove = true;

                }
                else if (board[Xcoord, Ycoord - 1].piece.color != color) {
                    board[Xcoord, Ycoord - 1].nextLegalMove = true;

                }


            //down right move
            if (Xcoord + 1 < boardSize && Ycoord + 1 < boardSize)
                if (board[Xcoord + 1, Ycoord + 1].isOccupied == false) {
                    board[Xcoord + 1, Ycoord + 1].nextLegalMove = true;

                }
                else if (board[Xcoord + 1, Ycoord + 1].piece.color != color) {
                    board[Xcoord + 1, Ycoord + 1].nextLegalMove = true;

                }


            //upper right move
            if (Xcoord - 1 >= 0 && Ycoord + 1 < boardSize)
                if (board[Xcoord - 1, Ycoord + 1].isOccupied == false) {
                    board[Xcoord - 1, Ycoord + 1].nextLegalMove = true;

                }
                else if (board[Xcoord - 1, Ycoord + 1].piece.color != color) {
                    board[Xcoord - 1, Ycoord + 1].nextLegalMove = true;

                }


            //down left move
            if (Xcoord + 1 < boardSize && Ycoord - 1 >= 0)
                if (board[Xcoord + 1, Ycoord - 1].isOccupied == false) {
                    board[Xcoord + 1, Ycoord - 1].nextLegalMove = true;

                }
                else if (board[Xcoord + 1, Ycoord - 1].piece.color != color) {
                    board[Xcoord + 1, Ycoord - 1].nextLegalMove = true;

                }

            //upper left move
            if (Xcoord - 1 >= 0 && Ycoord - 1 >= 0)
                if (board[Xcoord - 1, Ycoord - 1].isOccupied == false) {
                    board[Xcoord - 1, Ycoord - 1].nextLegalMove = true;

                }
                else if (board[Xcoord - 1, Ycoord - 1].piece.color != color) {
                    board[Xcoord - 1, Ycoord - 1].nextLegalMove = true;

                }

        }

        public override List<Box> getAvailableMoves(Box[,] board) {
            int Xcoord = this.x, Ycoord = this.y;
            List<Box> availableMoves = new List<Box>();

            //down move
            if (Xcoord + 1 < boardSize)
                if (board[Xcoord + 1, Ycoord].isOccupied == false) {
                    availableMoves.Add(board[Xcoord + 1, Ycoord]);

                } else if (board[Xcoord + 1, Ycoord].piece.color != color) {
                    availableMoves.Add(board[Xcoord + 1, Ycoord]);
                }


            //upper move
            if (Xcoord - 1 >= 0)
                if (board[Xcoord - 1, Ycoord].isOccupied == false) {
                    availableMoves.Add(board[Xcoord - 1, Ycoord]);

                } else if (board[Xcoord - 1, Ycoord].piece.color != color) {
                    availableMoves.Add(board[Xcoord - 1, Ycoord]);
                }


            //right move
            if (Ycoord + 1 < boardSize)
                if (board[Xcoord, Ycoord + 1].isOccupied == false) {
                    availableMoves.Add(board[Xcoord, Ycoord + 1]);
                } else if (board[Xcoord, Ycoord + 1].piece.color != color) {
                    availableMoves.Add(board[Xcoord, Ycoord + 1]);
                }


            //left move
            if (Ycoord - 1 >= 0)
                if (board[Xcoord, Ycoord - 1].isOccupied == false) {
                    availableMoves.Add(board[Xcoord, Ycoord - 1]);
                } else if (board[Xcoord, Ycoord - 1].piece.color != color) {
                    availableMoves.Add(board[Xcoord, Ycoord - 1]);
                }


            //down right move
            if (Xcoord + 1 < boardSize && Ycoord + 1 < boardSize)
                if (board[Xcoord + 1, Ycoord + 1].isOccupied == false) {
                    availableMoves.Add(board[Xcoord + 1, Ycoord + 1]);
                } else if (board[Xcoord + 1, Ycoord + 1].piece.color != color) {
                    availableMoves.Add(board[Xcoord + 1, Ycoord + 1]);
                }


            //upper right move
            if (Xcoord - 1 >= 0 && Ycoord + 1 < boardSize)
                if (board[Xcoord - 1, Ycoord + 1].isOccupied == false) {
                    availableMoves.Add(board[Xcoord - 1, Ycoord + 1]);
                } else if (board[Xcoord - 1, Ycoord + 1].piece.color != color) {
                    availableMoves.Add(board[Xcoord - 1, Ycoord + 1]);
                }


            //down left move
            if (Xcoord + 1 < boardSize && Ycoord - 1 >= 0)
                if (board[Xcoord + 1, Ycoord - 1].isOccupied == false) {
                    availableMoves.Add(board[Xcoord + 1, Ycoord - 1]);
                } else if (board[Xcoord + 1, Ycoord - 1].piece.color != color) {
                    availableMoves.Add(board[Xcoord + 1, Ycoord - 1]);
                }

            //upper left move
            if (Xcoord - 1 >= 0 && Ycoord - 1 >= 0)
                if (board[Xcoord - 1, Ycoord - 1].isOccupied == false) {
                    availableMoves.Add(board[Xcoord - 1, Ycoord - 1]);
                } else if (board[Xcoord - 1, Ycoord - 1].piece.color != color) {
                    availableMoves.Add(board[Xcoord - 1, Ycoord - 1]);
                }

            return availableMoves;
        }

        public override void checkKingMove(int Xcoord, int Ycoord, Box[,] board) {

            //down move
            if (Xcoord + 1 < boardSize)
                if (board[Xcoord + 1, Ycoord].isOccupied == false && board[Xcoord + 1, Ycoord].nextLegalMove != true) {    
                    board[Xcoord + 1, Ycoord].panel.BackColor = Color.DarkSeaGreen;


                }
                else if (board[Xcoord + 1, Ycoord].piece.color != color && board[Xcoord + 1, Ycoord].nextLegalMove != true) {
                    board[Xcoord + 1, Ycoord].panel.BackColor = Color.DarkSeaGreen;


                }


            //upper move
            if (Xcoord - 1 >= 0)
                if (board[Xcoord - 1, Ycoord].isOccupied == false && board[Xcoord - 1, Ycoord].nextLegalMove != true) {         
                    board[Xcoord - 1, Ycoord].panel.BackColor = Color.DarkSeaGreen;

                }
                else if (board[Xcoord - 1, Ycoord].piece.color != color && board[Xcoord - 1, Ycoord].nextLegalMove != true) {             
                    board[Xcoord - 1, Ycoord].panel.BackColor = Color.DarkSeaGreen;

                }


            //right move
            if (Ycoord + 1 < boardSize)
                if (board[Xcoord, Ycoord + 1].isOccupied == false && board[Xcoord, Ycoord + 1].nextLegalMove != true) {
                    board[Xcoord, Ycoord + 1].panel.BackColor = Color.DarkSeaGreen;


                }
                else if (board[Xcoord, Ycoord + 1].piece.color != color && board[Xcoord, Ycoord + 1].nextLegalMove != true) {
                    board[Xcoord, Ycoord + 1].panel.BackColor = Color.DarkSeaGreen;

                }


            //left move
            if (Ycoord - 1 >= 0)
                if (board[Xcoord, Ycoord - 1].isOccupied == false && board[Xcoord, Ycoord - 1].nextLegalMove != true) {
                    board[Xcoord, Ycoord - 1].panel.BackColor = Color.DarkSeaGreen;


                }
                else if (board[Xcoord, Ycoord - 1].piece.color != color && board[Xcoord, Ycoord - 1].nextLegalMove != true) {
                    board[Xcoord, Ycoord - 1].panel.BackColor = Color.DarkSeaGreen;

                }


            //down right move
            if (Xcoord + 1 < boardSize && Ycoord + 1 < boardSize)
                if (board[Xcoord + 1, Ycoord + 1].isOccupied == false && board[Xcoord + 1 , Ycoord + 1].nextLegalMove != true) {
                    board[Xcoord + 1, Ycoord + 1].panel.BackColor = Color.DarkSeaGreen;


                }
                else if (board[Xcoord + 1, Ycoord + 1].piece.color != color && board[Xcoord + 1, Ycoord + 1].nextLegalMove != true) {
                    board[Xcoord + 1, Ycoord + 1].panel.BackColor = Color.DarkSeaGreen;

                }


            //upper right move
            if (Xcoord - 1 >= 0 && Ycoord + 1 < boardSize)
                if (board[Xcoord - 1, Ycoord + 1].isOccupied == false && board[Xcoord - 1, Ycoord + 1].nextLegalMove != true)  {
                    board[Xcoord - 1, Ycoord + 1].panel.BackColor = Color.DarkSeaGreen;


                }
                else if (board[Xcoord - 1, Ycoord + 1].piece.color != color && board[Xcoord - 1, Ycoord + 1].nextLegalMove != true) {
                    board[Xcoord - 1, Ycoord + 1].panel.BackColor = Color.DarkSeaGreen;


                }


            //down left move
            if (Xcoord + 1 < boardSize && Ycoord - 1 >= 0)
                if (board[Xcoord + 1, Ycoord - 1].isOccupied == false && board[Xcoord + 1, Ycoord - 1].nextLegalMove != true) {
                    board[Xcoord + 1, Ycoord - 1].panel.BackColor = Color.DarkSeaGreen;


                }
                else if (board[Xcoord + 1, Ycoord - 1].piece.color != color && board[Xcoord + 1, Ycoord - 1].nextLegalMove != true) {
                    board[Xcoord + 1, Ycoord - 1].panel.BackColor = Color.DarkSeaGreen;


                }

            //upper left move
            if (Xcoord - 1 >= 0 && Ycoord - 1 >= 0)
                if (board[Xcoord - 1, Ycoord - 1].isOccupied == false && board[Xcoord - 1, Ycoord - 1].nextLegalMove != true) {
                    board[Xcoord - 1, Ycoord - 1].panel.BackColor = Color.DarkSeaGreen;

                }
                else if (board[Xcoord - 1, Ycoord - 1].piece.color != color && board[Xcoord - 1, Ycoord - 1].nextLegalMove != true) {
                    board[Xcoord - 1, Ycoord - 1].panel.BackColor = Color.DarkSeaGreen;
                }
        }

    }
}
