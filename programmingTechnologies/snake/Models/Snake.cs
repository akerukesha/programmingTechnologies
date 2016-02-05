﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake.Models
{   [Serializable]
    class Snake : Drawer
    {
        public int MyProperty { get; set; }

        public Snake()
        {
            sign = 'o';
        }

        public void Move(int dx, int dy)
        {
            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x = body[0].x + dx;
            body[0].y = body[0].y + dy;

            if(Game.snake.body[0].x == 0 || Game.snake.body[0].x == 47 || Game.snake.body[0].y == 0 || Game.snake.body[0].y == 47)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 10);
                Console.WriteLine("Game over!");
                Game.isActive = false;
            }

            if (Game.snake.body[0].x == Game.food.body[0].x && Game.snake.body[0].y == Game.food.body[0].y)
            {
                Game.snake.body.Add(new Point { x = Game.food.body[0].x, y = Game.food.body[0].y } );
                
                
                Game.food.body[0].x = new Random().Next(0, 47);
                Game.food.body[0].y = new Random().Next(0, 47);

            }

            for (int i = 0; i < Game.wall.body.Count; ++i)
            {
                if (Game.snake.body[0].x == Game.wall.body[i].x && Game.snake.body[0].y == Game.wall.body[i].y)
                {
                    Console.Clear();
                    Console.SetCursorPosition(20, 10);
                    Console.WriteLine("Game over!");
                    Game.isActive = false;
                }
            }

        }
    }
}
