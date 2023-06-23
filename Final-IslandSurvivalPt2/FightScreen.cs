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
    public partial class FightScreen : UserControl
    {
        Random randGen = new Random();


        public FightScreen()
        {
            InitializeComponent();
        }

        private void attackBtn_Click(object sender, EventArgs e)
        {
            
           Player.PDamageAmount = randGen.Next(1, 8);
            //enemy health goes down
            Enemies.EDamageAmount = enemy.Lives - Player.PDamageAmount;
            moveLabel.Text = $"Enemy Health: {enemy.Lives}.\n You dealt {Player.PDamageAmount} damage.";
            

            //enemy attack/player health goes down
            Enemies.EDamageAmount = randGen.Next(1, 6);
            GameScreen.hero.Lives = heroLives - Enemies.EDamageAmount;
            moveLabel.Text = $"Hero Health: {hero.lives}.\n Enemy dealt {Enemies.EDamageAmount} damage.";

            if (enemy.lives == 0)
            {
                Form1.ChangeScreen(this, new GameScreen());
                enemy.removeAt(i);
            }
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen());
        }
    }
}
