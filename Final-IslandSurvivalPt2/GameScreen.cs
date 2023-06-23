using Final_IslandSurvivalPt2.Properties;
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
    public partial class GameScreen : UserControl
    {
        List<int> inventory = new List<int>(new int[] { 0, 0, 0, 0, 0, 0, 0 });
        List<Enemies> enemy = new List<Enemies>();
        List<Resource> resources = new List<Resource>();

        Player hero;

        //control keys
        bool leftDown = false;
        bool rightDown = false;
        bool upDown = false;
        bool downDown = false;
        bool yDown = false;
        bool nDown = false;

        bool canMove = true;
        int playCounter, rCounter;

        //inventory tools
        bool axe = false;
        bool pickaxe = false;
        bool sword = false;
        bool hammer = false;

        bool resource01 = false;
        bool resource02 = false;
        bool resource03 = false;

        string mode = "attack";
        Random randGen = new Random();

        public GameScreen()
        {
            InitializeComponent();
            GameInitialize();
        }

        public void GameInitialize()
        {
            gameTimer.Enabled = true;
            hero = new Player(120, 310);

            Resource resource01 = new Resource(125, 250);
            resources.Add(resource01);

            Resource resource02 = new Resource(125, 250);
            resources.Add(resource02);

            Resource resource03 = new Resource(125, 250);
            resources.Add(resource03);
        }


        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                upDown = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                downDown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                leftDown = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                rightDown = false;
            }
            if (e.KeyCode == Keys.Y)
            {
                yDown = false;
            }
            if (e.KeyCode == Keys.N)
            {
                nDown = false;
            }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                upDown = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                downDown = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                leftDown = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                rightDown = true;
            }
            if (e.KeyCode == Keys.Y)
            {
                yDown = true;
            }
            if (e.KeyCode == Keys.N)
            {
                nDown = true;
            }
            if (e.KeyCode == Keys.I)
            {
                Form1.ChangeScreen(this, new InventoryScreen());
            }

                //case Keys.Space:
                //    if (gameState == "waiting" || gameState == "lose" || gameState == "win")
                //    {
                //        GameInitialize();
                //    }
                //    break;
                //case Keys.I:
                //    if (gameState == "running")
                //    {
                //        inventoryTLabel.Visible = true;
                //        inventoryRLabel.Visible = true;

                //        inventoryTLabel.Text = $"Axe:   {inventory[0]}\n";
                //        inventoryTLabel.Text += $"Pickaxe: {inventory[1]}\n";
                //        inventoryTLabel.Text += $"Sword:  {inventory[2]}\n";
                //        inventoryTLabel.Text += $"Hammer:  {inventory[3]}\n";

                //        inventoryRLabel.Text = $"Wood: {inventory[4]}\n";
                //        inventoryRLabel.Text += $"Stone:  {inventory[5]}\n";
                //        inventoryRLabel.Text += $"Iron:  {inventory[6]}\n";
                //    }
                //    break;
            }

        public void gameTimer_Tick(object sender, EventArgs e)
        {
            playCounter++;
            if (playCounter == 15)
            {
                canMove = true;
            }

            if (upDown && hero.y > 0 && canMove)
            {
                hero.Move("up");
                canMove = false;
                playCounter = 0;
            }
            if (downDown && hero.y < this.Height - hero.height && canMove)
            {
                hero.Move("down");
                canMove = false;
                playCounter = 0;
            }
            if (leftDown && hero.x > 0 && canMove)
            {
                hero.Move("left");
                canMove = false;
                playCounter = 0;
            }
            if (rightDown && hero.x < this.Width - hero.width && canMove)
            {
                hero.Move("right");
                canMove = false;
                playCounter = 0;
            }

            foreach(Enemies b in enemy)
            {
                b.Move(this.Width, this.Height);
            }

            //collision
            foreach (Enemies b in enemy)
            {
                if (b.Collision(hero))
                {
                    gameTimer.Enabled = false;
                    Form1.ChangeScreen(this, new FightScreen());
                }
            }
            for (int i = 0; i < enemy.Count; i++)
            {
                if (b.lives <= 0 || b.y <= 5)
                {
                    enemy.RemoveAt(i);
                }
            }

            //anvil
            //if (hero.IntersectsWith(anvil))
            //{
            //    Form1.ChangeScreen(this, new AnvilScreen());
            //}

            //regenerating resources
            if (hero.IntersectsWith(resource1))
            {
                inventory[5]++;
            }
            else if (hero.IntersectsWith(resource2))
            {
                inventory[6]++;
            }
            else if (hero.IntersectsWith(resource3))
            {
                inventory[4]++;
            }
            if (resource01 == true || resource02 == true || resource03 == true)
            {
                rCounter++;
            }

            if (hero.IntersectsWith(boat) && inventory[4] == 20 && inventory[5] == 15 && inventory[6] == 10 && hammer == true)
            {
                Form1.ChangeScreen(this, new WinSreen());
            }

            if (hero.lives == 0)
            {
                Form1.ChangeScreen(this, new LoseScreen());
            }
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw each enemy based on speed
            foreach (Enemies b in enemy)
            {
                b.ySpeed = randGen.Next(1, 4);

                if (b.ySpeed == 1)
                {
                    e.Graphics.DrawImage(Properties.Resources.Slime_Final, b.x, b.y);
                }
                else if (b.ySpeed == 2)
                {
                    e.Graphics.DrawImage(Properties.Resources.Skeleton_Final, b.x, b.y);
                }
                else if (b.ySpeed == 3)
                {
                    e.Graphics.DrawImage(Properties.Resources.Goblin_Final, b.x, b.y);
                }
            }

            //draw hero
            e.Graphics.DrawImage(Properties.Resources.Hero_Final, hero.x, hero.y);
        }

        //void FightMoves()
        //{
        //    switch (mode)
        //    {
        //        case "attack":
        //            if (rightDown == true)
        //            {
        //                mode = "run";
        //            }
        //break;
        //case "run":
        //    if (leftDown == true)
        //    {
        //        mode = "attack";
        //    }
        //    break;
        //}
        //}
    }
}
