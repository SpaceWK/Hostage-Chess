using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA {
    public class Player {
        public string name;
        public Color color;
        public List<Piece> pieces ;
        public List<Box> airport = new List<Box>();
        public List<Box> jails = new List<Box>();
        

        public Player(string name, Color color, Box[,] board) {
            pieces = new List<Piece>();
            this.name = name;
            this.color = color;
            setPieces(board);
  
        }


        public Piece getRandomPiece() {
            Random r = new Random();
            int rInt = r.Next(0, pieces.Count());
            return pieces[rInt];
        }

        public void enablePieces() {
            for (int i = 0; i < pieces.Count; i++) {
                pieces[i].enable();
            }
        }
        public void disablePieces() {
            for (int i = 0; i < pieces.Count; i++) {
                pieces[i].disable();
            }
        }

        private void setPieces(Box[,] board) {
            if (color == Color.Black)
                blackPieces(board);
            else
                whitePieces(board);
 
        }

        private void whitePieces(Box[,] board) {
           
            for (int i = 0; i < 8; i++) {
                pieces.Add(new Pawn(color, 1, 1, i));
                board[1, i].AddPiece(pieces[pieces.Count - 1]);
            }

            pieces.Add(new Rook(color, 3, 0, 0));
            board[0, 0].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Knight(color, 2, 0 ,1));
            board[0, 1].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Bishop(color, 2, 0, 2));
            board[0, 2].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new King(color, 5, 0, 3));
            board[0, 3].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Queen(color, 4, 0, 4));
            board[0, 4].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Bishop(color, 2, 0, 5));
            board[0, 5].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Knight(color, 2, 0, 6));
            board[0, 6].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Rook(color, 3, 0, 7));
            board[0, 7].AddPiece(pieces[pieces.Count - 1]);

        }
        private void blackPieces(Box[,] board) {

            for (int i = 0; i < 8; i++) {
                pieces.Add(new Pawn(color, 1, 6, i));
                board[6, i].AddPiece(pieces[pieces.Count - 1]);
            }

            pieces.Add(new Rook(color, 3, 7, 0));
            board[7, 0].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Knight(color, 2, 7, 1));
            board[7, 1].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Bishop(color, 2, 7, 2));
            board[7, 2].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new King(color, 5, 7, 3));
            board[7, 3].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Queen(color, 4, 7, 4));
            board[7, 4].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Bishop(color, 2, 7, 5));
            board[7, 5].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Knight(color, 2, 7, 6));
            board[7, 6].AddPiece( pieces[pieces.Count - 1]);

            pieces.Add(new Rook(color, 3, 7, 7));
            board[7, 7].AddPiece(pieces[pieces.Count - 1]);

        }


        private void OnlineSetPieces() {
            if (color == Color.Black)
                OnlineBlackPieces();
            else
                OnlineWhitePieces();
        }

        private void OnlineWhitePieces() {

            for (int i = 0; i < 8; i++) {
                pieces.Add(new Pawn(color, 1, 1, i));
                OnlineGame.board[1, i].AddPiece(pieces[pieces.Count - 1]);
            }

            pieces.Add(new Rook(color, 3, 0, 0));
            OnlineGame.board[0, 0].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Knight(color, 2, 0, 1));
            OnlineGame.board[0, 1].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Bishop(color, 2, 0, 2));
            OnlineGame.board[0, 2].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new King(color, 5, 0, 3));
            OnlineGame.board[0, 3].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Queen(color, 4, 0, 4));
            OnlineGame.board[0, 4].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Bishop(color, 2, 0, 5));
            OnlineGame.board[0, 5].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Knight(color, 2, 0, 6));
            OnlineGame.board[0, 6].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Rook(color, 3, 0, 7));
            OnlineGame.board[0, 7].AddPiece(pieces[pieces.Count - 1]);

        }
        private void OnlineBlackPieces() {

            for (int i = 0; i < 8; i++) {
                pieces.Add(new Pawn(color, 1, 6, i));
                OnlineGame.board[6, i].AddPiece(pieces[pieces.Count - 1]);
            }

            pieces.Add(new Rook(color, 3, 7, 0));
            OnlineGame.board[7, 0].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Knight(color, 2, 7, 1));
            OnlineGame.board[7, 1].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Bishop(color, 2, 7, 2));
            OnlineGame.board[7, 2].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new King(color, 5, 7, 3));
            OnlineGame.board[7, 3].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Queen(color, 4, 7, 4));
            OnlineGame.board[7, 4].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Bishop(color, 2, 7, 5));
            OnlineGame.board[7, 5].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Knight(color, 2, 7, 6));
            OnlineGame.board[7, 6].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Rook(color, 3, 7, 7));
            OnlineGame.board[7, 7].AddPiece(pieces[pieces.Count - 1]);

        }

    }
}
