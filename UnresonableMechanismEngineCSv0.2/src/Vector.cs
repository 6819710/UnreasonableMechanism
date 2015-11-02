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
            _i = to.DifferenceInX(from);
            _j = to.DifferenceInY(from);
            _k = to.DifferenceInZ(from);
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
                return Math.Sqrt(Math.Pow(_i, 2) + Math.Pow(_k, 2) + Math.Pow(_k, 2));
            }

            set
            {
                double phi = Phi;
                double theta = Theta;

                _i = value * Math.Cos(theta) * Math.Cos(phi);
                _j = value * Math.Cos(theta) * Math.Sin(phi);
                _k = value * Math.Sin(theta);
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
                return Math.Atan(_j / _k);
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
        public double Unit
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
        /// Calculates difference.
        /// </summary>
        /// <param name="subtrahend">Subtrahend vector.</param>
        /// <returns>Difference in vectors.</returns>
        public Vector Difference(Vector subtrahend)
        {
            Vector result = this;

            result.I = result.DifferenceInI(subtrahend);
            result.J = result.DifferenceInJ(subtrahend);
            result.K = result.DifferenceInK(subtrahend);

            return result;
        }

        /// <summary>
        /// Calculates difference.
        /// </summary>
        /// <param name="subtrahend">Subtrahend value.</param>
        /// <returns>Difference vector.</returns>
        public Vector Difference(double subtrahend)
        {
            Vector result = this;

            result.I = result.DifferenceInI(subtrahend);
            result.J = result.DifferenceInJ(subtrahend);
            result.K = result.DifferenceInK(subtrahend);

            return result;
        }

        /// <summary>
        /// Calculates difference in i.
        /// </summary>
        /// <param name="subtrahend">Subtrahend vector.</param>
        /// <returns>Difference in i</returns>
        public double DifferenceInI(Vector subtrahend)
        {
            return _i - subtrahend.I;
        }

        /// <summary>
        /// Calculates difference in i.
        /// </summary>
        /// <param name="i">Value of i.</param>
        /// <returns>Difference in i.</returns>
        public double DifferenceInI(double i)
        {
            return _i - i;
        }

        /// <summary>
        /// Calculates difference in j.
        /// </summary>
        /// <param name="subtrahend">Subtrahend vector.</param>
        /// <returns>Difference in j.</returns>
        public double DifferenceInJ(Vector subtrahend)
        {
            return _j - subtrahend.J;
        }

        /// <summary>
        /// Calculates difference in j.
        /// </summary>
        /// <param name="j">Value of j.</param>
        /// <returns>Difference in j.</returns>
        public double DifferenceInJ(double j)
        {
            return _j - j;
        }

        /// <summary>
        /// Calculates difference in k.
        /// </summary>
        /// <param name="subtrahend">Subtrahend vector.</param>
        /// <returns>Difference in k.</returns>
        public double DifferenceInK(Vector subtrahend)
        {
            return _k - subtrahend.K;
        }

        /// <summary>
        /// Calculates difference in k.
        /// </summary>
        /// <param name="k">Value of k.</param>
        /// <returns>Difference in k.</returns>
        public double DifferenceInK(double k)
        {
            return _k - k;
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
        /// Projects vector onto the vector provided.
        /// </summary>
        /// <param name="vector">Vector to project onto.</param>
        /// <returns>Projected vector.</returns>
        public Vector Project(Vector vector)
        {
            return this.DotProduct(vector) / vector.Magnitude * vector.Unit;
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
            return new Vector();
        }

        public static Vector operator+ (Vector left, double right)
        {
            return new Vector();
        }

        public static Vector operator- (Vector left, Vector right)
        {
            return left.Difference(right);
        }

        public static Vector operator- (Vector left, double right)
        {
            return left.Difference(right);
        }

        public static Vector operator* (Vector left, Vector right)
        {
            return new Vector();
        }

        public static Vector operator* (Vector left, double right)
        {
            return new Vector();
        }

        public static Vector operator/ (Vector left, Vector right)
        {
            return new Vector();
        }

        public static Vector operator/ (Vector left, double right)
        {
            return new Vector();
        }
    }
}