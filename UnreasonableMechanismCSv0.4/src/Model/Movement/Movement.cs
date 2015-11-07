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
    /// Movement defines basic static linear movement.
    /// </summary>
    public abstract class Movement
    {
        private UM.Vector _velocity;

        /// <summary>
        /// Constructs movement with provided delta.
        /// </summary>
        /// <param name="velocity">Vector with movement information.</param>
        public Movement(UM.Vector velocity)
        {
            _velocity = velocity;
        }

        /// <summary>
        /// Property: Velosity.
        /// </summary>
        public UM.Vector Velocity
        {
            get
            {
                return _velocity;
            }

            set
            {
                _velocity = value;
            }
        }

        /// <summary>
        /// Abstract method used to change delta values.
        /// </summary>
        public abstract void step();
    }
}