using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_IA {
    public partial class Form1 : Form {
        Game startGame;
        OnlineGame onlineGame;
        AIGame aiGame;

        public Form1() {
            InitializeComponent();
            connectTextBox.Text =  Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            serverTextBox.Text = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString(); 
        }

        public void Panel_Click(object sender, EventArgs e, int i, int j) {    
            if(startGame !=null )
                startGame.pieceClick(i, j);
            if (onlineGame != null)
                onlineGame.pieceClick(i, j);
            if (aiGame != null)
                aiGame.pieceClick(i, j);
        }

        public void Jail_Click(object sender, EventArgs e, int i, Player player) {
            if(startGame !=null )
                startGame.jailClick(i,player);
            if (onlineGame != null)
                onlineGame.jailClick(i,player);
            if (aiGame != null)
                aiGame.jailClick(i, player);
        }

        public void Airport_Click(object sender, EventArgs e, int i, Player player) {
            if (startGame != null)
                startGame.airportClick(i, player);
            if (onlineGame != null)
                onlineGame.airportClick(i, player);
            if (aiGame != null)
                aiGame.airportClick(i, player);
        }

        private void btnSinglePlayer_Click(object sender, EventArgs e) {
            this.Size = new Size(1050, 714);

            this.label1.Hide();
            this.label2.Hide();
            this.btnSinglePlayer.Hide();
            this.btnMultiPlayer.Hide();
            this.btnArtificialIntelligence.Hide();
            this.btnBackToMenu.Hide();

            startGame = new Game(this);
        }

        private void btnMultiPlayer_Click(object sender, EventArgs e) {
            this.label1.Hide();
            this.label2.Hide();
            this.btnSinglePlayer.Hide();
            this.btnMultiPlayer.Hide();
            this.btnArtificialIntelligence.Hide();

            this.serverBtn.Show();
            this.connectBtn.Show();
            this.serverTextBox.Show();
            this.connectTextBox.Show();
            this.btnBackToMenu.Show();

            onlineGame = new OnlineGame(this);
        }

        private void btnArtificialIntelligence_Click(object sender, EventArgs e) {
            this.Size = new Size(1050, 714);

            this.label1.Hide();
            this.label2.Hide();
            this.btnSinglePlayer.Hide();
            this.btnMultiPlayer.Hide();
            this.btnArtificialIntelligence.Hide();
            this.btnBackToMenu.Hide();

            aiGame = new AIGame(this);
        }

        private void btnBackToMenu_Click(object sender, EventArgs e) {
            this.btnSinglePlayer.Show();
            this.btnMultiPlayer.Show();
            this.btnArtificialIntelligence.Show();

            this.serverBtn.Hide();
            this.connectBtn.Hide();
            this.serverTextBox.Hide();
            this.connectTextBox.Hide();
            this.btnBackToMenu.Hide();
        }

        private void button1_Click(object sender, EventArgs e) {
            onlineGame.StartServer(serverTextBox.Text);
            this.Size = new Size(1050, 714);

            this.serverBtn.Hide();
            this.connectBtn.Hide();
            this.serverTextBox.Hide();
            this.connectTextBox.Hide();
            this.btnBackToMenu.Hide();
        }

        private void button2_Click(object sender, EventArgs e) {
            onlineGame.Connect(connectTextBox.Text);
            this.Size = new Size(1050, 714);

            this.serverBtn.Hide();
            this.connectBtn.Hide();
            this.serverTextBox.Hide();
            this.connectTextBox.Hide();
            this.btnBackToMenu.Hide();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            onlineGame.ReceiveData();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e) {
            onlineGame.SendData();
        }
    }
}
