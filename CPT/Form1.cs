using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;



//Jeremiah Vinu
//June 13th, 2025
//A Space Shooter Game with Piggies and Wolves

namespace CPT
   
{
    public enum GameStates { Menu, Game, Pause, Level2, Level3, GameOver }


    public partial class Form1 : Form
    {
        //global variables
        GameStates GameState = GameStates.Menu;

        //movements of piggys
        

        bool Piggy1Up = false;
        bool Piggy1Down = false;
        bool Piggy1Left = false;
        bool Piggy1Right = false;
        int Piggy1Speed = 9;

        //piggy2
        bool Piggy2Up = false;
        bool Piggy2Down = false;
        bool Piggy2Left = false;
        bool Piggy2Right = false;
        int Piggy2Speed = 9;

        //health bar set
        int Health = 10000;

        //set up lists for wolfs, bullets, and random number generator

        Random oRand = new Random();
        List<Wolf> Wolfs = new List<Wolf>();
        List<PictureBox> Bullets = new List<PictureBox>();
        bool FireBullet = true; //true can fire a bullet

        int currentLevel = 1;

        PictureBox bossWolf;
        int bossHealth = 500; // Boss HP
        Label lblBossHealth;
        bool bossSpawned = false;


        public Form1()
        {
            InitializeComponent();

            //makes it smoother
            this.DoubleBuffered = true;

            ShowMenu();

        }

