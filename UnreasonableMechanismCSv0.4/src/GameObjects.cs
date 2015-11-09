﻿using System;
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
        public static List<ItemEntity> Items = new List<ItemEntity>();
        public static PlayerEntity Player;
        public static Dictionary<string, Screen> Screens = new Dictionary<string, Screen>();

        /// <summary>
        /// Adds an item to the items list.
        /// </summary>
        /// <param name="obj">Object.</param>
        public static void AddItem(ItemEntity obj)
        {
            Items.Add(obj);
        }

        /// <summary>
        /// Adds a screen to the screens list.
        /// </summary>
        /// <param name="obj">Object.</param>
        public static void AddScreen(Screen obj)
        {
            Screens.Add(obj);
        }

        /// <summary>
        /// Draws all game items.
        /// </summary>
        public static void Draw()
        {
            DrawItemEntities();

            Player.Draw();
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

            Screens.Add("Test", new TestLevel());
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

            Player.ProcessEvents();
        }

        private static void ProcessItems()
        {
            foreach(ItemEntity item in Items)
            {
                item.ProcessEvents();
            }
        }

        /// <summary>
        /// Removes provided item from items list.
        /// </summary>
        /// <param name="obj">Object.</param>
        public static void RemoveItem(ItemEntity obj)
        {
            Items.Remove(obj);
        }

        /// <summary>
        /// Removes item from items list at given index.
        /// </summary>
        /// <param name="index">Index of item.</param>
        public static void RemoveItem(int index)
        {
            Items.RemoveAt(index);
        }
    }
}
