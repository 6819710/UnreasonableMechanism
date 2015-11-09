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
            _buttonNames.Add("Pause");
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
            foreach (string btn in _buttonNames)
            {
                Button(btn).Deselect();
            }
            Button("Shoot").Select();
        }

        /// <summary>
        /// Processes screen events.
        /// </summary>
        public override void ProvessEvents()
        {
            //Process user input.
            if (SwinGame.KeyTyped(Settings.DOWN))
            {
                if (Button("Shoot").Selected)
                {
                    Button("Bomb").Select();
                    Button("Shoot").Deselect();
                }
                else if (Button("Bomb").Selected)
                {
                    Button("Focus").Select();
                    Button("Bomb").Deselect();
                }
                else if (Button("Focus").Selected)
                {
                    Button("Pause").Select();
                    Button("Focus").Deselect();
                }
                else if (Button("Pause").Selected)
                {
                    Button("Up").Select();
                    Button("Pause").Deselect();
                }
                else if (Button("Up").Selected)
                {
                    Button("Down").Select();
                    Button("Up").Deselect();
                }
                else if (Button("Down").Selected)
                {
                    Button("Left").Select();
                    Button("Down").Deselect();
                }
                else if (Button("Left").Selected)
                {
                    Button("Right").Select();
                    Button("Left").Deselect();
                }
                else if (Button("Right").Selected)
                {
                    Button("Skip").Select();
                    Button("Right").Deselect();
                }
                else if (Button("Skip").Selected)
                {
                    Button("Quit").Select();
                    Button("Skip").Deselect();
                }
            }

            if (SwinGame.KeyTyped(Settings.UP))
            {
                if (Button("Bomb").Selected)
                {
                    Button("Shoot").Select();
                    Button("Bomb").Deselect();
                }
                else if (Button("Focus").Selected)
                {
                    Button("Bomb").Select();
                    Button("Focus").Deselect();
                }
                else if (Button("Pause").Selected)
                {
                    Button("Focus").Select();
                    Button("Pause").Deselect();
                }
                else if (Button("Up").Selected)
                {
                    Button("Pause").Select();
                    Button("Up").Deselect();
                }
                else if (Button("Down").Selected)
                {
                    Button("Up").Select();
                    Button("Down").Deselect();
                }
                else if (Button("Left").Selected)
                {
                    Button("Down").Select();
                    Button("Left").Deselect();
                }
                else if (Button("Right").Selected)
                {
                    Button("Left").Select();
                    Button("Right").Deselect();
                }
                else if (Button("Skip").Selected)
                {
                    Button("Right").Select();
                    Button("Skip").Deselect();
                }
                else if (Button("Quit").Selected)
                {
                    Button("Skip").Select();
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
                if (Button("Shoot").Selected)
                {
                    
                }
                else if (Button("Bomb").Selected)
                {

                }
                else if (Button("Focus").Selected)
                {

                }
                else if (Button("Pause").Selected)
                {

                }
                else if (Button("Up").Selected)
                {
                    
                }
                else if (Button("Down").Selected)
                {

                }
                else if (Button("Left").Selected)
                {

                }
                else if (Button("Right").Selected)
                {

                }
                else if (Button("Skip").Selected)
                {

                }
                else if (Button("Quit").Selected)
                {
                    ScreenControler.SetScreen("StartupMenu");
                    GameObjects.GameScreen("OptionsMenu").Reset();
                }
            }
        }
    }
}