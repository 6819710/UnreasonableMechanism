using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrealMechanismCS
{
    public struct Point2D
    {
        public double X;
        public double Y;

        public Point2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public static bool operator== (Point2D a, Point2D b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator!= (Point2D a, Point2D b)
        {
            return !(a == b);
        }

        public static Point2D operator+ (Point2D a, Point2D b)
        {
            return new Point2D(a.X + b.X, a.Y + b.Y);
        }

        public static Point2D operator+ (Point2D a, Vector2D b)
        {
            return new Point2D(a.X + b.i, a.Y + b.j);
        }

        public static Point2D operator- (Point2D a, Point2D b)
        {
            return new Point2D(a.X - b.X, a.Y - b.Y);
        }

        public static Point2D operator- (Point2D a, Vector2D b)
        {
            return new Point2D(a.X - b.i, a.Y - b.j);
        }
    }
}