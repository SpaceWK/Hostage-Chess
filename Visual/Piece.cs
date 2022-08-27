using System;
using System.Collections.Generic;
using System.Drawing;

namespace Proiect_IA {
    public class Piece {
        public int x;
        public int y;
        public Color color;
        public Image image;
        public bool moved;
        public int priority;
        protected int boardSize = 8;

        public Piece(int priority) {
            this.priority = priority;
        }

        public Piece(Color color, int priority, int x, int y) {
            this.x = x;
            this.y = y;
            this.color = color;
            this.priority = priority;
        }

        public Piece(Piece copiaza) {
            x = copiaza.x;
            y = copiaza.y;
            color = copiaza.color;
            image = copiaza.image;
            priority = copiaza.priority;
        }

        public virtual void Move(int Xcoord, int Ycoord, Box[,] board) {

        }

        public virtual void canMove(Box[,] board) {

        }

        public virtual List<Box> getAvailableMoves(Box[,] board) {
            return null;
        }

        public virtual void enable() {

        }

        public virtual void disable() {

        }

        public virtual void checkKingMove(int Xcoord, int Ycoord, Box[,] board) {
            throw new NotImplementedException();
        }

        public virtual void setCoords(int Xcoord, int Ycoord) {
            x = Xcoord;
            y = Ycoord;
        }
    }
}