        private void tmrGame_Tick(object sender, EventArgs e)
        {
            //game engine

            if (GameState != GameStates.Menu)
            {
                this.AutoScroll = false;
            }

            // Move Piggy1 with screen boundary checks
            if (Piggy1Up && picPiggy1.Top - Piggy1Speed >= 0)
                picPiggy1.Top -= Piggy1Speed;
            if (Piggy1Down && picPiggy1.Bottom + Piggy1Speed <= ClientSize.Height)
                picPiggy1.Top += Piggy1Speed;
            if (Piggy1Left && picPiggy1.Left - Piggy1Speed >= 0)
                picPiggy1.Left -= Piggy1Speed;
            if (Piggy1Right && picPiggy1.Right + Piggy1Speed <= ClientSize.Width)
                picPiggy1.Left += Piggy1Speed;

            // Move Piggy2 with screen boundary checks
            if (Piggy2Up && picPiggy2.Top - Piggy2Speed >= 0)
                picPiggy2.Top -= Piggy2Speed;
            if (Piggy2Down && picPiggy2.Bottom + Piggy2Speed <= ClientSize.Height)
                picPiggy2.Top += Piggy2Speed;
            if (Piggy2Left && picPiggy2.Left - Piggy2Speed >= 0)
                picPiggy2.Left -= Piggy2Speed;
            if (Piggy2Right && picPiggy2.Right + Piggy2Speed <= ClientSize.Width)
                picPiggy2.Left += Piggy2Speed;

            // Block piggy1 from walking into the house
            if (Health > 0 && picPiggy1.Bounds.IntersectsWith(picHouse.Bounds))
            {
                if (Piggy1Right && picPiggy1.Right > picHouse.Left)
                    picPiggy1.Left -= Piggy1Speed;
                if (Piggy1Left && picPiggy1.Left < picHouse.Right)
                    picPiggy1.Left += Piggy1Speed;
                if (Piggy1Down && picPiggy1.Bottom > picHouse.Top)
                    picPiggy1.Top -= Piggy1Speed;
                if (Piggy1Up && picPiggy1.Top < picHouse.Bottom)
                    picPiggy1.Top += Piggy1Speed;
            }

            // Block piggy2 from walking into the house
            if (Health > 0 && picPiggy2.Bounds.IntersectsWith(picHouse.Bounds))
            {
                if (Piggy2Right && picPiggy2.Right > picHouse.Left)
                    picPiggy2.Left -= Piggy2Speed;
                if (Piggy2Left && picPiggy2.Left < picHouse.Right)
                    picPiggy2.Left += Piggy2Speed;
                if (Piggy2Down && picPiggy2.Bottom > picHouse.Top)
                    picPiggy2.Top -= Piggy2Speed;
                if (Piggy2Up && picPiggy2.Top < picHouse.Bottom)
                    picPiggy2.Top += Piggy2Speed;
            }


            //make health a bar
            lblHealthBar.Text = $"Health  {Health}";
            lblHealthBar.Visible = true;



            //check if wolf and house  collide, if remove health
            for (int j = Wolfs.Count - 1; j >= 0; j--)
            {
                if (GameState == GameStates.Level3)
                {
                    // In Level 3: wolves affect piggies, not house
                    if (Wolfs[j].Bounds.IntersectsWith(picPiggy1.Bounds))
                    {
                        ApplyPiggyEffect(1);
                        Controls.Remove(Wolfs[j]);
                        Wolfs.RemoveAt(j);
                        continue;
                    }
                    if (Wolfs[j].Bounds.IntersectsWith(picPiggy2.Bounds))
                    {
                        ApplyPiggyEffect(2);
                        Controls.Remove(Wolfs[j]);
                        Wolfs.RemoveAt(j);
                        continue;
                    }
                }
                else
                {
                    // In other levels: damage the house
                    if (Wolfs[j].Bounds.IntersectsWith(picHouse.Bounds))
                    {
                        Controls.Remove(Wolfs[j]);
                        Wolfs.RemoveAt(j);
                        Health -= 1000;
                        lblHealthBar.Text = $"Health  {Health}";
                    }
                }
            }

            //move the bullets
            for (int i = Bullets.Count - 1; i > -1; i--)
            {
                //move the bullet to the right 
                Bullets[i].Left += 20;

                //check if bullet is off the form 
                if (Bullets[i].Left >= ClientSize.Width)
                {
                    //remove bullet from form control
                    this.Controls.Remove(Bullets[i]);

                    //remove bullet from the list 
                    Bullets.Remove(Bullets[i]);
                }
                else
                {
                    //check if bullet collides with a wolf
                    for (int j = Wolfs.Count - 1; j > -1; j--)
                    {
                        //check for wolf and bullet collision 
                        if (Wolfs[j].Bounds.IntersectsWith(Bullets[i].Bounds) )
                        {
                            //collision detected
                            //remove the wolf and bullet
                            this.Controls.Remove(Wolfs[j]);
                            Wolfs.Remove(Wolfs[j]);
                            this.Controls.Remove(Bullets[i]);
                            Bullets.Remove(Bullets[i]);

                            break;

                        }
                    }
                }


               




            }
            string Info = $"Bullet Count = {Bullets.Count}     ";

            //move the Wolfs
            foreach (Wolf oWolf in Wolfs)
            {
                //bounce if going out of bounce
                if (oWolf.Top <= 0 || oWolf.Bottom >= ClientSize.Height)
                    oWolf.BounceY();

                if (oWolf.Left <= 0 || oWolf.Right >= ClientSize.Width)
                    oWolf.BounceX();

                oWolf.MoveTick();
            }
            Info += $"Wolf Count = {Wolfs.Count}";

            if (bossSpawned && bossWolf != null)
            {
                // Slow leftward movement
                bossWolf.Left -= 1;

                // Update health label position
                lblBossHealth.Left = bossWolf.Left;
                lblBossHealth.Top = bossWolf.Top - 20;

                // If boss reaches house
                if (bossWolf.Bounds.IntersectsWith(picHouse.Bounds))
                {
                    Health = 0; // Force game over
                }

                // Bullet collision with boss
                for (int i = Bullets.Count - 1; i >= 0; i--)
                {
                    if (bossWolf.Bounds.IntersectsWith(Bullets[i].Bounds))
                    {
                        bossHealth -= 20;
                        lblBossHealth.Text = $"Boss Health: {bossHealth}";
                        Controls.Remove(Bullets[i]);
                        Bullets.RemoveAt(i);
                    }
                }

                // Boss defeated
                if (bossHealth <= 0)
                {
                    Controls.Remove(bossWolf);
                    Controls.Remove(lblBossHealth);
                    bossWolf = null;
                    bossSpawned = false;

                    if (GameState == GameStates.Level3)
                    {
                        tmrGame.Enabled = false;
                        foreach (Wolf wolf in Wolfs)
                        {
                            Controls.Remove(wolf);
                        }
                        Wolfs.Clear();
                        TriggerEndScreen();
                    }
                }
            }


            lblInfo.Text = Info;

            //check if all the wolfs are gone, players can then go to next level
            if (Wolfs.Count == 0)
            {
                if (GameState == GameStates.Game && Health > 0)
                {
                    StartNextLevel(); // from level 1 to 2
                }
                else if (GameState == GameStates.Level2 && Health > 300)
                {
                    StartNextLevel(); // from level 2 to 3
                }
            }

            // Check for game over


            // Additional Game Over conditions
            if ((GameState == GameStates.Game || GameState == GameStates.Level2) && Health <= 6000)
            {
                tmrGame.Enabled = false;
                GameState = GameStates.GameOver;

                picHouse.Visible = false;
                picPiggy1.Visible = false;
                picPiggy2.Visible = false;
                lblHealthBar.Visible = false;

                foreach (PictureBox bullet in Bullets)
                    this.Controls.Remove(bullet);
                Bullets.Clear();

                foreach (Wolf wolf in Wolfs)
                    this.Controls.Remove(wolf);
                Wolfs.Clear();

                Health = 10000;
                lblHealthBar.Text = $"Health  {Health}";
                lblHealthBar.Visible = false;

                
                TriggerGameOver();
            }

        }
        public void ShowGameOver()
        {
            lblGameOver.Text = "GAME OVER";
            lblGameOver.AutoSize = true;
            lblGameOver.Visible = true;
            lblGameOver.BringToFront();
            lblGameOver.Left = ClientSize.Width / 2 - lblGameOver.PreferredWidth / 2;
            lblGameOver.Top = ClientSize.Height / 2 - lblGameOver.PreferredHeight / 2;
            lblGameOver.BringToFront();
            lblGameOver.Visible = true;
        }

