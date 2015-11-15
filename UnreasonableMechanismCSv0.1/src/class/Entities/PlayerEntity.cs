using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace UnrealMechanismCS
{
    public class PlayerEntity : Entity
    {
        //attributes
        private PlayerType _playerType;

        private List<HitBox> _grazeBoxes = new List<HitBox>();

        private List<BulletEntity> _bullets = new List<BulletEntity>();

        private int _mainLevel;
        private int _auxLevel;

        private const double _delta = 2.0;

        //constructor
        /// <summary>
        /// PlayerEntity, constructor.
        /// </summary>
        public PlayerEntity(PlayerType playerType) : base(270.0, 430.0, new HitBox[] { new HitBox(270.0 - (GameResources.GameImage("Player").Width / 2.0), 430.0 - (GameResources.GameImage("Player").Height / 2.0), GameResources.GameImage("Player").Width / 2.0, GameResources.GameImage("Player").Height / 2.0)}, 1, "Player")
        {
            HitBox[] grazeBoxes = new HitBox[] { new HitBox(270.0 - (GameResources.GameImage("Player").Width / 2.0), 430.0 - (GameResources.GameImage("Player").Height / 2.0), GameResources.GameImage("Player").Width, GameResources.GameImage("Player").Height)};

            foreach(HitBox grazeBox in grazeBoxes)
            {
                _grazeBoxes.Add(grazeBox);
            }

            _mainLevel = 0;
            _auxLevel = 0;
        }

        //mehtods
        /// <summary>
        /// AddBullet, method, adds a bullet to the bullets list
        /// </summary>
        /// <param name="bullet">bullet to add</param>
        public void AddBullet(BulletEntity bullet)
        {
            _bullets.Add(bullet);
        }

        /// <summary>
        /// ProcessEvents, overide method.
        /// </summary>
        public override void ProcessEvents()
        {
            //process item collisions
            if (GameObjects.Items != null)
            {
                for (int i = 0; i < GameObjects.Items.Count; ++i)
                {
                    if (GameObjects.Items[i].Colides(this))
                    {
                        switch (GameObjects.Items[i].ItemType.ToString())
                        {
                            case "BigPower":
                                for (int j = 0; j < 5; ++j)
                                {
                                    GameScores.IncrementPower();
                                }
                                if (GameScores.Power < 128)
                                {
                                    GameScores.Score += GameScores.Points[0];
                                }
                                else
                                {
                                    GameScores.Score += GameScores.Points[GameScores.iterator];
                                    for (int k = 0; k < 8; ++k)
                                    {
                                        if (GameScores.iterator < 30)
                                        {
                                            GameScores.iterator++;
                                        }
                                    }
                                }
                                break;
                            case "Bomb":
                                GameScores.Bomb++;
                                break;
                            case "FullPower":
                                for (int l = 0; l < 128; ++l)
                                {
                                    GameScores.IncrementPower();
                                }
                                break;
                            case "Life":
                                GameScores.Player++;
                                break;
                            case "Point":
                                GameScores.Bonus++;
                                break;
                            case "Power":
                                GameScores.IncrementPower();
                                if (GameScores.Power < 128)
                                {
                                    GameScores.Score += GameScores.Points[0];
                                }
                                else
                                {
                                    GameScores.Score += GameScores.Points[GameScores.iterator];
                                    if(GameScores.iterator < 30)
                                    {
                                        GameScores.iterator++;
                                    }
                                }
                                break;
                            case "Star":
                                GameScores.Score += 500 + (10 * (GameScores.Graze / 3));
                                break;
                        }
                        GameObjects.RemoveItem(GameObjects.Items[i]);
                    }
                }
            }

            PowerLevel();

            if (SwinGame.KeyDown(GameKeys.SHOOT))
            {
                MainCannon();
                AuxCannon();
            }

            ProcessMovement();

            foreach(BulletEntity bullet in _bullets)
            {
                bullet.ProcessEvents();
            }

            for (int i = 0; i < _bullets.Count; ++i)
            {
                if (_bullets[i].Y < 0)
                {
                    _bullets.Remove(_bullets[i]);
                }
            }

            DrawEntity();

            if( _auxLevel > 0 )
            {
                SwinGame.DrawBitmap(GameResources.GameImage("YingYang" + (Tick % 64) / 8), (float)(X + 30) - (GameResources.GameImage("YingYang" + (Tick % 64) / 8).Width / 2), (float)Y - (GameResources.GameImage("YingYang" + (Tick % 64) / 8).Height / 2));
                SwinGame.DrawBitmap(GameResources.GameImage("YingYang" + (Tick % 64) / 8), (float)(X - 30) - (GameResources.GameImage("YingYang" + (Tick % 64) / 8).Width / 2), (float)Y - (GameResources.GameImage("YingYang" + (Tick % 64) / 8).Height / 2));
            }

            Tick++;
        }

        /// <summary>
        /// ProcessMovement, overide method, determines player movement.
        /// </summary>
        public override void ProcessMovement()
        {
            //left movement
            if (SwinGame.KeyDown(GameKeys.LEFT) && SwinGame.KeyDown(GameKeys.FOCUS))
            {
                if(X > 40.0 + GameResources.GameImage("Player").Width / 2.0)
                {
                    X -= _delta;

                    foreach (HitBox grazeBox in _grazeBoxes)
                    {
                        grazeBox.X -= _delta;
                    }

                    foreach (HitBox hitBox in HitBoxes)
                    {
                        hitBox.X -= _delta;
                    }

                    Bitmap = "PlayerLeft";
                }
            }
            else if(SwinGame.KeyDown(GameKeys.LEFT))
            {
                if (X > 40.0 + GameResources.GameImage("Player").Width / 2.0)
                {
                    X -= _delta * 2;

                    foreach (HitBox grazeBox in _grazeBoxes)
                    {
                        grazeBox.X -= _delta * 2;
                    }

                    foreach (HitBox hitBox in HitBoxes)
                    {
                        hitBox.X -= _delta * 2;
                    }

                    Bitmap = "PlayerLeft";
                }
            }
            //right movement
            else if (SwinGame.KeyDown(GameKeys.RIGHT) && SwinGame.KeyDown(GameKeys.FOCUS))
            {
                if (X < 500.0 - GameResources.GameImage("Player").Width / 2.0)
                {
                    X += _delta;

                    foreach (HitBox grazeBox in _grazeBoxes)
                    {
                        grazeBox.X += _delta;
                    }

                    foreach (HitBox hitBox in HitBoxes)
                    {
                        hitBox.X += _delta;
                    }

                    Bitmap = "PlayerRight";
                }
            }
            else if (SwinGame.KeyDown(GameKeys.RIGHT))
            {
                if (X < 500.0 - GameResources.GameImage("Player").Width / 2.0)
                {
                    X += _delta * 2;

                    foreach (HitBox grazeBox in _grazeBoxes)
                    {
                        grazeBox.X += _delta * 2;
                    }

                    foreach (HitBox hitBox in HitBoxes)
                    {
                        hitBox.X += _delta * 2;
                    }

                    Bitmap = "PlayerRight";
                }
            }
            else
            {
                Bitmap = "Player";
            }

            //up movement
            if (SwinGame.KeyDown(GameKeys.UP) && SwinGame.KeyDown(GameKeys.FOCUS))
            {
                if (Y > 20.0 + GameResources.GameImage("Player").Height / 2.0)
                {
                    Y -= _delta;

                    foreach (HitBox grazeBox in _grazeBoxes)
                    {
                        grazeBox.Y -= _delta;
                    }

                    foreach (HitBox hitBox in HitBoxes)
                    {
                        hitBox.Y -= _delta;
                    }
                }
            }
            else if (SwinGame.KeyDown(GameKeys.UP))
            {
                if (Y > 20.0 + GameResources.GameImage("Player").Height / 2.0)
                {
                    Y -= _delta * 2;

                    foreach (HitBox grazeBox in _grazeBoxes)
                    {
                        grazeBox.Y -= _delta * 2;
                    }

                    foreach (HitBox hitBox in HitBoxes)
                    {
                        hitBox.Y -= _delta * 2;
                    }
                }
            }

            //down movement
            if (SwinGame.KeyDown(GameKeys.DOWN) && SwinGame.KeyDown(GameKeys.FOCUS))
            {
                if (Y < 580.0 - GameResources.GameImage("Player").Height / 2.0)
                {
                    Y += _delta;

                    foreach (HitBox grazeBox in _grazeBoxes)
                    {
                        grazeBox.Y += _delta;
                    }

                    foreach (HitBox hitBox in HitBoxes)
                    {
                        hitBox.Y += _delta;
                    }
                }
            }
            else if (SwinGame.KeyDown(GameKeys.DOWN))
            {
                if (Y < 580.0 - GameResources.GameImage("Player").Height / 2.0)
                {
                    Y += _delta * 2;

                    foreach (HitBox grazeBox in _grazeBoxes)
                    {
                        grazeBox.Y += _delta * 2;
                    }

                    foreach (HitBox hitBox in HitBoxes)
                    {
                        hitBox.Y += _delta * 2;
                    }
                }
            }

            
        }

        protected void MainCannon()
        {
            switch(_mainLevel)
            {
                case 0:
                    if(Tick % 6 == 0)
                    {
                        AddBullet(new BulletEntity(X, Y, -90.0, -90.0, Colours.Blue, BulletType.Seed));
                    }
                    break;
                case 1:
                    if (Tick % 6 == 0)
                    {
                        AddBullet(new BulletEntity(X, Y, -92.0, -92.0, Colours.Blue, BulletType.Seed));
                        AddBullet(new BulletEntity(X, Y, -88.0, -88.0, Colours.Blue, BulletType.Seed));
                    }
                    break;
                case 2:
                    if (Tick % 6 == 0)
                    {
                        AddBullet(new BulletEntity(X, Y, -94.0, -94.0, Colours.Turquoise, BulletType.Seed));
                        AddBullet(new BulletEntity(X, Y, -90.0, -90.0, Colours.Blue, BulletType.Seed));
                        AddBullet(new BulletEntity(X, Y, -86.0, -86.0, Colours.Turquoise, BulletType.Seed));
                    }
                    break;
                case 3:
                    if (Tick % 6 == 0)
                    {
                        AddBullet(new BulletEntity(X, Y, -98.0, -98.0, Colours.Green, BulletType.Seed));
                        AddBullet(new BulletEntity(X, Y, -94.0, -94.0, Colours.Turquoise, BulletType.Seed));
                        AddBullet(new BulletEntity(X, Y, -90.0, -90.0, Colours.Blue, BulletType.Seed));
                        AddBullet(new BulletEntity(X, Y, -86.0, -86.0, Colours.Turquoise, BulletType.Seed));
                        AddBullet(new BulletEntity(X, Y, -82.0, -82.0, Colours.Green, BulletType.Seed));
                    }
                    break;
            }
        }

        protected void AuxCannon()
        {
            switch(_auxLevel)
            {
                case 1:
                    if(Tick % 24 == 0)
                    {
                        AddBullet(new BulletEntity(X + 32, Y, -90.0, -90.0, Colours.Purple, BulletType.Star));
                        AddBullet(new BulletEntity(X - 32, Y, -90.0, -90.0, Colours.Purple, BulletType.Star));
                    }
                    break;
                case 2:
                    if (Tick % 36 == 0)
                    {
                        AddBullet(new BulletEntity(X + 32, Y, -90.0, -90.0, Colours.Purple, BulletType.Star));
                        AddBullet(new BulletEntity(X - 32, Y, -90.0, -90.0, Colours.Purple, BulletType.Star));
                    }
                    if ((Tick + 18) % 36 == 0)
                    {
                        AddBullet(new BulletEntity(X + 28, Y, -90.0, -90.0, Colours.Red, BulletType.Star));
                        AddBullet(new BulletEntity(X - 28, Y, -90.0, -90.0, Colours.Red, BulletType.Star));
                    }
                    break;
                case 3:
                    if (Tick % 24 == 0)
                    {
                        AddBullet(new BulletEntity(X + 32, Y, -90.0, -90.0, Colours.Purple, BulletType.Star));
                        AddBullet(new BulletEntity(X - 32, Y, -90.0, -90.0, Colours.Purple, BulletType.Star));
                    }
                    if ((Tick + 12) % 24 == 0)
                    {
                        AddBullet(new BulletEntity(X + 28, Y, -90.0, -90.0, Colours.Red, BulletType.Star));
                        AddBullet(new BulletEntity(X - 28, Y, -90.0, -90.0, Colours.Red, BulletType.Star));
                    }
                    break;
                case 4:
                    if (Tick % 24 == 0)
                    {
                        AddBullet(new BulletEntity(X - 32, Y, -92.0, -92.0, Colours.Purple, BulletType.Star));
                        AddBullet(new BulletEntity(X + 32, Y, -88.0, -88.0, Colours.Purple, BulletType.Star));
                        AddBullet(new BulletEntity(X + 32, Y, -92.0, -92.0, Colours.Red, BulletType.Star));
                        AddBullet(new BulletEntity(X - 32, Y, -88.0, -88.0, Colours.Red, BulletType.Star));
                    }
                    if ((Tick + 12) % 24 == 0)
                    {
                        AddBullet(new BulletEntity(X - 28, Y, -92.0, -92.0, Colours.Purple, BulletType.Star));
                        AddBullet(new BulletEntity(X + 28, Y, -88.0, -88.0, Colours.Purple, BulletType.Star));
                        AddBullet(new BulletEntity(X + 28, Y, -92.0, -92.0, Colours.Red, BulletType.Star));
                        AddBullet(new BulletEntity(X - 28, Y, -88.0, -88.0, Colours.Red, BulletType.Star));
                    }
                    break;
            }
        }

        public void PowerLevel()
        {
            if(GameScores.Power < 8)
            {
                _mainLevel = 0;
                _auxLevel = 0;
            }
            else if(GameScores.Power < 16)
            {
                _mainLevel = 0;
                _auxLevel = 1;
            }
            else if (GameScores.Power < 32)
            {
                _mainLevel = 0;
                _auxLevel = 2;
            }
            else if (GameScores.Power < 48)
            {
                _mainLevel = 1;
                _auxLevel = 2;
            }
            else if (GameScores.Power < 80)
            {
                _mainLevel = 1;
                _auxLevel = 3;
            }
            else if (GameScores.Power < 96)
            {
                _mainLevel = 2;
                _auxLevel = 3;
            }
            else if (GameScores.Power < 128)
            {
                _mainLevel = 2;
                _auxLevel = 4;
            }
            else if (GameScores.Power == 128)
            {
                _mainLevel = 3;
                _auxLevel = 4;
            }
        }

        /// <summary>
        /// Collides, checks for colisions in all entity hitboxes against a given entity
        /// </summary>
        /// <param name="entity">Entity to check against</param>
        /// <returns>detected colisions</returns>
        public override bool Colides(Entity entity)
        {
            foreach (HitBox hitBoxA in _grazeBoxes)
            {
                foreach (HitBox hitBoxB in entity.HitBoxes)
                {
                    if (hitBoxA.Collides(hitBoxB))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //properties
    }
}
