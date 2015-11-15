using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealMechanismCS
{
    /// <summary>
    /// GravitaionalMovement, provides gravitational movement
    /// </summary>
    public class GravitationalMovement : Movement
    {
        //attributes
        private double _gravityX;
        private double _gravityY;
        private double _maxX;
        private double _maxY;

        //constructor
        /// <summary>
        /// GravitationalMovement, constructor for gravitaional movement patterns
        /// </summary>
        /// <param name="deltaX">Default change in X</param>
        /// <param name="deltaY">Default change in Y</param>
        /// <param name="gravityX">Gravity in X</param>
        /// <param name="gravityY">Gravity in Y</param>
        /// <param name="maxX">Max deltaX</param>
        /// <param name="maxY">Max deltaY</param>
        public GravitationalMovement(double deltaX, double deltaY, double gravityX, double gravityY, double maxX, double maxY) : base(deltaX, deltaY)
        {
            _gravityX = gravityX;
            _gravityY = gravityY;
            _maxX = maxX;
            _maxY = maxY;
        }

        //methods
        /// <summary>
        /// Step, method, used to process and update delta values
        /// </summary>
        /// <param name="value">Value to calculate delta</param>
        /// <param name="tick">Tick to calculate with</param>
        public override void Step(double value, int tick)
        {
            this.Step();
        }

        /// <summary>
        /// Step, overload
        /// </summary>
        /// <param name="value">Value to calculate delta</param>
        public override void Step(double value)
        {
            this.Step();
        }

        /// <summary>
        /// Step, overload
        /// </summary>
        public override void Step()
        {
            DeltaX += _gravityX;
            if (DeltaX > _maxX)
            {
                DeltaX = _maxX;
            }

            DeltaY += _gravityY;
            if (DeltaY > _maxY)
            {
                DeltaY = _maxY;
            }
        }

        //parameters
        /// <summary>
        /// GravityX, property
        /// </summary>
        public double GravityX
        {
            get
            {
                return _gravityX;
            }
            set
            {
                _gravityX = value;
            }
        }

        /// <summary>
        /// GravityY, property
        /// </summary>
        public double GravityY
        {
            get
            {
                return _gravityY;
            }
            set
            {
                _gravityY = value;
            }
        }

        /// <summary>
        /// MaxX, property
        /// </summary>
        public double MaxX
        {
            get
            {
                return _maxX;
            }
            set
            {
                _maxX = value;
            }
        }

        /// <summary>
        /// MaxY, property
        /// </summary>
        public double MaxY
        {
            get
            {
                return _maxY;
            }
            set
            {
                _maxY = value;
            }
        }
    }
}
