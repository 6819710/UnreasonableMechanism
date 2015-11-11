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

        private static List<BulletEntity> _bullets = new List<BulletEntity>();
        private static List<ItemEntity> _items = new List<ItemEntity>();

        /// <summary>
        /// Property: Bullets.
        /// </summary>
        public static List<BulletEntity> Bullets
        {
            get
            {
                return _bullets;
            }

            set
            {
                _bullets = value;
            }
        }

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

        public static void AddBullet(BulletEntity bullet)
        {
            _bullets.Add(bullet);
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
        /// Draws bullet objects.
        /// </summary>
        public static void DrawBullets()
        {
            foreach(BulletEntity bullet in _bullets)
            {
                bullet.Draw();
            }
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

        public static void Initalise()
        {
            _bullets.Clear();
            _items.Clear();
            _player = new PlayerEntity(PlayerType.NarrowA);
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
        /// Processes bullet events.
        /// </summary>
        public static void ProcessBulletEvents()
        {
            foreach(BulletEntity bullet in _bullets)
            {
                bullet.ProcessEvents();
            }

            for(int i = 0; i < _bullets.Count; i++)
            {
                if(_bullets[i].Remove)
                {
                    RemoveBullet(i);
                }
            }
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

            for(int i = 0; i < _items.Count; i++)
            {
                if(_items[i].Remove)
                {
                    RemoveItem(i);
                }
            }
        }

        /// <summary>
        /// Removes bullet from bullet list.
        /// </summary>
        /// <param name="bullet">Bullet to remove.</param>
        public static void RemoveBullet(BulletEntity bullet)
        {
            _bullets.Remove(bullet);
        }

        /// <summary>
        /// Removes bullet from bullet list at index.
        /// </summary>
        /// <param name="index">Index of bullet to remove.</param>
        public static void RemoveBullet(int index)
        {
            _bullets.RemoveAt(index);
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
