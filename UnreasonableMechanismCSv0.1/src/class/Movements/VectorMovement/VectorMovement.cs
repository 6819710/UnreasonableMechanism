using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealMechanismCS
{
    /// <summary>
    /// VectorMovement, class, defines linear vector movements.
    /// </summary>
    public class VectorMovement : Movement
    {
        //attributes
        private double _delta;
        private double _direction;

        //constuctors
        /// <summary>
        /// VectorMovement, constructor
        /// </summary>
        /// <param name="direction">Direction of movement (deg)</param>
        /// <param name="delta">Distance of movement</param>
        public VectorMovement(double direction, double delta) : base(0.0, 0.0)
        {
            _direction = direction;
            _delta = delta;
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
            DeltaX = _delta * Math.Cos(_direction * (Math.PI / 180));
            DeltaY = _delta * Math.Sin(_direction * (Math.PI / 180));
        }

        public void SetDirection(double vectX, double vectY)
        {
            _direction = Math.Atan2(vectY, vectX) * (180 / Math.PI);
        }

        public void SetDirection(double xTo, double yTo, double xFrom, double yFrom)
        {
            double vectX = (xFrom - xTo) * -1;
            double vectY = (yFrom - yTo) * -1;

            this.SetDirection(vectX, vectY);
        }

        //parameters
        /// <summary>
        /// Delta, patameter
        /// </summary>
        public double Delta
        {
            get
            {
                return _delta;
            }
            set
            {
                _delta = value;
            }
        }

        /// <summary>
        /// Direction, parameter
        /// </summary>
        public double Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;
            }
        }
    }
}
