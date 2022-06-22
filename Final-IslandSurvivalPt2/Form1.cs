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
        Rectangle hero = new Rectangle(325, 475, 30, 40);
        int heroSpeed = 10;
        int heroLives = 20;

        //inventory contents
        bool axe = false;
        bool pickaxe = false;
        bool sword = false;
        bool hammer = false;

        bool Axe2 = false;
        bool Pickaxe2 = false;
        bool Sword2 = false;


        //inventory system
        List<int> inventory = new List<int>(new int[] { 0, 0, 0, 0, 0, 0, 0 });

        //creating enemies
        Rectangle enemyFight = new Rectangle(50, 50, 50, 50);
        List<Rectangle> enemy = new List<Rectangle>();
        List<int> enemySpeeds = new List<int>();
        int enemySize = 30;
        int enemyLives = 10;

        //creating resources
        Rectangle resource1 = new Rectangle(125, 250, 20, 20);
        Rectangle resource2 = new Rectangle(325, 250, 20, 20);
        Rectangle resource3 = new Rectangle(250, 400, 20, 20);
        bool resource01 = false;
        bool resource02 = false;
        bool resource03 = false;

        //control keys
        bool leftDown = false;
        bool rightDown = false;
        bool upDown = false;
        bool downDown = false;
        bool yDown = false;
        bool nDown = false;

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
        Font fightFont = new Font("Rockwell", 12);

        Random randGen = new Random();

        int counter = 0;
        int rCounter = 0;
        int playerDamageAmount = 0;
        int enemyDamageAmount = 0;
        string gameState = "waiting";
        string mode = "attack";
        string anvilMode = "Axe";

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
                case Keys.Y:
                    yDown = true;
                    break;
                case Keys.N:
                    nDown = true;
                    break;
                case Keys.Space:
                    if (gameState == "waiting" || gameState == "lose" || gameState == "win")
                    {
                        GameInitialize();
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "lose" || gameState == "win")
                    {
                        Application.Exit();
                    }
                    break;
                case Keys.I:
                    if (gameState == "running")
                    {
                        inventoryTLabel.Visible = true;
                        inventoryRLabel.Visible = true;

                        inventoryTLabel.Text = $"Axe:   {inventory[0]}\n";
                        inventoryTLabel.Text += $"Pickaxe: {inventory[1]}\n";
                        inventoryTLabel.Text += $"Sword:  {inventory[2]}\n";
                        inventoryTLabel.Text += $"Hammer:  {inventory[3]}\n";

                        inventoryRLabel.Text = $"Wood: {inventory[4]}\n";
                        inventoryRLabel.Text += $"Stone:  {inventory[5]}\n";
                        inventoryRLabel.Text += $"Iron:  {inventory[6]}\n";
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
                case Keys.Y:
                    yDown = false;
                    break;
                case Keys.N:
                    nDown = false;
                    break;
                case Keys.I:
                    if (gameState == "running")
                    {
                        inventoryTLabel.Visible = false;
                        inventoryRLabel.Visible = false;
                    }
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //move hero
            {
                if (leftDown == true && hero.X > 150)
                {
                    hero.X -= heroSpeed;
                }

                if (rightDown == true && hero.X < this.Width - 75)
                {
                    hero.X += heroSpeed;
                }

                if (upDown == true && hero.Y > 100)
                {
                    hero.Y -= heroSpeed;
                }

                if (downDown == true && hero.Y < this.Height - 75)
                {
                    hero.Y += heroSpeed;
                }
            }

            //move enemy 
            for (int i = 0; i < enemy.Count(); i++)
            {
                //find the new postion of y based on speed 
                int y = enemy[i].Y + enemySpeeds[i];

                //replace the rectangle in the list with updated one using new y 
                enemy[i] = new Rectangle(enemy[i].X, y, enemySize, enemySize);
            }

            if (gameState == "running")
            {
                this.BackgroundImage = Properties.Resources.Background_Final;
                this.BackgroundImageLayout = ImageLayout.Stretch;

                inventoryImage.Visible = true;

                titleLabel.Text = "";
                subtitleLabel.Text = "";
                enemyLivesLabel.Text = "";
                heroLivesLabel.Text = "";

                //adds axe to inventory
                if (hero.IntersectsWith(axeTool))
                {
                    //add tool to inventory
                    axe = true;
                }

                //accessing anvil
                if (hero.IntersectsWith(anvil))
                {
                    gameState = "anvil";
                }

                //regenerating resources
                if (hero.IntersectsWith(resource1) && resource01 == false)
                {
                    resource01 = true;
                    inventory[5]++;
                }
                else if (hero.IntersectsWith(resource2) && resource02 == false)
                {
                    resource02 = true;
                    inventory[6]++;
                }
                else if (hero.IntersectsWith(resource3) && resource03 == false)
                {
                    resource03 = true;
                    inventory[4]++;
                }

                if (resource01 == true || resource02 == true || resource03 == true)
                {
                    rCounter++;
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

                //add new enemy
                counter++;
                if (enemy.Count <= 1 && counter > 100)
                {
                    //starts more in on island
                    enemy.Add(new Rectangle(200, 150, 10, 15));
                    enemySpeeds.Add(randGen.Next(1, 4));

                    counter = 0;
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

                //fights with enemy
                for (int i = 0; i < enemy.Count; i++)
                {
                    if (hero.IntersectsWith(enemy[i]))
                    {
                        //for (int j = 0; j > enemy.Count; j++)
                        //{
                        if (enemySpeeds[i] == 1 || enemySpeeds[i] == -1)
                        {
                            enemyLives = 7;
                        }
                        else if (enemySpeeds[i] == 2 || enemySpeeds[i] == -2)
                        {
                            enemyLives = 10;
                        }
                        else if (enemySpeeds[i] == 3 || enemySpeeds[i] == -3)
                        {
                            enemyLives = 15;
                        }

                        if (enemyLives <= 0)
                        {
                            enemy.RemoveAt(i);
                            enemySpeeds.RemoveAt(i);
                        }
                        //}
                        gameState = "fight";
                        this.BackColor = Color.Black;
                        inventoryImage.Visible = false;
                    }
                }

                //what you need to build boat and win
                if (hero.IntersectsWith(boat) && inventory[4] == 20 && inventory[5] == 15 && inventory[6] == 10 && hammer == true)
                {
                    gameState = "win";
                }

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

                //    if (enemyLives <= 0)
                //    {
                //        enemy.RemoveAt(i);
                //    }
                //}

                //for (int i = 0; i > enemy.Count; i++)
                //{
                //    if (enemyLives <= 0)
                //    {
                //        enemy.RemoveAt(i);
                //    }
                //}
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
            if (gameState == "waiting")
            {
                titleLabel.Text = "IslandSurvival";
                subtitleLabel.Text = "Press Space Bar to Start or Esc to Exit";
            }
            else if (gameState == "running")
            {
                //change back colour
                //this.BackColor = Color.MediumTurquoise;

                //draw island
                //e.Graphics.FillRectangle(greenBrush, mainIsland);
                //e.Graphics.FillRectangle(goldBrush, beachyIsland);


                //draw boat
                e.Graphics.DrawImage(Properties.Resources.Boat_Final, boat);

                //draw anvil
                e.Graphics.DrawImage(Properties.Resources.anvil_Final, anvil);

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


                //draw enemies
                for (int i = 0; i < enemy.Count(); i++)
                {
                    if (enemySpeeds[i] == 1 || enemySpeeds[i] == -1)
                    {
                        e.Graphics.DrawImage(Properties.Resources.Slime_Final, enemy[i]);
                    }
                    else if (enemySpeeds[i] == 2 || enemySpeeds[i] == -2)
                    {
                        e.Graphics.DrawImage(Properties.Resources.Skeleton_Final, enemy[i]);

                    }
                    else if (enemySpeeds[i] == 3 || enemySpeeds[i] == -3)
                    {
                        e.Graphics.DrawImage(Properties.Resources.Goblin_Final, enemy[i]);

                    }
                }

                //draw hero
                e.Graphics.DrawImage(Properties.Resources.Hero_Final, hero);
            }
            else if (gameState == "fight")
            {
                this.BackgroundImage = null;
                //draw image of enemy
                //if box is selected, colour selected box
                for (int i = 0; i < enemy.Count(); i++)
                {
                    if (enemySpeeds[i] == 1)
                    {
                        e.Graphics.DrawImage(Properties.Resources.Slime_Final, enemyFight);
                    }
                    else if (enemySpeeds[i] == 2)
                    {
                        e.Graphics.DrawImage(Properties.Resources.Skeleton_Final, enemyFight);
                    }
                    else if (enemySpeeds[i] == 3)
                    {
                        e.Graphics.DrawImage(Properties.Resources.Goblin_Final, enemyFight);
                    }
                }

                FightMenu();
                FightMoves();
            }
            else if (gameState == "anvil")
            {
                this.BackColor = Color.Green;
                anvilUpgradeMenu();
            }

            void anvilUpgradeMenu()
            {
                switch (anvilMode)
                {
                    case "Axe":
                        e.Graphics.FillRectangle(lightBlueBrush, 175, 275, 200, 30);
                        e.Graphics.FillRectangle(blueBrush, 175, 300, 200, 30);
                        e.Graphics.FillRectangle(blueBrush, 175, 325, 200, 30);

                        e.Graphics.DrawString("Axe", fightFont, blackBrush, 200, 300);
                        e.Graphics.DrawString("Pickaxe", fightFont, blackBrush, 200, 325);
                        e.Graphics.DrawString("Sword", fightFont, blackBrush, 200, 350);
                        break;
                    case "Pickaxe":
                        e.Graphics.FillRectangle(lightBlueBrush, 175, 300, 200, 30);
                        e.Graphics.FillRectangle(blueBrush, 175, 275, 200, 30);
                        e.Graphics.FillRectangle(blueBrush, 175, 325, 200, 30);

                        e.Graphics.DrawString("Axe", fightFont, blackBrush, 200, 300);
                        e.Graphics.DrawString("Pickaxe", fightFont, blackBrush, 200, 325);
                        e.Graphics.DrawString("Sword", fightFont, blackBrush, 200, 350);
                        break;
                    case "Sword":
                        e.Graphics.FillRectangle(lightBlueBrush, 175, 325, 200, 30);
                        e.Graphics.FillRectangle(blueBrush, 175, 300, 200, 30);
                        e.Graphics.FillRectangle(blueBrush, 175, 275, 200, 30);

                        e.Graphics.DrawString("Axe", fightFont, blackBrush, 200, 300);
                        e.Graphics.DrawString("Pickaxe", fightFont, blackBrush, 200, 325);
                        e.Graphics.DrawString("Sword", fightFont, blackBrush, 200, 350);
                        break;
                }
            }

            void FightMenu()
            {
                switch (mode)
                {
                    case "attack":
                        e.Graphics.FillRectangle(lightBlueBrush, 30, 415, 200, 30);
                        e.Graphics.FillRectangle(blueBrush, 260, 415, 200, 30);

                        e.Graphics.DrawString("Attack", fightFont, blackBrush, 103, 420);
                        e.Graphics.DrawString("Run", fightFont, blackBrush, 340, 420);
                        break;
                    case "run":
                        e.Graphics.FillRectangle(lightBlueBrush, 260, 415, 200, 30);
                        e.Graphics.FillRectangle(blueBrush, 30, 415, 200, 30);


                        e.Graphics.DrawString("Attack", fightFont, blackBrush, 103, 420);
                        e.Graphics.DrawString("Run", fightFont, blackBrush, 340, 420);
                        break;
                }
            }
        }

        void FightMoves()
        {
            switch (mode)
            {
                case "attack":
                    if (rightDown == true)
                    {
                        mode = "run";
                    }
                    else if (yDown == true)
                    {
                        playerDamageAmount = randGen.Next(1, 8);
                        //enemy health goes down
                        enemyLives = enemyLives - playerDamageAmount;
                        enemyLivesLabel.Text = $"Enemy Health: {enemyLives}.\n You dealt {playerDamageAmount} damage.";

                        //enemy attack/player health goes down
                        enemyDamageAmount = randGen.Next(1, 6);
                        heroLives = heroLives - enemyDamageAmount;
                        heroLivesLabel.Text = $"Hero Health: {heroLives}.\n Enemy dealt {enemyDamageAmount} damage.";

                        //skillMenu2Yes
                        yDown = false;
                    }
                    break;
                case "run":
                    if (leftDown == true)
                    {
                        mode = "attack";
                    }
                    if (yDown == true)
                    {
                        gameState = "running";
                        enemyLivesLabel.Visible = false;
                        heroLivesLabel.Visible = false;
                        yDown = false;
                    }
                    break;
            }
        }

        void anvilUpgrade()
        {
            switch (anvilMode)
            {
                case "Axe":
                    if (downDown == true)
                    {
                        anvilMode = "Pickaxe";
                        downDown = false;
                    }
                    else if (downDown == true && pickaxe == true)
                    {
                        anvilMode = "Pickaxe1";
                        downDown = false;
                    }
                    else if (yDown == true)
                    {
                        if (inventory[4] == 5)
                        {
                            Axe2 = true;
                        }
                        else
                        {
                            Axe2 = false;
                            subtitleLabel.Text = "You don't have enough resources to make this upgrade.";
                        }
                        yDown = false;
                    }
                    else if (nDown == true)
                    {
                        gameState = "running";
                    }
                    break;
                case "Pickaxe":
                    if (downDown == true)
                    {
                        anvilMode = "Sword";
                        downDown = false;
                    }
                    else if (downDown == true && sword == true)
                    {
                        anvilMode = "Sword1";
                        downDown = false;
                    }
                    else if (upDown == true)
                    {
                        anvilMode = "Axe";
                        upDown = false;
                    }
                    else if (yDown == true)
                    {
                        if (inventory[4] == 8 && inventory[5] == 3)
                        {
                            pickaxe = true;
                        }
                        else
                        {
                            Pickaxe2 = false;
                            subtitleLabel.Text = "You don't have enough resources to make this upgrade.";
                        }
                        yDown = false;
                    }
                    else if (nDown == true)
                    {
                        gameState = "running";
                    }
                    break;
                case "Sword":
                    if (upDown == true)
                    {
                        anvilMode = "Pickaxe";
                        upDown = false;
                    }
                    else if (upDown == true && pickaxe == true)
                    {
                        anvilMode = "Pickaxe1";
                        upDown = false;
                    }
                    else if (yDown == true)
                    {
                        if (inventory[4] == 12 && inventory[5] == 7 && inventory[6] == 2)
                        {
                            Sword2 = true;
                        }
                        else
                        {
                            Sword2 = false;
                            subtitleLabel.Text = "You don't have enough resources to make this upgrade.";
                        }
                        yDown = false;
                    }
                    else if (nDown == true)
                    {
                        gameState = "running";
                    }
                    break;
                case "Pickaxe1":
                    if (downDown == true)
                    {
                        anvilMode = "Sword";
                        downDown = false;
                    }
                    else if (downDown == true && sword == true)
                    {
                        anvilMode = "Sword1";
                        downDown = false;
                    }
                    else if (upDown == true)
                    {
                        anvilMode = "Axe";
                        upDown = false;
                    }
                    else if (yDown == true && pickaxe == true)
                    {
                        if (inventory[4] == 10 && inventory[5] == 5)
                        {
                            Pickaxe2 = true;
                        }
                        else
                        {
                            Pickaxe2 = false;
                            subtitleLabel.Text = "You don't have enough resources to make this upgrade.";
                        }
                        yDown = false;
                    }
                    else if (nDown == true)
                    {
                        gameState = "running";
                    }
                    break;
                case "Sword1":
                    if (upDown == true)
                    {
                        anvilMode = "Pickaxe";
                        upDown = false;
                    }
                    else if (upDown == true && pickaxe == true)
                    {
                        anvilMode = "Pickaxe1";
                        upDown = false;
                    }
                    else if (yDown == true && sword == true)
                    {
                        if (inventory[4] == 12 && inventory[5] == 7 && inventory[6] == 2)
                        {
                            Sword2 = true;
                        }
                        else
                        {
                            Sword2 = false;
                            subtitleLabel.Text = "You don't have enough resources to make this upgrade.";
                        }
                        yDown = false;
                    }
                    else if (nDown == true)
                    {
                        gameState = "running";
                    }
                    break;
            }
        }
    }
}