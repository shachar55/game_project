using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_project
{
    class Game
    {
        public Game(Field f)
        {
            Random rnd = new Random();
            Player player1 = new Player(new Positions(10, 10));
            Dot dot1 = new Dot(new Positions(rnd.Next(f.GetLeft() + safeSides, f.GetRight() - safeSides + 1), rnd.Next(f.GetUp() + safeUpDown, f.GetDown() - safeUpDown + 1)));
            field = f;
            safeSides = 3;
            safeUpDown = 1;
            dot = dot1;
            player = player1;

        }
        private Dot dot;
        private Player player;
        private Field field;
        private int safeSides; // safe distance from side borders to print the player
        private int safeUpDown; // safe distance from side borders to print the player

        public int PlayerEat(int points)
        {
            if (dot.GetXpos() == player.GetXpos()&& dot.GetYpos() ==player.GetYpos())
            {
                player.FacingMinus();
                return points+1;
            }
            return points;
        }

        public void MovePlayer(int dirction)// dirction = 0 - up;1 - right;2 - down;3 - left
        {
            if (dirction == 0)
            {
                player.SetYpos(player.GetYpos() - 1);
                if (player.GetYpos() <= field.GetUp()+ safeUpDown)
                {
                    player.SetYpos(field.GetDown() - 3);
                }
            }
            else if (dirction == 1)
            {
                player.SetXpos(player.GetXpos() + 1);
                if (player.GetXpos() >= field.GetRight() - safeSides)
                {
                    player.SetXpos(field.GetLeft() + 3);
                }
            }
            else if (dirction == 2)
            {
                player.SetYpos(player.GetYpos() + 1);
                if (player.GetYpos() >= field.GetDown() - safeUpDown)
                {
                    player.SetYpos(field.GetUp() + 3);
                }
            }
            else if (dirction == 3)
            {
                player.SetXpos(player.GetXpos() - 1);
                if (player.GetXpos() <= field.GetLeft() + safeSides)
                {
                    player.SetXpos(field.GetRight() - 3);
                }
            }
            player.FacingPlus();
        }

        public void KeyPressed()
        {
            if (Console.KeyAvailable) // any key was pressed - check which one
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.RightArrow) // right arrow was pressed
                {
                    player.Clear();
                    MovePlayer(1);
                    player.Print();
                }
                else if (key == ConsoleKey.LeftArrow) // left arrow was pressed
                {
                    player.Clear();
                    MovePlayer(3);
                    player.Print();
                }
                else if (key == ConsoleKey.UpArrow) // up arrow was pressed
                {
                    player.Clear();
                    MovePlayer(0);
                    player.Print();
                }
                else if (key == ConsoleKey.DownArrow) // down arrow was pressed
                {
                    player.Clear();
                    MovePlayer(2);
                    player.Print();
                }
            }
        }

        public void Main()
        {
            int steps = 0;
            int points = 0;
            field.Draw('-', '|');
            bool End = false; // continue game loop until End will become true
                              // in the loop need to check if any jey was pressed
                              // if pressed move the character accordingly
                              // otherwise sleep for 0.1 sec
            while (!End)
            {
                if (Console.KeyAvailable) // any key was pressed - check which one
                {
                    ConsoleKey key = Console.ReadKey().Key;
                    if (key == ConsoleKey.RightArrow) // right arrow was pressed
                    {
                        player.Clear();
                        MovePlayer(1);
                        player.Print();
                        steps++;
                    }
                    else if (key == ConsoleKey.LeftArrow) // left arrow was pressed
                    {
                        player.Clear();
                        MovePlayer(3);
                        player.Print();
                        steps++;
                    }
                    else if (key == ConsoleKey.UpArrow) // up arrow was pressed
                    {
                        player.Clear();
                        MovePlayer(0);
                        player.Print();
                        steps++;
                    }
                    else if (key == ConsoleKey.DownArrow) // down arrow was pressed
                    {
                        player.Clear();
                        MovePlayer(2);
                        player.Print();
                        steps++;
                    }
                }
                dot.draw('■');
                points = PlayerEat(points);
                Console.SetCursorPosition(30, 0);
                Console.Write($"Steps: {steps}     Points: {points}");
            }
        }

    }
}
