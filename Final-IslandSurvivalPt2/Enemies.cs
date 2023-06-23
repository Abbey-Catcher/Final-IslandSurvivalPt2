using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_IslandSurvivalPt2
{
    public class Enemies
    {
        public int x, y, xSpeed, ySpeed;
        public int size = 30;
        public int lives = 10;

        public Enemies (int _x, int _y, int _xSpeed, int _ySpeed)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
        }

        public void Move(int width, int height)
        {
            x -= xSpeed;
        }

        public bool Collision(Player p)
        {
            Rectangle carRec = new Rectangle(x, y, size, size);
            Rectangle playerRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (carRec.IntersectsWith(playerRec))
            {
                if (ySpeed > 0)
                {
                    p.y = 310;
                    p.x = 120;
                }

                ySpeed *= -1;
                return true;
            }

            return false;
        }
    }
}
