using System;
using SwinGameSDK;

namespace UnrealMechanismCS
{
    public struct Vector
    {
        /// <summary>
        /// Offeset in direction of x.
        /// </summary>
        public double i;

        /// <summary>
        /// Offeset in direction of y.
        /// </summary>
        public double j;

        /// <summary>
        /// Offeset in direction of z.
        /// </summary>
        public double k;

        /// <summary>
        /// Defines a vector in 3D cartesian vector coordinates.
        /// </summary>
        /// <param name="i">Offeset in direction of x.</param>
        /// <param name="j">Offeset in direction of t.</param>
        /// <param name="k">Offeset in direction of z.</param>
        public Vector(double i, double j, double k)
        {
            this.i = i;
            this.j = j;
            this.k = k;
        }

        /// <summary>
        /// Defines a vector in 2D cartesian vector coordinates.
        /// </summary>
        /// <param name="i">Offeset in direction of x.</param>
        /// <param name="j">Offeset in direction of y.</param>
        public Vector(double i, double j)
        {
            this.i = i;
            this.j = j;
            this.k = 0;
        }

        /// <summary>
        /// Defines a vector based on a point.
        /// </summary>
        /// <param name="delta">Point.</param>
        public Vector(Point delta)
        {
            this = delta.ToVector();
        }

        /// <summary>
        /// Defines a vector based on two points.
        /// </summary>
        /// <param name="a">From point.</param>
        /// <param name="b">To point.</param>
        public Vector(Point a, Point b)
        {
            Point delta = b - a;
            this = delta.ToVector();
        }

        /// <summary>
        /// Magnitude
        /// </summary>
        public double r
        {
            get
            {
                return Math.Sqrt((i * i) + (j * j) + (k * k));
            }

            set
            {
                double phi = φ;
                double theta = θ;
                i = (value * Math.Cos(theta)) * Math.Cos(phi);
                j = (value * Math.Cos(theta)) * Math.Sin(phi);
                k = value * Math.Sin(theta);
            }
        }

        /// <summary>
        /// Angle theta.
        /// </summary>
        public double θ
        {
            get
            {
                return Math.Atan(k / r);
            }

            set
            {
                double angle = φ;
                double magnitude = r;
                i = (magnitude * Math.Cos(value)) * Math.Cos(angle);
                j = (magnitude * Math.Cos(value)) * Math.Sin(angle);
                k = magnitude * Math.Sin(value);
            }
        }

        /// <summary>
        /// Angle theta in degrees.
        /// </summary>
        public double θDeg
        {
            get
            {
                return Mathematics.ToDeg(θ);
            }

            set
            {
                θ = Mathematics.ToRad(value);
            }
        }

        /// <summary>
        /// Rho.
        /// </summary>
        public double ρ
        {
            get
            {
                return Math.Sqrt((i * i) + (j * j));
            }

            set
            {
                double angle = φ;
                i = value * Math.Cos(angle);
                j = value * Math.Sin(angle);
            }
        }

        /// <summary>
        /// Angle phi
        /// </summary>
        public double φ
        {
            get
            {
                return Math.Atan(j / i);
            }

            set
            {
                double magnitude = ρ;
                i = magnitude * Math.Cos(value);
                j = magnitude * Math.Sin(value);
            }
        }

        /// <summary>
        /// Angle phi in degrees.
        /// </summary>
        public double φDeg
        {
            get
            {
                return Mathematics.ToDeg(φ);
            }

            set
            {
                φ = Mathematics.ToRad(value);
            }
        }

        /// <summary>
        /// Gets the unit vector.
        /// </summary>
        public Vector Unit
        {
            get
            {
                return this / r;
            }
        }

        /// <summary>
        /// Calculates the Dot Product against the provided vector.
        /// </summary>
        /// <param name="vector">Vector to dot against.</param>
        /// <returns>Dot "Scalar" product.</returns>
        public double Dot(Vector vector)
        {
            return i * vector.i + j * vector.j + k * vector.k;
        }

        /// <summary>
        /// Calculates the Cross Product against the provided vector
        /// </summary>
        /// <param name="vector">Vector to cross.</param>
        /// <returns>Cross "Vector" product</returns>
        public Vector Cross(Vector vector)
        {
            Vector result = new Vector(1, -1, 1);

            result.i = result.i * ((j * vector.k) - (k * vector.j));
            result.j = result.j * ((i * vector.k) - (k * vector.i));
            result.k = result.k * ((i * vector.j) - (j * vector.i));

            return result;
        }

        /// <summary>
        /// Projects the vector in the direction of the vector provided.
        /// </summary>
        /// <param name="vector">Vector to project onto.</param>
        /// <returns>Projected Vector.</returns>
        public Vector ProjectOnto(Vector vector)
        {
            return ((this.Dot(vector))/vector.r) * vector.Unit;
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

            Vector vec = (Vector)obj;

            if((object)vec == null)
            {
                return false;
            }

            return i == vec.i && j == vec.j && k == vec.k;
        }

        /// <summary>
        /// Overides getHashCode method.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (int)i ^ (int)j ^ (int)k;
        }

        /// <summary>
        /// Overides toString method.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (k == 0)
            {
                return "(" + i + ", " + j + ")";
            }
            else
            {
                return "(" + i + ", " + j + ", " + k + ")";
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
            return new Vector(left.i + right.i, left.j + right.j, left.k + right.j);
        }

        public static Vector operator+ (Point left, Vector right)
        {
            return new Vector(left.x + right.i, left.y + right.j, left.z + right.j);
        }

        public static Vector operator+ (Vector left, Point right)
        {
            return new Vector(left.i + right.x, left.j + right.y, left.k + right.z);
        }

        public static Vector operator- (Vector left, Vector right)
        {
            return new Vector(left.i - right.i, left.j - right.j, left.k - right.j);
        }

        public static Vector operator- (Point left, Vector right)
        {
            return new Vector(left.x - right.i, left.y - right.j, left.z - right.j);
        }

        public static Vector operator- (Vector left, Point right)
        {
            return new Vector(left.i - right.x, left.j - right.y, left.k - right.z);
        }

        public static Vector operator* (Vector left, double right)
        {
            return new Vector(left.i * right, left.j * right, left.k * right);
        }

        public static Vector operator* (double left, Vector right)
        {
            return new Vector(right.i * left, right.j * left, right.k * left);
        }

        public static Vector operator/ (Vector left, double right)
        {
            return new Vector(left.i / right, left.j / right, left.k / right);
        }

        public static Vector operator/ (double left, Vector right)
        {
            return new Vector(left / right.i, left / right.j, left / right.k);
        }

        public Point ToPoint()
        {
            return new Point(i, j, k);
        }

        public void Draw(Color clr, Point pos)
        {
            float x = (float)pos.x;
            float y = (float)pos.y;

            float i = (float)this.i;
            float j = (float)this.j;

            SwinGame.DrawThickLine(clr, x, y, x + i, y + j, 2);
        }
    }
}