using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealMechanismCS
{
    /// <summary>
    /// GameObjects, Static Class, Stores the game objects
    /// </summary>
    public static class GameObjects
    {
        //attributes
        public static PlayerEntity Player;

        public static List<ItemEntity> Items = new List<ItemEntity>();

        //methods
        /// <summary>
        /// AddItem, method, adds the item to the Items list.
        /// </summary>
        /// <param name="item">Item to add.</param>
        public static void AddItem(ItemEntity item)
        {
            Items.Add(item);
        }

        /// <summary>
        /// RemoveItem, method, removes the item from the Items list.
        /// </summary>
        /// <param name="item">the item to remove</param>
        public static void RemoveItem(ItemEntity item)
        {
            Items.Remove(item);
        }
    }
}
