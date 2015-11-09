﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnreasonableMechanismEngineCS;
using SwinGameSDK;

using Colour = SwinGameSDK.Color;
using Vector = UnreasonableMechanismEngineCS.Vector;

namespace UnreasonableMechanismCS
{
    /// <summary>
    /// Game objects library.
    /// </summary>
    public static class GameObjects
    {
        private static Dictionary<string, Screen> _screens = new Dictionary<string, Screen>();
        private static PlayerEntity _player = new PlayerEntity(PlayerType.NarrowA);

        /// <summary>
        /// Readonly Property: Player.
        /// </summary>
        public static PlayerEntity Player
        {
            get
            {
                return _player;
            }
        }

        /// <summary>
        /// Loads game objects.
        /// </summary>
        public static void LoadGameOjects()
        {
            LoadGameScreens();
        }

        private static void LoadGameScreens()
        {
            NewScreen("StartupMenu", new StarupMenu());
        }

        /// <summary>
        /// Fetches named screen.
        /// </summary>
        /// <param name="screen">Screen to fetch.</param>
        /// <returns>Screen.</returns>
        public static Screen GameScreen(string screen)
        {
            return _screens[screen];
        }

        private static void NewScreen(string screenName, Screen screen)
        {
            _screens.Add(screenName, screen);
        }

    }
}
