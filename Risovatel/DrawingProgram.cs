using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace RefactorMe
{
    class Painter
    {
        static float startX, startY;
        static Graphics graphics;

        public static void Initialize ( Graphics newGraphics )
        {
            graphics = newGraphics;
            graphics.SmoothingMode = SmoothingMode.None;
            graphics.Clear(Color.Black);
        }

        public static void SetPosition(float coordX, float coordY)
        {startX = coordX; startY = coordY;}

        public static void DrawFigure(Pen drawMethod, double length, double angle)
        {
            //Делает шаг длиной length в направлении angle и рисует пройденную траекторию
            var newCoordX = (float)(startX + length * Math.Cos(angle));
            var newCoordY = (float)(startY + length * Math.Sin(angle));
            graphics.DrawLine(drawMethod, startX, startY, newCoordX, newCoordY);
            startX = newCoordX;
            startY = newCoordY;
        }

        public static void Change(double length, double angle)
        {
            startX = (float)(startX + length * Math.Cos(angle)); 
            startY = (float)(startY + length * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        public static void Draw(int width, int height, double angle, Graphics graphics)
        {
            // angle пока не используется, но будет использоваться в будущем
            Painter.Initialize(graphics);

            var size = Math.Min(width, height);

            var diagonalLength = Math.Sqrt(2) * (size * 0.375f + size * 0.04f) / 2;
            var startX = (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
            var startY = (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

            Painter.SetPosition(startX, startY);

            //Рисуем 1-ую сторону

            DrawSide(size);

            Painter.DrawFigure(Pens.Yellow, size * 0.375f, 0);
            Painter.DrawFigure(Pens.Yellow, size * 0.04f * Math.Sqrt(2), Math.PI / 4);
            Painter.DrawFigure(Pens.Yellow, size * 0.375f, Math.PI);
            Painter.DrawFigure(Pens.Yellow, size * 0.375f - size * 0.04f, Math.PI / 2);

            Painter.Change(size * 0.04f, -Math.PI);
            Painter.Change(size * 0.04f * Math.Sqrt(2), 3 * Math.PI / 4);

            //Рисуем 2-ую сторону
            Painter.DrawFigure(Pens.Yellow, size * 0.375f, -Math.PI / 2);
            Painter.DrawFigure(Pens.Yellow, size * 0.04f * Math.Sqrt(2), -Math.PI / 2 + Math.PI / 4);
            Painter.DrawFigure(Pens.Yellow, size * 0.375f, -Math.PI / 2 + Math.PI);
            Painter.DrawFigure(Pens.Yellow, size * 0.375f - size * 0.04f, -Math.PI / 2 + Math.PI / 2);

            Painter.Change(size * 0.04f, -Math.PI / 2 - Math.PI);
            Painter.Change(size * 0.04f * Math.Sqrt(2), -Math.PI / 2 + 3 * Math.PI / 4);

            //Рисуем 3-ю сторону
            Painter.DrawFigure(Pens.Yellow, size * 0.375f, Math.PI);
            Painter.DrawFigure(Pens.Yellow, size * 0.04f * Math.Sqrt(2), Math.PI + Math.PI / 4);
            Painter.DrawFigure(Pens.Yellow, size * 0.375f, Math.PI + Math.PI);
            Painter.DrawFigure(Pens.Yellow, size * 0.375f - size * 0.04f, Math.PI + Math.PI / 2);

            Painter.Change(size * 0.04f, Math.PI - Math.PI);
            Painter.Change(size * 0.04f * Math.Sqrt(2), Math.PI + 3 * Math.PI / 4);

            //Рисуем 4-ую сторону
            Painter.DrawFigure(Pens.Yellow, size * 0.375f, Math.PI / 2);
            Painter.DrawFigure(Pens.Yellow, size * 0.04f * Math.Sqrt(2), Math.PI / 2 + Math.PI / 4);
            Painter.DrawFigure(Pens.Yellow, size * 0.375f, Math.PI / 2 + Math.PI);
            Painter.DrawFigure(Pens.Yellow, size * 0.375f - size * 0.04f, Math.PI / 2 + Math.PI / 2);

            Painter.Change(size * 0.04f, Math.PI / 2 - Math.PI);
            Painter.Change(size * 0.04f * Math.Sqrt(2), Math.PI / 2 + 3 * Math.PI / 4);
        }

        public static void DrawSide(int size)
        {
            Painter.DrawFigure(Pens.Yellow, size * 0.375f, 0);
            Painter.DrawFigure(Pens.Yellow, size * 0.04f * Math.Sqrt(2), Math.PI / 4);
            Painter.DrawFigure(Pens.Yellow, size * 0.375f, Math.PI);
            Painter.DrawFigure(Pens.Yellow, size * 0.375f - size * 0.04f, Math.PI / 2);

            Painter.Change(size * 0.04f, -Math.PI);
            Painter.Change(size * 0.04f * Math.Sqrt(2), 3 * Math.PI / 4);
        }
    }
}