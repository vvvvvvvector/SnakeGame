using System;

namespace Snake
{
    class Pixel
    {
        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }
        public int xNewCoordinate { get; set; } = 1;
        public int yNewCoordinate { get; set; } = 0;
        public ConsoleColor pixelColor { get; set; }
        public Pixel(int xCoordinate, int yCoordinate, ConsoleColor pixelColor)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
            this.pixelColor = pixelColor;
        }
        public void DrawPixel()
        {
            Console.SetCursorPosition(xCoordinate, yCoordinate);
            Console.ForegroundColor = pixelColor;
            Console.Write("*");
        }
        public void UpdatePosition()
        {
            xCoordinate += xNewCoordinate;
            yCoordinate += yNewCoordinate;
        }
        public void NewDirection(int x, int y)
        {
            xNewCoordinate = x;
            yNewCoordinate = y;
        }
        public bool IsMovingUpOrDown()
        {
            return xNewCoordinate == 0 && yNewCoordinate == -1 || xNewCoordinate == 0 && yNewCoordinate == 1;
        }
        public bool IsMovingLeftOrRight() 
        {
            return xNewCoordinate == 1 && yNewCoordinate == 0 || xNewCoordinate == -1 && yNewCoordinate == 0;
        }
    }
}