using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_project
{

    class Player
    {
        public Player(Positions p)
        {
            pos = p;
            facing = facingDirction.up;
        }

        private Positions pos;
        public enum facingDirction { up,right,down,left }; // facing = 0 - up;1 - right;2 - down;3 - left
        public facingDirction facing;
        private void draw(char ch1, char ch2)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (facing == facingDirction.up)
            {
                Console.SetCursorPosition(pos.GetXpos() - 1, pos.GetYpos());
                Console.Write(new string(ch1, 1));
                Console.SetCursorPosition(pos.GetXpos() + 1, pos.GetYpos());
                Console.Write(new string(ch1, 1));
                Console.SetCursorPosition(pos.GetXpos() , pos.GetYpos() + 1);
                Console.Write(new string(ch2, 1));
                Console.SetCursorPosition(0, 0);
            }
            else if (facing == facingDirction.right)
            {
                Console.SetCursorPosition(pos.GetXpos(), pos.GetYpos() - 1);
                Console.Write(new string(ch2, 1));
                Console.SetCursorPosition(pos.GetXpos() , pos.GetYpos() + 1);
                Console.Write(new string(ch2, 1));
                Console.SetCursorPosition(pos.GetXpos() - 1, pos.GetYpos());
                Console.Write(new string(ch1, 1));
                Console.SetCursorPosition(0, 0);
            }
            else if (facing == facingDirction.down)
            {
                Console.SetCursorPosition(pos.GetXpos() - 1, pos.GetYpos());
                Console.Write(new string(ch1, 1));
                Console.SetCursorPosition(pos.GetXpos() + 1, pos.GetYpos());
                Console.Write(new string(ch1, 1));
                Console.SetCursorPosition(pos.GetXpos() , pos.GetYpos() - 1);
                Console.Write(new string(ch2, 1));
                Console.SetCursorPosition(0, 0);
            }
            else if (facing == facingDirction.left)
            {
                Console.SetCursorPosition(pos.GetXpos(), pos.GetYpos() - 1);
                Console.Write(new string(ch2, 1));
                Console.SetCursorPosition(pos.GetXpos(), pos.GetYpos() + 1);
                Console.Write(new string(ch2, 1));
                Console.SetCursorPosition(pos.GetXpos() + 1, pos.GetYpos());
                Console.Write(new string(ch1, 1));
                Console.SetCursorPosition(0, 0);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Print()
        {
            char ch1 = '|';
            char ch2 = '-';
            draw(ch1, ch2);
        }
        
        public void Clear()
        {
            draw(' ', ' ');
        }

        public int GetXpos() { return pos.GetXpos(); }
        public int GetYpos() { return pos.GetYpos(); }
        public void SetXpos(int newXpos) { pos.SetXpos(newXpos); }
        public void SetYpos(int newYpos) { pos.SetYpos(newYpos); }
        public void FacingPlus() 
        {
            int facing = (int)this.facing;
            facing++;
            facing = facing % 4;
            this.facing = (facingDirction) facing;
        }

    }
}
