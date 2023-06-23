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
            
            playerDamageAmount = randGen.Next(1, 8);
            //enemy health goes down
                = enemyLives - playerDamageAmount;
            moveLabel.Text = $"Enemy Health: {enemyLives}.\n You dealt {playerDamageAmount} damage.";
            

            //enemy attack/player health goes down
            enemyDamageAmount = randGen.Next(1, 6);
            heroLives = heroLives - enemyDamageAmount;
            heroLivesLabel.Text = $"Hero Health: {heroLives}.\n Enemy dealt {enemyDamageAmount} damage.";
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen());
        }
    }
}
