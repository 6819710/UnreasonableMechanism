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
    public class PlayerSelect : Screen
    {
        private Dictionary<string, Button> _buttons = new Dictionary<string, Button>();
        private List<string> _buttonNames = new List<string>();

        public PlayerSelect()
        {
            _buttons.Add("Wide", new Button("Wide", new Point(20, 20)));
            _buttons.Add("Narrow", new Button("Narrow", new Point(20, 40)));
            _buttons.Add("Quit", new Button("Quit", new Point(20, 60)));

            _buttonNames.Add("Wide");
            _buttonNames.Add("Narrow");
            _buttonNames.Add("Quit");
        }

        private Button Button(string buttonName)
        {
            return _buttons[buttonName];
        }

        /// <summary>
        /// Draws game screen.
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
        /// Initalises game screen.
        /// </summary>
        public override void Initalise()
        {
            foreach (string btn in _buttonNames)
            {
                Button(btn).Deselect();
            }
            Button("Wide").Select();
        }

        /// <summary>
        /// Processes game screen events.
        /// </summary>
        public override void ProvessEvents()
        {
            //Process user input.
            if (SwinGame.KeyTyped(Settings.DOWN))
            {
                if (Button("Wide").Selected)
                {
                    Button("Narrow").Select();
                    Button("Wide").Deselect();
                }
                else if (Button("Narrow").Selected)
                {
                    Button("Quit").Select();
                    Button("Narrow").Deselect();
                }
            }

            if (SwinGame.KeyTyped(Settings.UP))
            {
                if (Button("Narrow").Selected)
                {
                    Button("Wide").Select();
                    Button("Narrow").Deselect();
                }
                else if (Button("Quit").Selected)
                {
                    Button("Narrow").Select();
                    Button("Quit").Deselect();
                }
            }

            if (SwinGame.KeyTyped(Settings.BOMB) || SwinGame.KeyTyped(Settings.PAUSE))
            {
                foreach (string btn in _buttonNames)
                {
                    Button(btn).Deselect();
                }
                Button("Quit").Select();
            }

            if (SwinGame.KeyTyped(Settings.SHOOT))
            {
                if (Button("Wide").Selected)
                {

                }
                else if (Button("Narrow").Selected)
                {

                }
                else if (Button("Quit").Selected)
                {
                    ScreenControler.SetScreen("ModeSelect");
                    GameObjects.GameScreen("PlayerSelect").Reset();
                }
            }
        }
    }
}