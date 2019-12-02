using System;

namespace Snake
{
    class Pixel
    {
        public int xPos { get; set; }
        public int yPos { get; set; }
        public int xSpeed { get; set; } = 1;
        public int ySpeed { get; set; } = 0;
        public ConsoleColor PixelColor { get; set; }
        public Pixel(int x, int y, ConsoleColor color)
        {
            xPos = x;
            yPos = y;
            PixelColor = color;
        }
        public void DrawPixel()
        {
            Console.SetCursorPosition(xPos, yPos);
            Console.ForegroundColor = PixelColor;
            Console.Write("*");
        }
        public void Update()
        {
            xPos += xSpeed;
            yPos += ySpeed;
        }
        public void direction(int x, int y)
        {
            xSpeed = x;
            ySpeed = y;
        }
    }
}