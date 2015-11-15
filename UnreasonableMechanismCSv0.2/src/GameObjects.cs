using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace UnrealMechanismCS
{
    public static class GameObjects
    {
        private static PlayerEntity _player;
        private static List<ItemEntity> _items = new List<ItemEntity>();
        private static List<BulletEntity> _bullets = new List<BulletEntity>();

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

        public static void ProcessEvents()
        {
            ProcessItems();
            ProcessBullets();
            ProcessPlayer();

            SwinGame.DrawBitmap(GameResources.GameImage("GameArea"), 0, 0);
            SwinGame.DrawText("Score: " + GameScores.Score, Color.Black, 540, 40);
            SwinGame.DrawText("Lives: " + GameScores.Player, Color.Black, 540, 60);
            SwinGame.DrawText("Bombs: " + GameScores.Bomb, Color.Black, 540, 80);
            SwinGame.DrawText("Power: " + GameScores.Power, Color.Black, 540, 120);
            SwinGame.DrawText("Graze: " + GameScores.Graze, Color.Black, 540, 140);
            SwinGame.DrawText("Bonus: " + GameScores.Bonus, Color.Black, 540, 160);
            SwinGame.DrawText("Player HP: " + _player.Hitpoints, Color.Black, 540, 180);
        }
        
        /// <summary>
        /// ProcessItems Method, processes the item entities.
        /// </summary>
        public static void ProcessItems()
        {
            foreach(ItemEntity item in _items)
            {
                item.ProcessEvents();
            }

            for (int i = 0; i < _items.Count; ++i)
            {
                if (_items[i].Y  > 580.0 || _items[i].Hitpoints == 0)
                {
                    //_items.Remove(_items[i]);
                }
            }
        }

        /// <summary>
        /// ProcessBullets Method, processes the bullet entities.
        /// Should follow the arrangement, clear illegal bullets, move bullets, draw bullets
        /// </summary>
        public static void ProcessBullets()
        {
            foreach (BulletEntity bullet in _bullets)
            {
                bullet.ProcessEvents();
            }

            for (int i = 0; i < _bullets.Count; ++i)
            {
                if (_bullets[i].Y < 0 || _bullets[i].Hitpoints == 0)
                {
                    //_bullets.Remove(_bullets[i]);
                }
            }
        }

        public static void ProcessPlayer()
        {
            _player.ProcessEvents();

            if (_player.Hitpoints == 0)
            {
                Point2D pnt = new Point2D(270, 430);
                GameScores.Player -= 1;

                _player.Position = pnt;

                Point2D[] point = new Point2D[]
                {
                    new Point2D(-2,-6),
                    new Point2D(0, 0)
                };

                for (int i = 0; i < _player.Hitboxes.Count; ++i)
                {
                    _player.Hitboxes[i].Offset(pnt);
                }
            }
            _player.Hitpoints = 1;
        }

        /// <summary>
        /// Initalise GameObjects
        /// </summary>
        public static void Initalise()
        {
            _player = new PlayerEntity(PlayerType.NarrowA);
        }

        public static void AddItem(ItemEntity obj)
        {
            _items.Add(obj);
        }

        public static void RemoveItem(ItemEntity obj)
        {
            _items.Remove(obj);
        }

        public static void RemoveItem(int index)
        {
            _items.RemoveAt(index);
        }

        public static void AddBullet(BulletEntity obj)
        {
            _bullets.Add(obj);
        }

        public static void RemoveBullet(BulletEntity obj)
        {
            _bullets.Remove(obj);
        }

        public static void RemoveBullet(int index)
        {
            _bullets.RemoveAt(index);
        }
    }
}