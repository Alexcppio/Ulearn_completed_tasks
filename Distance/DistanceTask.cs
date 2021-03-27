using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
		// Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
			
		public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
		{
			//double negativeValue = RemoveNegative(ax, ay, bx, by, x, y);
			//double sideAB = LengthVect(ax + negativeValue, ay + negativeValue, bx + negativeValue, by + negativeValue);
			//double sideBC = LengthVect(bx + negativeValue, by + negativeValue, x + negativeValue, y + negativeValue);
			//double sideCA = LengthVect(x + negativeValue, y + negativeValue, ax + negativeValue, ay + negativeValue);

			double sideAB = LengthVect(ax, ay, bx, by);
			double sideBC = LengthVect(bx, by, x, y);
			double sideCA = LengthVect(x, y, ax, ay);
			/*
			if (y == ay && ay == by
				&& x > Math.Max(ax, bx)
				|| y == ay && ay == by 
				&& x < Math.Min(ax, bx))
			{
				if(x > Math.Max(ax, bx))
				{
					return x - Math.Max(ax, bx);

				}				
				else if(x < Math.Min(ax, bx))
				{
					return Math.Min(ax, bx) - x;
				}
			}
			
			else if(x == ax && ax == bx
				&& y > Math.Max(ay, by)
				|| x == ax && ax == bx
				&& y < Math.Min(ay, by))
			{
				if (y > Math.Max(ay, by))
				{
					return y - Math.Max(ay, by);

				}
				else if (y < Math.Min(ay, by))
				{
					return Math.Min(ay, by) - y;
				}
			}
			else if(x == ax && ax == bx
				&& y == ay && ay == by)
			{
				return 0;
			}
			else if(VectorsAngle(ax, ay, bx, by, x, y) < 0
				|| VectorsAngle(bx, by, ax, ay, x, y) < 0)
			{
				return Math.Min(sideBC, sideCA);
			}
			*/
			//else 
			if(x >= Math.Min(ax, bx)
				&& x <= Math.Max(ax, bx)
				|| y >= Math.Min(ay, by)
				&& y <= Math.Max(ay, by))
			{
				//return (2 * AreaTriangle(sideAB, sideBC, sideCA)) / sideAB;
			}
			//return 0;
			return Math.Min(sideBC, sideCA);
		}
			public static double LengthVect(double ax, double ay, double bx, double by)
        {
			return Math.Sqrt(((bx - ax) * (bx - ax)) + ((by - ay) * (by - ay)));
        }

		public static double AreaTriangle(double sideAB, double sideBC, double sideCA)
        {
			double semiPerimeter = (sideAB + sideBC + sideCA) / 2;
			return Math.Sqrt(semiPerimeter * (semiPerimeter - sideAB) * (semiPerimeter - sideBC) * (semiPerimeter - sideCA));
        }
		/*
		public static double RemoveNegative(double ax, double ay, double bx, double by, double x, double y)
        {
			double[] values = { ax, ay, bx, by, x, y };
			Array.Sort(values);
			return Math.Abs(values[0]);
        }
		*/
		public static double VectorsAngle(double ax, double ay, double bx, double by, double x, double y)
        {
			double ABCD = ((bx - ax) * (x - ax)) + ((by - ay) * (y - ay));
			double AB = Math.Sqrt(((bx - ax) * (bx - ax)) + ((by - ay) * (by - ay)));
			double CD = Math.Sqrt(((x - ax) * (x - ax)) + ((y - ay) * (y - ay)));
			return AB * CD / ABCD;
        }
		
	}
}