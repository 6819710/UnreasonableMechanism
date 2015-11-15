using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealMechanismCS
{
    public class CosineMovement : TrigMovement
    {
        //constructor
        /// <summary>
        /// CosMovement, constuctor
        /// </summary>
        /// <param name="amplitude">amplitude of the waveform</param>
        /// <param name="period">period of the waveform</param>
        /// <param name="phase">phase of the waveform</param>
        /// <param name="shift">shift of the waveform</param>
        public CosineMovement(double amplitude, double period, double phase, double shift):base(amplitude, period, phase, shift)
        {

        }

        /// <summary>
        /// Step, returns the value of the sin movement
        /// </summary>
        /// <param name="tick">entity tick</param>
        /// <returns>value of the movement</returns>
        public override double Step(int tick)
        {
            return Amplitude * Math.Cos(Period * tick - Phase) + Shift;
        }
    }
}
