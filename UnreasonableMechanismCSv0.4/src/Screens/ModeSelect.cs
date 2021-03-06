﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnreasonableMechanismEngineCS;
using SwinGameSDK;

using Colour = SwinGameSDK.Color;
using Vector = UnreasonableMechanismEngineCS.Vector;

namespace UnreasonableMechanismCS
{
    public class ModeSelect : Screen
    {
        private Dictionary<string, Button> _buttons = new Dictionary<string, Button>();
        private List<string> _buttonNames = new List<string>();

        public ModeSelect()
        {
            _buttons.Add("Demo", new Button("Demo", new Point(20, 20)));
            _buttons.Add("Easy", new Button("Easy", new Point(20, 40)));
            _buttons.Add("Normal", new Button("Normal", new Point(20, 60)));
            _buttons.Add("Hard", new Button("Hard", new Point(20, 80)));
            _buttons.Add("Lunatic", new Button("Lunatic", new Point(20, 100)));
            _buttons.Add("Quit", new Button("Quit", new Point(20, 120)));

            _buttonNames.Add("Demo");
            _buttonNames.Add("Easy");
            _buttonNames.Add("Normal");
            _buttonNames.Add("Hard");
            _buttonNames.Add("Lunatic");
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
            Button("Demo").Select();
        }

        /// <summary>
        /// Processes game screen events.
        /// </summary>
        public override void ProvessEvents()
        {
            //Process user input.
            if (SwinGame.KeyTyped(Settings.DOWN))
            {
                if (Button("Demo").Selected)
                {
                    Button("Easy").Select();
                    Button("Demo").Deselect();
                }
                else if (Button("Easy").Selected)
                {
                    Button("Normal").Select();
                    Button("Easy").Deselect();
                }
                else if (Button("Normal").Selected)
                {
                    Button("Hard").Select();
                    Button("Normal").Deselect();
                }
                else if (Button("Hard").Selected)
                {
                    Button("Lunatic").Select();
                    Button("Hard").Deselect();
                }
                else if (Button("Lunatic").Selected)
                {
                    Button("Quit").Select();
                    Button("Lunatic").Deselect();
                }
            }

            if (SwinGame.KeyTyped(Settings.UP))
            {
                if (Button("Easy").Selected)
                {
                    Button("Demo").Select();
                    Button("Easy").Deselect();
                }
                else if (Button("Normal").Selected)
                {
                    Button("Easy").Select();
                    Button("Normal").Deselect();
                }
                else if (Button("Hard").Selected)
                {
                    Button("Normal").Select();
                    Button("Hard").Deselect();
                }
                else if (Button("Lunatic").Selected)
                {
                    Button("Hard").Select();
                    Button("Lunatic").Deselect();
                }
                else if (Button("Quit").Selected)
                {
                    Button("Lunatic").Select();
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
                if (Button("Demo").Selected)
                {
                    Settings.GAMEMODE = 0;
                    ScreenControler.SetScreen("TestLevel");
                    GameObjects.GameScreen("ModeSelect").Reset();
                }
                else if (Button("Easy").Selected)
                {
                    Settings.GAMEMODE = 1;
                    ScreenControler.SetScreen("PlayerSelect");
                    GameObjects.GameScreen("ModeSelect").Reset();
                }
                else if (Button("Normal").Selected)
                {
                    Settings.GAMEMODE = 2;
                    ScreenControler.SetScreen("PlayerSelect");
                    GameObjects.GameScreen("ModeSelect").Reset();
                }
                else if (Button("Hard").Selected)
                {
                    Settings.GAMEMODE = 3;
                    ScreenControler.SetScreen("PlayerSelect");
                    GameObjects.GameScreen("ModeSelect").Reset();
                }
                else if (Button("Lunatic").Selected)
                {
                    Settings.GAMEMODE = 4;
                    ScreenControler.SetScreen("PlayerSelect");
                    GameObjects.GameScreen("ModeSelect").Reset();
                }
                else if (Button("Quit").Selected)
                {
                    ScreenControler.SetScreen("StartupMenu");
                    GameObjects.GameScreen("ModeSelect").Reset();
                }
            }
        }
    }
}