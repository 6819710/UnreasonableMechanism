using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealMechanismCS
{
    public class VerticalCosusodalMovement : Movement
    {
        //attributes
        private CosineMovement _cosineMovement;

        //constructor
        /// <summary>
        /// VerticalSinusoalMovement, constuctor
        /// </summary>
        /// <param name="minX">Min X Value</param>
        /// <param name="maxX">Max X Value</param>
        /// <param name="x">Inital X Value</param>
        /// <param name="deltaY">Delta Y</param>
        /// <param name="period">Period (In Ticks)</param>
        public VerticalCosusodalMovement(double minX, double maxX, double x, double period, double deltaY) : base(0.0, deltaY)
        {
            double amplitude = (maxX - minX) / 2;
            double offset = maxX - amplitude;
            double phase = Math.Acos((offset - x) / amplitude) + (2 * Math.PI);
            double altered = 0.2 * Math.PI / period;

            _cosineMovement = new CosineMovement(amplitude, altered, phase, offset);
        }

        //mehtods
        /// <summary>
        /// Step, method, used to process and update delta values
        /// </summary>
        /// <param name="value">Value to calculate delta</param>
        /// <param name="tick">Tick to calculate with</param>
        public override void Step(double value, int tick)
        {
            DeltaY = _cosineMovement.Step(tick) - value;
        }

        /// <summary>
        /// Step, overload
        /// </summary>
        /// <param name="value">Value to calculate delta</param>
        public override void Step(double value)
        {
            this.Step(value, 0);
        }

        /// <summary>
        /// Step, overload
        /// </summary>
        public override void Step()
        {
            this.Step(0.0, 0);
        }

        //properies
        /// <summary>
        /// SinMovement, property
        /// </summary>
        public CosineMovement CosineMovement
        {
            get
            {
                return _cosineMovement;
            }
            set
            {
                _cosineMovement = value;
            }
        }
    }
}
