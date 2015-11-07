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

        /// <summary>
        /// Constructs a new item entitiy.
        /// </summary>
        /// <param name="position">Position of the item (point).</param>
        /// <param name="itemType">Type of item (itemtype).</param>
        public ItemEntity(Point position, ItemType itemType) : base (position, InitBounding(position, itemType), 1, "Item" + itemType.ToString() )
        {
            _itemType = itemType;
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

        public override void DrawEntity()
        {
            base.DrawEntity();
        }

        public override void ProcessEvents()
        {
            throw new NotImplementedException();
        }

        public override void ProcessMovement()
        {
            throw new NotImplementedException();
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