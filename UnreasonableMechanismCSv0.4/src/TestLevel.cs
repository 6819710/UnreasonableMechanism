using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UM = UnreasonableMechanismEngineCS;
using UnreasonableMechanismEngineCS;
using SwinGameSDK;

namespace UnreasonableMechanismCS
{
    public static class TestLevel
    {
        private static Random _rand = new Random();

        private static ItemType[] _items = new ItemType[]
            {
                    ItemType.BigPower,
                    ItemType.Bomb,
                    ItemType.FullPower,
                    ItemType.Life,
                    ItemType.Point,
                    ItemType.Power,
                    ItemType.Star
            };

        private static int[] _trigger = new int[]
        {
                    _rand.Next()%340 + 600,
                    _rand.Next()%340 + 40,
                    _rand.Next()%340 + 6000,
                    _rand.Next()%340 + 60,
                    _rand.Next()%140 + 40,
                    _rand.Next()%140 + 20,
                    _rand.Next()%140 + 40
        };

        public static void Step(uint tick)
        {
            for (int i = 0; i < 7; ++i)
            {
                if (tick % (_trigger[i]) == 0 && tick > 0)
                {
                    GameObjects.AddItem(new ItemEntity(new Point(_rand.Next() % (460 - GameResources.GameImage("Item" + _items[i].ToString()).Width) + 40, 50), _items[i]));
                }
            }
        }
    }
}