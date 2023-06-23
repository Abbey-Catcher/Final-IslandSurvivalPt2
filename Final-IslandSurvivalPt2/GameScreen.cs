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
        List<Resource1> resource1 = new List<Resource1>();

        Player hero;

        //control keys
        bool leftDown = false;
        bool rightDown = false;
        bool upDown = false;
        bool downDown = false;
        bool yDown = false;
        bool nDown = false;

        //inventory tools
        bool axe = false;
        bool pickaxe = false;
        bool sword = false;
        bool hammer = false;

        public GameScreen()
        {
            InitializeComponent();
            GameInitialize();
        }

        public void GameInitialize()
        {
            gameTimer.Enabled = true;
            
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
            if (e.KeyCode == Keys.Space)
            {

            }
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
            if (e.KeyCode == Keys.I)
            {

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
            //collision
            foreach (Enemies e in enemy)
            {
                if (e.Collision(hero))
                {
                    FightScreen fs = new FightScreen();
                    this.Controls.Add(fs);
                }
            }
            
        }
    }
    }
}