        public void ShowMenu()
        {
            //show the menu panel

            //center the panel on the form
            pnlMenu.Left = ClientSize.Width / 2 - pnlMenu.Width / 2;
            pnlMenu.Top = ClientSize.Height / 2 - pnlMenu.Height / 2;

            GameState = GameStates.Menu;

            pnlMenu.Visible = true;

        }

        public void HideMenu()
        {
            //hide the menu

            pnlMenu.Visible = false;
        }


        public void StartGame()
        {
            HideMenu();

            // Set the piggy and house positions FIRST
            picPiggy1.Left = ClientSize.Width / 4 - picPiggy1.Width / 2;
            picPiggy1.Top = ClientSize.Height / 4 - picPiggy1.Height / 2;
            picPiggy1.Visible = true;

            picPiggy2.Left = ClientSize.Width * 1 / 4 - picPiggy2.Width / 2;
            picPiggy2.Top = ClientSize.Height * 3 / 4 - picPiggy2.Height / 2;
            picPiggy2.Visible = true;

            picHouse.Left = ClientSize.Width / 8 - picHouse.Width / 2;
            picHouse.Top = ClientSize.Height / 2 - picHouse.Height / 2;
            picHouse.Visible = true;

            lblOptions.Visible = false;

            // Now set game state and start
            GameState = GameStates.Game;
            SpawnWolves(7);
            FireBullet = true;
            tmrGame.Enabled = true;
            // Reset movement
            Piggy1Up = false;
            Piggy1Down = false;
            Piggy1Left = false;
            Piggy1Right = false;
            Piggy2Up = false;
            Piggy2Down = false;
            Piggy2Left = false;
            Piggy2Right = false;
        }

