using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealMechanismCS
{
    public class HorizontalSinusodalMovement : Movement
    {
        //attributes
        private SineMovement _sineMovement;

        //constructor
        /// <summary>
        /// VerticalSinusoalMovement, constuctor
        /// </summary>
        /// <param name="minY">Min Y Value</param>
        /// <param name="maxY">Max Y Value</param>
        /// <param name="y">Inital Y Value</param>
        /// <param name="deltaX">Delta X</param>
        /// <param name="period">Period (In Ticks)</param>
        public HorizontalSinusodalMovement(double minY, double maxY, double y, double period, double deltaX) : base(deltaX, 0.0)
        {
            double amplitude = (maxY - minY) / 2;
            double offset = maxY - amplitude;
            double phase = Math.Asin((offset - y) / amplitude) + (2 * Math.PI);
            double altered = 0.2 * Math.PI / period;

            _sineMovement = new SineMovement(amplitude, altered, phase, offset);
        }

        //mehtods
        /// <summary>
        /// Step, method, used to process and update delta values
        /// </summary>
        /// <param name="value">Value to calculate delta</param>
        /// <param name="tick">Tick to calculate with</param>
        public override void Step(double value, int tick)
        {
            DeltaY = _sineMovement.Step(tick) - value;
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
        public SineMovement SineMovement
        {
            get
            {
                return _sineMovement;
            }
            set
            {
                _sineMovement = value;
            }
        }
    }
}
