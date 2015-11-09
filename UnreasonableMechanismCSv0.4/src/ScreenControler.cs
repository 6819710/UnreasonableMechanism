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

        public static void SetScreen(Screen screen)
        {
            _screen = screen;
        }
    }
}