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
    public class OptionsMenu : Screen
    {
        private Dictionary<string, Button> _buttons = new Dictionary<string, Button>();
        private List<string> _buttonNames = new List<string>();

        public OptionsMenu()
        {
            _buttons.Add("Shoot", new Button("Shoot", new Point(20, 20)));
            _buttons.Add("Bomb", new Button("Bomb", new Point(20, 40)));
            _buttons.Add("Focus", new Button("Focus", new Point(20, 60)));
            _buttons.Add("Pause", new Button("Pause", new Point(20, 80)));
            _buttons.Add("Up", new Button("Up", new Point(20, 100)));
            _buttons.Add("Down", new Button("Down", new Point(20, 120)));
            _buttons.Add("Left", new Button("Left", new Point(20, 140)));
            _buttons.Add("Right", new Button("Right", new Point(20, 160)));
            _buttons.Add("Skip", new Button("Skip", new Point(20, 180)));
            _buttons.Add("Quit", new Button("Quit", new Point(20, 200)));

            _buttonNames.Add("Shoot");
            _buttonNames.Add("Bomb");
            _buttonNames.Add("Focus");
            _buttonNames.Add("Up");
            _buttonNames.Add("Down");
            _buttonNames.Add("Left");
            _buttonNames.Add("Right");
            _buttonNames.Add("Skip");
            _buttonNames.Add("Quit");
        }

        private Button Button(string buttonName)
        {
            return _buttons[buttonName];
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
            Button("Shoot").Select();
        }

        public override void ProvessEvents()
        {
            //Process user input.
        }
    }
}