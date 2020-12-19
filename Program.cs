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
            Player player1 = new Player(new Positions(10, 10));
            Game game = new Game(new Field(3, 3, 58, 164),player1);
            game.Main();
        }
    }
}
