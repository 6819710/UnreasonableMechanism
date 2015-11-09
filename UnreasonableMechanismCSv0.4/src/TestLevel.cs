using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UM = UnreasonableMechanismEngineCS;
using UnreasonableMechanismEngineCS;
using SwinGameSDK;

namespace UnreasonableMechanismCS
{
    public class TestLevel : Screen
    {
        private List<ItemType> _itemType;
        private Random _rand;
        private List<int> _trigger;

        public override void Initalise()
        {
            _itemType = new List<ItemType>(new ItemType[]
            {
                ItemType.BigPower,
                ItemType.Bomb,
                ItemType.FullPower,
                ItemType.Life,
                ItemType.Point,
                ItemType.Power,
                ItemType.Star
            });

            _rand = new Random();
            _trigger = new List<int>(new int[]
            {
                _rand.Next()%340 + 600,
                _rand.Next()%340 + 40,
                _rand.Next()%340 + 6000,
                _rand.Next()%340 + 60,
                _rand.Next()%140 + 40,
                _rand.Next()%140 + 20,
                _rand.Next()%140 + 40
            });
        }

        public override void ProvessEvents()
        {
            for (int i = 0; i < 7; ++i)
            {
                if (Tick % (_trigger[i]) == 0 && Tick > 0)
                {
                    GameObjects.AddItem(new ItemEntity(new Point(_rand.Next() % (460 - GameResources.GameImage("Item" + _itemType[i].ToString()).Width) + 40, 30), _itemType[i]));
                }
            }
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}