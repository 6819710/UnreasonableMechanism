using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace UnreasonableMechanismEngineCS
{
    /// <summary>
    /// Vector defines a magnitude and direction in 3D space.
    /// </summary>
    public struct Vector
    {
        private double _i;
        private double _j;
        private double _k;

        /// <summary>
        /// Constructs a vector using a point source.
        /// </summary>
        /// <param name="point">Point source.</param>
        public Vector(Point point)
        {
            _i = point.X;
            _j = point.Y;
            _k = point.Z;
        }

        /// <summary>
        /// Constructs a vector between two points.
        /// </summary>
        /// <param name="to">To point.</param>
        /// <param name="from">From point.</param>
        public Vector(Point to, Point from)
        {
            _i = to.DifferenceByX(from);
            _j = to.DifferenceByY(from);
            _k = to.DifferenceByZ(from);
        }

        /// <summary>
        /// Constructs a vector using 3D vector coordinates.
        /// </summary>
        /// <param name="i">Magnitude in direction of x.</param>
        /// <param name="j">Magnitude in direction of y.</param>
        /// <param name="k">Magnitude in firection of z.</param>
        public Vector(double i, double j, double k)
        {
            _i = i;
            _j = j;
            _k = k;
        }

        /// <summary>
        /// Constructs a vector using 2D vector coordinates.
        /// </summary>
        /// <param name="i">Magnitude in direction of x.</param>
        /// <param name="j">Magnitude in direction of y.</param>
        public Vector(double i, double j)
        {
            _i = i;
            _j = j;
            _k = 0;
        }

        /// <summary>
        /// Property: I
        /// </summary>
        public double I
        {
            get
            {
                return _i;
            }

            set
            {
                _i = value;
            }
        }

        /// <summary>
        /// Property: J
        /// </summary>
        public double J
        {
            get
            {
                return _j;
            }

            set
            {
                _j = value;
            }
        }

        /// <summary>
        /// Property: K
        /// </summary>
        public double K
        {
            get
            {
                return _k;
            }

            set
            {
                _k = value;
            }
        }

        /// <summary>
        /// Property: Magnitude
        /// </summary>
        public double Magnitude
        {
            get
            {
                return Math.Sqrt(Math.Pow(_i, 2) + Math.Pow(_j, 2) + Math.Pow(_k, 2));
            }

            set
            {
                Vector unit  = this.Unit;
                
                _i = value * unit.I;
                _j = value * unit.J;
                _k = value * unit.K;
            }
        }

        /// <summary>
        /// Property: Magnitude projected on x/y plane.
        /// </summary>
        public double Rho
        {
            get
            {
                return Math.Sqrt(Math.Pow(_i, 2) + Math.Pow(_k, 2));
            }

            set
            {
                double phi = Phi;

                _i = value * Math.Cos(phi);
                _j = value * Math.Sin(phi);
            }
        }

        /// <summary>
        /// Property: Angle theta.
        /// </summary>
        public double Theta
        {
            get
            {
                return Math.Atan(_k / Magnitude);
            }

            set
            {
                double phi = Phi;
                double magnitude = Magnitude;

                _i = magnitude * Math.Cos(value) * Math.Cos(phi);
                _j = magnitude * Math.Cos(value) * Math.Sin(phi);
                _k = magnitude * Math.Sin(value);
            }
        }

        /// <summary>
        /// Property: Angle phi.
        /// </summary>
        public double Phi
        {
            get
            {
                return Math.Atan(_j / _i);
            }

            set
            {
                double rho = Rho;

                _i = rho * Math.Cos(value);
                _j = rho * Math.Sin(value);
            }
        }

        /// <summary>
        /// Readonly Property: Unit vector.
        /// </summary>
        public Vector Unit
        {
            get
            {
                return this / Magnitude;
            }
        }

        /// <summary>
        /// Calculates the corss product.
        /// </summary>
        /// <param name="multiplier">Multiplyer vector.</param>
        /// <returns>Cross "vector" product.</returns>
        public Vector CrossProduct(Vector multiplier)
        {
            Vector result = new Vector(1, -1, 1);

            result.I = result.I * (_j * multiplier.K - _k * multiplier.J);
            result.J = result.J * (_i * multiplier.K - _k * multiplier.I);
            result.K = result.K * (_i * multiplier.J - _j * multiplier.I);

            return result;
        }

        /// <summary>
        /// Calculates difference from vector (minuend - subtrahend = difference).
        /// </summary>
        /// <param name="subtrahend">Subtrahend vector.</param>
        /// <returns>Difference.</returns>
        public Vector DifferenceBy(Vector subtrahend)
        {
            Vector result = this;

            result.I = result.DifferenceByI(subtrahend);
            result.J = result.DifferenceByJ(subtrahend);
            result.K = result.DifferenceByK(subtrahend);

            return result;
        }

        /// <summary>
        /// Calculates the difference from minuend (minuend - subtrahend = difference).
        /// </summary>
        /// <param name="minuend">Minuend vector.</param>
        /// <returns>Difference.</returns>
        public Vector DifferenceFrom(Vector minuend)
        {
            Vector result = this;

            result.I = result.DifferenceFromI(minuend);
            result.J = result.DifferenceFromJ(minuend);
            result.K = result.DifferenceFromK(minuend);

            return result;
        }

        /// <summary>
        /// Calculates difference from vector (minuend - subtrahend = difference).
        /// </summary>
        /// <param name="subtrahend">Subtrahend value.</param>
        /// <returns>Difference.</returns>
        public Vector DifferenceBy(double subtrahend)
        {
            Vector result = this;

            result.I = result.DifferenceByI(subtrahend);
            result.J = result.DifferenceByJ(subtrahend);
            result.K = result.DifferenceByK(subtrahend);

            return result;
        }

        /// <summary>
        /// Calculates the difference from minuend (minuend - subtrahend = difference).
        /// </summary>
        /// <param name="minuend">Minuend value.</param>
        /// <returns>Difference</returns>
        public Vector DifferenceFrom(double minuend)
        {
            Vector result = this;

            result.I = result.DifferenceFromI(minuend);
            result.J = result.DifferenceFromJ(minuend);
            result.K = result.DifferenceFromK(minuend);

            return result;
        }

        /// <summary>
        /// Calculates difference from i.
        /// </summary>
        /// <param name="subtrahend">Subtrahend vector.</param>
        /// <returns>Difference from i.</returns>
        public double DifferenceByI(Vector subtrahend)
        {
            return _i - subtrahend.I;
        }

        /// <summary>
        /// Calculates difference from minuend.
        /// </summary>
        /// <param name="minuend">Minuend Vector.</param>
        /// <returns>Difference from muniend.</returns>
        public double DifferenceFromI(Vector minuend)
        {
            return minuend.I - _i;
        }

        /// <summary>
        /// Calculates difference from i.
        /// </summary>
        /// <param name="subtrahend">Subtrahend value.</param>
        /// <returns>Difference from i.</returns>
        public double DifferenceByI(double subtrahend)
        {
            return _i - subtrahend;
        }

        /// <summary>
        /// Calculates difference from minuend.
        /// </summary>
        /// <param name="minuend">Minuend Value.</param>
        /// <returns>Difference from muniend.</returns>
        public double DifferenceFromI(double minuend)
        {
            return minuend - _i;
        }

        /// <summary>
        /// Calculates difference from j.
        /// </summary>
        /// <param name="subtrahend">Subtrahend vector.</param>
        /// <returns>Difference from j.</returns>
        public double DifferenceByJ(Vector subtrahend)
        {
            return _j - subtrahend.J;
        }

        /// <summary>
        /// Calculates difference from minuend.
        /// </summary>
        /// <param name="minuend">Minuend Vector.</param>
        /// <returns>Difference from muniend.</returns>
        public double DifferenceFromJ(Vector minuend)
        {
            return minuend.J - _j;
        }

        /// <summary>
        /// Calculates difference from j.
        /// </summary>
        /// <param name="subtrahend">Subtrahend value.</param>
        /// <returns>Difference from j.</returns>
        public double DifferenceByJ(double subtrahend)
        {
            return _j - subtrahend;
        }

        /// <summary>
        /// Calculates difference from minuend.
        /// </summary>
        /// <param name="minuend">Minuend Value.</param>
        /// <returns>Difference from muniend.</returns>
        public double DifferenceFromJ(double minuend)
        {
            return minuend - _j;
        }

        /// <summary>
        /// Calculates difference from k.
        /// </summary>
        /// <param name="subtrahend">Subtrahend vector.</param>
        /// <returns>Difference from k.</returns>
        public double DifferenceByK(Vector subtrahend)
        {
            return _k - subtrahend.K;
        }

        /// <summary>
        /// Calculates difference from minuend.
        /// </summary>
        /// <param name="minuend">Minuend Vector.</param>
        /// <returns>Difference from muniend.</returns>
        public double DifferenceFromK(Vector minuend)
        {
            return minuend.K - _k;
        }

        /// <summary>
        /// Calculates difference from k.
        /// </summary>
        /// <param name="subtrahend">Subtrahend value.</param>
        /// <returns>Difference from k.</returns>
        public double DifferenceByK(double subtrahend)
        {
            return _k - subtrahend;
        }

        /// <summary>
        /// Calculates difference from minuend.
        /// </summary>
        /// <param name="minuend">Minuend Value.</param>
        /// <returns>Difference from muniend.</returns>
        public double DifferenceFromK(double minuend)
        {
            return minuend - _k;
        }

        /// <summary>
        /// Calculates the dot product.
        /// </summary>
        /// <param name="multiplier">Multiplier vector.</param>
        /// <returns>Dot "scalar" product.</returns>
        public double DotProduct(Vector multiplier)
        {
            return _i * multiplier.I + _j * multiplier.J + _k * multiplier.K;
        }

        /// <summary>
        /// Draws a vector to the screen at the point.
        /// </summary>
        /// <param name="clr">Color to draw vector.</param>
        /// <param name="position">Position to draw vector.</param>
        public void Draw(Color clr, Point position)
        {
            float x = (float)position.X;
            float y = (float)position.Y;

            float i = (float)_i;
            float j = (float)_j;

            SwinGame.DrawLine(clr, x, y, x + i, y + j);
        }

        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }

            Vector vec = (Vector)obj;

            if((object)vec == null)
            {
                return false;
            }

            return _i == vec.I && _j == vec.J && _k == vec.K;
        }

        public override int GetHashCode()
        {
            return (int)_i ^ (int)_j ^ (int)_k;
        }

        /// <summary>
        /// Calculates the product.
        /// </summary>
        /// <param name="factor">Factor value.</param>
        /// <returns>Product.</returns>
        public Vector Product(double factor)
        {
            Vector result = this;

            result.I = result.ProductInI(factor);
            result.J = result.ProductInJ(factor);
            result.K = result.ProductInK(factor);

            return result;
        }

        /// <summary>
        /// Calculates the product by i.
        /// </summary>
        /// <param name="factor">Factor value.</param>
        /// <returns>Product by i.</returns>
        public double ProductInI(double factor)
        {
            return _i * factor;
        }

        /// <summary>
        /// Calculates the product by j.
        /// </summary>
        /// <param name="factor">Factor value.</param>
        /// <returns>Product by j.</returns>
        public double ProductInJ(double factor)
        {
            return _j * factor;
        }

        /// <summary>
        /// Calculates the product by k.
        /// </summary>
        /// <param name="factor">Factor value.</param>
        /// <returns>Product by k.</returns>
        public double ProductInK(double factor)
        {
            return _k * factor;
        }

        /// <summary>
        /// Projects vector onto the vector provided.
        /// </summary>
        /// <param name="vector">Vector to project onto.</param>
        /// <returns>Projected vector.</returns>
        public Vector Project(Vector vector)
        {
            return vector.Unit * (DotProduct(vector) / vector.Magnitude);
        }

        /// <summary>
        /// Calculates the counterclockwise perpendicular vector in the x-y plane. Note: Does not work for 3D vectors.
        /// </summary>
        /// <returns>Perpendicular vector.</returns>
        public Vector PerpendicularVector2D()
        {
            return new Vector(-_j, _i);
        }

        /// <summary>
        /// Calculates quotent from divisor.
        /// </summary>
        /// <param name="divisior">Divisor value.</param>
        /// <returns>Quorent.</returns>
        public Vector QuotentBy(double divisor)
        {
            Vector result = this;

            result.I = result.QuotentByI(divisor);
            result.J = result.QuotentByJ(divisor);
            result.K = result.QuotentByK(divisor);

            return result;
        }

        /// <summary>
        /// Calculates quotent from dividend.
        /// </summary>
        /// <param name="dividend">Dividend value.</param>
        /// <returns>Quorent.</returns>
        public Vector QuotentFrom(double dividend)
        {
            Vector result = this;

            result.I = result.QuotentFromI(dividend);
            result.J = result.QuotentFromJ(dividend);
            result.K = result.QuotentFromK(dividend);

            return result;
        }

        /// <summary>
        /// Calculates quotent from i.
        /// </summary>
        /// <param name="divisior">Divisor value.</param>
        /// <returns>Quorent.</returns>
        public double QuotentByI(double divisor)
        {
            return _i / divisor;
        }

        /// <summary>
        /// Calculates quotent from dividend.
        /// </summary>
        /// <param name="dividend">Dividend value.</param>
        /// <returns>Quorent.</returns>
        public double QuotentFromI(double dividend)
        {
            return dividend / _i;
        }

        /// <summary>
        /// Calculates quotent from j.
        /// </summary>
        /// <param name="divisior">Divisor value.</param>
        /// <returns>Quorent.</returns>
        public double QuotentByJ(double divisor)
        {
            return _j / divisor;
        }

        /// <summary>
        /// Calculates quotent from dividend.
        /// </summary>
        /// <param name="dividend">Dividend value.</param>
        /// <returns>Quorent.</returns>
        public double QuotentFromJ(double dividend)
        {
            return dividend / _i;
        }

        /// <summary>
        /// Calculates quotent from k.
        /// </summary>
        /// <param name="divisior">Divisor value.</param>
        /// <returns>Quorent.</returns>
        public double QuotentByK(double divisor)
        {
            return _k / divisor;
        }

        /// <summary>
        /// Calculates quotent from dividend.
        /// </summary>
        /// <param name="dividend">Dividend value.</param>
        /// <returns>Quorent.</returns>
        public double QuotentFromK(double dividend)
        {
            return dividend / _k;
        }

        /// <summary>
        /// Calculates sum.
        /// </summary>
        /// <param name="addend">Addend vector.</param>
        /// <returns>Sum of vectors.</returns>
        public Vector Sum(Vector addend)
        {
            Vector result = this;

            result.I = result.SumInI(addend);
            result.J = result.SumInJ(addend);
            result.K = result.SumInK(addend);

            return result;
        }

        /// <summary>
        /// Calculates sum.
        /// </summary>
        /// <param name="addend">Addend value.</param>
        /// <returns>Sum.</returns>
        public Vector Sum(double addend)
        {
            Vector result = this;

            result.I = result.SumInI(addend);
            result.J = result.SumInJ(addend);
            result.K = result.SumInK(addend);

            return result;
        }

        /// <summary>
        /// Calculates sum of i.
        /// </summary>
        /// <param name="addend">Addend vector.</param>
        /// <returns>Sum of i.</returns>
        public double SumInI(Vector addend)
        {
            return _i + addend.I;
        }

        /// <summary>
        /// Calculates sum of i.
        /// </summary>
        /// <param name="i">Value of i.</param>
        /// <returns>Sum of i.</returns>
        public double SumInI(double i)
        {
            return _i + i;
        }

        /// <summary>
        /// Calculates sum of j.
        /// </summary>
        /// <param name="addend">Addend vector.</param>
        /// <returns>Sum of j.</returns>
        public double SumInJ(Vector addend)
        {
            return _j + addend.J;
        }

        /// <summary>
        /// Calculates sum of j.
        /// </summary>
        /// <param name="j">Value of j.</param>
        /// <returns>Sum of j.</returns>
        public double SumInJ(double j)
        {
            return _j + j;
        }

        /// <summary>
        /// Calculates sum of k.
        /// </summary>
        /// <param name="addend">Addend vector.</param>
        /// <returns>Sum of k.</returns>
        public double SumInK(Vector addend)
        {
            return _k + addend.K;
        }

        /// <summary>
        /// Calculates sum of k.
        /// </summary>
        /// <param name="k">Value of k.</param>
        /// <returns>Sum of k.</returns>
        public double SumInK(double k)
        {
            return _k + k;
        }

        /// <summary>
        /// Converts vector to point.
        /// </summary>
        /// <returns>Point.</returns>
        public Point ToPoint()
        {
            return new Point(_i, _j, _k);
        }

        public override string ToString()
        {
            if (_k == 0)
            {
                return "(" + _i + ", " + _j + ")";
            }
            else
            {
                return "(" + _i + ", " + _j + ", " + _k + ")";
            }
        }

        public static bool operator== (Vector left, Vector right)
        {
            return left.Equals(right);
        }

        public static bool operator!= (Vector left, Vector right)
        {
            return !left.Equals(right);
        }

        public static Vector operator+ (Vector left, Vector right)
        {
            return left.Sum(right);
        }

        public static Vector operator+ (Vector left, double right)
        {
            return left.Sum(right);
        }

        public static Vector operator+ (double left, Vector right)
        {
            return right.Sum(left);
        }

        public static Vector operator- (Vector left, Vector right)
        {
            return left.DifferenceBy(right);
        }

        public static Vector operator- (Vector left, double right)
        {
            return left.DifferenceBy(right);
        }

        public static Vector operator- (double left, Vector right)
        {
            return right.DifferenceFrom(left);
        }

        public static Vector operator* (Vector left, Vector right)
        {
            return left.CrossProduct(right);
        }

        public static Vector operator* (Vector left, double right)
        {
            return left.Product(right);
        }

        public static Vector operator* (double left, Vector right)
        {
            return right.Product(left);
        }

        public static Vector operator/ (Vector left, double right)
        {
            return left.QuotentBy(right);
        }

        public static Vector operator/ (double left, Vector right)
        {
            return right.QuotentFrom(left);
        }
    }
}