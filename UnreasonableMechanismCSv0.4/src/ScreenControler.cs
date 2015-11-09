using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnreasonableMechanismCS
{
    /// <summary>
    /// Controlls screen transitions.
    /// </summary>
    public static class ScreenControler
    {
        private static Screen _screen;

        /// <summary>
        /// Readonly Property: Screen.
        /// </summary>
        public static Screen Screen
        {
            get
            {
                return _screen;
            }
        }

        /// <summary>
        /// Initalises the screen.
        /// </summary>
        public static void Initalise()
        {
            _screen.Initalise();
        }

        public static void SetScreen(string screen)
        {
            _screen = GameObjects.GameScreen(screen);
        }
    }
}