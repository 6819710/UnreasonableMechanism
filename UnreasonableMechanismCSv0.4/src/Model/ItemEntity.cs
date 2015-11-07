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

        public ItemEntity(Point position, ItemType itemType) : base (position, InitBounding(position, itemType), 1, "Item" + itemType.ToString() )
        {
            _itemType = itemType;
        }
    }
}