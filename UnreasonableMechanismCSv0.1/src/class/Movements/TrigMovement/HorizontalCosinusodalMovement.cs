using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealMechanismCS
{
    public class HorizontalCosusodalMovement : Movement
    {
        //attributes
        private CosineMovement _cosineMovement;
        
        //constructor
        /// <summary>
        /// VerticalSinusoalMovement, constuctor
        /// </summary>
        /// <param name="minY">Min Y Value</param>
        /// <param name="maxY">Max Y Value</param>
        /// <param name="y">Inital Y Value</param>
        /// <param name="deltaX">Delta X</param>
        /// <param name="period">Period (In Ticks)</param>
        public HorizontalCosusodalMovement(double minY, double maxY, double y, double period, double deltaX) : base(deltaX, 0.0)
        {
            double amplitude = (maxY - minY) / 2;
            double offset = maxY - amplitude;
            double phase = Math.Acos((offset - y) / amplitude) + (2 * Math.PI);
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
