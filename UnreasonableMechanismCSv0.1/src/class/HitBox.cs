using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealMechanismCS
{
    /// <summary>
    /// Hitbox Class, defines the aspects of a standard colision box.
    /// </summary>
    public class HitBox
    {
        //attributes
        private double _x;
        private double _y;

        private double _width;
        private double _height;

        //constructor
        /// <summary>
        /// Hit Box Constructor
        /// Initalises and sets the values for the class variables
        /// Uses Cartesian Coordinates
        /// </summary>
        /// <param name="x">The inital x position</param>
        /// <param name="y">The inital y position</param>
        /// <param name="width">The inital width</param>
        /// <param name="height">The inital height</param>
        public HitBox(double x, double y, double width, double height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }

        //methods
        /// <summary>
        /// Collides Method
        /// Dectects a colition against the provided Hit Box
        /// </summary>
        /// <param name="hitBox">The Hit Box to check against</param>
        /// <returns>true if colition is detected</returns>
        public bool Collides(HitBox hitBox)
        {
            // HitBoxes Colide if all the folowing conditions are met:
            // x + width > hitBox x
            // x < hitBox x + hitBox width
            // y + height > hitBox y
            // y < hitBox y + hitBox height
            if(_x + _width > hitBox.X && _x < hitBox.X + hitBox.Width && _y + _height > hitBox.Y && _y < hitBox.Y + hitBox.Height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //property
        /// <summary>
        /// X, property
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
        /// Y, property
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
        /// Width, property
        /// </summary>
        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        /// <summary>
        /// Height, property
        /// </summary>
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }
    }
}