        public void Instructions()
        {
            //instructions menu
            HideMenu();

            string Text =
"🐷 Welcome to *Space Piggies*! 🐺\n\n" +
"In this game, two brave piggies must defend their home from waves of Big Bad Wolves.\n\n" +
"🌟 Objective:\n" +
"Defend the house at all costs! If the wolves destroy it, it's game over.\n\n" +
"🏁 Levels:\n" +
"• **Level 1** – Intro stage. Wolves attack the house. If the house health falls below 6000, you lose.\n" +
"• **Level 2** – More wolves and pressure. Same health rule: drop below 6000 and it's game over.\n" +
"• **Level 3** – Final showdown. Wolves don’t hurt the house anymore—they just get in your way. The boss wolf is your only real threat. Defeat it to win!\n\n" +
"❤️ House Health:\n" +
"The house starts with 10,000 health. Wolves that reach it will lower this value. Keep the house above 6000 HP to survive Levels 1 and 2!\n\n" +
"🎯 Tip:\n" +
"Use teamwork! Cover both sides and don’t let wolves slip past you.\n\n" +
"Press **2** for controls or **Enter** to start!";

            lblOptions.Text = Text;

           



            lblOptions.Visible = true;
        }

        public void ControlMenu()
        {
            //controlmenu
            HideMenu();
            
            string Text =
"🎮 Controls Guide:\n\n" +
"👤 **Player 1 (Top Piggy)**\n" +
"• Move: Arrow Keys (↑ ↓ ← →)\n" +
"• Shoot: Spacebar\n\n" +
"👤 **Player 2 (Bottom Piggy)**\n" +
"• Move: W (up), A (left), S (down), D (right)\n" +
"• Shoot: F key\n\n" +
"⚠️ Each piggy can only shoot once at a time. Let go of the shoot key to reload.\n\n" +
"Press **1** for instructions or **Enter** to start the game.";

            lblOptions.Text = Text;





            lblOptions.Visible = true;


        }

        public void StartNextLevel()
        {
            HideMenu();

            // Reset positions
            picPiggy1.Left = ClientSize.Width / 4 - picPiggy1.Width / 2;
            picPiggy1.Top = ClientSize.Height / 4 - picPiggy1.Height / 2;
            picPiggy2.Left = ClientSize.Width / 4 - picPiggy2.Width / 2;
            picPiggy2.Top = ClientSize.Height * 3 / 4 - picPiggy2.Height / 2;
            picHouse.Left = ClientSize.Width / 8 - picHouse.Width / 2;
            picHouse.Top = ClientSize.Height / 2 - picHouse.Height / 2;

            // Reset health for the new level
            Health = Math.Max(10000 - currentLevel * 1000, 3000); // Gets harder
            lblHealthBar.Text = $"Health  {Health}";

            // Clear bullets and wolves
            foreach (PictureBox bullet in Bullets)
                this.Controls.Remove(bullet);
            Bullets.Clear();

            foreach (Wolf wolf in Wolfs)
                this.Controls.Remove(wolf);
            Wolfs.Clear();

            // Show level label
            lblLevelUp.Text = $"Level {currentLevel + 1}!";
            lblLevelUp.AutoSize = true;
            lblLevelUp.BackColor = Color.Transparent;
            lblLevelUp.Left = ClientSize.Width / 2 - 100;
            lblLevelUp.Top = ClientSize.Height / 2 - 50;
            lblLevelUp.Visible = true;

            // Start timer
            tmrLevelLabel.Tick -= TmrLevelLabel_Tick;
            tmrLevelLabel.Tick += TmrLevelLabel_Tick;
            tmrLevelLabel.Interval = 3000;
            tmrLevelLabel.Start();
        }

