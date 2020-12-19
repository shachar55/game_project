using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_project
{
    class Dot
    {
        public Dot(Field f)
        {
           
            field = f;
            Create();
            safe = 3;
        }


        private Field field;
        private Positions pos;
        private int safe; // safe distance from boraders

        private void Create()
        {
            Random rnd = new Random();
            pos.SetXpos(rnd.Next(field.GetLeft() + safe,field.GetRight() - safe ));
            pos.SetYpos(rnd.Next(field.GetUp() + safe, field.GetDown() - safe));
        }
        public void draw(char ch1) 
        {
            Create();
            Console.SetCursorPosition(pos.GetXpos(),pos.GetYpos());
            Console.Write(ch1);
        }
    }
}
