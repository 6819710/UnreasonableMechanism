using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                //double phi = Phi;
                //double theta = Theta;



            }
        }
    }
}