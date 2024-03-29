﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_IslandSurvivalPt2
{
    public partial class Form1 : Form
    {
        //size: 480, 648

        //Rectangle mainIsland = new Rectangle(75, 100, 300, 400);
        //Rectangle beachyIsland = new Rectangle(75, 475, 300, 60);
        Rectangle boat = new Rectangle(100, 505, 40, 40);

        Rectangle anvil = new Rectangle(250, 495, 20, 20);
        Rectangle axeTool = new Rectangle(200, 500, 20, 20);
        Rectangle pickaxeTool = new Rectangle(200, 500, 20, 20);
        Rectangle swordTool = new Rectangle(200, 500, 20, 20);
        Rectangle hammerTool = new Rectangle(200, 500, 20, 20);

        //hero.Location = new Point(325, 475);
        //Rectangle hero = new Rectangle(325, 475, 30, 40);

        

        bool Axe2 = false;
        bool Pickaxe2 = false;
        bool Sword2 = false;


        //inventory system
        

        //creating enemies
        //Rectangle enemyFight = new Rectangle(50, 50, 50, 50);

        //creating resources
        //Rectangle resource1 = new Rectangle(125, 250, 20, 20);
        Rectangle resource2 = new Rectangle(325, 250, 20, 20);
        Rectangle resource3 = new Rectangle(250, 400, 20, 20);
        bool resource01 = false;
        bool resource02 = false;
        bool resource03 = false;

        //brushes
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush goldBrush = new SolidBrush(Color.Gold);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush brownBrush = new SolidBrush(Color.Brown);
        SolidBrush resourceReload = new SolidBrush(Color.DarkGoldenrod);
        SolidBrush resource = new SolidBrush(Color.Goldenrod);
        SolidBrush lightBlueBrush = new SolidBrush(Color.LightBlue);
        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush blackBrush = new SolidBrush(Color.Black);

        int counter = 0;
        int rCounter = 0;
        

        public Form1()
        {
            InitializeComponent();
        }

        public void GameInitialize()
        {
            titleLabel.Text = "";
            subtitleLabel.Text = "";
            inventoryTLabel.Text = "";

            inventoryImage.Visible = true;
            
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            {

                //adds axe to inventory
                if (hero.IntersectsWith(axeTool))
                {
                    //add tool to inventory
                    axe = true;
                }


               

                //if counter >= 8 seconds, set bools to false
                if (rCounter >= 400 && resource01 == true)
                {
                    resource01 = false;
                    rCounter = 0;
                }
                else if (rCounter >= 400 && resource02 == true)
                {
                    resource02 = false;
                    rCounter = 0;
                }
                else if (rCounter >= 400 && resource03 == true)
                {
                    resource03 = false;
                    rCounter = 0;
                }



                //removes when off screen
                //
                //edit code so enemy goes back to base and then gets removed
                for (int i = 0; i < enemy.Count(); i++)
                {
                    if (enemy[i].Y > 425)
                    {
                        //turn around
                        enemySpeeds[i] = enemySpeeds[i] * -1;
                    }
                    else if (enemy[i].Y < 125)
                    {
                        enemy.RemoveAt(i);
                        enemySpeeds.RemoveAt(i);
                        counter = 0;
                    }
                }


                //for (int i = 0; i > enemy.Count; i++)
                /
            }
            else if (gameState == "fight")
            {
                enemyLivesLabel.Visible = true;
                heroLivesLabel.Visible = true;
                enemyLivesLabel.Text = $"Enemy Health: {enemyLives}";
                heroLivesLabel.Text = $"Hero Health: {heroLives}";

                //for (int i = 0; i > enemy.Count; i++)
                //{
                //    if (enemySpeeds[i] == 1 || enemySpeeds[i] == -1)
                //    {
                //        enemyLives = 7;
                //    }
                //    else if (enemySpeeds[i] == 2 || enemySpeeds[i] == -2)
                //    {
                //        enemyLives = 10;
                //    }
                //    else if (enemySpeeds[i] == 3 || enemySpeeds[i] == -3)
                //    {
                //        enemyLives = 15;
                //    }
                //}

                //for (int i = 0; i > enemy.Count; i++)
                //{
                if (enemyLives <= 0)
                {
                    gameState = "running";
                    //enemy.RemoveAt(i);
                }
                else if (heroLives <= 0)
                {
                    gameState = "lose";
                }

            }
            else if (gameState == "anvil")
            {
                this.BackgroundImage = null;
                inventoryImage.Visible = false;
                anvilUpgrade();

                if (nDown == true)
                {
                    gameState = "running";
                    nDown = false;
                }
            }
            else if (gameState == "win")
            {
                this.BackColor = Color.Green;
                titleLabel.Text = "Yay! \nYou repaired the boat and got off the island!";
                subtitleLabel.Text = "Press Space Bar to Start Again\nPress Esc to Exit";
            }
            else if (gameState == "lose")
            {
                this.BackColor = Color.Red;

                enemyLivesLabel.Visible = false;
                heroLivesLabel.Visible = false;

                titleLabel.Text = "Oh no! \nYou died!";
                subtitleLabel.Text = "Press Space Bar to Start Again\nPress Esc to Exit";
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
                //draw first tool
                if (axe == false)
                {
                    e.Graphics.DrawImage(Properties.Resources.Axe_Final, axeTool);
                }

                //regenerating resource
                if (resource01 == true)
                {
                    e.Graphics.FillRectangle(resourceReload, resource1);
                }
                else
                {
                    e.Graphics.FillRectangle(resource, resource1);
                }

                if (resource02 == true)
                {
                    e.Graphics.FillRectangle(resourceReload, resource2);
                }
                else
                {
                    e.Graphics.FillRectangle(resource, resource2);
                }

            if (resource03 == true)
            {
                e.Graphics.FillRectangle(resourceReload, resource3);
            }
            else
            {
                e.Graphics.FillRectangle(resource, resource3);
            }
            }
            

        //void anvilUpgrade()
        //{
        //    switch (anvilMode)
        //    {
        //        //upgrade axe
        //        case "Axe":
        //            if (downDown == true)
        //            {
        //                anvilMode = "Pickaxe";
        //                downDown = false;
        //            }
        //            else if (downDown == true && pickaxe == true)
        //            {
        //                anvilMode = "Pickaxe1";
        //                downDown = false;
        //            }
        //            else if (yDown == true)
        //            {
        //                if (inventory[4] == 5)
        //                {
        //                    Axe2 = true;
        //                }
        //                else
        //                {
        //                    Axe2 = false;
        //                    subtitleLabel.Text = "You don't have enough resources to make this upgrade.";
        //                }
        //                yDown = false;
        //            }
        //            else if (nDown == true)
        //            {
        //                gameState = "running";
        //            }
        //            break;
        //        case "Pickaxe":
        //            if (downDown == true)
        //            {
        //                anvilMode = "Sword";
        //                downDown = false;
        //            }
        //            else if (downDown == true && sword == true)
        //            {
        //                anvilMode = "Sword1";
        //                downDown = false;
        //            }
        //            else if (upDown == true)
        //            {
        //                anvilMode = "Axe";
        //                upDown = false;
        //            }
        //            else if (yDown == true)
        //            {
        //                if (inventory[4] == 8 && inventory[5] == 3)
        //                {
        //                    pickaxe = true;
        //                }
        //                else
        //                {
        //                    Pickaxe2 = false;
        //                    subtitleLabel.Text = "You don't have enough resources to make this upgrade.";
        //                }
        //                yDown = false;
        //            }
        //            else if (nDown == true)
        //            {
        //                gameState = "running";
        //            }
        //            break;
        //        case "Sword":
        //            if (upDown == true)
        //            {
        //                anvilMode = "Pickaxe";
        //                upDown = false;
        //            }
        //            else if (upDown == true && pickaxe == true)
        //            {
        //                anvilMode = "Pickaxe1";
        //                upDown = false;
        //            }
        //            else if (yDown == true)
        //            {
        //                if (inventory[4] == 12 && inventory[5] == 7 && inventory[6] == 2)
        //                {
        //                    Sword2 = true;
        //                }
        //                else
        //                {
        //                    Sword2 = false;
        //                    subtitleLabel.Text = "You don't have enough resources to make this upgrade.";
        //                }
        //                yDown = false;
        //            }
        //            else if (nDown == true)
        //            {
        //                gameState = "running";
        //            }
        //            break;
        //        case "Pickaxe1":
        //            if (downDown == true)
        //            {
        //                anvilMode = "Sword";
        //                downDown = false;
        //            }
        //            else if (downDown == true && sword == true)
        //            {
        //                anvilMode = "Sword1";
        //                downDown = false;
        //            }
        //            else if (upDown == true)
        //            {
        //                anvilMode = "Axe";
        //                upDown = false;
        //            }
        //            else if (yDown == true && pickaxe == true)
        //            {
        //                if (inventory[4] == 10 && inventory[5] == 5)
        //                {
        //                    Pickaxe2 = true;
        //                }
        //                else
        //                {
        //                    Pickaxe2 = false;
        //                    subtitleLabel.Text = "You don't have enough resources to make this upgrade.";
        //                }
        //                yDown = false;
        //            }
        //            else if (nDown == true)
        //            {
        //                gameState = "running";
        //            }
        //            break;
        //        case "Sword1":
        //            if (upDown == true)
        //            {
        //                anvilMode = "Pickaxe";
        //                upDown = false;
        //            }
        //            else if (upDown == true && pickaxe == true)
        //            {
        //                anvilMode = "Pickaxe1";
        //                upDown = false;
        //            }
        //            else if (yDown == true && sword == true)
        //            {
        //                if (inventory[4] == 12 && inventory[5] == 7 && inventory[6] == 2)
        //                {
        //                    Sword2 = true;
        //                }
        //                else
        //                {
        //                    Sword2 = false;
        //                    subtitleLabel.Text = "You don't have enough resources to make this upgrade.";
        //                }
        //                yDown = false;
        //            }
        //            else if (nDown == true)
        //            {
        //                gameState = "running";
        //            }
        //            break;
        //    }
        //}

        public static void ChangeScreen(UserControl current, UserControl next)
        {
            Form f = current.FindForm();
            f.Controls.Remove(current);

            next.Location = new Point((f.ClientSize.Width - next.Width) / 2,
                (f.ClientSize.Height - next.Height) / 2);

            //make form1 the same size as new screens
            f.Controls.Add(next);
            next.Focus();
        }
    }
}