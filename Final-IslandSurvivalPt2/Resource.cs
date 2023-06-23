using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_IslandSurvivalPt2
{
    public class Resource
    {
        public int x, y;
        public static int TimeCounter;

        public Resource(int _x, int _y)
        {
            x = _x;
            y = _y;

            TimeCounter++;
            if (TimeCounter >= 5)
            {
                TimeCounter = 0;
            }
        }


    }
}
