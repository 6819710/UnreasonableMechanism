using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UM = UnreasonableMechanismEngineCS;
using UnreasonableMechanismEngineCS;
using SwinGameSDK;

namespace UnreasonableMechanismCS
{
    public class Linear : Movement
    {
        /// <summary>
        /// Constructs basic linear movement.
        /// </summary>
        /// <param name="velocity">Velosity vector.</param>
        public Linear(UM.Vector velocity) : base(velocity)
        {
        }

        /// <summary>
        /// Processes step in movement.
        /// </summary>
        public override void step()
        {
        }
    }
}