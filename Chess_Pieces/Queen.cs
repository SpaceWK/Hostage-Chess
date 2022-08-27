using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA {
    class Queen : Piece {
        public Queen(Color color, int priority, int x, int y) : base(color, priority, x, y) {
            image = color == Color.White ? (Proiect_IA.Properties.Resources.queen_w) : (Proiect_IA.Properties.Resources.queen_b_d);
            priority = 1000;
        }

        public override void enable() {
            image = color == Color.White ? (Proiect_IA.Properties.Resources.queen_w) : (Proiect_IA.Properties.Resources.queen_b);
        }
        public override void disable() {
            image = color == Color.White ? (Proiect_IA.Properties.Resources.queen_w_d) : (Proiect_IA.Properties.Resources.queen_b_d);
        }

        public override void Move(int Xcoord, int Ycoord, Box[,] board) {
            Rook MyRook = new Rook(color, priority, Xcoord, Ycoord);
            Bishop MyBishop = new Bishop(color, priority, Xcoord, Ycoord);
            MyBishop.Move(Xcoord, Ycoord, board);
            MyRook.Move(Xcoord, Ycoord, board);
        }

        public override void canMove(Box[,] board) {
            Rook MyRook = new Rook(color, priority, this.x, this.y);
            Bishop MyBishop = new Bishop(color, priority, this.x, this.y);
            MyBishop.canMove(board);
            MyRook.canMove(board);
        }

        public override List<Box> getAvailableMoves(Box[,] board) {
            List<Box> availableMoves = new List<Box>();

            Rook MyRook = new Rook(color, priority, this.x, this.y);
            Bishop MyBishop = new Bishop(color, priority, this.x, this.y);
            List<Box> myBishopMoves = MyBishop.getAvailableMoves(board);
            List<Box> myRookMoves = MyRook.getAvailableMoves(board);

            availableMoves = myBishopMoves.Concat(myRookMoves).ToList();

            return availableMoves;
        }
    }
}
