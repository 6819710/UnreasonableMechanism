using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace UnrealMechanismCS
{
    public class PlayerEntity : Entity
    {
        private PlayerType _playerType;

        private List<Bounding> _grazeboxes;

        private Movement _movementLeft;
        private Movement _movementRight;
        private Movement _movementDown;
        private Movement _movementUp;

        private int _cannonMain;
        private int _cannonAux;

        private const double _speed = 2.0;

        private uint _coolDown;

        public PlayerEntity(PlayerType playerType) : base(new Point2D(270, 430), InitaliseBounding(new Point2D(270, 430)), 1, "Player")
        {
            _grazeboxes = InitaliseBounding(new Point2D(270, 430));

            _cannonAux = 0;
            _cannonMain = 0;

            _coolDown = 0;

            _playerType = playerType;

            _movementLeft = new VectorMovement(new Velocity2D(2.0, 180));
            _movementRight = new VectorMovement(new Velocity2D(2.0, 0));
            _movementDown = new VectorMovement(new Velocity2D(2.0, 90));
            _movementUp = new VectorMovement(new Velocity2D(2.0, 270));
        }

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
                                    if (GameScores.iterator < 30)
                                    {
                                        GameScores.iterator++;
                                    }
                                }
                                break;
                            case "Star":
                                GameScores.Score += 500 + (10 * (GameScores.Graze / 3));
                                break;
                        }
                        GameObjects.Items[i].Hitpoints = 0;
                    }
                }
            }
            
            foreach(BulletEntity bullet in GameObjects.Bullets)
            {
                if(bullet.Owner != this && bullet.Colides(this))
                {
                    Hitpoints -= bullet.Hitpoints;
                    bullet.Hitpoints = 0;
                }
            }
            
            Level();

            if (SwinGame.KeyDown(GameKeys.SHOOT))
            {
                Cannon();
            }

            if (SwinGame.KeyDown(GameKeys.BOMB) && GameScores.Bomb > 0 && _coolDown == 0)
            {
                foreach(BulletEntity bullet in GameObjects.Bullets)
                {
                    if(bullet.Owner != this)
                    {
                        GameObjects.AddItem(new ItemEntity(bullet.Position, ItemType.Star));
                        bullet.Hitpoints = 0;
                    }
                }

                foreach(ItemEntity item in GameObjects.Items)
                {
                    item.Flag = true;
                }

                GameScores.Bomb--;
                _coolDown = 60;
            }

            if(Y < 160)
            {
                foreach (ItemEntity item in GameObjects.Items)
                {
                    item.Flag = true;
                }
            }

            ProcessMovement();

            DrawEntity();

            if (_cannonAux > 0)
            {
                SwinGame.DrawBitmap(GameResources.GameImage("YingYang" + (Tick % 64) / 8), (float)(X + 30) - (GameResources.GameImage("YingYang" + (Tick % 64) / 8).Width / 2), (float)Y - (GameResources.GameImage("YingYang" + (Tick % 64) / 8).Height / 2));
                SwinGame.DrawBitmap(GameResources.GameImage("YingYang" + (Tick % 64) / 8), (float)(X - 30) - (GameResources.GameImage("YingYang" + (Tick % 64) / 8).Width / 2), (float)Y - (GameResources.GameImage("YingYang" + (Tick % 64) / 8).Height / 2));
            }

            Tick++;

            if(_coolDown > 0)
            {
                _coolDown--;
            }
        }

        public override void ProcessMovement()
        {
            //left movement
            if (SwinGame.KeyDown(GameKeys.LEFT) && SwinGame.KeyDown(GameKeys.FOCUS))
            {
                if (X > 40.0 + GameResources.GameImage("Player").Width / 2.0)
                {
                    X -= _speed;

                    foreach (Bounding grazeBox in _grazeboxes)
                    {
                        grazeBox.Offset(_movementLeft.Delta);
                    }

                    foreach (Bounding hitBox in Hitboxes)
                    {
                        hitBox.Offset(_movementLeft.Delta);
                    }

                    Bitmap = "PlayerLeft";58
                }
            }
            else if (SwinGame.KeyDown(GameKeys.LEFT))
            {
                if (X > 40.0 + GameResources.GameImage("Player").Width / 2.0)
                {
                    X -= _speed * 2;

                    foreach (Bounding grazeBox in _grazeboxes)
                    {
                        grazeBox.Offset(_movementLeft.Delta);
                        grazeBox.Offset(_movementLeft.Delta);
                    }

                    foreach (Bounding hitBox in Hitboxes)
                    {
                        hitBox.Offset(_movementLeft.Delta);
                        hitBox.Offset(_movementLeft.Delta);
                    }

                    Bitmap = "PlayerLeft";
                }
            }
            //right movement
            else if (SwinGame.KeyDown(GameKeys.RIGHT) && SwinGame.KeyDown(GameKeys.FOCUS))
            {
                if (X < 500.0 - GameResources.GameImage("Player").Width / 2.0)
                {
                    X += _speed;

                    foreach (Bounding grazeBox in _grazeboxes)
                    {
                        grazeBox.Offset(_movementRight.Delta);
                    }

                    foreach (Bounding hitBox in Hitboxes)
                    {
                        hitBox.Offset(_movementRight.Delta);
                    }

                    Bitmap = "PlayerRight";
                }
            }
            else if (SwinGame.KeyDown(GameKeys.RIGHT))
            {
                if (X < 500.0 - GameResources.GameImage("Player").Width / 2.0)
                {
                    X += _speed * 2;

                    foreach (Bounding grazeBox in _grazeboxes)
                    {
                        grazeBox.Offset(_movementRight.Delta);
                        grazeBox.Offset(_movementRight.Delta);
                    }

                    foreach (Bounding hitBox in Hitboxes)
                    {
                        hitBox.Offset(_movementRight.Delta);
                        hitBox.Offset(_movementRight.Delta);
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
                    Y -= _speed;

                    foreach (Bounding grazeBox in _grazeboxes)
                    {
                        grazeBox.Offset(_movementUp.Delta);
                    }

                    foreach (Bounding hitBox in Hitboxes)
                    {
                        hitBox.Offset(_movementUp.Delta);
                    }
                }
            }
            else if (SwinGame.KeyDown(GameKeys.UP))
            {
                if (Y > 20.0 + GameResources.GameImage("Player").Height / 2.0)
                {
                    Y -= _speed * 2;

                    foreach (Bounding grazeBox in _grazeboxes)
                    {
                        grazeBox.Offset(_movementUp.Delta);
                        grazeBox.Offset(_movementUp.Delta);
                    }

                    foreach (Bounding hitBox in Hitboxes)
                    {
                        hitBox.Offset(_movementUp.Delta);
                        hitBox.Offset(_movementUp.Delta);
                    }
                }
            }

            //down movement
            if (SwinGame.KeyDown(GameKeys.DOWN) && SwinGame.KeyDown(GameKeys.FOCUS))
            {
                if (Y < 580.0 - GameResources.GameImage("Player").Height / 2.0)
                {
                    Y += _speed;

                    foreach (Bounding grazeBox in _grazeboxes)
                    {
                        grazeBox.Offset(_movementDown.Delta);
                    }

                    foreach (Bounding hitBox in Hitboxes)
                    {
                        hitBox.Offset(_movementDown.Delta);
                    }
                }
            }
            else if (SwinGame.KeyDown(GameKeys.DOWN))
            {
                if (Y < 580.0 - GameResources.GameImage("Player").Height / 2.0)
                {
                    Y += _speed * 2;

                    foreach (Bounding grazeBox in _grazeboxes)
                    {
                        grazeBox.Offset(_movementDown.Delta);
                        grazeBox.Offset(_movementDown.Delta);
                    }

                    foreach (Bounding hitBox in Hitboxes)
                    {
                        hitBox.Offset(_movementDown.Delta);
                        hitBox.Offset(_movementDown.Delta);
                    }
                }
            }
        }

        protected void Level()
        {
            if (GameScores.Power < 8)
            {
                _cannonMain = 0;
                _cannonAux = 0;
            }
            else if (GameScores.Power < 16)
            {
                _cannonMain = 0;
                _cannonAux = 1;
            }
            else if (GameScores.Power < 32)
            {
                _cannonMain = 0;
                _cannonAux = 2;
            }
            else if (GameScores.Power < 48)
            {
                _cannonMain = 1;
                _cannonAux = 2;
            }
            else if (GameScores.Power < 80)
            {
                _cannonMain = 1;
                _cannonAux = 3;
            }
            else if (GameScores.Power < 96)
            {
                _cannonMain = 2;
                _cannonAux = 3;
            }
            else if (GameScores.Power < 128)
            {
                _cannonMain = 2;
                _cannonAux = 4;
            }
            else if (GameScores.Power == 128)
            {
                _cannonMain = 3;
                _cannonAux = 4;
            }
        }

        public void Cannon()
        {
            switch (_playerType)
            {
                case PlayerType.NarrowA:
                    switch (_cannonMain)
                    {
                        case 0:
                            if (Tick % 6 == 0)
                            {
                                GameObjects.AddBullet(new BulletEntity(Position, new Velocity2D(8.0, -90.0), -90.0, BulletColour.Blue, BulletType.Seed, this));
                            }
                            break;
                        case 1:
                            if (Tick % 6 == 0)
                            {
                                GameObjects.AddBullet(new BulletEntity(Position, new Velocity2D(8.0, -92.0), -92.0, BulletColour.Blue, BulletType.Seed, this));
                                GameObjects.AddBullet(new BulletEntity(Position, new Velocity2D(8.0, -88.0), -88.0, BulletColour.Blue, BulletType.Seed, this));
                            }
                            break;
                        case 2:
                            if (Tick % 6 == 0)
                            {
                                GameObjects.AddBullet(new BulletEntity(Position, new Velocity2D(8.0, -94.0), -94.0, BulletColour.Turquoise, BulletType.Seed, this));
                                GameObjects.AddBullet(new BulletEntity(Position, new Velocity2D(8.0, -90.0), -90.0, BulletColour.Blue, BulletType.Seed, this));
                                GameObjects.AddBullet(new BulletEntity(Position, new Velocity2D(8.0, -86.0), -86.0, BulletColour.Turquoise, BulletType.Seed, this));
                            }
                            break;
                        case 3:
                            if (Tick % 6 == 0)
                            {
                                GameObjects.AddBullet(new BulletEntity(Position, new Velocity2D(8.0, -98.0), -98.0, BulletColour.Green, BulletType.Seed, this));
                                GameObjects.AddBullet(new BulletEntity(Position, new Velocity2D(8.0, -94.0), -94.0, BulletColour.Turquoise, BulletType.Seed, this));
                                GameObjects.AddBullet(new BulletEntity(Position, new Velocity2D(8.0, -90.0), -90.0, BulletColour.Blue, BulletType.Seed, this));
                                GameObjects.AddBullet(new BulletEntity(Position, new Velocity2D(8.0, -86.0), -86.0, BulletColour.Turquoise, BulletType.Seed, this));
                                GameObjects.AddBullet(new BulletEntity(Position, new Velocity2D(8.0, -82.0), -82.0, BulletColour.Green, BulletType.Seed, this));
                            }
                            break;
                    }
                    switch (_cannonAux)
                    {
                        case 1:
                            if (Tick % 24 == 0)
                            {
                                GameObjects.AddBullet(new BulletEntity(new Point2D(X + 32, Y), new Velocity2D(5.8, -90.0), -90.0, BulletColour.Purple, BulletType.Star, this));
                                GameObjects.AddBullet(new BulletEntity(new Point2D(X - 32, Y), new Velocity2D(5.8, -90.0), -90.0, BulletColour.Purple, BulletType.Star, this));
                            }
                            break;
                        case 2:
                            if (Tick % 36 == 0)
                            {
                                GameObjects.AddBullet(new BulletEntity(new Point2D(X + 32, Y), new Velocity2D(5.8, -90.0), -90.0, BulletColour.Purple, BulletType.Star, this));
                                GameObjects.AddBullet(new BulletEntity(new Point2D(X - 32, Y), new Velocity2D(5.8, -90.0), -90.0, BulletColour.Purple, BulletType.Star, this));
                            }
                            if ((Tick + 18) % 36 == 0)
                            {
                                GameObjects.AddBullet(new BulletEntity(new Point2D(X + 28, Y), new Velocity2D(5.8, -90.0), -90.0, BulletColour.Red, BulletType.Star, this));
                                GameObjects.AddBullet(new BulletEntity(new Point2D(X - 28, Y), new Velocity2D(5.8, -90.0), -90.0, BulletColour.Red, BulletType.Star, this));
                            }
                            break;
                        case 3:
                            if (Tick % 24 == 0)
                            {
                                GameObjects.AddBullet(new BulletEntity(new Point2D(X + 32, Y), new Velocity2D(5.8, -90.0), -90.0, BulletColour.Purple, BulletType.Star, this));
                                GameObjects.AddBullet(new BulletEntity(new Point2D(X - 32, Y), new Velocity2D(5.8, -90.0), -90.0, BulletColour.Purple, BulletType.Star, this));
                            }
                            if ((Tick + 12) % 24 == 0)
                            {
                                GameObjects.AddBullet(new BulletEntity(new Point2D(X + 28, Y), new Velocity2D(5.8, -90.0), -90.0, BulletColour.Red, BulletType.Star, this));
                                GameObjects.AddBullet(new BulletEntity(new Point2D(X - 28, Y), new Velocity2D(5.8, -90.0), -90.0, BulletColour.Red, BulletType.Star, this));
                            }
                            break;
                        case 4:
                            if (Tick % 24 == 0)
                            {
                                GameObjects.AddBullet(new BulletEntity(new Point2D(X - 32, Y), new Velocity2D(5.8, -92.0), -92.0, BulletColour.Purple, BulletType.Star, this));
                                GameObjects.AddBullet(new BulletEntity(new Point2D(X + 32, Y), new Velocity2D(5.8, -88.0), -88.0, BulletColour.Purple, BulletType.Star, this));
                                GameObjects.AddBullet(new BulletEntity(new Point2D(X + 32, Y), new Velocity2D(5.8, -92.0), -92.0, BulletColour.Red, BulletType.Star, this));
                                GameObjects.AddBullet(new BulletEntity(new Point2D(X - 32, Y), new Velocity2D(5.8, -88.0), -88.0, BulletColour.Red, BulletType.Star, this));
                            }
                            if ((Tick + 12) % 24 == 0)
                            {
                                GameObjects.AddBullet(new BulletEntity(new Point2D(X - 28, Y), new Velocity2D(5.8, -92.0), -92.0, BulletColour.Purple, BulletType.Star, this));
                                GameObjects.AddBullet(new BulletEntity(new Point2D(X + 28, Y), new Velocity2D(5.8, -88.0), -88.0, BulletColour.Purple, BulletType.Star, this));
                                GameObjects.AddBullet(new BulletEntity(new Point2D(X + 28, Y), new Velocity2D(5.8, -92.0), -92.0, BulletColour.Red, BulletType.Star, this));
                                GameObjects.AddBullet(new BulletEntity(new Point2D(X - 28, Y), new Velocity2D(5.8, -88.0), -88.0, BulletColour.Red, BulletType.Star, this));
                            }
                            break;
                    }
                    break;

                case PlayerType.NarrowB:
                    break;

                case PlayerType.WideA:
                    break;

                case PlayerType.WideB:
                    break;
            }
        }

        public static List<Bounding> InitaliseBounding(Point2D point)
        {
            List<Bounding> result = new List<Bounding>();

            result.Add(new Bounding(new Point2D[]
            {
                new Point2D(point.X + 2, point.Y - 2),
                new Point2D(point.X - 2, point.Y - 2),
                new Point2D(point.X - 2, point.Y + 2),
                new Point2D(point.X + 2, point.Y + 2)
            }));

            return result;
        }
    }
}