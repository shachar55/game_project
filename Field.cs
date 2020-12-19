using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_project
{
    class Field
    {
        public Field(int u,int l,int d,int r)
        {
            left = l;
            right = r;
            up = u;
            down = d;

        }

        private int down;
        private int up;
        private int left;
        private int right;

        public int GetUp() { return up; }
        public int GetDown() { return down; }
        public int GetRight() { return right; }
        public int GetLeft() { return left; }
        public void SetUp(int newUp) { up = newUp; }
        public void SetDown(int newDown) { down = newDown; }
        public void SetLeft(int newLeft) { left = newLeft; }
        public void SetRight(int newRight) { right = newRight; }

        public void Draw(char ch1,char ch2)
        {
            
            Console.WindowWidth = right+2;
            Console.WindowHeight = down+2;
            for (int i = 0; i <= right - left; i++)
            {
                Console.SetCursorPosition(left+i, up);
                Console.Write(ch1);
                Console.SetCursorPosition(left + i, down);
                Console.Write(ch1);
            }
            for (int i = 1; i < down -up; i++)
            {
                Console.SetCursorPosition(left, up + i);
                Console.Write(ch2);
                Console.SetCursorPosition(right, up + i);
                Console.Write(ch2);
            }

        }
        
    }
}
