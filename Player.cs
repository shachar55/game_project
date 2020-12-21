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
            facing = 0;
        }

        private Positions pos; 
        private int facing; // facing = 0 - up;1 - right;2 - down;3 - left

        private void draw(char ch1, char ch2)
        {
            if (facing == 0)
            {
                Console.SetCursorPosition(pos.GetXpos() - 2, pos.GetYpos());
                Console.Write(new string(ch1, 1));
                Console.SetCursorPosition(pos.GetXpos() + 2, pos.GetYpos());
                Console.Write(new string(ch1, 1));
                Console.SetCursorPosition(pos.GetXpos() - 1, pos.GetYpos() + 1);
                Console.Write(new string(ch2, 3));
                Console.SetCursorPosition(0, 0);
            }
            else if (facing == 1)
            {
                Console.SetCursorPosition(pos.GetXpos() - 2, pos.GetYpos() - 1);
                Console.Write(new string(ch2, 3));
                Console.SetCursorPosition(pos.GetXpos() - 2, pos.GetYpos() + 1);
                Console.Write(new string(ch2, 3));
                Console.SetCursorPosition(pos.GetXpos() - 3, pos.GetYpos());
                Console.Write(new string(ch1, 1));
                Console.SetCursorPosition(0, 0);
            }
            else if (facing == 2)
            {
                Console.SetCursorPosition(pos.GetXpos() - 2, pos.GetYpos());
                Console.Write(new string(ch1, 1));
                Console.SetCursorPosition(pos.GetXpos() + 2, pos.GetYpos());
                Console.Write(new string(ch1, 1));
                Console.SetCursorPosition(pos.GetXpos() - 1, pos.GetYpos() - 1);
                Console.Write(new string(ch2, 3));
                Console.SetCursorPosition(0, 0);
            }
            else if (facing == 3)
            {
                Console.SetCursorPosition(pos.GetXpos(), pos.GetYpos() - 1);
                Console.Write(new string(ch2, 3));
                Console.SetCursorPosition(pos.GetXpos(), pos.GetYpos() + 1);
                Console.Write(new string(ch2, 3));
                Console.SetCursorPosition(pos.GetXpos() + 3, pos.GetYpos());
                Console.Write(new string(ch1, 1));
                Console.SetCursorPosition(0, 0);
            }
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
            facing++;
            facing = facing % 4;
        }
        public int GetFacing()
        {
            return facing;
        }

    }
}
