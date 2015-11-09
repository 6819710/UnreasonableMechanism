using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnreasonableMechanismEngineCS;
using SwinGameSDK;

using Colour = SwinGameSDK.Color;
using Vector = UnreasonableMechanismEngineCS.Vector;

namespace UnreasonableMechanismCS
{
    /// <summary>
    /// Defines buttons used in game screens.
    /// </summary>
    public class Button
    {
        private string _buttonText;
        private Point _buttonLocation;

        /// <summary>
        /// Button location.
        /// </summary>
        /// <param name="buttonText">Text to use on button.</param>
        /// <param name="location">Button location</param>
        public Button(string buttonText, Point location)
        {
            _buttonText = buttonText;
            _buttonLocation = location;
        }

        /// <summary>
        /// Draws the button.
        /// </summary>
        public void Draw()
        {
            DrawText(Colour.White);
        }

        private void DrawText(Colour clr)
        {
            SwinGame.DrawText(_buttonText, clr, (float)_buttonLocation.X, (float)_buttonLocation.Y);
        }
    }
}