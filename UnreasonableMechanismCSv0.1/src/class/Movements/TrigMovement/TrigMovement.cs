using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealMechanismCS
{
    public abstract class TrigMovement
    {
        //attributes
        private double _amp;
        private double _period;
        private double _phase;
        private double _shift;

        //constructor
        /// <summary>
        /// TrigMovement, constuctor
        /// </summary>
        /// <param name="amplitude">amplitude of the waveform</param>
        /// <param name="period">period of the waveform</param>
        /// <param name="phase">phase of the waveform</param>
        /// <param name="shift">shift of the waveform</param>
        public TrigMovement(double amplitude, double period, double phase, double shift)
        {
            _amp = amplitude;
            _period = period;
            _phase = phase;
            _shift = shift;
        }

        //methods
        /// <summary>
        /// Step, returns the value of the movement
        /// </summary>
        /// <param name="tick">entity tick</param>
        /// <returns>value of the movement</returns>
        public abstract double Step(int tick);

        //properties
        /// <summary>
        /// Amplitude, property
        /// </summary>
        public double Amplitude
        {
            get
            {
                return _amp;
            }
            set
            {
                _amp = value;
            }
        }

        /// <summary>
        /// Period, property
        /// </summary>
        public double Period
        {
                get
            {
                    return _period;
            }
                set
            {
                    _period = value;
            }
        }

        /// <summary>
        /// Phase, property
        /// </summary>
        public double Phase
        {
            get
            {
                return _phase;
            }
            set
            {
                _phase = value;
            }
        }

        /// <summary>
        /// Shift, property
        /// </summary>
        public double Shift
        {
            get
            {
                return _shift;
            }
            set
            {
                _shift = value;
            }
        }
    }
}
