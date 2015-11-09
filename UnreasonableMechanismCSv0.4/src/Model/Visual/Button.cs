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
        private bool _selected;

        /// <summary>
        /// Button location.
        /// </summary>
        /// <param name="buttonText">Text to use on button.</param>
        /// <param name="location">Button location</param>
        public Button(string buttonText, Point location)
        {
            _buttonText = buttonText;
            _buttonLocation = location;
            _selected = false;
        }

        /// <summary>
        /// Readonly Property: Selected.
        /// </summary>
        public bool Selected
        {
            get
            {
                return _selected;
            }
        }

        /// <summary>
        /// Draws the button.
        /// </summary>
        public void Draw()
        {
            if(_selected)
            {
                DrawText(Colour.White);
            }
            else
            {
                DrawText(Colour.Yellow);
            }
        }
        
        private void DrawText(Colour clr)
        {
            SwinGame.DrawText(_buttonText, clr, (float)_buttonLocation.X, (float)_buttonLocation.Y);
        }

        /// <summary>
        /// Selects button.
        /// </summary>
        public void Select()
        {
            _selected = true;
        }

        /// <summary>
        /// Deselects button.
        /// </summary>
        public void Deselect()
        {
            _selected = false;
        }
    }
}