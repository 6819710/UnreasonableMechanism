using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnreasonableMechanismCS
{
    /// <summary>
    /// Screen is an abstract class defining game screens.
    /// </summary>
    public abstract class Screen
    {
        private uint _tick;

        /// <summary>
        /// Constructs an empty screen.
        /// </summary>
        public Screen()
        {
            _tick = 0;
        }

        /// <summary>
        /// Readonly Property: Tick
        /// </summary>
        public uint Tick
        {
            get
            {
                return _tick;
            }
        }

        /// <summary>
        /// Draws the screen.
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// Initalises Screen.
        /// </summary>
        public abstract void Initalise();

        public void NextTick()
        {
            //TODO: Set tick to clock rather than frame rate. Optimisation.
            _tick++;
        }

        /// <summary>
        /// Processes Screen Events.
        /// </summary>
        public abstract void ProvessEvents();

        /// <summary>
        /// Resets screen.
        /// </summary>
        public void Reset()
        {
            Initalise();
        }

        /// <summary>
        /// Resets screen tick to 0.
        /// </summary>
        public void ResetTick()
        {
            _tick = 0;
        }
    }
}