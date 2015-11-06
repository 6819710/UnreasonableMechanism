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
        /// Calculates difference from point.
        /// </summary>
        /// <param name="subtrahend">Subtrahend point.</param>
        /// <returns>Difference from point.</returns>
        public Point DifferenceBy(Point subtrahend)
        {
            Point result = this;

            result.X = result.DifferenceByX(subtrahend);
            result.Y = result.DifferenceByY(subtrahend);
            result.Z = result.DifferenceByZ(subtrahend);

            return result;
        }

        /// <summary>
        /// Calculates difference from minuend.
        /// </summary>
        /// <param name="minuend">Minuend point.</param>
        /// <returns>Difference from minuend.</returns>
        public Point DifferenceFrom(Point minuend)
        {
            Point result = this;

            result.X = result.DifferenceFromX(minuend);
            result.Y = result.DifferenceFromY(minuend);
            result.Z = result.DifferenceFromZ(minuend);

            return result;
        }

        /// <summary>
        /// Calculates difference from point.
        /// </summary>
        /// <param name="subtrahend">Subtrahend value.</param>
        /// <returns>Difference from point.</returns>
        public Point DifferenceBy(double subtrahend)
        {
            Point result = this;

            result.X = result.DifferenceByX(subtrahend);
            result.Y = result.DifferenceByY(subtrahend);
            result.Z = result.DifferenceByZ(subtrahend);

            return result;
        }

        /// <summary>
        /// Calculates difference from minuend.
        /// </summary>
        /// <param name="minuend">Minuend value.</param>
        /// <returns>Difference from minuend.</returns>
        public Point DifferenceFrom(double minuend)
        {
            Point result = this;

            result.X = result.DifferenceFromX(minuend);
            result.Y = result.DifferenceFromY(minuend);
            result.Z = result.DifferenceFromZ(minuend);

            return result;
        }

        /// <summary>
        /// Calculates difference from point.
        /// </summary>
        /// <param name="subtrahend">Subtrahend point.</param>
        /// <returns>Difference from point.</returns>
        public double DifferenceByX(Point subtrahend)
        {
            return _x - subtrahend.X;
        }

        /// <summary>
        /// Calculates difference from minuend.
        /// </summary>
        /// <param name="minuend">Minuend point.</param>
        /// <returns>Difference from minuend.</returns>
        public double DifferenceFromX(Point minuend)
        {
            return minuend.X - _x;
        }

        /// <summary>
        /// Calculates difference from point.
        /// </summary>
        /// <param name="subtrahend">Subtrahend value.</param>
        /// <returns>Difference from point.</returns>
        public double DifferenceByX(double subtrahend)
        {
            return _x - subtrahend;
        }

        /// <summary>
        /// Calculates difference from minuend.
        /// </summary>
        /// <param name="munuend">Minuend value.</param>
        /// <returns>Difference from minuend.</returns>
        public double DifferenceFromX(double munuend)
        {
            return munuend - _x;
        }

        /// <summary>
        /// Calculates difference from point.
        /// </summary>
        /// <param name="subtrahend">Subtrahend point.</param>
        /// <returns>Difference from point.</returns>
        public double DifferenceByY(Point subtrahend)
        {
            return _y - subtrahend.Y;
        }

        /// <summary>
        /// Calculates difference from minuend.
        /// </summary>
        /// <param name="minuend">Minuend point.</param>
        /// <returns>Difference from minuend.</returns>
        public double DifferenceFromY(Point minuend)
        {
            return minuend.Y - _y;
        }

        /// <summary>
        /// Calculates difference from point.
        /// </summary>
        /// <param name="subtrahend">Subtrahend value.</param>
        /// <returns>Difference from point.</returns>
        public double DifferenceByY(double subtrahend)
        {
            return _y - subtrahend;
        }

        /// <summary>
        /// Calculates difference from minuend.
        /// </summary>
        /// <param name="minuend">Minuend value.</param>
        /// <returns>Difference from minuend.</returns>
        public double DifferenceFromY(double minuend)
        {
            return minuend - _y;
        }

        /// <summary>
        /// Calculates difference from point.
        /// </summary>
        /// <param name="subtrahend">Subtrahend point.</param>
        /// <returns>Difference from point.</returns>
        public double DifferenceByZ(Point subtrahend)
        {
            return _z - subtrahend.Z;
        }

        /// <summary>
        /// Calculates difference from minuend.
        /// </summary>
        /// <param name="minuend">Minuend point.</param>
        /// <returns>Difference from minuend.</returns>
        public double DifferenceFromZ(Point minuend)
        {
            return minuend.Z - _z;
        }

        /// <summary>
        /// Calculates difference from point.
        /// </summary>
        /// <param name="subtrahend">Subtrahend value.</param>
        /// <returns>Difference from point.</returns>
        public double DifferenceByZ(double subtrahend)
        {
            return _z - subtrahend;
        }

        /// <summary>
        /// Calculates difference from minuend.
        /// </summary>
        /// <param name="minuend">Minuend value.</param>
        /// <returns>Difference from minuend.</returns>
        public double DifferenceFromZ(double minuend)
        {
            return minuend - _z;
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
        /// Offsets the point by the given movement vector.
        /// </summary>
        /// <param name="point">Movement vector.</param>
        public Point Offset(Vector movement)
        {
            return Sum(movement.ToPoint());
        }

        /// <summary>
        /// Pitches the point about the trajectory from the given point.
        /// </summary>
        /// <param name="angle">Angle to pitch (radians).</param>
        /// <param name="point">Point to pivet about.</param>
        /// <param name="trajectory">Trajectory vector.</param>
        /// <param name="roll">Roll vector.</param>
        /// <returns></returns>
        public Point Pitch(double angle, Point point, Vector trajectory, Vector roll)
        {
            Point delta = this - point;

            double x = delta.X;
            double y = delta.Y;
            double z = delta.Z;

            return delta + point;
        }

        /// <summary>
        /// Pitches the point about the y coordinate of the given point.
        /// </summary>
        /// <param name="angle">Angle to pitch (radians).</param>
        /// <param name="point">Point to pivit about.</param>
        public Point PitchY(double angle, Point point)
        {
            Point delta = this - point;

            double x = delta.X;
            double z = delta.Z;

            delta.X = Math.Cos(angle) * x - Math.Sin(angle) * z;
            delta.Z = Math.Sin(angle) * x + Math.Cos(angle) * z;

            return delta + point;
        }

        /// <summary>
        /// Calculates product.
        /// </summary>
        /// <param name="multiplier">Multiplier point.</param>
        /// <returns>Product.</returns>
        public Point Product(Point multiplier)
        {
            Point result = this;

            result.X = result.ProductInX(multiplier);
            result.Y = result.ProductInY(multiplier);
            result.Z = result.ProductInZ(multiplier);

            return result;
        }

        /// <summary>
        /// Calculates product.
        /// </summary>
        /// <param name="multiplier">Multiplier value.</param>
        /// <returns>Product.</returns>
        public Point Product(double multiplier)
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
        /// Calculates quotient from point.
        /// </summary>
        /// <param name="divisor">Divisor point.</param>
        /// <returns>Quotient from point.</returns>
        public Point QuotientBy(Point divisor)
        {
            Point result = this;

            result.X = result.QuotientByX(divisor);
            result.Y = result.QuotientByY(divisor);
            result.Z = result.QuotientByZ(divisor);

            return result;
        }

        /// <summary>
        /// Calculates quotient from dividend.
        /// </summary>
        /// <param name="dividend">Dividend point.</param>
        /// <returns>Quotient from dividend.</returns>
        public Point QuotientFrom(Point dividend)
        {
            Point result = this;

            result.X = result.QuotientFromX(dividend);
            result.Y = result.QuotientFromY(dividend);
            result.Z = result.QuotientFromZ(dividend);

            return result;
        }

        /// <summary>
        /// Calculates quotient from point.
        /// </summary>
        /// <param name="divisor">Divisor value.</param>
        /// <returns>Quotient from point.</returns>
        public Point QuotientBy(double divisor)
        {
            Point result = this;

            result.X = result.QuotientByX(divisor);
            result.Y = result.QuotientByY(divisor);
            result.Z = result.QuotientByZ(divisor);

            return result;
        }

        /// <summary>
        /// Calculates quotient from dividend.
        /// </summary>
        /// <param name="dividend">Dividend value.</param>
        /// <returns>Quotient from dividend.</returns>
        public Point QuotientFrom(double dividend)
        {
            Point result = this;

            result.X = result.QuotientFromX(dividend);
            result.Y = result.QuotientFromY(dividend);
            result.Z = result.QuotientFromZ(dividend);

            return result;
        }

        /// <summary>
        /// Calculates quotient from point.
        /// </summary>
        /// <param name="divisor">Divisor point.</param>
        /// <returns>Quotient from point.</returns>
        public double QuotientByX(Point divisor)
        {
            return _x / divisor.X;
        }

        /// <summary>
        /// Calculates quotient from dividend.
        /// </summary>
        /// <param name="dividend">Dividend point.</param>
        /// <returns>Quotient from dividend.</returns>
        public double QuotientFromX(Point dividend)
        {
            return dividend.X / _x;
        }

        /// <summary>
        /// Calculates quotient from point.
        /// </summary>
        /// <param name="divisor">Divisor value.</param>
        /// <returns>Quotient from point.</returns>
        public double QuotientByX(double divisor)
        {
            return _x / divisor;
        }

        /// <summary>
        /// Calculates quotient from dividend.
        /// </summary>
        /// <param name="dividend">Dividend value.</param>
        /// <returns>Quotient from dividend.</returns>
        public double QuotientFromX(double dividend)
        {
            return dividend / _y;
        }

        /// <summary>
        /// Calculates quotient from point.
        /// </summary>
        /// <param name="divisor">Divisor point.</param>
        /// <returns>Quotient from point.</returns>
        public double QuotientByY(Point divisor)
        {
            return _y / divisor.Y;
        }

        /// <summary>
        /// Calculates quotient from dividend.
        /// </summary>
        /// <param name="dividend">Dividend point.</param>
        /// <returns>Quotient from dividend.</returns>
        public double QuotientFromY(Point dividend)
        {
            return dividend.Y / _y;
        }

        /// <summary>
        /// Calculates quotient from point.
        /// </summary>
        /// <param name="divisor">Divisor value.</param>
        /// <returns>Quotient from point.</returns>
        public double QuotientByY(double divisor)
        {
            return _y / divisor;
        }

        /// <summary>
        /// Calculates quotient from dividend.
        /// </summary>
        /// <param name="dividend">Dividend value.</param>
        /// <returns>Quotient from dividend.</returns>
        public double QuotientFromY(double dividend)
        {
            return dividend / _y;
        }

        /// <summary>
        /// Calculates quotient from point.
        /// </summary>
        /// <param name="divisor">Divisor point.</param>
        /// <returns>Quotient from point.</returns>
        public double QuotientByZ(Point divisor)
        {
            return _z / divisor.Z;
        }

        /// <summary>
        /// Calculates quotient from dividend.
        /// </summary>
        /// <param name="dividend">Dividend point.</param>
        /// <returns>Quotient from dividend.</returns>
        public double QuotientFromZ(Point dividend)
        {
            return dividend.Z / _z;
        }

        /// <summary>
        /// Calculates quotient from point.
        /// </summary>
        /// <param name="divisor">Divisor value.</param>
        /// <returns>Quotient from point.</returns>
        public double QuotientByZ(double divisor)
        {
            return _z / divisor;
        }

        /// <summary>
        /// Calculates quotient from dividend.
        /// </summary>
        /// <param name="dividend">Dividend value.</param>
        /// <returns>Quotient from dividend.</returns>
        public double QuotientFromZ(double dividend)
        {
            return dividend / _z;
        }

        /// <summary>
        /// Rolls the point about the x coordinate of the given point.
        /// </summary>
        /// <param name="angle">Angle to roll.</param>
        /// <param name="point">Point to roll about.</param>
        public Point RollX(double angle, Point point)
        {
            Point delta = this - point;

            double y = delta.Y;
            double z = delta.Z;

            delta.Y = Math.Cos(angle) * y + Math.Sin(angle) * z;
            delta.Z = -Math.Sin(angle) * y + Math.Cos(angle) * z;

            return delta + point;
        }

        /// <summary>
        /// Calculates sum.
        /// </summary>
        /// <param name="addend">Addend point.</param>
        /// <returns>Sum.</returns>
        public Point Sum(Point addend)
        {
            Point result = this;

            result.X = result.SumInX(addend);
            result.Y = result.SumInY(addend);
            result.Z = result.SumInZ(addend);

            return result;
        }

        /// <summary>
        /// Calculates sum.
        /// </summary>
        /// <param name="addend">Addend value.</param>
        /// <returns>Sum.</returns>
        public Point Sum(double addend)
        {
            Point result = this;

            result.X = result.SumInX(addend);
            result.Y = result.SumInY(addend);
            result.Z = result.SumInZ(addend);

            return result;
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

        /// <summary>
        /// Converts vector to point.
        /// </summary>
        /// <returns>Vector.</returns>
        public Vector ToVector()
        {
            return new Vector(_x, _y, _z);
        }

        /// <summary>
        /// Yaws the point about the z coordinate of the given point.
        /// </summary>
        /// <param name="angle">Angle to yaw.</param>
        /// <param name="point">Point to yaw about.</param>
        public Point YawZ(double angle, Point point)
        {
            Point delta = this - point;

            double x = delta.X;
            double y = delta.Y;

            delta.X = Math.Cos(angle) * x + Math.Sin(angle) * y;
            delta.Y = -Math.Sin(angle) * x + Math.Cos(angle) * y;

            return delta + point;
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

        public static Point operator+ (Point left, double right)
        {
            return left.Sum(right);
        }

        public static Point operator+ (double left, Point right)
        {
            return right.Sum(left);
        }

        public static Point operator- (Point left, Point right)
        {
            return left.DifferenceBy(right);
        }

        public static Point operator- (Point left, double right)
        {
            return left.DifferenceBy(right);
        }

        public static Point operator- (double left, Point right)
        {
            return right.DifferenceFrom(left);
        }

        public static Point operator* (Point left, Point right)
        {
            return left.Product(right);
        }

        public static Point operator* (Point left, double right)
        {
            return left.Product(right);
        }

        public static Point operator* (double left, Point right)
        {
            return right.Product(left);
        }

        public static Point operator/ (Point left, Point right)
        {
            return left.QuotientBy(right);
        }

        public static Point operator/ (Point left, double right)
        {
            return left.QuotientBy(right);
        }

        public static Point operator/ (double left, Point right)
        {
            return right.QuotientFrom(left);
        }
    }
}