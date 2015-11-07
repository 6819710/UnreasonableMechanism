using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UM = UnreasonableMechanismEngineCS;
using UnreasonableMechanismEngineCS;
using SwinGameSDK;

namespace UnreasonableMechanismCS
{
    /// <summary>
    /// ItemEntities define all collectable items and powerups.
    /// </summary>
    public class ItemEntity : Entity
    {
        private ItemType _itemType;
        private Movement _movement;
        private bool _flag;

        /// <summary>
        /// Constructs a new item entitiy.
        /// </summary>
        /// <param name="position">Position of the item (point).</param>
        /// <param name="itemType">Type of item (itemtype).</param>
        public ItemEntity(Point position, ItemType itemType) : base (position, InitBounding(position, itemType), 1, "Item" + itemType.ToString() )
        {
            _itemType = itemType;
            _flag = itemType == ItemType.Star;
            _movement = new Gravity(new UM.Vector(0, -3), new UM.Vector(0, 0.1), 1.8);
        }

        /// <summary>
        /// Readonly Property: ItemType.
        /// </summary>
        public ItemType ItemType
        {
            get
            {
                return _itemType;
            }
        }

        /// <summary>
        /// Draws the item entity.
        /// </summary>
        public override void DrawEntity()
        {
            float x = (float)Position.X - (GameResources.GameImage(Bitmap).Width / 2);
            float y = (float)Position.Y - (GameResources.GameImage(Bitmap).Height / 2);

            if (Position.Y < 20 - GameResources.GameImage(Bitmap).Height / 2)
            {
                SwinGame.DrawBitmap(GameResources.GameImage("Above" + Bitmap), x, 20);
            }
            else
            {
                SwinGame.DrawBitmap(GameResources.GameImage(Bitmap), x, y);
            }
        }

        /// <summary>
        /// Processes entity events.
        /// </summary>
        public override void ProcessEvents()
        {
            ProcessMovement();
            DrawEntity();
        }

        /// <summary>
        /// Processes entity movement.
        /// </summary>
        public override void ProcessMovement()
        {
            if(_flag)
            {
                UM.Vector v = new UM.Vector(GameObjects.Player.Position, Position);

                if(v.Magnitude > 5)
                {
                    v.Magnitude = 5;
                }

                _movement = new Linear(v);
            }
            _movement.step();
            Offset(_movement.Velocity);
        }

        private static Polygon InitBounding(Point position, ItemType itemType)
        {
            double x = position.X;
            double y = position.Y;

            double width = GameResources.GameImage("Item" + itemType.ToString()).Width;
            double Height = GameResources.GameImage("Item" + itemType.ToString()).Height;

            Point[] vertices = new Point[]
            {
                new Point(x + width, y - Height),
                new Point(x - width, y - Height),
                new Point(x - width, y + Height),
                new Point(x + width, y + Height),
            };

            return new Polygon(vertices);
        }
    }
}