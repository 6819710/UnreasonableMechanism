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
    public class StarupMenu : Screen
    {
        private Dictionary<string, Button> _buttons = new Dictionary<string, Button>();
        private List<string> _buttonNames = new List<string>();

        /// <summary>
        /// Constructs the startup menu
        /// </summary>
        public StarupMenu()
        {
            _buttons.Add("Play", new Button("Play", new Point(20, 20)));
            _buttonNames.Add("Play");
        }

        /// <summary>
        /// Draws the screen.
        /// </summary>
        public override void Draw()
        {
            SwinGame.ClearScreen(Colour.Black);
            foreach (string btn in _buttonNames)
            {
                _buttons[btn].Draw();
            }
        }

        /// <summary>
        /// Initalises the screen.
        /// </summary>
        public override void Initalise()
        {
            _buttons["Play"].Select();
        }

        /// <summary>
        /// Processes screen events.
        /// </summary>
        public override void ProvessEvents()
        {
        }
    }
}