using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealMechanismCS
{
    public class VerticalSinusodalMovement : Movement
    {
        //attributes
        private SineMovement _sineMovement;

        //constructor
        /// <summary>
        /// VerticalSinusoalMovement, constuctor
        /// </summary>
        /// <param name="minX">Min X Value</param>
        /// <param name="maxX">Max X Value</param>
        /// <param name="x">Inital X Value</param>
        /// <param name="deltaY">Delta Y</param>
        /// <param name="period">Period (In Ticks)</param>
        public VerticalSinusodalMovement(double minX, double maxX, double x, double period, double deltaY) : base(0.0, deltaY)
        {
            double amplitude = (maxX - minX) / 2;
            double offset = maxX - amplitude;
            double phase = Math.Asin((offset - x) / amplitude) + (2 * Math.PI);
            double altered = 0.2 * Math.PI / period;

            //double phase = (Math.Asin((offset - x) / amp) + 2 * Math.PI) / period;

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
