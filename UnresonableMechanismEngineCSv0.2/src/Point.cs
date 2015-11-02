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
        /// <param name="point">Point to check against.</param>
        /// <returns>Difference in points.</returns>
        public Point Difference(Point point)
        {
            Point result = this;

            result.X -= point.X;
            result.Y -= point.Y;
            result.Z -= point.Z;

            return new Point();
        }

        /// <summary>
        /// Calculates difference in x.
        /// </summary>
        /// <param name="point">Point to check against.</param>
        /// <returns>Difference in x.</returns>
        public double DifferenceInX(Point point)
        {
            return _x - point.X;
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
        /// <param name="point">Point to check against.</param>
        /// <returns>Difference in y.</returns>
        public double DifferenceInY(Point point)
        {
            return _y - point.Y;
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
        /// <param name="point">Point to check against.</param>
        /// <returns>Difference in z.</returns>
        public double DifferenceInZ(Point point)
        {
            return _z - point.Z;
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

        /// <summary>
        /// Calculates sum.
        /// </summary>
        /// <param name="point">Point to add.</param>
        /// <returns>Sum of points.</returns>
        public Point Sum(Point point)
        {
            Point result = this;

            result.X += point.X;
            result.Y += point.Y;
            result.Z += point.Z;

            return new Point();
        }

        /// <summary>
        /// Calculates sum of x.
        /// </summary>
        /// <param name="point">Point to add.</param>
        /// <returns>Sum of x.</returns>
        public double SumInX(Point point)
        {
            return _x + point.X;
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
        /// <param name="point">Point to add.</param>
        /// <returns>Sum of y</returns>
        public double SumInY(Point point)
        {
            return _y + point.Y;
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
        /// <param name="point">Point to add.</param>
        /// <returns>Sum of z.</returns>
        public double SumInZ(Point point)
        {
            return _z + point.Z;
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
    }
}