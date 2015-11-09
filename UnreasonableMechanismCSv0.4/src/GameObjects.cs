using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnreasonableMechanismEngineCS;
using SwinGameSDK;

namespace UnreasonableMechanismCS
{
    public static class GameObjects
    {
        public static Entity Player;
        public static List<ItemEntity> Items = new List<ItemEntity>();

        /// <summary>
        /// Adds an item to the items list.
        /// </summary>
        /// <param name="obj">Object.</param>
        public static void AddItem(ItemEntity obj)
        {
            Items.Add(obj);
        }

        /// <summary>
        /// Draws all game items.
        /// </summary>
        public static void Draw()
        {
            Player.Draw();

            DrawItemEntities();
        }

        private static void DrawItemEntities()
        {
            foreach(ItemEntity item in Items)
            {
                item.Draw();
            }
        }

        public static void Initalise()
        {
            Player = new PlayerEntity(PlayerType.NarrowA);
        }

        /// <summary>
        /// Processes events for all game objects.
        /// </summary>
        public static void ProcessEvents()
        {
            if(Items.Count > 0)
            {
                ProcessItems();
            }
        }

        private static void ProcessItems()
        {
            foreach(ItemEntity item in Items)
            {
                item.ProcessEvents();
            }
        }

        /// <summary>
        /// Removes the provided item from the items list.
        /// </summary>
        /// <param name="obj">Object.</param>
        public static void RemoveItem(ItemEntity obj)
        {
            Items.Remove(obj);
        }

        /// <summary>
        /// Removes the item from the items list at the given index.
        /// </summary>
        /// <param name="index">Index of item.</param>
        public static void RemoveItem(int index)
        {
            Items.RemoveAt(index);
        }
    }
}
