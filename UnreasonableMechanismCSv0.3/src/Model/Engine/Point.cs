using System;
using SwinGameSDK;

namespace UnrealMechanismCS
{
    public struct Point
    {
        /// <summary>
        /// Cartesian x coordinate.
        /// </summary>
        public double x;

        /// <summary>
        /// Cartesian y corrdinate.
        /// </summary>
        public double y;

        /// <summary>
        /// Cartesian z coordinate.
        /// </summary>
        public double z;

        /// <summary>
        /// Defines a point in 3D Cartesian coordinates.
        /// </summary>
        /// <param name="x">Cartesian x coordinate.</param>
        /// <param name="y">Cartesian y coordinate.</param>
        /// <param name="z">Cartesian z coordinate.</param>
        public Point(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Defines a point in 2D Cartesian coordinates.
        /// </summary>
        /// <param name="x">Cartesian x coordinate.</param>
        /// <param name="y">Cartesian y coordinate.</param>
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
            this.z = 0;
        }
        
        /// <summary>
        /// Direct distance of point from origin.
        /// </summary>
        public double r
        {
            get
            {
                return Math.Sqrt((x * x) + (y * y) + (z * z));
            }

            set
            {
                double setPhi = phi;
                double setTheta = theta;
                x = (value * Math.Cos(setTheta)) * Math.Cos(setPhi);
                y = (value * Math.Cos(setTheta)) * Math.Sin(setPhi);
                z = value * Math.Sin(setTheta);
            }
        }

        /// <summary>
        /// Angle theta.
        /// </summary>
        public double theta
        {
            get
            {
                return Math.Atan(z / r);
            }

            set
            {
                double angle = phi;
                double displacement = r;
                x = (displacement * Math.Cos(value)) * Math.Cos(angle);
                y = (displacement * Math.Cos(value)) * Math.Sin(angle);
                z = displacement * Math.Sin(value);
            }
        }

        /// <summary>
        /// Rho.
        /// </summary>
        public double Rho
        {
            get
            {
                return Math.Sqrt((x * x) + (y * y));
            }

            set
            {
                double angle = phi;
                x = value * Math.Cos(angle);
                y = value * Math.Sin(angle);
            }
        }

        /// <summary>
        /// Angle phi.
        /// </summary>
        public double phi
        {
            get
            {
                return Math.Atan(y / x);
            }

            set
            {
                double displacement = Rho;
                x = displacement * Math.Cos(value);
                y = displacement * Math.Sin(value);
            }
        }

        /// <summary>
        /// Converts a point to a vector.
        /// </summary>
        /// <returns>Converted vector.</returns>
        public Vector ToVector()
        {
            return new Vector(x, y, z);
        }

        /// <summary>
        /// Calculates the distance the point is from the given x coordinate.
        /// </summary>
        /// <param name="x">Coordinate to check.</param>
        /// <returns>Distance from coordinate x.</returns>
        public double DistanceFromX(double x)
        {
            return Math.Abs(this.x - x);
        }

        /// <summary>
        /// Calculates the distance the point is from the given y coordinate.
        /// </summary>
        /// <param name="y">Coordinate to check.</param>
        /// <returns>Distance from coordinate y.</returns>
        public double DistanceFromY(double y)
        {
            return Math.Abs(this.y - y);
        }

        /// <summary>
        /// Calculates the distance the point is from the given z coordinate.
        /// </summary>
        /// <param name="z">Coordinate to check.</param>
        /// <returns>Distance from coordinate z.</returns>
        public double DistanceFromZ(double z)
        {
            return Math.Abs(this.z - z);
        }

        /// <summary>
        /// Overides equals method.
        /// </summary>
        /// <param name="obj">object to check against.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }

            Point pnt = (Point)obj;

            if((object)pnt == null)
            {
                return false;
            }

            return x == pnt.x && y == pnt.y && z == pnt.z;
        }

        /// <summary>
        /// Overides getHashCode method.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (int)x ^ (int)y ^ (int)z;
        }

        /// <summary>
        /// Overides toString method.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if(z == 0)
            {
                return "(" + x + ", " + y + ")";
            }
            else
            {
                return "(" + x + ", " + y + ", " + z + ")";
            }
        }

        /// <summary>
        /// Overides equals operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator== (Point left, Point right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Overides does not equal operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator!= (Point left, Point right)
        {
            return !(left.Equals(right));
        }

        /// <summary>
        /// Overides plus operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Point operator+ (Point left, Point right)
        {
            return new Point(left.x + right.x, left.y + right.y, left.z + right.z);
        }

        /// <summary>
        /// Overides minus operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Point operator- (Point left, Point right)
        {
            return new Point(left.x - right.x, left.y - right.y, left.z - right.z);
        }

        /// <summary>
        /// Returns a point mutiplied by a scarlar
        /// </summary>
        /// <param name="left">Point</param>
        /// <param name="right">Scarlar</param>
        /// <returns></returns>
        public static Point operator* (Point left, double right)
        {
            left.x = left.x * right;
            left.y = left.y * right;
            left.z = left.z * right;

            return left;
        }

        /// <summary>
        /// Returns a point devided by a scarlar
        /// </summary>
        /// <param name="left">Point</param>
        /// <param name="right">Scarlar</param>
        /// <returns></returns>
        public static Point operator/ (Point left, double right)
        {
            left.x = left.x / right;
            left.y = left.y / right;
            left.z = left.z / right;

            return left;
        }

        /// <summary>
        /// Draws a stylised point to screen
        /// </summary>
        public void Draw(Color clr)
        {
            float x1 = (float)this.x - 5;
            float x2 = (float)this.x + 5;

            float x = (float)this.x;

            float y1 = (float)this.y - 5;
            float y2 = (float)this.y + 5;

            float y = (float)this.y;

            SwinGame.DrawThickLine(clr, x1, y, x2, y, 2);
            SwinGame.DrawThickLine(clr, x, y1, x, y2, 2);
        }
    }
}