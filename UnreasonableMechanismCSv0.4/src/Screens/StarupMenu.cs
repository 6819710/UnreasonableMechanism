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
    /// StartupMenu is a child class of Screen defining startup menu of game.
    /// </summary>
    public class StarupMenu : Screen
    {
        private Dictionary<string, Button> _buttons;
        private List<string> _buttonNames = new List<string>();
        
        //TODO: Add background image.

        /// <summary>
        /// Constructs Startup Menu.
        /// </summary>
        public StarupMenu()
        {
            _buttons = new Dictionary<string, Button>();

            //Startup Menu Buttons
            Button[] buttons = new Button[]
            {
                new Button("Play", new Point(20, 20)),
                new Button("Practice", new Point(20, 40)),
                new Button("Replay", new Point(20, 60)),
                new Button("Scores", new Point(20, 80)),
                new Button("Option", new Point(20, 100)),
                new Button("Quit", new Point(20, 120))
            };

            string[] names = new string[]
            {
                "Play",
                "Practice",
                "Replay",
                "Scores",
                "Option",
                "Quit"
            };

            _buttonNames = new List<string>(names);

            for(int i = 0; i < _buttonNames.Count; i++)
            {
                _buttons.Add(names[i], buttons[i]);
            }
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
            //TODO: Add graphical menu.

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
            Button("Play").Select();
        }

        /// <summary>
        /// Processes screen events.
        /// </summary>
        public override void ProvessEvents()
        {
            //Process user input.
            if(SwinGame.KeyTyped(Settings.DOWN))
            {
                if (Button("Play").Selected)
                {
                    Button("Practice").Select();
                    Button("Play").Deselect();
                }
                else if (Button("Practice").Selected)
                {
                    Button("Replay").Select();
                    Button("Practice").Deselect();
                }
                else if (Button("Replay").Selected)
                {
                    Button("Scores").Select();
                    Button("Replay").Deselect();
                }
                else if (Button("Scores").Selected)
                {
                    Button("Option").Select();
                    Button("Scores").Deselect();
                }
                else if (Button("Option").Selected)
                {
                    Button("Quit").Select();
                    Button("Option").Deselect();
                }
            }

            if(SwinGame.KeyTyped(Settings.UP))
            {
                if (Button("Practice").Selected)
                {
                    Button("Play").Select();
                    Button("Practice").Deselect();
                }
                else if (Button("Replay").Selected)
                {
                    Button("Practice").Select();
                    Button("Replay").Deselect();
                }
                else if (Button("Scores").Selected)
                {
                    Button("Replay").Select();
                    Button("Scores").Deselect();
                }
                else if (Button("Option").Selected)
                {
                    Button("Scores").Select();
                    Button("Option").Deselect();
                }
                else if(Button("Quit").Selected)
                {
                    Button("Option").Select();
                    Button("Quit").Deselect();
                }
            }

            if(SwinGame.KeyTyped(Settings.BOMB) || SwinGame.KeyTyped(Settings.PAUSE))
            {
                foreach (string btn in _buttonNames)
                {
                    Button(btn).Deselect();
                }
                Button("Quit").Select();
            }

            if(SwinGame.KeyTyped(Settings.SHOOT))
            {
                if (Button("Play").Selected)
                {
                    ScreenControler.SetScreen("ModeSelect");
                }
                else if (Button("Practice").Selected)
                {
                    
                }
                else if (Button("Replay").Selected)
                {
                    
                }
                else if (Button("Scores").Selected)
                {
                    
                }
                else if (Button("Option").Selected)
                {
                    ScreenControler.SetScreen("OptionsMenu");
                }
                else if (Button("Quit").Selected)
                {
                    Settings.EXIT = true;
                }
            }
        }
    }
}