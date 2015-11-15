using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealMechanismCS
{
    public class Movement
    {
        private Velocity2D _velocity;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="velocity"></param>
        public Movement(Velocity2D velocity)
        {
            _velocity = velocity;
        }

        /// <summary>
        /// Step Method, used to update movement deltas
        /// </summary>
        public override void Step()
        {
            Delta = CalculateCartesianDelta(_velocity);
        }

        /// <summary>
        /// Step Method, uses a tick to update movement deltas
        /// </summary>
        /// <param name="tick">Tick to use in calculation</param>
        public override void Step(uint tick)
        {
            this.Step();
        }

        /// <summary>
        /// Step Method, uses a value to update movement deltas
        /// </summary>
        /// <param name="value">Value to use in calculation</param>
        public override void Step(double value)
        {
            this.Step();
        }

        /// <summary>
        /// Step Method, uses a tick and a value to update movement deltas
        /// </summary>
        /// <param name="value">Value to use in calculation</param>
        /// <param name="tick">Tick to use in calculation</param>
        public override void Step(double value, uint tick)
        {
            this.Step();
        }

        /// <summary>
        /// SetDirection Method, sets the direction of movement using to and from coordinates.
        /// </summary>
        /// <param name="faceX">X to face</param>
        /// <param name="faceY">Y to face</param>
        /// <param name="x">X of entity</param>
        /// <param name="y">Y of entity</param>
        public void SetDirection(Point2D face, Point2D me)
        {
            _velocity.Velocity.Direction = CalculateDirection(CalculateDelta(face, me));
        }

        /// <summary>
        /// CalculateCartesianDelta,
        /// </summary>
        /// <param name="velocity"></param>
        /// <returns></returns>
        public static Point2D CalculateCartesianDelta(Velocity2D velocity)
        {
            return new Point2D(velocity.Velocity.Magnitude * Math.Cos(velocity.Velocity.Direction * (Math.PI / 180)), velocity.Velocity.Magnitude * Math.Sin(velocity.Velocity.Direction * (Math.PI / 180)));
        }

        /// <summary>
        /// CalculateDelta method, calculates the difference in the form for use in movements.
        /// </summary>
        /// <param name="to">value for to</param>
        /// <param name="from">value for from</param>
        /// <returns></returns>
        public static Point2D CalculateDelta(Point2D to, Point2D from)
        {
            return new Point2D(to.X - from.X, to.Y - from.Y);
        }

        /// <summary>
        /// CalculateDirection
        /// </summary>
        /// <param name="delta">Delta in Direction (Rise, Run)</param>
        /// <returns></returns>
        public static double CalculateDirection(Point2D delta)
        {
            return Math.Atan2(delta.Y, delta.X) * (180 / Math.PI);
        }
        
        /// <summary>
        /// Direction Property, accessor for direction of movement.
        /// </summary>
        public double Direction
        {
            get { return _velocity.Velocity.Magnitude; }
            set { _velocity.Velocity.Magnitude = value; }
        }

        /// <summary>
        /// Speed Property, accessor for speed.
        /// </summary>
        public double Speed
        {
            get { return _velocity.Velocity.Magnitude; }
            set { _velocity.Velocity.Magnitude = value; }
        }

        /// <summary>
        /// Velocity Property, accestor for velocity
        /// </summary>
        public Velocity2D Velocity2D
        {
            get { return _velocity; }
            set { _velocity = value; }
        }
    }
}
