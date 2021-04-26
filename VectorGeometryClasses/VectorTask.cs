using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTasks
{
    public class Vector
    {
        public double X;
        public double Y;

        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        public Vector Add(Vector obj)
        {
            return Geometry.Add(this, obj);
        }

        public bool Belongs(Segment obj)
        {
            return Geometry.IsVectorInSegment(this, obj);
        }
    }

    public class Segment
    {
        public Vector Begin;
        public Vector End;

        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        public bool Contains(Vector obj)
        {
            return Geometry.IsVectorInSegment(obj, this);
        }
    }

    public static class Geometry
    {
        public static double GetLength(Vector obj)
        {
            return Math.Sqrt(obj.X * obj.X + obj.Y * obj.Y);
        }

        public static Vector Add(Vector obj1, Vector obj2)
        {
            Vector obj3 = new Vector();
            obj3.X = obj1.X + obj2.X;
            obj3.Y = obj1.Y + obj2.Y;
            return obj3;
        }

        public static double GetLength(Segment obj)
        {
            var vect = new Vector();
            vect.X = obj.End.X - obj.Begin.X;
            vect.Y = obj.End.Y - obj.Begin.Y;
            return Math.Sqrt((vect.X * vect.X) + (vect.Y * vect.Y));
        }

        public static bool IsVectorInSegment(Vector obj, Segment obj2)
        {
            var segmLength = GetLength(obj2);
            var vect2 = new Vector();
            vect2.X = obj.X - obj2.Begin.X;
            vect2.Y = obj.Y - obj2.Begin.Y;
            if (((obj2.End.X - obj2.Begin.X) * vect2.Y - vect2.X * (obj2.End.Y - obj2.Begin.Y)) == 0
                && obj.X <= obj2.End.X
                && obj.X >= obj2.Begin.X
                && obj.Y <= obj2.End.Y
                && obj.Y >= obj2.Begin.Y)
            {
                return true;
            }
            return false;
        }
    }
}