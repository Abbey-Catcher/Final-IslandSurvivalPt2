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
        Player hero;

        //control keys
        bool leftDown = false;
        bool rightDown = false;
        bool upDown = false;
        bool downDown = false;
        bool yDown = false;
        bool nDown = false;

        public GameScreen()
        {
            InitializeComponent();
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
        }
    }
}
