using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace UnreasonableMechanismEngineCS
{
    /// <summary>
    /// Point defines positions in 3D space.
    /// </summary>
    public struct Point
    {
        private double _x;
        private double _y;
        private double _z;

        /// <summary>
        /// Constructs a point using 3D cartesian coordinates.
        /// </summary>
        /// <param name="x">Cartesian x coordinate.</param>
        /// <param name="y">Cartesian y coordinate.</param>
        /// <param name="z">Cartesian z coordinate.</param>
        public Point(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        /// <summary>
        /// Constructs a point using 2D caresian coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(double x, double y)
        {
            _x = x;
            _y = y;
            _z = 0;
        }

        /// <summary>
        /// Property: Cartesian x coordinate.
        /// </summary>
        public double X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        /// <summary>
        /// Property: Cartesian y coordinate.
        /// </summary>
        public double Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }

        /// <summary>
        /// Property: Cartesian z coordinate.
        /// </summary>
        public double Z
        {
            get
            {
                return _z;
            }

            set
            {
                _z = value;
            }
        }

        /// <summary>
        /// Property: Distance from origin.
        /// </summary>
        public double R
        {
            get
            {
                return Math.Sqrt(Math.Pow(_x, 2) + Math.Pow(_y, 2) + Math.Pow(_z, 2));
            }

            set
            {
                double phi = Phi;
                double theta = Theta;

                _x = value * Math.Cos(theta) * Math.Cos(phi);
                _y = value * Math.Cos(theta) * Math.Sin(phi);
                _z = value * Math.Sin(theta);
            }
        }

        /// <summary>
        /// Property: Distance from orgigin projected on x/y plane.
        /// </summary>
        public double Rho
        {
            get
            {
                return Math.Sqrt(Math.Pow(_x, 2) + Math.Pow(_y, 2));
            }

            set
            {
                double phi = Phi;

                _x = value * Math.Cos(phi);
                _y = value * Math.Sin(phi);
            }
        }

        /// <summary>
        /// Property: Angle theta.
        /// </summary>
        public double Theta
        {
            get
            {
                return Math.Atan(_z / R);
            }

            set
            {
                double phi = Phi;
                double r = R;

                _x = r * Math.Cos(value) * Math.Cos(phi);
                _y = r * Math.Cos(value) * Math.Sin(phi);
                _z = r * Math.Sin(value);
            }
        }

        /// <summary>
        /// Property: Angle phi.
        /// </summary>
        public double Phi
        {
            get
            {
                return Math.Atan(_y / _x);
            }

            set
            {
                double rho = Rho;

                _x = rho * Math.Cos(value);
                _y = rho * Math.Sin(value);
            }
        }

        /// <summary>
        /// Calculates difference.
        /// </summary>
        /// <param name="subtrahend">Subtrahend point.</param>
        /// <returns>Difference in points.</returns>
        public Point Difference(Point subtrahend)
        {
            Point result = this;

            result.X -= result.DifferenceInX(subtrahend);
            result.Y -= result.DifferenceInY(subtrahend);
            result.Z -= result.DifferenceInZ(subtrahend);

            return new Point();
        }

        /// <summary>
        /// Calculates difference in x.
        /// </summary>
        /// <param name="subtrahend">Subtrahend point.</param>
        /// <returns>Difference in x.</returns>
        public double DifferenceInX(Point subtrahend)
        {
            return _x - subtrahend.X;
        }

        /// <summary>
        /// Calculates difference in x.
        /// </summary>
        /// <param name="x">Value of x.</param>
        /// <returns>Difference in x.</returns>
        public double DifferenceInX(double x)
        {
            return _x - x;
        }

        /// <summary>
        /// Calculates difference in y.
        /// </summary>
        /// <param name="subtrahend">Subtrahend point.</param>
        /// <returns>Difference in y.</returns>
        public double DifferenceInY(Point subtrahend)
        {
            return _y - subtrahend.Y;
        }

        /// <summary>
        /// Calculates difference in y.
        /// </summary>
        /// <param name="y">Value of y.</param>
        /// <returns>Difference in y.</returns>
        public double DifferenceInY(double y)
        {
            return _y - y;
        }

        /// <summary>
        /// Calculates difference in z.
        /// </summary>
        /// <param name="subtrahend">Subtrahend point.</param>
        /// <returns>Difference in z.</returns>
        public double DifferenceInZ(Point subtrahend)
        {
            return _z - subtrahend.Z;
        }

        /// <summary>
        /// Calculates difference in z.
        /// </summary>
        /// <param name="z">Value of z.</param>
        /// <returns>Difference in z.</returns>
        public double DifferenceInZ(double z)
        {
            return _z - z;
        }

        /// <summary>
        /// Draws a stylised point (cross) to screen.
        /// </summary>
        /// <param name="clr">Colour to draw.</param>
        public void Draw(Color clr)
        {
            float x = (float)_x;
            float y = (float)_y;

            SwinGame.DrawLine(clr, x - 5, y, x + 5, y);
            SwinGame.DrawLine(clr, x, y - 5, x, y + 5);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Point pnt = (Point)obj;

            if ((object)pnt == null)
            {
                return false;
            }

            return _x == pnt.X && _y == pnt.Y && _z == pnt.Z;
        }

        public override int GetHashCode()
        {
            return (int)_x ^ (int)_y ^ (int)_z;
        }

        /// <summary>
        /// Offsets the point by the given point.
        /// </summary>
        /// <param name="point">Distance to offset.</param>
        public void Offset(Point point)
        {
            this = Sum(point);
        }

        /// <summary>
        /// Calculates product.
        /// </summary>
        /// <param name="multiplier">Multiplier point.</param>
        /// <returns>Product of points.</returns>
        public Point Product(Point multiplier)
        {
            Point result = this;

            result.X = result.ProductInX(multiplier);
            result.Y = result.ProductInY(multiplier);
            result.Z = result.ProductInZ(multiplier);

            return result;
        }

        /// <summary>
        /// Calculates product in x.
        /// </summary>
        /// <param name="multiplier">Multiplier point.</param>
        /// <returns>Product of x.</returns>
        public double ProductInX(Point multiplier)
        {
            return _x * multiplier.X;
        }

        /// <summary>
        /// Calculates product of x.
        /// </summary>
        /// <param name="x">Value of x.</param>
        /// <returns>Product of x.</returns>
        public double ProductInX(double x)
        {
            return _x * x;
        }

        /// <summary>
        /// Calculates product of y.
        /// </summary>
        /// <param name="multiplier">Multiplier point.</param>
        /// <returns>Product of y</returns>
        public double ProductInY(Point multiplier)
        {
            return _y * multiplier.Y;
        }

        /// <summary>
        /// Calculates product of y.
        /// </summary>
        /// <param name="y">Value of y.</param>
        /// <returns>Product of y.</returns>
        public double ProductInY(double y)
        {
            return _y * y;
        }

        /// <summary>
        /// Calculates product of z.
        /// </summary>
        /// <param name="multiplier">Multiplier point.</param>
        /// <returns>Procuct of z.</returns>
        public double ProductInZ(Point multiplier)
        {
            return _z * multiplier.Z;
        }

        /// <summary>
        /// Calculates Product of z.
        /// </summary>
        /// <param name="z">Value of z.</param>
        /// <returns>Product of z.</returns>
        public double ProductInZ(double z)
        {
            return _z * z;
        }

        /// <summary>
        /// Calculates quotient.
        /// </summary>
        /// <param name="divisor">Divisor point.</param>
        /// <returns>Quotient of points.</returns>
        public Point Quotient(Point divisor)
        {
            Point result = this;

            result.X = result.QuotientInX(divisor);
            result.Y = result.QuotientInY(divisor);
            result.Z = result.QuotientInZ(divisor);

            return result;
        }

        /// <summary>
        /// Calculates quotient of x.
        /// </summary>
        /// <param name="divisor">Divisor point.</param>
        /// <returns>Quotient of x.</returns>
        public double QuotientInX(Point divisor)
        {
            return _x / divisor.X;
        }

        /// <summary>
        /// Calculates quotient of x.
        /// </summary>
        /// <param name="x">Value of x.</param>
        /// <returns>Quotient of x.</returns>
        public double QuotientInX(double x)
        {
            return _x / x;
        }

        /// <summary>
        /// Calculates quotient of y.
        /// </summary>
        /// <param name="divisor">Divisor point.</param>
        /// <returns>Quotient of y.</returns>
        public double QuotientInY(Point divisor)
        {
            return _y / divisor.Y;
        }

        /// <summary>
        /// Calculates quotient of y.
        /// </summary>
        /// <param name="y">Value of y.</param>
        /// <returns>Quotient of y.</returns>
        public double QuotientInY(double y)
        {
            return _y / y;
        }

        /// <summary>
        /// Calculates quotient of z.
        /// </summary>
        /// <param name="divisor">Divisor point.</param>
        /// <returns>Quotient of z.</returns>
        public double QuotientInZ(Point divisor)
        {
            return _z / divisor.Z;
        }

        /// <summary>
        /// Calculates quotient of z.
        /// </summary>
        /// <param name="z">Value of z.</param>
        /// <returns>Quotient of z.</returns>
        public double QuotientInZ(double z)
        {
            return _z / z;
        }

        /// <summary>
        /// Calculates sum.
        /// </summary>
        /// <param name="addend">Addend point.</param>
        /// <returns>Sum of points.</returns>
        public Point Sum(Point addend)
        {
            Point result = this;

            result.X += result.SumInX(addend);
            result.Y += result.SumInY(addend);
            result.Z += result.SumInZ(addend);

            return new Point();
        }

        /// <summary>
        /// Calculates sum of x.
        /// </summary>
        /// <param name="addend">Addend point.</param>
        /// <returns>Sum of x.</returns>
        public double SumInX(Point addend)
        {
            return _x + addend.X;
        }

        /// <summary>
        /// Calculates sum of x.
        /// </summary>
        /// <param name="x">Value of x.</param>
        /// <returns>Sum of x.</returns>
        public double SumInX(double x)
        {
            return _x + x;
        }

        /// <summary>
        /// Calculates sum of y.
        /// </summary>
        /// <param name="addend">Addend point.</param>
        /// <returns>Sum of y</returns>
        public double SumInY(Point addend)
        {
            return _y + addend.Y;
        }

        /// <summary>
        /// Calculates sum of y.
        /// </summary>
        /// <param name="y">Value of y.</param>
        /// <returns>Sum of y.</returns>
        public double SumInY(double y)
        {
            return _y + y;
        }

        /// <summary>
        /// Calculates Sum of z.
        /// </summary>
        /// <param name="addend">Addend point.</param>
        /// <returns>Sum of z.</returns>
        public double SumInZ(Point addend)
        {
            return _z + addend.Z;
        }

        /// <summary>
        /// Calculates sum of z.
        /// </summary>
        /// <param name="z">Value of z</param>
        /// <returns>Sum of z.</returns>
        public double SumInZ(double z)
        {
            return _z + z;
        }

        public override string ToString()
        {
            if (_z == 0)
            {
                return "(" + _x + ", " + _y + ")";
            }
            else
            {
                return "(" + _x + ", " + _y + ", " + _z + ")";
            }
        }

        public static bool operator ==(Point left, Point right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !(left.Equals(right));
        }

        public static Point operator +(Point left, Point right)
        {
            return left.Sum(right);
        }

        public static Point operator -(Point left, Point right)
        {
            return left.Difference(right);
        }

        public static Point operator* (Point left, Point right)
        {
            return left.Product(right);
        }

        public static Point operator/ (Point left, Point right)
        {
            return left.Quotient(right);
        }
    }
}