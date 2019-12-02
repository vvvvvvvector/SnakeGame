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
        public static void DrawPixel(Pixel pixel)
        {
            Console.SetCursorPosition(pixel.xPos, pixel.yPos);
            Console.ForegroundColor = pixel.PixelColor;
            Console.Write("*");
        }
        public static void Update(Pixel pixel)
        {
            pixel.xPos += pixel.xSpeed;
            pixel.yPos += pixel.ySpeed;
        }
        public void direction(int x, int y)
        {
            xSpeed = x;
            ySpeed = y;
        }
    }
}