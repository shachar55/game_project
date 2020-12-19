using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_project
{
    class Positions
    {
        public Positions(int x,int y)
        {
            xpos = x;
            ypos = y;
        }

        private int xpos;
        private int ypos;

        
        public int GetXpos() { return xpos; }
        public int GetYpos() { return ypos; }
        public void SetXpos(int newXpos) { xpos = newXpos; }
        public void SetYpos(int newYpos) { ypos = newYpos; }
    }

}
