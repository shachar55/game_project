using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_project
{
    class Dot
    {
        public Dot(Positions p)
        {
            pos = p;
        }


        private Positions pos;

        public void draw(char ch1) 
        {
            Console.SetCursorPosition(pos.GetXpos(),pos.GetYpos());
            Console.Write(ch1);
        }
        public int GetXpos() { return pos.GetXpos(); }
        public int GetYpos() { return pos.GetYpos(); }
        public void SetXpos(int x) { pos.SetXpos(x); }
        public void SetYpos(int y) { pos.SetYpos(y); }
    }
}
