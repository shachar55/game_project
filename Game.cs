using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_project
{
    class Game
    {
        public Game(Field f,int steps)
        {
            Random rnd = new Random();
            Player player = new Player(new Positions(10, 10));
            Dot dot = new Dot(new Positions(rnd.Next(f.GetLeft() + safeSides, f.GetRight() - safeSides + 1), rnd.Next(f.GetUp() + safeUpDown, f.GetDown() - safeUpDown + 1)));
            field = f;
            stepsLeft = steps;
            safeSides = 3;
            safeUpDown = 3;
            this.dot = dot;
            this.player = player;

        }
        private Dot dot;
        private Player player;
        private Field field;
        private int stepsLeft;
        private int safeSides; // safe distance from side borders to print the player
        private int safeUpDown; // safe distance from side borders to print the player

        public void PlayerRandomize()
        {
            Random rnd = new Random();
            player.Clear();
            player.SetXpos(rnd.Next(field.GetLeft() + safeSides, field.GetRight() - safeSides + 1));
            player.SetYpos(rnd.Next(field.GetUp() + safeUpDown, field.GetDown() - safeUpDown + 1));
        }

        public void PlayerEat()
        {
            if (dot.GetXpos() == player.GetXpos() && dot.GetYpos() == player.GetYpos())
            {
                Random rnd = new Random();
                PlayerRandomize();
                dot.Clear();
                dot.SetXpos(rnd.Next(field.GetLeft() + safeSides, field.GetRight() - safeSides + 1));
                dot.SetYpos(rnd.Next(field.GetUp() + safeUpDown, field.GetDown() - safeUpDown + 1));
                dot.draw('■');
                stepsLeft += 100;
            }
        }

        public void EatDirction()
        {
            Random rnd = new Random();
            if (dot.GetXpos()+1 == player.GetXpos() && dot.GetYpos() == player.GetYpos())
            {
                if (player.GetFacing() == 0)
                {
                    PlayerRandomize();
                }
                if (player.GetFacing() == 1)
                {
                    PlayerRandomize();
                }
                if (player.GetFacing() == 2)
                {
                    PlayerRandomize();
                }
            }
            if (dot.GetXpos() - 1 == player.GetXpos() && dot.GetYpos() == player.GetYpos())
            {
                if (player.GetFacing() == 0)
                {
                    PlayerRandomize();
                }
                if (player.GetFacing() == 3)
                {
                    PlayerRandomize();
                }
                if (player.GetFacing() == 2)
                {
                    PlayerRandomize();
                }
            }
            if (dot.GetXpos() == player.GetXpos() && dot.GetYpos()+1 == player.GetYpos())
            {
                if (player.GetFacing() == 1)
                {
                    PlayerRandomize();
                }
                if (player.GetFacing() == 3)
                {
                    PlayerRandomize();
                }
                if (player.GetFacing() == 0)
                {
                    PlayerRandomize();
                }
            }
            if (dot.GetXpos() == player.GetXpos() && dot.GetYpos() - 1 == player.GetYpos())
            {
                if (player.GetFacing() == 1)
                {
                    PlayerRandomize();
                }
                if (player.GetFacing() == 3)
                {
                    PlayerRandomize();
                }
                if (player.GetFacing() == 2)
                {
                    PlayerRandomize();
                }
            }
        }
        public void MovePlayer(int dirction)// dirction = 0 - up;1 - right;2 - down;3 - left
        {
            if (dirction == 0)
            {
                player.SetYpos(player.GetYpos() - 1);
                if (player.GetYpos() <= field.GetUp() + safeUpDown)
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
                        stepsLeft--;
                    }
                    else if (key == ConsoleKey.LeftArrow) // left arrow was pressed
                    {
                        player.Clear();
                        MovePlayer(3);
                        player.Print();
                        steps++;
                        stepsLeft--;
                    }
                    else if (key == ConsoleKey.UpArrow) // up arrow was pressed
                    {
                        player.Clear();
                        MovePlayer(0);
                        player.Print();
                        steps++;
                        stepsLeft--;
                    }
                    else if (key == ConsoleKey.DownArrow) // down arrow was pressed
                    {
                        player.Clear();
                        MovePlayer(2);
                        player.Print();
                        steps++;
                        stepsLeft--;
                    }
                    EatDirction();
                    PlayerEat();
                }
                if (stepsLeft <= 0)
                {
                    End = true;
                }
                dot.draw('■');
                Console.SetCursorPosition(30, 0);
                Console.Write($"Steps Left: {stepsLeft}     Steps: {steps}");
            }
        }

    }
}
