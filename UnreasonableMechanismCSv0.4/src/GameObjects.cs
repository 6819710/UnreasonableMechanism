using System;
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

        private static List<ItemEntity> _items = new List<ItemEntity>();

        /// <summary>
        /// Property: Items.
        /// </summary>
        public static List<ItemEntity> Items
        {
            get
            {
                return _items;
            }

            set
            {
                _items = value;
            }
        }

        /// <summary>
        /// Property: Player.
        /// </summary>
        public static PlayerEntity Player
        {
            get
            {
                return _player;
            }

            set
            {
                _player = value;
            }
        }

        /// <summary>
        /// Adds item to item list.
        /// </summary>
        /// <param name="item">Item to add.</param>
        public static void AddItem(ItemEntity item)
        {
            _items.Add(item);
        }

        /// <summary>
        /// Draws item objects.
        /// </summary>
        public static void DrawItems()
        {
            foreach(ItemEntity item in _items)
            {
                item.Draw();
            }
        }

        /// <summary>
        /// Draws player object.
        /// </summary>
        public static void DrawPlayer()
        {
            _player.Draw();
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
            NewScreen("OptionsMenu", new OptionsMenu());
            NewScreen("ModeSelect", new ModeSelect());
            NewScreen("PlayerSelect", new PlayerSelect());
            NewScreen("TestLevel", new TestLevel());
            NewScreen("PauseMenu", new PauseMenu());

            GameScreen("StartupMenu").Initalise();
            GameScreen("OptionsMenu").Initalise();
            GameScreen("ModeSelect").Initalise();
            GameScreen("PlayerSelect").Initalise();
            GameScreen("TestLevel").Initalise();
            GameScreen("PauseMenu").Initalise();
        }

        private static void NewScreen(string screenName, Screen screen)
        {
            _screens.Add(screenName, screen);
        }

        /// <summary>
        /// Processes item events.
        /// </summary>
        public static void ProcessItemEvents()
        {
            foreach (ItemEntity item in _items)
            {
                item.ProcessEvents();
            }
        }

        /// <summary>
        /// Removes item from item list.
        /// </summary>
        /// <param name="item">Item to remove.</param>
        public static void RemoveItem(ItemEntity item)
        {
            _items.Remove(item);
        }

        /// <summary>
        /// Removes item from item list at index.
        /// </summary>
        /// <param name="index">Index of item to remove.</param>
        public static void RemoveItem(int index)
        {
            _items.RemoveAt(index);
        }
    }
}
