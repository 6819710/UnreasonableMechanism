using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnreasonableMechanismCS
{
    /// <summary>
    /// ScreenController is a static class defining tools to handle screen management and transition.
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

        /// <summary>
        /// Sets Screen to provided Screen.
        /// </summary>
        /// <param name="screen">Screen.</param>
        public static void SetScreen(string screen)
        {
            try
            {
                _screen = GameObjects.GameScreen(screen);
            }
            catch
            {
                throw new ApplicationException("Error: Feature not yet avalible.");
            }
        }

        /// <summary>
        /// Draws the current screen.
        /// </summary>
        public static void DrawScreen()
        {
            _screen.Draw();
        }
    }
}