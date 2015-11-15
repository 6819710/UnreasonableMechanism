using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealMechanismCS
{
    /// <summary>
    /// GravitationalMovement Class, defines gravitational movement.
    /// </summary>
    public class GravitationalMovement : VectorMovement
    {
        private Acceleration2D _acceleration;

        /// <summary>
        /// GravitationalMovement Constructor, sets inital values for velosity and acceleration.
        /// </summary>
        /// <param name="velocity"></param>
        /// <param name="acceleration"></param>
        public GravitationalMovement(Velocity2D velocity, Acceleration2D acceleration) : base(velocity)
        {
            _acceleration = acceleration;
        }

        /// <summary>
        /// Step Method, used to update movement deltas
        /// </summary>
        public override void Step()
        {
            
            //Update Delta
            Speed += _acceleration.Acceleration.Magnitude;
            if (Speed > _acceleration.TermV)
            {
                Speed = _acceleration.TermV;
            }

            Delta = CalculateCartesianDelta(Velocity2D);
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
        /// Acceleration Property, accessor for acceleration
        /// </summary>
        public Acceleration2D Acceleration2D
        {
            get { return _acceleration; }
            set { _acceleration = value; }
        }

        /// <summary>
        /// Gravity Property, accessor for gravity (acceleration).
        /// </summary>
        public double Gravity
        {
            get { return _acceleration.Acceleration.Magnitude; }
            set { _acceleration.Acceleration.Magnitude = value; }
        }

        /// <summary>
        /// TerminalVelocity Property, accessor for terminal velocity.
        /// </summary>
        public double TerminalVelocity
        {
            get { return _acceleration.TermV; }
            set { _acceleration.TermV = value; }
        }
    }
}
