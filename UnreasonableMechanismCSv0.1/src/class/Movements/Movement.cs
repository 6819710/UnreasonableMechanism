using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealMechanismCS
{
    /// <summary>
    /// Movement Class, bass class for movements.
    /// </summary>
    public abstract class Movement
    {
        //attributes
        private double _deltaX;
        private double _deltaY;


        //constructor
        /// <summary>
        /// Movement, constructor for basic movement
        /// </summary>
        /// <param name="deltaX">Delta for movement in X</param>
        /// <param name="deltaY">Delta for movement in Y</param>
        public Movement(double deltaX, double deltaY)
        {
            _deltaX = deltaX;
            _deltaY = deltaY;
        }


        //methods
        /// <summary>
        /// Step, method, used to process and update delta values
        /// </summary>
        /// <param name="value">Value to calculate delta</param>
        /// <param name="tick">Tick to calculate with</param>
        public abstract void Step(double value, int tick);

        /// <summary>
        /// Step, overload
        /// </summary>
        /// <param name="value">Value to calculate delta</param>
        public abstract void Step(double value);

        /// <summary>
        /// Step, overload
        /// </summary>
        public abstract void Step();


        //properties
        /// <summary>
        /// DeltaX, property
        /// </summary>
        public double DeltaX
        {
            get
            {
                return _deltaX;
            }
            set
            {
                _deltaX = value;
            }
        }

        /// <summary>
        /// DeltaY, property
        /// </summary>
        public double DeltaY
        {
            get
            {
                return _deltaY;
            }
            set
            {
                _deltaY = value;
            }
        }
    }
}
