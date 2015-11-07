using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UM = UnreasonableMechanismEngineCS;
using UnreasonableMechanismEngineCS;
using SwinGameSDK;

namespace UnreasonableMechanismCS
{
    /// <summary>
    /// Defines gravitational movements.
    /// </summary>
    public class Gravity : Movement
    {
        private UM.Vector _acceleration;
        private double _terminal;

        /// <summary>
        /// Constructs a force of gravity.
        /// </summary>
        /// <param name="velocity">Velosity of object.</param>
        /// <param name="acceleration">Acceleration force of gravity.</param>
        /// <param name="terminal">Terminal velosity of object.</param>
        public Gravity(UM.Vector velocity, UM.Vector acceleration, double terminal) : base(velocity)
        {
            _acceleration = acceleration;
            _terminal = terminal;
        }

        /// <summary>
        /// Readonly Property: Acceleration.
        /// </summary>
        public UM.Vector Acceleration
        {
            get
            {
                return _acceleration;
            }
        }

        /// <summary>
        /// Property: Terminal velocity.
        /// </summary>
        public double Terminal
        {
            get
            {
                return _terminal;
            }

            set
            {
                _terminal = value;
            }
        }

        /// <summary>
        /// Processes step in movement.
        /// </summary>
        public override void step()
        {
            UM.Vector v = Velocity;
            v += Acceleration;

            if(v.Magnitude > _terminal)
            {
                v.Magnitude = _terminal;
            }

            Velocity = v;
        }
    }
}