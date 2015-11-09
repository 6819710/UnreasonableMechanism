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
        /// <param name="position">Position of the item (point).</param>
        /// <param name="itemType">Type of item (itemtype).</param>
        public ItemEntity(Point position, ItemType itemType) : base ("Item" + itemType.ToString(), InitBounding(position, itemType), 1)
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
        /// Draws the item entity.
        /// </summary>
        public override void DrawEntity()
        {
            if(Settings.SHOWHITBOX)
            {
                Colour colour = Colour.White;
                switch(_itemType)
                {
                    case ItemType.BigPower:
                        colour = Colour.Red;
                        break;

                    case ItemType.Bomb:
                        colour = Colour.Green;
                        break;

                    case ItemType.FullPower:
                        colour = Colour.Yellow;
                        break;

                    case ItemType.Life:
                        colour = Colour.MediumPurple;
                        break;

                    case ItemType.Point:
                        colour = Colour.Blue;
                        break;

                    case ItemType.Power:
                        colour = Colour.Red;
                        break;

                    case ItemType.Star:
                        colour = Colour.White;
                        break;
                }

                Hitbox.DrawEdge(colour);
                Hitbox.Center.Draw(colour);
            }
            else
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

        private static Polygon InitBounding(Point position, ItemType itemType)
        {
            double x = position.X;
            double y = position.Y;

            double width = GameResources.GameImage("Item" + itemType.ToString()).Width;
            double Height = GameResources.GameImage("Item" + itemType.ToString()).Height;

            Point[] vertices = new Point[]
            {
                new Point(x + width / 2, y - Height / 2),
                new Point(x - width / 2, y - Height / 2),
                new Point(x - width / 2, y + Height / 2),
                new Point(x + width / 2, y + Height / 2),
            };

            return new Polygon(vertices);
        }
    }
}