using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Proiect_IA {
    class OnlineGame {
        public Form1 startingForm { get; }

        static int index = 0;
        static Box clickedBox = null;
        static Boolean clicked = false;
        public static Boolean jailClicked = false;
        static Boolean airportClicked = false;
        private Player currentPlayer;
        public Boolean myTurn;

        static public Box[,] board  = new Box[8, 8];
        private List<Player> players = new List<Player>();

        //Retea
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string data_to_send;
        string data_received;

        public OnlineGame(Form1 form1) {
            startingForm = form1;
            
        }
        public void StartGame() {
            createTable();
            players.Add(new Player("alb", Color.White, board));
            players.Add(new Player("negru", Color.Black, board));
            currentPlayer = players[index++ % 2];
            createJails();

        }
        public void StartServer(String serverIP) {
            TcpListener listener = new TcpListener(IPAddress.Any, 2133);
            listener.Start();
            client = listener.AcceptTcpClient();
            STR = new StreamReader(client.GetStream());
            STW = new StreamWriter(client.GetStream());
            STW.AutoFlush = true;
            startingForm.backgroundWorker1.RunWorkerAsync();                         //start receiving data in background
            startingForm.backgroundWorker2.WorkerSupportsCancellation = true;        //ability to cancel this thread

            //WhitePlayer TO DO
            myTurn= true;
            StartGame();

        }
        public void Connect(String connectIP) {
            client = new TcpClient();
            IPEndPoint IP_End = new IPEndPoint(IPAddress.Parse(connectIP), 2133);
            try {
                client.Connect(IP_End);
                if (client.Connected) {
                    STW = new StreamWriter(client.GetStream());
                    STR = new StreamReader(client.GetStream());
                    STW.AutoFlush = true;
                    startingForm.backgroundWorker1.RunWorkerAsync();                         //start receiving data in background
                    startingForm.backgroundWorker2.WorkerSupportsCancellation = true;        //ability to cancel this thread

                    //BlackPlAYER TO DO
                    myTurn = false;
                    StartGame();

                }
            }
            catch (Exception x) {
                MessageBox.Show(x.Message.ToString());
            }
        }

        public void ReceiveData() {
            while (client.Connected )
            try {
                    string receive = STR.ReadLine();
                    if (data_received == receive)
                        continue;
                    else
                        data_received = receive;
                    string[] coords = data_received.Split('-');

                    if (!myTurn) {
                        switch (coords[0]) {
                            case "B":
                                if (board[Int32.Parse(coords[1]), Int32.Parse(coords[2])].piece != null
                                    && board[Int32.Parse(coords[1]), Int32.Parse(coords[2])].piece.color != currentPlayer.color) {
                                    board[Int32.Parse(coords[1]), Int32.Parse(coords[2])].addToJail(players[index % 2]);
                                }
                                changePieces(board[Int32.Parse(coords[1]), Int32.Parse(coords[2])],
                                             board[Int32.Parse(coords[3]), Int32.Parse(coords[4])]
                                             );
                                switchPlayer();
                                myTurn = true;
                                break;
                            case "J":
                                clickedBox = currentPlayer.jails[Int32.Parse(coords[1])];
                                //Adaugare piesa pe tabla
                                changePieces(board[Int32.Parse(coords[2]), Int32.Parse(coords[3])], clickedBox);
                                clickedBox.panel.BackColor = Color.DarkGray;

                                //Adaugare piesa adversar pe airport
                                var airportPiece = players[index % 2].jails.OrderByDescending(i => i.piece.priority).First();
                                airportPiece.addToAirport(players[index % 2]);
                                airportPiece.panel.BackgroundImage = null;
                                airportPiece.piece = null;

                                switchPlayer();
                                myTurn = true;
                                break;
                            case "A":
                                clickedBox = currentPlayer.airport[Int32.Parse(coords[1])];
                                changePieces(board[Int32.Parse(coords[2]), Int32.Parse(coords[3])], clickedBox);
                                clickedBox.panel.BackColor = Color.Silver;

                                switchPlayer();
                                myTurn = true;
                                break;
                            default:
                                MessageBox.Show("Eroare!");
                                break;
                        }
                    }
                }
                catch (Exception x) {
                    MessageBox.Show(x.Message.ToString());
                }
        }
        public void PrepareToSend() {

            startingForm.backgroundWorker2.RunWorkerAsync(); 
            SendData();

        }
        public void SendData() {

            if (client.Connected) {  
                STW.WriteLine(data_to_send);
            }
            else {
                MessageBox.Show("Send Faild ");
            }
            startingForm.backgroundWorker2.CancelAsync();

        }
        private bool chess() {

            var piece = currentPlayer.pieces.Find(pi => pi is King);

            foreach (var pieces in players[index % 2].pieces)
                pieces.canMove(board);
            if (board[piece.x, piece.y].nextLegalMove == true) {
                ResetBoard();
                board[piece.x, piece.y].panel.BackColor = Color.Red;
                return true;
            }

            return false;
        }

        private bool chessMate() {
            Dictionary<Box, Box> possibleMoves = getPossibleMoves(currentPlayer.color);
            foreach (var possibleMove in possibleMoves) {

                doMoves(possibleMove.Value, possibleMove.Key);

                //Testare daca inca este in sah
                var piece = currentPlayer.pieces.Find(pi => pi is King);
                foreach (var pieces in players[index % 2].pieces)
                    pieces.canMove(board);
                if (board[piece.x, piece.y].nextLegalMove == false) {
                    ResetBoard();
                    undoMoves(possibleMove.Value, possibleMove.Key);
                    board[piece.x, piece.y].panel.BackColor = Color.Red;
                    return false;
                }
                ResetBoard();

                undoMoves(possibleMove.Value, possibleMove.Key);

            }
            return true;
        }

        public void pieceClick(int xCoord, int yCoord) {
            if (!myTurn)
                return;
            if (clicked) {
                secondClick(xCoord, yCoord);
            }
            else {
                firstClick(xCoord, yCoord);
            }
        }

        public void jailClick(int i, Player player) {
            if (!myTurn)
                return;
            if (!jailClicked) {
                if (player.jails[i].piece != null && currentPlayer.color == player.color) {
                    if (players[index % 2].jails.FindAll(pi => pi.piece != null).Count > 0 &&
                        player.jails[i].piece.priority <= players[index % 2].jails.FindAll(pi => pi.piece != null).Max(pi => pi.piece.priority)
                        ) 
                        {
                        player.jails[i].panel.BackColor = Color.Khaki;
                        clickedBox = player.jails[i];
                        data_to_send = "J-" + i.ToString();
                        jailClicked = true;
                    }
                    else {
                        player.jails[i].panel.BackColor = Color.Tomato;
                        jailClicked = true;
                    }
                }
            }
            else {
                player.jails[i].panel.BackColor = Color.DarkGray;
                jailClicked = false;
            }
        }

        public void airportClick(int i, Player player) {
            if (!myTurn)
                return;

            if (!airportClicked) {
                if (player.airport[i].piece != null && currentPlayer.color == player.color) {
                    player.airport[i].panel.BackColor = Color.Khaki;
                    clickedBox = player.airport[i];
                    data_to_send = "A-" + i.ToString();
                    airportClicked = true;
                }
            }
            else {
                player.airport[i].panel.BackColor = Color.Silver;
                airportClicked = false;
            }
        }

        public void firstClick(int xCoord, int yCoord) {
            if (jailClicked || airportClicked) {
                AddToTable(xCoord, yCoord);
            }
            else {
                if (board[xCoord, yCoord].isOccupied && currentPlayer.color == board[xCoord, yCoord].piece.color) {
                    clickedBox = board[xCoord, yCoord];
                    clicked = true;
                    board[xCoord, yCoord].piece.Move(xCoord, yCoord, board);
                    board[xCoord, yCoord].panel.BackColor = Color.Khaki;
                }
            }
        }

        public void secondClick(int xCoord, int yCoord) {
            if (clickedBox == board[xCoord, yCoord]) {
                ResetBoard();
                clicked = false;
                clickedBox = null;


            }
            else if (board[xCoord, yCoord].nextLegalMove) {

                if (NoValidMove(board[xCoord, yCoord], clickedBox))
                    return;

                if (board[xCoord, yCoord].piece != null && board[xCoord, yCoord].piece.color != currentPlayer.color) {
                    board[xCoord, yCoord].addToJail(players[index % 2]);
                }

                // Rocada
                if (clickedBox.piece is King && board[xCoord, yCoord].piece is Rook && !board[xCoord, yCoord].piece.moved) {
                    if (clickedBox.y - yCoord > 0) {
                        board[xCoord, 1].SwitchBoxes(board[xCoord, 3]);
                        board[xCoord, 2].SwitchBoxes(board[xCoord, 0]);
                        goto JumpSwitch;
                    }
                    else {
                        board[xCoord, 5].SwitchBoxes(board[xCoord, 3]);
                        board[xCoord, 4].SwitchBoxes(board[xCoord, 7]);
                        goto JumpSwitch;
                    }
                }
                else {
                    if (clickedBox.piece is King && clickedBox.piece is Rook) {
                        clickedBox.piece.moved = true;
                    }
                }

                data_to_send = "B-" + xCoord.ToString() + "-" + yCoord.ToString() + "-" +
                               clickedBox.x.ToString() + "-" + clickedBox.y.ToString();

                changePieces(board[xCoord, yCoord], clickedBox);
               
                PrepareToSend();
                myTurn = false;
            JumpSwitch:

                ResetBoard();
                //schimbare rand la jucatori
                switchPlayer();

                clicked = false;
                clickedBox = null;
                //removeClickEvents();
                
            }
        }

        public void switchPlayer() {
            currentPlayer = players[index++ % 2];

            players[index % 2].disablePieces();
            currentPlayer.enablePieces();

            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    if (board[i, j].piece != null) {
                        board[i, j].panel.BackgroundImage = board[i, j].piece.image;
                    }
                }
            }

            if (chess()) {
                if (chessMate())
                    MessageBox.Show("Check Mate!");
                else
                    board[currentPlayer.pieces.Find(pi => pi is King).x, currentPlayer.pieces.Find(pi => pi is King).y].panel.BackColor = Color.Red;
            }
        }

        private void AddToTable(int xCoord, int yCoord) {
            if (jailClicked) {
                if (!board[xCoord, yCoord].isOccupied) {
                    if (clickedBox != null) {

                        data_to_send = data_to_send +"-"+ xCoord.ToString() + "-" + yCoord.ToString(); 
                              
                        myTurn = !myTurn;
                        PrepareToSend();

                        //Adaugare piesa pe tabla
                        changePieces(board[xCoord, yCoord], clickedBox);
                        //board[xCoord, yCoord].SwitchBoxes(clickedBox);
                        clickedBox.panel.BackColor = Color.DarkGray;

                        //Adaugare piesa adversar pe airport
                        var airportPiece = players[index % 2].jails.FindAll(pi => pi.piece != null).OrderByDescending(i => i.piece.priority).First();
                        airportPiece.addToAirport(players[index % 2]);
                        airportPiece.panel.BackgroundImage = null;
                        airportPiece.piece = null;

                        jailClicked = false;
                        switchPlayer();
                    }
                }
            }
            else {
                if (!board[xCoord, yCoord].isOccupied) {
                    data_to_send = data_to_send + "-" + xCoord.ToString() + "-" + yCoord.ToString();

                    myTurn = !myTurn;
                    PrepareToSend();

                    changePieces(board[xCoord, yCoord], clickedBox);
                    //board[xCoord, yCoord].SwitchBoxes(clickedBox);
                    clickedBox.panel.BackColor = Color.Silver;

                    airportClicked = false;
                    switchPlayer();
                }
            }
        }

        private void ResetBoard() {
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    board[i, j].nextLegalMove = false;
                    board[i, j].panel.BackColor = (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1) ? Color.Moccasin : Color.BurlyWood;
                }
            }

            // Airport
            foreach (Player player in players) {
                foreach (var airportBox in player.airport) {
                    airportBox.panel.BackColor = Color.Silver;
                }
            }

            // Jails
            foreach (Player player in players) {
                foreach (var jailsBox in player.jails) {
                    jailsBox.panel.BackColor = Color.DarkGray;
                }
            }
        }

        private void removeClickEvents() {
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    Panel b = board[i, j].panel;
                    FieldInfo f1 = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);

                    object obj = f1.GetValue(b);
                    PropertyInfo pi = b.GetType().GetProperty("Events",
                        BindingFlags.NonPublic | BindingFlags.Instance);

                    EventHandlerList list = (EventHandlerList)pi.GetValue(b, null);
                    list.RemoveHandler(obj, list[obj]);

                }
            }
        }

        public void createTable() {
         
            Box.createBoundries(startingForm);

            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    int h = i, l = j;
                    board[i, j] = new Box(i, j);
                    board[i, j].panel.Click += (sender, EventArgs) => { startingForm.Panel_Click(sender, EventArgs, h, l); };
                    startingForm.Controls.Add(board[i, j].panel);
                }
            }
        }

        public void createJails() {
            // Airports
            for (int i = 1; i <= 5; i++) {
                int k = i - 1;
                Box box = new Box(7, 7 + i, -1);

                box.panel.BackColor = Color.Silver;
                box.panel.Click += (sender, EventArgs) => { startingForm.Airport_Click(sender, EventArgs, k, players[1]); };

                startingForm.Controls.Add(box.panel);
                players[1].airport.Add(box);
            }
            for (int i = 1; i <= 5; i++) {
                int k = i - 1;
                Box box = new Box(2, 7 + i, -1);

                box.panel.BackColor = Color.Silver;
                box.panel.Click += (sender, EventArgs) => { startingForm.Airport_Click(sender, EventArgs, k, players[0]); };

                startingForm.Controls.Add(box.panel);
                players[0].airport.Add(box);
            }

            // Jails
            for (int i = 1; i <= 10; i++) {
                int k = i - 1;
                //Box box = new Box(6, 7 + i);
                Box box;
                if (i > 5) {
                    box = new Box(5, 7 + (i - 5), -1);
                }
                else {
                    box = new Box(6, 7 + i, -1);
                }

                box.panel.BackColor = Color.DarkGray;
                box.panel.Click += (sender, EventArgs) => { startingForm.Jail_Click(sender, EventArgs, k, players[1]); };

                startingForm.Controls.Add(box.panel);
                players[1].jails.Add(box);
            }
            for (int i = 1; i <= 10; i++) {
                int k = i - 1;
                //Box box = new Box(0, 7 + i);
                Box box;
                if (i > 5) {
                    box = new Box(0, 7 + (i - 5), -1);
                }
                else {
                    box = new Box(1, 7 + i, -1);
                }

                box.panel.BackColor = Color.DarkGray;
                box.panel.Click += (sender, EventArgs) => { startingForm.Jail_Click(sender, EventArgs, k, players[0]); };

                startingForm.Controls.Add(box.panel);
                players[0].jails.Add(box);
            }
        }

        public void changePieces(Box currentBoxClicked, Box clickedBox) {

            currentBoxClicked.SwitchBoxes(clickedBox);

            if (players[index % 2].pieces.Find(pi => pi.x == currentBoxClicked.x && pi.y == currentBoxClicked.y) != null)
                players[index % 2].pieces.RemoveAt(players[index % 2].pieces.FindIndex(pi => pi.x == currentBoxClicked.x && pi.y == currentBoxClicked.y));

            if (currentPlayer.pieces.Find(pi => pi.x == clickedBox.x && pi.y == clickedBox.y) != null) {
                currentPlayer.pieces.Find(pi => pi.x == clickedBox.x && pi.y == clickedBox.y).setCoords(currentBoxClicked.x, currentBoxClicked.y);
            }
            else {
                currentBoxClicked.piece.setCoords(currentBoxClicked.x, currentBoxClicked.y);
                currentPlayer.pieces.Add(currentBoxClicked.piece);
            }
        }

        public Dictionary<Box, Box> getPossibleMoves(Color playerColor) {
            Dictionary<Box, Box> allPossibleMoves = new Dictionary<Box, Box>();
            Player myPlayer = players.Find(pl => pl.color == playerColor);

            foreach (var myPiece in myPlayer.pieces) {
                List<Box> onePieceMove = myPiece.getAvailableMoves(board);
                if (onePieceMove != null) {
                    foreach (var item in onePieceMove) {
                        allPossibleMoves[board[myPiece.x, myPiece.y]] = item;
                    }
                }
            }

            return allPossibleMoves;

        }

        private void undoMoves(Box nextMove, Box initialMove) {

            initialMove.SwitchBoxesIA(nextMove);

            if (currentPlayer.pieces.Find(pi => pi.x == nextMove.x && pi.y == nextMove.y) != null) {
                currentPlayer.pieces.Find(pi => pi.x == nextMove.x && pi.y == nextMove.y).setCoords(initialMove.x, initialMove.y);
            }


        }
        public void doMoves(Box nextMove, Box currentMove) {

            nextMove.SwitchBoxesIA(currentMove);
            //setare coordonate in afara tablei, piesa trece in jail
            if (players[index % 2].pieces.Find(pi => pi.x == nextMove.x && pi.y == nextMove.y) != null) {
                players[index % 2].pieces.RemoveAt(players[index % 2].pieces.FindIndex(pi => pi.x == nextMove.x && pi.y == nextMove.y));

            }
            //Trecere piese pe noile coordonate
            if (currentPlayer.pieces.Find(pi => pi.x == currentMove.x && pi.y == currentMove.y) != null) {
                currentPlayer.pieces.Find(pi => pi.x == currentMove.x && pi.y == currentMove.y).setCoords(nextMove.x, nextMove.y);
            }
        }
        private bool NoValidMove(Box currentBox, Box clickedBox) {
            ResetBoard();
            doMoves(currentBox, clickedBox);

            var piece = currentPlayer.pieces.Find(pi => pi is King);

            foreach (var pieces in players[index % 2].pieces)
                pieces.canMove(board);
            if (board[piece.x, piece.y].nextLegalMove == true) {
                ResetBoard();
                undoMoves(currentBox, clickedBox);
                return true;
            }
            ResetBoard();
            undoMoves(currentBox, clickedBox);
            return false;
        }

    }
}
