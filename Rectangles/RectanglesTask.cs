using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
		// Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
			int neg;
			neg = GetNegativeCoordinate(r1, r2);

			if (AutoCheck(r1.Left, r2.Left, r2.Right, neg)
				|| AutoCheck(r1.Right, r2.Left, r2.Right, neg)
				|| AutoCheck(r2.Left, r1.Left, r1.Right, neg)
				|| AutoCheck(r2.Right, r1.Left, r1.Right, neg))
            {
				if (AutoCheck(r1.Top, r2.Top, r2.Bottom, neg)
					|| AutoCheck(r1.Bottom, r2.Top, r2.Bottom, neg)
					|| AutoCheck(r2.Top, r1.Top, r1.Bottom, neg)
					|| AutoCheck(r2.Bottom, r1.Top, r1.Bottom, neg))
                {
					return true;
                }
            }
			
			return false;
			// так можно обратиться к координатам левого верхнего угла первого прямоугольника: r1.Left, r1.Top
		}

		// Площадь пересечения прямоугольников
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{

			if(AreIntersected(r1, r2))
            {
				int neg;
				neg = GetNegativeCoordinate(r1, r2);
				return GetArea(r1, r2, neg);
			}

			return 0;
		}

		public static int GetArea(Rectangle r1, Rectangle r2, int neg)
        {
			if (r1.Left + neg == r1.Right + neg
				|| r1.Top + neg == r1.Bottom + neg
				|| r2.Left + neg == r2.Right + neg
				|| r2.Top + neg == r2.Bottom + neg)
			{
				return 0;
			}
			else if (r1.Width * r1.Height < r2.Width * r2.Height
					&& r1.Left + neg > r2.Left + neg
					&& r1.Right + neg < r2.Right + neg
					&& r1.Top + neg > r2.Top + neg
					&& r1.Bottom + neg < r2.Bottom + neg)
			{
				return r1.Height * r1.Width; //inner r1
			}
			else if (r1.Width * r1.Height > r2.Width * r2.Height
					&& r1.Left + neg < r2.Left + neg
					&& r1.Right + neg > r2.Right + neg
					&& r1.Top + neg < r2.Top + neg
					&& r1.Bottom + neg > r2.Bottom + neg)
			{
				return r2.Height * r2.Width; //inner r2
			}
			else
            {
					int left = Math.Max(r1.Left, r2.Left);
					int top = Math.Min(r1.Bottom, r2.Bottom);
					int right = Math.Min(r1.Right, r2.Right);
					int bottom = Math.Max(r1.Top, r2.Top);

					int width = right - left;
					int height = top - bottom;

					if (width < 0 || height < 0)
						return 0;

					return width * height;
			}

			//return 0;
        }

		public static int GetNegativeCoordinate(Rectangle r1, Rectangle r2)
        {
			int[] negative = {r1.Left, r1.Top, 
					r2.Left, r2.Top};
			if (r1.Left < 0 || r1.Top < 0 || r2.Left < 0 || r2.Top < 0)
            {
				Array.Sort(negative);
				return Math.Abs(negative[0]);
			}
			return 0;
        }

		public static bool AutoCheck(int coord, int coord2, int coord3, int neg)
		{

			if (coord + neg >= coord2 + neg && coord + neg <= coord3 + neg)
            {
				return true;
            }
			
			return false;
		}

		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		// Если прямоугольники совпадают, можно вернуть номер любого из них.
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
			int neg;
			neg = GetNegativeCoordinate(r1, r2);
			if (AreIntersected(r1, r2))
			{
				if (r1.Height * r1.Width <= r2.Height * r2.Width
					&& r1.Left + neg >= r2.Left + neg
					&& r1.Right + neg <= r2.Right + neg
					&& r1.Top + neg >= r2.Top + neg
					&& r1.Bottom + neg <= r2.Bottom + neg)
				{
					return 0; //inner r1
				}
				else if (r1.Height * r1.Width >= r2.Height * r2.Width
					&& r1.Left + neg <= r2.Left + neg
					&& r1.Right + neg >= r2.Right + neg
					&& r1.Top + neg <= r2.Top + neg
					&& r1.Bottom + neg >= r2.Bottom + neg)
				{
					return 1; //inner r2
				}
			}
			return -1;
		}
	}
}