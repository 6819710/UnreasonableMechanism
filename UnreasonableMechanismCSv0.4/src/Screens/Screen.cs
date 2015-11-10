using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnreasonableMechanismCS
{
    /// <summary>
    /// Screen defines screen types for game.
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
        /// Property: Tick
        /// </summary>
        public uint Tick
        {
            get
            {
                return _tick;
            }

            set
            {
                _tick = value;
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

        /// <summary>
        /// Processes Screen Events.
        /// </summary>
        public abstract void ProvessEvents();

        /// <summary>
        /// Resets the screen
        /// </summary>
        public void Reset()
        {
            _tick = 0;
            Initalise();
        }
    }
}