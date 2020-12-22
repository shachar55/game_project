using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace game_project
{
    class Program
    {   
        static void Main(string[] args)
        {
            Game game = new Game(new Field(3, 3, 58, 164), 500);
            bool End = false;
            Console.WriteLine("You wanna start?: (y/n)");
            char ans = char.Parse(Console.ReadLine());
            if (ans == 'n')
            {
                End = true;
            }
            while (!End)
            {
                game.Main();
                Console.SetCursorPosition(30, 16);
                Console.Write("Do you want to continue playing? (y/n):  ");
                ans = char.Parse(Console.ReadLine());
                if (ans == 'n')
                {
                    End = true;
                }
            }    
        }
    }
}
