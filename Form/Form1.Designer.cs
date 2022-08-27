namespace Proiect_IA {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnSinglePlayer = new System.Windows.Forms.Button();
            this.btnMultiPlayer = new System.Windows.Forms.Button();
            this.btnArtificialIntelligence = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.serverBtn = new System.Windows.Forms.Button();
            this.connectBtn = new System.Windows.Forms.Button();
            this.serverTextBox = new System.Windows.Forms.TextBox();
            this.connectTextBox = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.btnBackToMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSinglePlayer
            // 
            this.btnSinglePlayer.Location = new System.Drawing.Point(12, 120);
            this.btnSinglePlayer.Name = "btnSinglePlayer";
            this.btnSinglePlayer.Size = new System.Drawing.Size(425, 50);
            this.btnSinglePlayer.TabIndex = 0;
            this.btnSinglePlayer.Text = "Single Player";
            this.btnSinglePlayer.UseVisualStyleBackColor = true;
            this.btnSinglePlayer.Click += new System.EventHandler(this.btnSinglePlayer_Click);
            // 
            // btnMultiPlayer
            // 
            this.btnMultiPlayer.Location = new System.Drawing.Point(12, 185);
            this.btnMultiPlayer.Name = "btnMultiPlayer";
            this.btnMultiPlayer.Size = new System.Drawing.Size(425, 50);
            this.btnMultiPlayer.TabIndex = 1;
            this.btnMultiPlayer.Text = "Multi Player";
            this.btnMultiPlayer.UseVisualStyleBackColor = true;
            this.btnMultiPlayer.Click += new System.EventHandler(this.btnMultiPlayer_Click);
            // 
            // btnArtificialIntelligence
            // 
            this.btnArtificialIntelligence.Location = new System.Drawing.Point(12, 251);
            this.btnArtificialIntelligence.Name = "btnArtificialIntelligence";
            this.btnArtificialIntelligence.Size = new System.Drawing.Size(425, 50);
            this.btnArtificialIntelligence.TabIndex = 2;
            this.btnArtificialIntelligence.Text = "Artificial Intelligence";
            this.btnArtificialIntelligence.UseVisualStyleBackColor = true;
            this.btnArtificialIntelligence.Click += new System.EventHandler(this.btnArtificialIntelligence_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Copperplate Gothic Bold", 34F);
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 63);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hostage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 24F);
            this.label2.Location = new System.Drawing.Point(300, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 49);
            this.label2.TabIndex = 4;
            this.label2.Text = "Chess";
            // 
            // serverBtn
            // 
            this.serverBtn.Location = new System.Drawing.Point(12, 120);
            this.serverBtn.Name = "serverBtn";
            this.serverBtn.Size = new System.Drawing.Size(208, 50);
            this.serverBtn.TabIndex = 5;
            this.serverBtn.Text = "Start Server";
            this.serverBtn.UseVisualStyleBackColor = true;
            this.serverBtn.Visible = false;
            this.serverBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(241, 120);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(196, 50);
            this.connectBtn.TabIndex = 6;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Visible = false;
            this.connectBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // serverTextBox
            // 
            this.serverTextBox.Location = new System.Drawing.Point(12, 185);
            this.serverTextBox.Name = "serverTextBox";
            this.serverTextBox.Size = new System.Drawing.Size(208, 22);
            this.serverTextBox.TabIndex = 7;
            this.serverTextBox.Visible = false;
            // 
            // connectTextBox
            // 
            this.connectTextBox.Location = new System.Drawing.Point(241, 185);
            this.connectTextBox.Name = "connectTextBox";
            this.connectTextBox.Size = new System.Drawing.Size(196, 22);
            this.connectTextBox.TabIndex = 8;
            this.connectTextBox.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // btnBackToMenu
            // 
            this.btnBackToMenu.Location = new System.Drawing.Point(12, 251);
            this.btnBackToMenu.Name = "btnBackToMenu";
            this.btnBackToMenu.Size = new System.Drawing.Size(425, 50);
            this.btnBackToMenu.TabIndex = 9;
            this.btnBackToMenu.Text = "Back to Menu";
            this.btnBackToMenu.UseVisualStyleBackColor = true;
            this.btnBackToMenu.Visible = false;
            this.btnBackToMenu.Click += new System.EventHandler(this.btnBackToMenu_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(446, 319);
            this.Controls.Add(this.btnBackToMenu);
            this.Controls.Add(this.connectTextBox);
            this.Controls.Add(this.serverTextBox);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.serverBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnArtificialIntelligence);
            this.Controls.Add(this.btnMultiPlayer);
            this.Controls.Add(this.btnSinglePlayer);
            this.Name = "Form1";
            this.Text = "Hostage Chess";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSinglePlayer;
        private System.Windows.Forms.Button btnMultiPlayer;
        private System.Windows.Forms.Button btnArtificialIntelligence;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button serverBtn;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.TextBox serverTextBox;
        private System.Windows.Forms.TextBox connectTextBox;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Button btnBackToMenu;
    }
}

