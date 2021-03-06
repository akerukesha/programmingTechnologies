﻿using snake.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class Program
    {
        public static int level = 1;
        public static int gainedPoints = 0;

        static void Main(string[] args)
        {
            while (level <= Directory.GetFiles(@"C:\Users\Админ\Source\Repos\programmingTechnologies\programmingTechnologies\snake\bin\Debug\Levels").Length)
            {
                Game.Init();
                Game.LoadlLevel(level);
                Game.RandomSnake();

                while (Game.isActive)
                {
                    Game.Draw();

                    ConsoleKeyInfo pressedKey = Console.ReadKey();
                    switch (pressedKey.Key)
                    {
                        case ConsoleKey.UpArrow:
                            Game.snake.Move(0, -1);
                            break;
                        case ConsoleKey.DownArrow:
                            Game.snake.Move(0, 1);
                            break;
                        case ConsoleKey.LeftArrow:
                            Game.snake.Move(-1, 0);
                            break;
                        case ConsoleKey.RightArrow:
                            Game.snake.Move(1, 0);
                            break;
                        case ConsoleKey.Escape:
                            Game.isActive = false;
                            break;
                        case ConsoleKey.Q:
                            Game.Save();
                            break;
                        case ConsoleKey.W:
                            Game.Resume();
                            break;
                    }
                }

                Console.ReadKey();
            }
            Console.Clear();
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("Conratulations! You won!");
            Console.WriteLine("Your score is " + gainedPoints);
            Game.isActive = false;
        }
    }
}
