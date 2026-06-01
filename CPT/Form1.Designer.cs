namespace CPT
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tmrGame = new System.Windows.Forms.Timer(this.components);
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHealthBar = new System.Windows.Forms.Label();
            this.picHouse = new System.Windows.Forms.PictureBox();
            this.picPiggy2 = new System.Windows.Forms.PictureBox();
            this.picPiggy1 = new System.Windows.Forms.PictureBox();
            this.lblOptions = new System.Windows.Forms.Label();
            this.lblLevelUp = new System.Windows.Forms.Label();
            this.tmrLevelLabel = new System.Windows.Forms.Timer(this.components);
            this.lblGameOver = new System.Windows.Forms.Label();
            this.tmrGameOver = new System.Windows.Forms.Timer(this.components);
            this.lblEndScreen = new System.Windows.Forms.Label();
            this.tmrEndScreen = new System.Windows.Forms.Timer(this.components);
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPiggy2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPiggy1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("SimSun-ExtB", 20F);
            this.lblInfo.ForeColor = System.Drawing.Color.IndianRed;
            this.lblInfo.Location = new System.Drawing.Point(2, 539);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(68, 27);
            this.lblInfo.TabIndex = 3;
            this.lblInfo.Text = "Info";
            this.lblInfo.Visible = false;
            // 
            // tmrGame
            // 
            this.tmrGame.Interval = 20;
            this.tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenu.Controls.Add(this.label4);
            this.pnlMenu.Controls.Add(this.label3);
            this.pnlMenu.Controls.Add(this.label2);
            this.pnlMenu.Controls.Add(this.label1);
            this.pnlMenu.Location = new System.Drawing.Point(273, 30);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(754, 365);
            this.pnlMenu.TabIndex = 5;
            this.pnlMenu.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun-ExtB", 36F);
            this.label4.ForeColor = System.Drawing.Color.IndianRed;
            this.label4.Location = new System.Drawing.Point(28, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(596, 48);
            this.label4.TabIndex = 3;
            this.label4.Text = "Press 2 for Control Menu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun-ExtB", 36F);
            this.label3.ForeColor = System.Drawing.Color.IndianRed;
            this.label3.Location = new System.Drawing.Point(28, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(596, 48);
            this.label3.TabIndex = 2;
            this.label3.Text = "Press 1 for Instructions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun-ExtB", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.IndianRed;
            this.label2.Location = new System.Drawing.Point(74, 122);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(500, 48);
            this.label2.TabIndex = 1;
            this.label2.Text = "Press ENTER to Start";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun-ExtG", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(25, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(456, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "Space Piggies";
            // 
            // lblHealthBar
            // 
            this.lblHealthBar.AutoSize = true;
            this.lblHealthBar.BackColor = System.Drawing.Color.Transparent;
            this.lblHealthBar.Font = new System.Drawing.Font("SimSun-ExtB", 36F, System.Drawing.FontStyle.Bold);
            this.lblHealthBar.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblHealthBar.Location = new System.Drawing.Point(13, 9);
            this.lblHealthBar.Name = "lblHealthBar";
            this.lblHealthBar.Size = new System.Drawing.Size(170, 48);
            this.lblHealthBar.TabIndex = 8;
            this.lblHealthBar.Text = "Health";
            this.lblHealthBar.Visible = false;
            // 
            // picHouse
            // 
            this.picHouse.BackColor = System.Drawing.Color.Transparent;
            this.picHouse.Image = global::CPT.Assets.House;
            this.picHouse.Location = new System.Drawing.Point(23, 30);
            this.picHouse.Name = "picHouse";
            this.picHouse.Size = new System.Drawing.Size(205, 415);
            this.picHouse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHouse.TabIndex = 7;
            this.picHouse.TabStop = false;
            this.picHouse.Visible = false;
            // 
            // picPiggy2
            // 
            this.picPiggy2.BackColor = System.Drawing.Color.Transparent;
            this.picPiggy2.Image = global::CPT.Assets.Piggy2;
            this.picPiggy2.Location = new System.Drawing.Point(914, 189);
            this.picPiggy2.Name = "picPiggy2";
            this.picPiggy2.Size = new System.Drawing.Size(90, 87);
            this.picPiggy2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPiggy2.TabIndex = 6;
            this.picPiggy2.TabStop = false;
            this.picPiggy2.Visible = false;
            // 
            // picPiggy1
            // 
            this.picPiggy1.BackColor = System.Drawing.Color.Transparent;
            this.picPiggy1.Image = global::CPT.Assets.Piggy1;
            this.picPiggy1.Location = new System.Drawing.Point(928, 412);
            this.picPiggy1.Margin = new System.Windows.Forms.Padding(2);
            this.picPiggy1.Name = "picPiggy1";
            this.picPiggy1.Size = new System.Drawing.Size(90, 95);
            this.picPiggy1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPiggy1.TabIndex = 4;
            this.picPiggy1.TabStop = false;
            this.picPiggy1.Visible = false;
            // 
            // lblOptions
            // 
            this.lblOptions.AutoSize = true;
            this.lblOptions.BackColor = System.Drawing.Color.Transparent;
            this.lblOptions.Font = new System.Drawing.Font("SimSun-ExtB", 16F);
            this.lblOptions.ForeColor = System.Drawing.Color.IndianRed;
            this.lblOptions.Location = new System.Drawing.Point(27, 99);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(142, 22);
            this.lblOptions.TabIndex = 9;
            this.lblOptions.Text = "Menu Options";
            this.lblOptions.Visible = false;
            // 
            // lblLevelUp
            // 
            this.lblLevelUp.AutoSize = true;
            this.lblLevelUp.BackColor = System.Drawing.Color.Transparent;
            this.lblLevelUp.Font = new System.Drawing.Font("SimSun-ExtB", 100F);
            this.lblLevelUp.ForeColor = System.Drawing.Color.IndianRed;
            this.lblLevelUp.Location = new System.Drawing.Point(308, 412);
            this.lblLevelUp.Name = "lblLevelUp";
            this.lblLevelUp.Size = new System.Drawing.Size(660, 134);
            this.lblLevelUp.TabIndex = 10;
            this.lblLevelUp.Text = "Level Up!";
            this.lblLevelUp.Visible = false;
            // 
            // tmrLevelLabel
            // 
            this.tmrLevelLabel.Interval = 3000;
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.BackColor = System.Drawing.Color.Transparent;
            this.lblGameOver.Font = new System.Drawing.Font("SimSun-ExtB", 20F);
            this.lblGameOver.ForeColor = System.Drawing.Color.IndianRed;
            this.lblGameOver.Location = new System.Drawing.Point(54, 477);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(124, 27);
            this.lblGameOver.TabIndex = 11;
            this.lblGameOver.Text = "GameOver";
            this.lblGameOver.Visible = false;
            // 
            // tmrGameOver
            // 
            this.tmrGameOver.Interval = 3000;
            // 
            // lblEndScreen
            // 
            this.lblEndScreen.AutoSize = true;
            this.lblEndScreen.Font = new System.Drawing.Font("SimSun-ExtB", 20F);
            this.lblEndScreen.ForeColor = System.Drawing.Color.IndianRed;
            this.lblEndScreen.Location = new System.Drawing.Point(142, 493);
            this.lblEndScreen.Name = "lblEndScreen";
            this.lblEndScreen.Size = new System.Drawing.Size(152, 27);
            this.lblEndScreen.TabIndex = 12;
            this.lblEndScreen.Text = "End Screen";
            this.lblEndScreen.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1166, 589);
            this.Controls.Add(this.lblEndScreen);
            this.Controls.Add(this.lblGameOver);
            this.Controls.Add(this.lblLevelUp);
            this.Controls.Add(this.lblOptions);
            this.Controls.Add(this.lblHealthBar);
            this.Controls.Add(this.picHouse);
            this.Controls.Add(this.picPiggy2);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.picPiggy1);
            this.Controls.Add(this.lblInfo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpacePiggies - Jeremiah";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPiggy2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPiggy1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Timer tmrGame;
        private System.Windows.Forms.PictureBox picPiggy1;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picPiggy2;
        private System.Windows.Forms.PictureBox picHouse;
        private System.Windows.Forms.Label lblHealthBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOptions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLevelUp;
        private System.Windows.Forms.Timer tmrLevelLabel;
        private System.Windows.Forms.Label lblGameOver;
        private System.Windows.Forms.Timer tmrGameOver;
        private System.Windows.Forms.Label lblEndScreen;
        private System.Windows.Forms.Timer tmrEndScreen;
    }
}

