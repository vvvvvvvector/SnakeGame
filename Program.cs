using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Snake
{
    class Program
    {
        static void Main()
        {
            CursorVisible = false;
            WindowWidth = 40;
            WindowHeight = 20;

            var gameover = true;
            var score = 2;
            var snakeSpeed = 200;
            var random = new Random();

            var snakeHead = new Pixel(WindowWidth / 2, WindowHeight / 2, ConsoleColor.DarkRed);
            var food = new Pixel(random.Next(1, WindowWidth - 2), random.Next(1, WindowHeight - 2), ConsoleColor.Cyan);
            var snakeBody = new List<Pixel>();

            DrawBorder();

            while (gameover)
            {
                if (snakeHead.xCoordinate == WindowWidth - 1 || snakeHead.xCoordinate == 0 || snakeHead.yCoordinate == WindowHeight - 1 || snakeHead.yCoordinate == 0)
                {
                    gameover = false;
                }
                if (snakeHead.xCoordinate == food.xCoordinate && snakeHead.yCoordinate == food.yCoordinate)
                {
                    if (score % 4 == 0)
                    {
                        snakeSpeed -= 15;
                    }
                    score++;
                    food = new Pixel(random.Next(1, WindowWidth - 2), random.Next(1, WindowHeight - 2), ConsoleColor.Cyan);
                }

                for (int i = 0; i < snakeBody.Count - 1; i++)
                {
                    snakeBody[i].DrawPixel();
                    if (snakeHead.xCoordinate == snakeBody[i].xCoordinate && snakeHead.yCoordinate == snakeBody[i].yCoordinate)
                    {
                        gameover = false;
                    }
                }
                if (gameover == false)
                {
                    break;
                }
                snakeHead.UpdatePosition();
                SpeedControl(snakeSpeed);
                ClearGameField();
                snakeHead.DrawPixel();
                food.DrawPixel();
                snakeBody.Add(new Pixel(snakeHead.xCoordinate, snakeHead.yCoordinate, ConsoleColor.Green));
                SetSnakeDirection(snakeHead);
                if (snakeBody.Count - 1 > score)
                {
                    snakeBody.RemoveAt(0);
                }
            }
            SetCursorPosition(WindowWidth / 2 - 9, WindowHeight / 2);
            Write($"Game over, score: {score - 2}");
            SetCursorPosition(WindowWidth / 2 - 14, WindowHeight / 2 + 1);
            Write($"Press R button to restart game");
            SetCursorPosition(WindowWidth / 2 - 14, WindowHeight / 2 + 2);
            Write($"or press another button to quit");
            ConsoleKeyInfo key = ReadKey(true);
            if (key.Key == ConsoleKey.R)
            {
                Main();
            }
        }
        public static void SetSnakeDirection(Pixel snake)
        {
            if (KeyAvailable)
            {
                ConsoleKeyInfo key = ReadKey(true);

                if (snake.IsMovingUpOrDown())
                {
                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        snake.NewDirection(1, 0);
                    }
                    else if (key.Key == ConsoleKey.LeftArrow)
                    {
                        snake.NewDirection(-1, 0);
                    }
                }
                else if (snake.IsMovingLeftOrRight())
                {
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        snake.NewDirection(0, -1);
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        snake.NewDirection(0, 1);
                    }
                }
            }
        }
        public static void ClearGameField()
        {
            var line = string.Join("", new byte[WindowWidth - 2].Select(b => " ").ToArray());
            for (int i = 1; i < WindowHeight - 1; i++)
            {
                SetCursorPosition(1, i);
                Write(line);
            }
        }
        public static void DrawBorder()
        {
            for (int i = 0; i < WindowHeight; i++)
            {
                ForegroundColor = ConsoleColor.White;
                SetCursorPosition(0, i);
                Write("1");
                SetCursorPosition(WindowWidth - 1, i);
                Write("1");
            }
            for (int i = 0; i < WindowWidth; i++)
            {
                ForegroundColor = ConsoleColor.White;
                SetCursorPosition(i, 0);
                Write("1");
                SetCursorPosition(i, WindowHeight - 1);
                Write("1");
            }
        }
        public static void SpeedControl(int speedValue) 
        {
            DateTime t1 = DateTime.Now;
            while (true)
            {
                DateTime t2 = DateTime.Now;
                if (t2.Subtract(t1).TotalMilliseconds > speedValue)
                {
                    break;
                }
            }
        }
    }
}