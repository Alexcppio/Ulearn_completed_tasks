using System;
using System.Drawing;

namespace Fractals
{
	internal static class DragonFractalTask
	{
		public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
		{
			var x = 1.0;
			var y = 0.0;
			var random = new Random(seed);

			for (int i = 0; i < iterationsCount; i++)
            {
				var nextNumber = random.Next(1, 3);
				if(nextNumber == 1)
                {
					var newX = (x * Math.Cos(Math.PI * 45.0 / 180.0) - y * Math.Sin(Math.PI * 45.0 / 180.0)) / Math.Sqrt(2.0);
					var newY = (x * Math.Sin(Math.PI * 45.0 / 180.0) + y * Math.Cos(Math.PI * 45.0 / 180.0)) / Math.Sqrt(2.0);
					x = newX;
					y = newY;
				}
				else if(nextNumber == 2)
                {
					var newX = (x * Math.Cos(Math.PI * 135.0 / 180.0) - y * Math.Sin(Math.PI * 135.0 / 180.0)) / Math.Sqrt(2.0) + 1;
					var newY = (x * Math.Sin(Math.PI * 135.0 / 180.0) + y * Math.Cos(Math.PI * 135.0 / 180.0)) / Math.Sqrt(2.0);
					x = newX;
					y = newY;
				}
				pixels.SetPixel(x, y);
			}
		}
	}
}