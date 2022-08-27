using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_IA {
    public class Box {
        private const int boxSize = 75;
        public int x { get; set; }
        public int y { get; set; }

        public Panel panel;

        public Boolean isOccupied;

        public Piece piece;

        public Boolean nextLegalMove;

        public Box(int i, int j) {
            panel = new Panel {
                Location = new System.Drawing.Point(( j+1 ) * boxSize, (8-i) * boxSize),
                Size = new System.Drawing.Size(boxSize, boxSize),
                BackColor = (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1) ? Color.Moccasin : Color.BurlyWood  
            };          
            x = i;
            y = j;
            isOccupied = false;
            nextLegalMove = false;
        }

        //Box for jail and airport
        public Box(int i, int j, int k) {
            panel = new Panel {
                Location = new System.Drawing.Point((j + 1) * boxSize, (8 - i) * boxSize),
                Size = new System.Drawing.Size(boxSize, boxSize),
                BackColor = (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1) ? Color.Moccasin : Color.BurlyWood
            };
            x = i;
            y = j;
            isOccupied = false;
            nextLegalMove = false;
            piece = null;
        }

        public void AddPiece(Piece piece) {
            this.piece = piece;
            panel.BackgroundImage = piece.image;
            isOccupied = true;
        }
        static public void createBoundries(Form1 startingForm) {
            for (int i = 1; i <= 8; i++) {
                Panel left = new Panel {
                    Location = new System.Drawing.Point(0, i * boxSize),
                    Size = new System.Drawing.Size(boxSize, boxSize),
                    BackColor = Color.LightGray
                };
                left.Controls.Add(new Label {
                    Location = new System.Drawing.Point(30, 30),
                    Text = (9-i).ToString(),
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    ForeColor = Color.Gray
                });
                startingForm.Controls.Add(left);

                Panel up = new Panel {
                    Location = new System.Drawing.Point(i * boxSize, 0),
                    Size = new System.Drawing.Size(boxSize, boxSize),
                    BackColor = Color.LightGray
                };
                up.Controls.Add(new Label {
                    Location = new System.Drawing.Point(30, 30),
                    Text = Convert.ToChar('A' + i - 1).ToString(),
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    ForeColor = Color.Gray
                });
                startingForm.Controls.Add(up);

                // Colt
                Panel corner = new Panel {
                    Location = new System.Drawing.Point(0, 0),
                    Size = new System.Drawing.Size(boxSize, boxSize),
                    BackColor = Color.LightGray
                };
                startingForm.Controls.Add(corner);
            }     
            
        }

        public void SwitchBoxes(Box clickedBox) {
            panel.BackgroundImage = clickedBox.panel.BackgroundImage;
            clickedBox.panel.BackgroundImage = null;

            isOccupied = true;
            clickedBox.isOccupied = false;

            piece = clickedBox.piece;
            clickedBox.piece = null;

        }

        public void SwitchBoxesIA(Box initialMove) {
            isOccupied = true;
            initialMove.isOccupied = false;

            Piece swapPiece = piece;
            piece = initialMove.piece;
            if(piece != null)
                initialMove.piece = swapPiece;
            else 
                initialMove.piece = swapPiece;
            
        }

        public void resetBox() {
            panel.BackgroundImage = null;
            isOccupied = false;
            piece = new Piece(-1);
        }

        public void addToJail(Player player) {
            foreach(var item in player.jails) {
                if(item.piece == null) {
                    item.panel.BackgroundImage = this.panel.BackgroundImage;
                    item.piece = this.piece;
                    break;
                }
            }
        }

        public void addToAirport(Player player) {
            foreach (var item in player.airport) {
                if (item.piece == null) {
                    item.panel.BackgroundImage = this.panel.BackgroundImage;
                    item.piece = this.piece;
                    break;
                }
            }
        }
    }    
}
