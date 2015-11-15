using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrealMechanismCS
{
    public struct Vector2D
    {
        public double Direction;
        public double Magnitude;

        public Vector2D(double i, double j)
        {
            this.Magnitude = Math.Sqrt(i * i + j * j);
            this.Direction = Math.Atan2(i, j) * (180 / Math.PI);
        }

        public Vector2D(Point2D a, Point2D b)
        {
            double i = (a - b).X;
            double j = (a - b).Y;

            this.Magnitude = Math.Sqrt(i * i + j * j);
            this.Direction = Math.Atan2(i, j) * (180 / Math.PI);
        }

        public double i
        {
            get
            {
                return Magnitude * Math.Cos(Direction * (Math.PI / 180));
            }
        }

        public double j
        {
            get
            {
                return Magnitude * Math.Sin(Direction * (Math.PI / 180));
            }
        }

        public double Dot(Vector2D vector)
        {
            return Magnitude * vector.Magnitude * Math.Cos(Direction - vector.Magnitude);
        }

        public double Dot(Point2D vector)
        {
            return Magnitude * Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y) * Math.Cos(Direction - Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y));
        }

        public static bool operator== (Vector2D a, Vector2D b)
        {
            return a.Direction == b.Direction && a.Magnitude == b.Magnitude;
        }

        public static bool operator!= (Vector2D a, Vector2D b)
        {
            return !(a == b);
        }

        public static Vector2D operator+ (Vector2D a, Vector2D b)
        {
            return new Vector2D(a.i + b.i, a.j + b.j);
        }

        public static Vector2D operator+ (Vector2D a, Point2D b)
        {
            return new Vector2D(a.i + b.X, a.j + b.Y);
        }

        public static Vector2D operator- (Vector2D a, Vector2D b)
        {
            return new Vector2D(a.i - b.i, a.j - b.j);
        }

        public static Vector2D operator- (Vector2D a, Point2D b)
        {
            return new Vector2D(a.i - b.X, a.j - b.Y);
        }

        public void Normalise()
        {
            Direction = Math.Atan2(i / Magnitude, j / Magnitude) * (180 / Math.PI);
        }

        public Vector2D GetNormal()
        {
            return new Vector2D(i / Magnitude, j / Magnitude);
        }
    }
}