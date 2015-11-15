using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace UnrealMechanismCS
{
    /// <summary>
    /// ItemEntity Class, defines items.
    /// </summary>
    public class ItemEntity : Entity
    {
        private ItemType _itemType;
        private VectorMovement _flagMovement;
        private GravitationalMovement _movement;
        private bool _flag;

        /// <summary>
        /// ItemEntity Constructor, initalises item.
        /// </summary>
        /// <param name="point"></param>
        /// <param name="itemType"></param>
        public ItemEntity(Point2D point, ItemType itemType) : base(point, InitaliseBounding(point, itemType), 1, "Item" + itemType.ToString())
        {
            _itemType = itemType;

            _movement = new GravitationalMovement(new Velocity2D(-3.0, 90.0), new Acceleration2D(new Vector2D(0, 0.1), 1.8));
            _flagMovement = new VectorMovement(new Velocity2D(5.0, 90.0));

            _flag = _itemType == UnrealMechanismCS.ItemType.Star;
        }

        /// <summary>
        /// ItemType Read-only Property, returns the item type.
        /// </summary>
        public ItemType ItemType
        {
            get
            {
                return _itemType;
            }
        }

        /// <summary>
        /// Flag Property, accessor for flag attribute.
        /// </summary>
        public bool Flag
        {
            get
            {
                return _flag;
            }
            set
            {
                _flag = value;
            }
        }

        /// <summary>
        /// Process Events Method, processes item events.
        /// </summary>
        public override void ProcessEvents()
        {
            ProcessMovement();

            DrawEntity();

            Tick++;
        }

        /// <summary>
        /// ProcessMovement Method, steps items through their movement patterns
        /// </summary>
        public override void ProcessMovement()
        {
            switch(_flag)
            {
                case true:
                    _flagMovement.Step();

                    _flagMovement.SetDirection(GameObjects.Player.Position, this.Position);

                    X += _flagMovement.DeltaX;
                    Y += _flagMovement.DeltaY;

                    foreach (Bounding hitBox in Hitboxes)
                    {
                        hitBox.Offset(_flagMovement.Delta);
                    }
                    break;

                case false:
                    _movement.Step();

                    X += _movement.DeltaX;
                    Y += _movement.DeltaY;

                    foreach (Bounding hitBox in Hitboxes)
                    {
                        hitBox.Offset(_movement.Delta);
                    }
                    break;
            }
        }

        /// <summary>
        /// DrawEntity Method, draws the item.
        /// </summary>
        public override void DrawEntity()
        {
            float x = (float)X - (GameResources.GameImage(Bitmap).Width / 2);
            float y = (float)Y - (GameResources.GameImage(Bitmap).Height / 2);

            if (Y < 20 - GameResources.GameImage(Bitmap).Height / 2)
            {
                SwinGame.DrawBitmap(GameResources.GameImage("Above" + Bitmap), x, 20);
            }
            else
            {
                SwinGame.DrawBitmap(GameResources.GameImage(Bitmap), x, y);
            }
        }

        public static List<Bounding> InitaliseBounding(Point2D point, ItemType itemType)
        {
            List<Bounding> result = new List<Bounding>();

            result.Add(new Bounding(new Point2D[]
            {
                new Point2D(point.X + GameResources.GameImage("Item" + itemType.ToString()).Width,point.Y - GameResources.GameImage("Item" + itemType.ToString()).Height),
                new Point2D(point.X - GameResources.GameImage("Item" + itemType.ToString()).Width,point.Y - GameResources.GameImage("Item" + itemType.ToString()).Height),
                new Point2D(point.X - GameResources.GameImage("Item" + itemType.ToString()).Width,point.Y + GameResources.GameImage("Item" + itemType.ToString()).Height),
                new Point2D(point.X + GameResources.GameImage("Item" + itemType.ToString()).Width,point.Y + GameResources.GameImage("Item" + itemType.ToString()).Height)
            }));

            return result;
        }
    }
}