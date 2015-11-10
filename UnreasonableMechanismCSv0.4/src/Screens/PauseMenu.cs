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
    public class PauseMenu : Screen
    {
        private Dictionary<string, Button> _buttons = new Dictionary<string, Button>();
        private List<string> _buttonNames = new List<string>();

        public PauseMenu()
        {
            _buttons.Add("Unpause", new Button("Unpause", new Point(20, 20)));
            _buttons.Add("Quit", new Button("Quit Game", new Point(20, 40)));

            _buttonNames.Add("Unpause");
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
            Button("Unpause").Select();
        }

        /// <summary>
        /// Processes game screen events.
        /// </summary>
        public override void ProvessEvents()
        {
            //Process user input.
            if (SwinGame.KeyTyped(Settings.DOWN))
            {
                if (Button("Unpause").Selected)
                {
                    Button("Quit").Select();
                    Button("Unpause").Deselect();
                }
            }

            if (SwinGame.KeyTyped(Settings.UP))
            {
                if (Button("Quit").Selected)
                {
                    Button("Unpause").Select();
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
                if (Button("Unpause").Selected)
                {
                    ScreenControler.SetScreen("TestLevel");
                    GameObjects.GameScreen("PauseMenu").Reset();
                }
                else if (Button("Quit").Selected)
                {
                    ScreenControler.SetScreen("StartupMenu");
                    GameObjects.GameScreen("PauseMenu").Reset();
                    GameObjects.GameScreen("TestLevel").Reset();
                    GameObjects.Initalise();
                }
            }
        }
    }
}