        // Update the timer tick handler:
        private void TmrLevelLabel_Tick(object sender, EventArgs e)
        {
            lblLevelUp.Visible = false;
            tmrLevelLabel.Stop();

            currentLevel++;

            int wolvesToSpawn = 5 * currentLevel;

            if (currentLevel == 2)
            {
                SpawnWolves(wolvesToSpawn); // Level 2 regular wolves
                GameState = GameStates.Level2;
            }
            if (currentLevel == 3)
            {
                SpawnWolves(5);      // fewer regular wolves
                SpawnBossWolf();     // only spawn in Level 3
                GameState = GameStates.Level3;
            }
            FireBullet = true;

            

            tmrGame.Enabled = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (GameState == GameStates.Menu)
            {
                //in Menu mode

                if (e.KeyCode == Keys.Return)
                {
                    //start the game
                    StartGame();
                }
                if (e.KeyCode == Keys.D1)
                {
                    //Open instructions 
                    Instructions();

                }
                if (e.KeyCode == Keys.D2)
                {
                    //Open instructions 
                    ControlMenu();
                }





            }
            if (GameState == GameStates.Game || GameState == GameStates.Level2 || GameState == GameStates.Level3)
            {
                //in Game Play mode
                if (e.KeyCode == Keys.Up) Piggy1Up = true;
                if (e.KeyCode == Keys.Down) Piggy1Down = true;
                if (e.KeyCode == Keys.Right) Piggy1Right = true;
                if (e.KeyCode == Keys.Left) Piggy1Left = true;

                if (e.KeyCode == Keys.W) Piggy2Up = true;
                if (e.KeyCode == Keys.S) Piggy2Down = true;
                if (e.KeyCode == Keys.D) Piggy2Right = true;
                if (e.KeyCode == Keys.A) Piggy2Left = true;

                //detect if a space  and F is pressed to fire a bullet
                if (e.KeyCode == Keys.Space && FireBullet)
                {
                    CreateBullet1();

                    //must reload to fire another bullet
                    FireBullet = false;
                }
                if (e.KeyCode == Keys.F && FireBullet)
                {
                    CreateBullet2();

                    //must reload to fire another bullet
                    FireBullet = false;
                }

            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            if (GameState == GameStates.Game || GameState == GameStates.Level2 || GameState == GameStates.Level3)
            {
                //in Game Play mode
                if (e.KeyCode == Keys.Up) Piggy1Up = false;
                if (e.KeyCode == Keys.Down) Piggy1Down = false;
                if (e.KeyCode == Keys.Right) Piggy1Right = false;
                if (e.KeyCode == Keys.Left) Piggy1Left = false;

                if (e.KeyCode == Keys.W) Piggy2Up = false;
                if (e.KeyCode == Keys.S) Piggy2Down = false;
                if (e.KeyCode == Keys.D) Piggy2Right = false;
                if (e.KeyCode == Keys.A) Piggy2Left = false;


                //reload bullet 
                if (e.KeyCode == Keys.Space) FireBullet = true;
                if (e.KeyCode == Keys.F) FireBullet = true;


            }

        }

        public void CreateWolf()
        {
           

            

            //create an Wolf

            //set position of wolfs
            int X =  ClientSize.Width - 100;
            int Y = oRand.Next(30, ClientSize.Height - 50);

            

            //set a random angle
            double Angle = oRand.Next(10, 351);
            if (Angle == 90 || Angle == 180 || Angle == 270)
                Angle += 10;
            //convert to radian
            Angle = Angle * Math.PI / 180;

            //set a random speed
            int Speed = oRand.Next(10, 19);

            //set a random size
            int Size = oRand.Next(1, 4);
            if (Size == 1)
                Size = 30; //small Wolf
            else if (Size == 2)
                Size = 40;  //medium Wolf
            else
                Size = 55; //large Wolf

            //create the Wolf in memory
            Wolf oWolf = new Wolf(X, Y, Angle, Speed, Size);

            //add the Wolf control to the form
            this.Controls.Add(oWolf);

            //add the Wolf to the list Wolfs
            Wolfs.Add(oWolf);


        }

        
        public void CreateBullet1()
        {
            //create a bulet when fired from the Piggy1

            PictureBox Bullet1 = new PictureBox();
            Bullet1.BackColor = Color.Teal;
            Bullet1.Width = 10;
            Bullet1.Height = 5;
            //position the bullet based on Piggy1 position
            Bullet1.Left = picPiggy1.Right;
            Bullet1.Top = picPiggy1.Top + (picPiggy1.Height / 2 - Bullet1.Height / 2);
            Bullet1.Visible = true;

            //add the bullet to form controls
            this.Controls.Add(Bullet1);

            //add the bullet to the bullet list
            Bullets.Add(Bullet1);

        }

        public void CreateBullet2()
        {
            //create a bulet when fired from the Piggy2

            PictureBox Bullet2 = new PictureBox();
            Bullet2.BackColor = Color.Teal;
            Bullet2.Width = 10;
            Bullet2.Height = 5;
            //position the bullet based on Piggy1 position
            Bullet2.Left = picPiggy2.Right;
            Bullet2.Top = picPiggy2.Top + (picPiggy2.Height / 2 - Bullet2.Height / 2);
            Bullet2.Visible = true;

            //add the bullet to form controls
            this.Controls.Add(Bullet2);

            //add the bullet to the bullet list
            Bullets.Add(Bullet2);

        }

        
        private void SpawnWolves(int count)
        {
            for (int i = 0; i < count; i++)
            {
                CreateWolf(); // Uses your existing Wolf creation logic
            }
        }

        public void Level3()
        {
            HideMenu();

            // Reset positions
            picPiggy1.Left = ClientSize.Width / 4 - picPiggy1.Width / 2;
            picPiggy1.Top = ClientSize.Height / 4 - picPiggy1.Height / 2;
            picPiggy2.Left = ClientSize.Width / 4 - picPiggy2.Width / 2;
            picPiggy2.Top = ClientSize.Height * 3 / 4 - picPiggy2.Height / 2;
            picHouse.Left = ClientSize.Width / 8 - picHouse.Width / 2;
            picHouse.Top = ClientSize.Height / 2 - picHouse.Height / 2;

            // Reset health
            Health = 8000; // Harder because it's lower than previous level
            lblHealthBar.Text = $"Health  {Health}";

            // Clear bullets and wolves
            foreach (PictureBox bullet in Bullets)
                this.Controls.Remove(bullet);
            Bullets.Clear();

            foreach (Wolf wolf in Wolfs)
                this.Controls.Remove(wolf);
            Wolfs.Clear();

            // Show "Level 3" message
            lblLevelUp.Text = "Level 3!";
            lblLevelUp.AutoSize = true;
            lblLevelUp.BackColor = Color.Transparent;
            lblLevelUp.Left = ClientSize.Width / 2 - 100;
            lblLevelUp.Top = ClientSize.Height / 2 - 50;
            lblLevelUp.Visible = true;

            tmrLevelLabel.Tick -= TmrLevelLabel_Tick;
            tmrLevelLabel.Tick += TmrLevelLabel_Tick;
            tmrLevelLabel.Interval = 3000;
            tmrLevelLabel.Start();
        }

        public void TriggerGameOver()
        {
            // Show the Game Over label
            lblGameOver.Text = "GAME OVER";
            lblGameOver.Font = new Font("Arial", 28, FontStyle.Bold);
            lblGameOver.ForeColor = Color.Red;
            lblGameOver.BackColor = Color.Transparent;
            lblGameOver.Left = ClientSize.Width / 2 - lblGameOver.Width / 2;
            lblGameOver.Top = ClientSize.Height / 2 - lblGameOver.Height / 2;
            lblGameOver.Visible = true;
            lblGameOver.BringToFront();

            tmrGameOver.Interval = 3000; // show for 3 seconds
            tmrGameOver.Tick -= TmrGameOver_Tick;
            tmrGameOver.Tick += TmrGameOver_Tick;
            tmrGameOver.Start();
        }
        private void TmrGameOver_Tick(object sender, EventArgs e)
        {
            tmrGameOver.Stop();
            lblGameOver.Visible = false;

            // Reset game state
            currentLevel = 1;
            Health = 10000;

            // Reset player visibility
            picPiggy1.Visible = false;
            picPiggy2.Visible = false;
            picHouse.Visible = false;
            lblHealthBar.Visible = false;

            // Clear all bullets and wolves
            foreach (PictureBox bullet in Bullets)
                this.Controls.Remove(bullet);
            Bullets.Clear();

            foreach (Wolf wolf in Wolfs)
                this.Controls.Remove(wolf);
            Wolfs.Clear();
            // Reset movement flags
            Piggy1Up = false;
            Piggy1Down = false;
            Piggy1Left = false;
            Piggy1Right = false;
            Piggy2Up = false;
            Piggy2Down = false;
            Piggy2Left = false;
            Piggy2Right = false;
            ShowMenu();
        }

        public void TriggerEndScreen()
        {
            // Stop the game loop
            tmrGame.Enabled = false;

            // Hide all gameplay elements
            picPiggy1.Visible = false;
            picPiggy2.Visible = false;
            picHouse.Visible = false;
            lblHealthBar.Visible = false;

            // Remove bullets
            foreach (PictureBox bullet in Bullets)
            {
                this.Controls.Remove(bullet);
            }
            Bullets.Clear();

            // Remove wolves
            foreach (Wolf wolf in Wolfs)
            {
                this.Controls.Remove(wolf);
            }
            Wolfs.Clear();

            // Remove boss if still there
            if (bossWolf != null)
            {
                Controls.Remove(bossWolf);
                bossWolf = null;
            }
            if (lblBossHealth != null)
            {
                Controls.Remove(lblBossHealth);
                lblBossHealth = null;
            }

            // Show the End Screen label
            lblEndScreen.Text = "You defended the piggies!\nThe house is safe 🐷🏠\nYou win!";
            lblEndScreen.Font = new Font("Arial", 20, FontStyle.Bold);
            lblEndScreen.ForeColor = Color.Green;
            lblEndScreen.BackColor = Color.Transparent;
            lblEndScreen.AutoSize = true;
            lblEndScreen.Left = ClientSize.Width / 2 - lblEndScreen.Width / 2;
            lblEndScreen.Top = ClientSize.Height / 2 - lblEndScreen.Height / 2;
            lblEndScreen.Visible = true;
            lblEndScreen.BringToFront();

            // Start timer to go back to menu
            tmrEndScreen.Interval = 4000;
            tmrEndScreen.Tick -= TmrEndScreen_Tick;
            tmrEndScreen.Tick += TmrEndScreen_Tick;
            tmrEndScreen.Start();
        }

        private void TmrEndScreen_Tick(object sender, EventArgs e)
        {
            tmrEndScreen.Stop();
            lblEndScreen.Visible = false;
            ShowMenu();
            currentLevel = 1;
            Health = 10000;
        }
        private void SpawnBossWolf()
        {
            bossWolf = new PictureBox();
            bossWolf.Image = Assets.Wolf;
            bossWolf.SizeMode = PictureBoxSizeMode.StretchImage;
            bossWolf.Width = 380;  // wider
            bossWolf.Height = 380; // taller
            bossWolf.Left = ClientSize.Width - bossWolf.Width;
            bossWolf.Top = ClientSize.Height / 2 - bossWolf.Height / 2;
            bossWolf.Tag = "Boss";

            Controls.Add(bossWolf);
            bossWolf.BringToFront();

            bossHealth = 500; // Reset health every time boss is created

            // Boss health bar
            lblBossHealth = new Label();
            lblBossHealth.Text = $"Boss Health: {bossHealth}";
            lblBossHealth.ForeColor = Color.White;
            lblBossHealth.BackColor = Color.Black;
            lblBossHealth.Font = new Font("Arial", 10, FontStyle.Bold);
            lblBossHealth.AutoSize = true;
            lblBossHealth.Left = bossWolf.Left;
            lblBossHealth.Top = bossWolf.Top - 20;
            lblBossHealth.BringToFront();

            Controls.Add(lblBossHealth);

            bossSpawned = true;
        }
        private void ApplyPiggyEffect(int piggyNumber)
        {
            PictureBox piggy = (piggyNumber == 1) ? picPiggy1 : picPiggy2;
            int originalSpeed = (piggyNumber == 1) ? Piggy1Speed : Piggy2Speed;
            int slowSpeed = 3;

            // Shrink and slow down
            piggy.Width /= 2;
            piggy.Height /= 2;
            if (piggyNumber == 1) Piggy1Speed = slowSpeed;
            else Piggy2Speed = slowSpeed;

            //make sure they dont skrink too low
            if (piggy.Width <= 10 || piggy.Height <= 10)
                return; // already too small
            // Timer to reset
            Timer effectTimer = new Timer();
            effectTimer.Interval = 3000; // 3 seconds effect
            effectTimer.Tick += (s, e) =>
            {
                // Restore size
                piggy.Width *= 2;
                piggy.Height *= 2;

                // Restore speed
                if (piggyNumber == 1) Piggy1Speed = originalSpeed;
                else Piggy2Speed = originalSpeed;

                effectTimer.Stop();
                effectTimer.Dispose();
            };
            effectTimer.Start();
        }
    }
}
