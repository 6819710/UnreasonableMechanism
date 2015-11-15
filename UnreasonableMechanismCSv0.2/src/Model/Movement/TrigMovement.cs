using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealMechanismCS
{
    /// <summary>
    /// TrigMovement Class, defines sinusodal movement.
    /// </summary>
    public class TrigMovement : Movement
    {
        private double _angle;

        private double _amplitude;
        private double _period;
        private double _phase;
        private double _shift;

        /// <summary>
        /// TrigMovement Constructor, 
        /// </summary>
        /// <param name="amplitude">amlitude of sinusodal movement</param>
        /// <param name="period">period of sinusodal movement</param>
        /// <param name="phase">phase of sinusodal movement</param>
        /// <param name="shift">shift of sinusodal movement</param>
        /// <param name="tick">tick of game object</param>
        /// <param name="delta">velosity to move down path</param>
        /// <param name="direction">overall direction of movement (irrespective of sinusodal movement)</param>
        public TrigMovement(double amplitude, double period, double phase, double shift, uint tick, Velocity2D velocity) : base(velocity)
        {
            //Note: wave is in form - amplitude sin(period * tick - phase) + shift
            _amplitude = amplitude;
            _period = period;
            _phase = period;
            _shift = shift;

            //Note: angle of movement is - (amplitude * period cos(period * tick + phase)) + direction
            _angle = (amplitude * period * Math.Cos(period * tick - phase)) + Velocity2D.Velocity.Direction;
        }
        
        

        /// <summary>
        /// SetDirection Method, sets the direction of movement using a change in x and y.
        /// </summary>
        /// <param name="deltaX">Change in x.</param>
        /// <param name="deltaY">Change in y.</param>
        /// <param name="directionFlag"></param>
        public void SetDirection(double deltaX, double deltaY, bool directionFlag)
        {
            double normal = Math.Atan2(deltaY, deltaX) * (180 / Math.PI);

            if(directionFlag)
            {
                Direction = normal + 90;
            }
            else
            {
                Direction = normal - 90;
            }
        }

        /// <summary>
        /// SetDirection Method, sets the direction of movement using to and from coordinates.
        /// </summary>
        /// <param name="xTo"></param>
        /// <param name="yTo"></param>
        /// <param name="xFrom"></param>
        /// <param name="yFrom"></param>
        /// <param name="directionFlag"></param>
        public void SetDirection(double xTo, double yTo, double xFrom, double yFrom, bool directionFlag)
        {
            double deltaX = (xFrom - xTo) * -1;
            double deltaY = (yFrom - yTo) * -1;

            this.SetDirection(deltaX, deltaY, directionFlag);
        }
        
        /// <summary>
        /// Step Method, used to update movement deltas
        /// </summary>
        public override void Step()
        {
            this.Step(0);
        }

        /// <summary>
        /// Step Method, uses a tick to update movement deltas
        /// </summary>
        /// <param name="tick">Tick to use in calculation</param>
        public override void Step(uint tick)
        {
            //Note: angle of movement is - (amplitude * period cos(period * tick + phase)) + direction
            _angle = (_amplitude * _period * Math.Cos(_period * tick - _phase)) + Direction;

            Delta = CalculateCartesianDelta(Velocity2D);
        }

        /// <summary>
        /// Step Method, uses a value to update movement deltas
        /// </summary>
        /// <param name="value">Value to use in calculation</param>
        public override void Step(double value)
        {
            this.Step((uint)value);
        }

        /// <summary>
        /// Step Method, uses a tick and a value to update movement deltas
        /// </summary>
        /// <param name="value">Value to use in calculation</param>
        /// <param name="tick">Tick to use in calculation</param>
        public override void Step(double value, uint tick)
        {
            this.Step(tick);
        }


        /// <summary>
        /// CalculateAmplitude Method, calculates and returns the amplitude based on a pair of points.
        /// </summary>
        /// <param name="a">Point a.</param>
        /// <param name="b">Point b.</param>
        /// <returns>Amplitude based on coordinates (half the distance between points).</returns>
        public double CalculateAmplitude(Point2D a, Point2D b)
        {
            return CalculateDistanceBetweenPoints(a, b) / 2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a">Point a.</param>
        /// <param name="b">Point b.</param>
        /// <returns></returns>
        public double CalculateDistanceBetweenPoints(Point2D a, Point2D b)
        {
            return Math.Sqrt((b.X - a.X) + (b.Y - a.Y));
        }
    }
}
