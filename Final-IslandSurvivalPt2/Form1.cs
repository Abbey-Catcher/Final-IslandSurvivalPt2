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
        Rectangle mainIsland = new Rectangle(75, 100, 300, 400);
        Rectangle beachyIsland = new Rectangle(75, 475 , 300, 60);
        Rectangle boat = new Rectangle(100, 515, 20, 30);
        Rectangle tool = new Rectangle(200, 500, 20, 20);
        Rectangle hero = new Rectangle(10, 10, 15, 25);
        int heroSpeed = 10;

        //inventory contents
        bool axe = false;
        bool pickaxe = false;
        bool sword = false;
        bool hammer = false;
        int wood = 0;
        int stone = 0;
        int iron = 0;

        //creating enemies
        List<Rectangle> enemy = new List<Rectangle>();
        List<int> enemySpeeds = new List<int>();
        int enemySize = 10;

        //creating resources
        //List<Rectangle> resource = new List<Rectangle>();
        Rectangle resource1 = new Rectangle(125, 250, 20, 20);
        Rectangle resource2 = new Rectangle(325, 250, 20, 20);
        Rectangle resource3 = new Rectangle(250, 400, 20, 20);

        //control keys
        bool leftDown = false;
        bool rightDown = false;
        bool upDown = false;
        bool downDown = false;

        //brushes
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush goldBrush = new SolidBrush(Color.Gold);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush brownBrush = new SolidBrush(Color.Brown);
        SolidBrush resource = new SolidBrush(Color.DarkGoldenrod);
        SolidBrush resourceReload = new SolidBrush(Color.Goldenrod);

        Random randGen = new Random();

        int counter = 0;
        string gameState = "waiting";

        public Form1()
        {
            InitializeComponent();
        }

        public void GameInitialize()
        {
            titleLabel.Text = "";
            subtitleLabel.Text = "";

            gameTimer.Enabled = true;
            gameState = "running";
            enemy.Clear();
            enemySpeeds.Clear();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
                case Keys.Up:
                    upDown = true;
                    break;
                case Keys.Down:
                    downDown = true;
                    break;
                case Keys.Space:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        GameInitialize();
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        Application.Exit();
                    }
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
                case Keys.Up:
                    upDown = false;
                    break;
                case Keys.Down:
                    downDown = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //move hero 
            if (leftDown == true && hero.X > 0)
            {
                hero.X -= heroSpeed;
            }

            if (rightDown == true && hero.X < this.Width - hero.Width)
            {
                hero.X += heroSpeed;
            }

            if (upDown == true && hero.Y > 0)
            {
                hero.Y -= heroSpeed;
            }

            if (downDown == true && hero.Y < this.Height - hero.Height)
            {
                hero.Y += heroSpeed;
            }

            //move enemy 
            for (int i = 0; i < enemy.Count(); i++)
            {
                //find the new postion of y based on speed 
                int y = enemy[i].Y + enemySpeeds[i];

                //replace the rectangle in the list with updated one using new y 
                enemy[i] = new Rectangle(enemy[i].X, y, enemySize, enemySize);
            }

            //add new enemy
            counter++;
            if (enemy.Count <= 1 && counter > 100)
            {
                //starts more in on island
                enemy.Add(new Rectangle(200, mainIsland.Y + 40, 10, 15));
                enemySpeeds.Add(randGen.Next(1, 4));
                counter = 0;
            }

            //removes when off screen
            //
            //edit code so enemy goes back to base and then gets removed
            for (int i = 0; i < enemy.Count(); i++)
            {
                if (enemy[i].Y > beachyIsland.Y - enemy[i].Height)
                {
                    //turn around
                    enemySpeeds[i] = enemySpeeds[i] * -1;
                }
                else if (enemy[i].Y < mainIsland.Y + 20)
                {
                    enemy.RemoveAt(i);
                    enemySpeeds.RemoveAt(i);
                    counter = 0;
                }
            }

            if (hero.IntersectsWith(tool))
            {
                //add tool to inventory
                axe = true;
            }

            if (hero.IntersectsWith(boat) && wood == 20)
            {

            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "waiting")
            {
                titleLabel.Text = "IslandSurvival";
                subtitleLabel.Text = "Press Space Bar to Start or Escape to Exit";
            }
            else if (gameState == "running")
            {
                //change back colour
                this.BackColor = Color.MediumTurquoise;

                //draw island
                e.Graphics.FillRectangle(greenBrush, mainIsland);
                e.Graphics.FillRectangle(goldBrush, beachyIsland);

                //draw boat
                e.Graphics.FillRectangle(brownBrush, boat);

                //draw first tool
                e.Graphics.DrawImage(Properties.Resources.Axe_Final, tool);

                //draw resources
                //
                //for (int i = 0; i < resource.Count(); i++)
                //{
                //    e.Graphics.FillRectangle(brownBrush, resource[i]);
                //}
                e.Graphics.FillRectangle(resource, resource1);
                e.Graphics.FillRectangle(goldBrush, resource2);
                e.Graphics.FillRectangle(goldBrush, resource3);

                //regenerating resource
                int rCounter = 0;
                if (hero.IntersectsWith(resource1))
                {
                    e.Graphics.FillRectangle(resourceReload, resource1);
                    rCounter++;
                }
                else if (hero.IntersectsWith(resource2))
                {
                    e.Graphics.FillRectangle(resourceReload, resource2);
                    rCounter++;
                }
                else if (hero.IntersectsWith(resource3))
                {
                    e.Graphics.FillRectangle(resourceReload, resource3);
                    rCounter++;
                }

                //draw enemies
                for (int i = 0; i < enemy.Count(); i++)
                {
                    e.Graphics.FillRectangle(goldBrush, enemy[i]);
                }

                //draw hero
                e.Graphics.FillRectangle(whiteBrush, hero);
            }
        }
    }
}
