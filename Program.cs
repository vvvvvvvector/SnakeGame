using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            CursorVisible = false;
            WindowWidth = 40;
            WindowHeight = 20;

            bool gameover = true;
            int score = 2;
            int speed = 200;
            Random random = new Random();

            Pixel head = new Pixel(WindowWidth / 2, WindowHeight / 2, ConsoleColor.DarkRed);
            Pixel food = new Pixel(random.Next(1, WindowWidth - 2), random.Next(1, WindowHeight - 2), ConsoleColor.Cyan);
            List<Pixel> body = new List<Pixel>();

            DrawBorder();

            while (gameover)
            {
                if (head.xPos == WindowWidth - 1 || head.xPos == 0 || head.yPos == WindowHeight - 1 || head.yPos == 0)
                {
                    gameover = false;
                }
                if (head.xPos == food.xPos && head.yPos == food.yPos)
                {
                    if (score % 4 == 0)
                    {
                        speed -= 15;
                    }
                    score++;
                    food = new Pixel(random.Next(1, WindowWidth - 2), random.Next(1, WindowHeight - 2), ConsoleColor.Cyan);
                }

                for (int i = 0; i < body.Count - 1; i++)
                {
                    Pixel.DrawPixel(body[i]);
                    if (head.xPos == body[i].xPos && head.yPos == body[i].yPos)
                    {
                        gameover = false;
                    }
                }
                if (gameover == false)
                {
                    break;
                }
                Pixel.Update(head);
                Thread.Sleep(speed);
                ClearConsole();
                Pixel.DrawPixel(head);
                Pixel.DrawPixel(food);
                body.Add(new Pixel(head.xPos, head.yPos, ConsoleColor.Green));
                Read(head);
                if (body.Count - 1 > score)
                {
                    body.RemoveAt(0);
                }
            }
            SetCursorPosition(WindowWidth / 2 - 9, WindowHeight / 2);
            Write($"Game over, score: {score - 2}");
            ReadKey();
        }
        static void Read(Pixel p)
        {
            if (KeyAvailable)
            {
                ConsoleKeyInfo key = ReadKey(true);

                if (p.xSpeed == 0 && p.ySpeed == -1 || p.xSpeed == 0 && p.ySpeed == 1)
                {
                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        p.direction(1, 0);
                    }
                    else if (key.Key == ConsoleKey.LeftArrow)
                    {
                        p.direction(-1, 0);
                    }
                }
                else if (p.xSpeed == 1 && p.ySpeed == 0 || p.xSpeed == -1 && p.ySpeed == 0)
                {
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        p.direction(0, -1);
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        p.direction(0, 1);
                    }
                }
            }
        }
        public static void ClearConsole()
        {
            var line = string.Join("", new byte[WindowWidth - 2].Select(b => " ").ToArray());
            for (int i = 1; i < WindowHeight - 1; i++)
            {
                SetCursorPosition(1, i);
                Write(line);
            }
        }
        static void DrawBorder()
        {
            for (int i = 0; i < WindowHeight; i++)
            {
                SetCursorPosition(0, i);
                Write("1");
                SetCursorPosition(WindowWidth - 1, i);
                Write("1");
            }
            for (int i = 0; i < WindowWidth; i++)
            {
                SetCursorPosition(i, 0);
                Write("1");
                SetCursorPosition(i, WindowHeight - 1);
                Write("1");
            }
        }
    }
}
