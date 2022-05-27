using System;
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
        Rectangle hero = new Rectangle(10, 10, 15, 25);
        int heroSpeed = 10;

        List<Rectangle> enemy = new List<Rectangle>();
        List<int> enemySpeeds = new List<int>();
        int enemySize = 10;

        bool leftDown = false;
        bool rightDown = false;
        bool upDown = false;
        bool downDown = false;

        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush goldBrush = new SolidBrush(Color.Gold);
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        Random randGen = new Random();
        int randValue = 0;

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

            //add new
            counter++;
            if (enemy.Count <= 1)
            {
                enemy.Add(new Rectangle(200, 50, 10, 15));
                enemySpeeds.Add(randGen.Next(1, 4));
                counter = 0;
            }

            //removes when off screen
            //
            //edit code so enemy goes back to base and then gets removed
            //currently removes when bottom of screen is reached
            for (int i = 0; i < enemy.Count(); i++)
            {
                if (enemy[i].Y > this.Height - enemySize)
                {
                    enemy.RemoveAt(i);
                    enemySpeeds.RemoveAt(i);
                }
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
                //draw hero
                e.Graphics.FillRectangle(whiteBrush, hero);

                //draw enemies
                for (int i = 0; i < enemy.Count(); i++)
                {
                    e.Graphics.FillRectangle(goldBrush, enemy[i]);
                }
            }
        }
    }
}
