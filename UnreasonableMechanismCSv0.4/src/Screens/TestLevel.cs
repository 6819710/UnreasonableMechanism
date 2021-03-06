﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnreasonableMechanismEngineCS;
using SwinGameSDK;

using Colour = SwinGameSDK.Color;
using Vector = UnreasonableMechanismEngineCS.Vector;

namespace UnreasonableMechanismCS
{
    public class TestLevel : Screen
    {
        private Random _rand;
        
        private BulletColour[] _bulletColours;
        private BulletType[] _bulletTypes;
        private ItemType[] _itemTypes;
        private Vector[] _trajectories;

        private int[] _triggers;

        public TestLevel()
        {
            _rand = new Random();

            _bulletColours = new BulletColour[]
            {
                BulletColour.Black,
                BulletColour.Blue,
                BulletColour.Green,
                BulletColour.Purple,
                BulletColour.Red,
                BulletColour.Turquoise,
                BulletColour.White,
                BulletColour.Yellow
            };

            _bulletTypes = new BulletType[]
            {
                BulletType.Beam,
                BulletType.BigStar,
                BulletType.Crystal,
                BulletType.Dart,
                BulletType.HugeSphere,
                BulletType.LargeSphere,
                BulletType.Palse,
                BulletType.Ring,
                BulletType.Seed,
                BulletType.Shere,
                BulletType.SmallRing,
                BulletType.SmallSphere,
                BulletType.Star
            };

            _itemTypes = new ItemType[]
            {
                ItemType.BigPower,
                ItemType.Bomb,
                ItemType.FullPower,
                ItemType.Life,
                ItemType.Point,
                ItemType.Power,
                ItemType.Star
            };

            _trajectories = new Vector[]
            {
                new Vector(Math.Cos(BasicMath.ToRad(30)), Math.Sin(BasicMath.ToRad(30))),
                new Vector(Math.Cos(BasicMath.ToRad(60)), Math.Sin(BasicMath.ToRad(60))),
                new Vector(Math.Cos(BasicMath.ToRad(90)), Math.Sin(BasicMath.ToRad(90))),
                new Vector(Math.Cos(BasicMath.ToRad(120)), Math.Sin(BasicMath.ToRad(120))),
                new Vector(Math.Cos(BasicMath.ToRad(150)), Math.Sin(BasicMath.ToRad(150))),
                new Vector(Math.Cos(BasicMath.ToRad(180)), Math.Sin(BasicMath.ToRad(180))),
                new Vector(Math.Cos(BasicMath.ToRad(210)), Math.Sin(BasicMath.ToRad(210))),
                new Vector(Math.Cos(BasicMath.ToRad(240)), Math.Sin(BasicMath.ToRad(240))),
                new Vector(Math.Cos(BasicMath.ToRad(270)), Math.Sin(BasicMath.ToRad(270))),
                new Vector(Math.Cos(BasicMath.ToRad(300)), Math.Sin(BasicMath.ToRad(300))),
                new Vector(Math.Cos(BasicMath.ToRad(330)), Math.Sin(BasicMath.ToRad(330))),
                new Vector(Math.Cos(BasicMath.ToRad(360)), Math.Sin(BasicMath.ToRad(360)))
            };

            _triggers = new int[]
            {
                _rand.Next()%340 + 600,
                _rand.Next()%340 + 40,
                _rand.Next()%340 + 6000,
                _rand.Next()%340 + 60,
                _rand.Next()%140 + 40,
                _rand.Next()%140 + 20,
                _rand.Next()%140 + 40
            };
        }

        public override void Draw()
        {
            SwinGame.ClearScreen(Color.DarkSlateGray);

            GameObjects.DrawItems();
            GameObjects.DrawBullets();
            GameObjects.DrawPlayer();

            SwinGame.DrawBitmap(GameResources.GameImage("GameArea"), 0, 0);

            SwinGame.DrawText("Score: " + GameScores.SCORE, Color.Black, 540, 40);
            SwinGame.DrawText("Lives: " + GameScores.PLAYER, Color.Black, 540, 60);
            SwinGame.DrawText("Bombs: " + GameScores.BOMB, Color.Black, 540, 80);
            SwinGame.DrawText("Power: " + GameScores.POWER, Color.Black, 540, 120);
            SwinGame.DrawText("Graze: " + GameScores.GRAZE, Color.Black, 540, 140);
            SwinGame.DrawText("Bonus: " + GameScores.BONUS, Color.Black, 540, 160);
        }

        public override void Initalise()
        {
        }

        public override void ProvessEvents()
        {
            if(SwinGame.KeyTyped(Settings.PAUSE))
            {
                ScreenControler.SetScreen("PauseMenu");
            }

            for(int i = 0; i < 7; ++i)
            {
                if (Tick % (_triggers[i]) == 0)
                {
                    GameObjects.AddItem(new ItemEntity(new Point(_rand.Next() % (460 - GameResources.GameImage("Item" + _itemTypes[i].ToString()).Width) + 40, 50), _itemTypes[i]));
                }
            }

            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 13; j++)
                {
                    if(Tick % (_rand.Next() % 50000 + 30) == 0 && Tick > 0)
                    {
                        Point position = new Point(_rand.Next() % 460 + 40, _rand.Next() % 460 + 40);
                        for(int k = 0; k < 12; k++)
                        {
                            GameObjects.AddBullet(new BulletEntity(_bulletColours[i], _bulletTypes[j], null, position, _trajectories[k]));
                        }
                    }
                }
            }

            GameObjects.ProcessItemEvents();
            GameObjects.ProcessBulletEvents();
            GameObjects.Player.ProcessEvents();

            NextTick();
        }
    }
}