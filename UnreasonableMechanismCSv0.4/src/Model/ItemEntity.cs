using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;
using UnreasonableMechanismEngineCS;

using Vector = UnreasonableMechanismEngineCS.Vector;
using Colour = SwinGameSDK.Color;


namespace UnreasonableMechanismCS
{
    /// <summary>
    /// ItemEntity defines collectable items within the game.
    /// </summary>
    public class ItemEntity : Entity
    {
        private ItemType _itemType;
        private Movement _movement;
        private bool _flag;

        /// <summary>
        /// Constructs a new item entitiy.
        /// </summary>
        /// <param name="location">Position of the item (point).</param>
        /// <param name="itemType">Type of item (itemtype).</param>
        public ItemEntity(Point location, ItemType itemType) : base ("Item" + itemType.ToString(), InitBounding(location, itemType), 1)
        {
            _itemType = itemType;
            _flag = itemType == ItemType.Star;
            _movement = new Gravity(new Vector(0, -3), new Vector(0, 0.1), 1.8);
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
        /// Draws entity.
        /// </summary>
        public override void Draw()
        {
            if (Settings.SHOWHITBOX)
            {
                switch (_itemType)
                {
                    case ItemType.BigPower:
                        DrawHitbox(Colour.Red);
                        break;

                    case ItemType.Bomb:
                        DrawHitbox(Colour.Green);
                        break;

                    case ItemType.FullPower:
                        DrawHitbox(Colour.Yellow);
                        break;

                    case ItemType.Life:
                        DrawHitbox(Colour.MediumPurple);
                        break;

                    case ItemType.Point:
                        DrawHitbox(Colour.Blue);
                        break;

                    case ItemType.Power:
                        DrawHitbox(Colour.Red);
                        break;

                    case ItemType.Star:
                        DrawHitbox(Colour.White);
                        break;
                }
            }
            else
            {
                DrawEntity();
            }
        }

        /// <summary>
        /// Draws entity bitmap.
        /// </summary>
        public override void DrawEntity()
        {
            float x = (float)Hitbox.Center.X - (GameResources.GameImage(Bitmap).Width / 2);
            float y = (float)Hitbox.Center.Y - (GameResources.GameImage(Bitmap).Height / 2);

            if (Hitbox.Center.Y < 20 - GameResources.GameImage(Bitmap).Height / 2)
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
                Vector v = new Vector(GameObjects.Player.Hitbox.Center, Hitbox.Center);

                if(v.Magnitude > 5)
                {
                    v.Magnitude = 5;
                }

                _movement = new Linear(v);
            }

            _movement.step();
            Offset(_movement.Velocity);
        }

        private static Polygon InitBounding(Point location, ItemType itemType)
        {
            double width = GameResources.GameImage("Item" + itemType.ToString()).Width;
            double height = GameResources.GameImage("Item" + itemType.ToString()).Height;

            Point[] vertices = new Point[]
            {
                new Point(0, 0),
                new Point(width, 0),
                new Point(width, height),
                new Point(0, height),
            };

            return new Polygon(vertices, location);
        }
    }
}