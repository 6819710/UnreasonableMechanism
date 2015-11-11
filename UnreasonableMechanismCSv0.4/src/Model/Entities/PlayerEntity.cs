using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;
using UnreasonableMechanismEngineCS;

using Vector = UnreasonableMechanismEngineCS.Vector;
using Colour = SwinGameSDK.Color;


namespace UnreasonableMechanismCS
{
    /// <summary>
    /// Defines the player charicter
    /// </summary>
    public class PlayerEntity : Entity
    {
        private PlayerType _playerType;
        private Polygon _grazebox;

        private int _cannonMain;
        private int _cannonAux;

        /// <summary>
        /// Constructs a new player in the defult position.
        /// </summary>
        /// <param name="playerType">Type of player selected.</param>
        public PlayerEntity(PlayerType playerType) : base("Player" + playerType.ToString(), InitBounding(new Point(270, 430), playerType), 1)
        {
            _playerType = playerType;
            _grazebox = InitGrazeBox(Hitbox.Centroid, playerType);

            _cannonAux = 0;
            _cannonMain = 0;
        }

        /// <summary>
        /// Property: Grazebox.
        /// </summary>
        public Polygon Grazebox
        {
            get
            {
                return _grazebox;
            }

            set
            {
                _grazebox = value;
            }
        }

        private void Cannon()
        {
            switch(_playerType)
            {
                case PlayerType.NarrowA:
                    switch(_cannonMain)
                    {
                        case 0:
                            if(Tick % 6 == 0)
                            {
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Blue, BulletType.Seed, this, Hitbox.Middle, new Vector(Math.Cos(BasicMath.ToRad(-90)) * 6, Math.Sin(BasicMath.ToRad(-90)) * 6)));
                            }
                            break;
                        case 1:
                            if (Tick % 6 == 0)
                            {
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Blue, BulletType.Seed, this, Hitbox.Middle, new Vector(Math.Cos(BasicMath.ToRad(-92)) * 6, Math.Sin(BasicMath.ToRad(-92)) * 6)));
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Blue, BulletType.Seed, this, Hitbox.Middle, new Vector(Math.Cos(BasicMath.ToRad(-88)) * 6, Math.Sin(BasicMath.ToRad(-88)) * 6)));
                            }
                            break;
                        case 2:
                            if (Tick % 6 == 0)
                            {
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Turquoise, BulletType.Seed, this, Hitbox.Middle, new Vector(Math.Cos(BasicMath.ToRad(-94)) * 6, Math.Sin(BasicMath.ToRad(-94)) * 6)));
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Blue, BulletType.Seed, this, Hitbox.Middle, new Vector(Math.Cos(BasicMath.ToRad(-90)) * 6, Math.Sin(BasicMath.ToRad(-90)) * 6)));
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Turquoise, BulletType.Seed, this, Hitbox.Middle, new Vector(Math.Cos(BasicMath.ToRad(-86)) * 6, Math.Sin(BasicMath.ToRad(-86)) * 6)));
                            }
                            break;
                        case 3:
                            if (Tick % 6 == 0)
                            {
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Green, BulletType.Seed, this, Hitbox.Middle, new Vector(Math.Cos(BasicMath.ToRad(-98)) * 6, Math.Sin(BasicMath.ToRad(-98)) * 6)));
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Turquoise, BulletType.Seed, this, Hitbox.Middle, new Vector(Math.Cos(BasicMath.ToRad(-94)) * 6, Math.Sin(BasicMath.ToRad(-94)) * 6)));
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Blue, BulletType.Seed, this, Hitbox.Middle, new Vector(Math.Cos(BasicMath.ToRad(-90)) * 6, Math.Sin(BasicMath.ToRad(-90)) * 6)));
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Turquoise, BulletType.Seed, this, Hitbox.Middle, new Vector(Math.Cos(BasicMath.ToRad(-86)) * 6, Math.Sin(BasicMath.ToRad(-86)) * 6)));
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Green, BulletType.Seed, this, Hitbox.Middle, new Vector(Math.Cos(BasicMath.ToRad(-82)) * 6, Math.Sin(BasicMath.ToRad(-82)) * 6)));
                            }
                            break;
                    }
                    switch (_cannonAux)
                    {
                        case 1:
                            if (Tick % 24 == 0)
                            {
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Purple, BulletType.Star, this, new Point(Hitbox.Middle.X + 32, Hitbox.Middle.Y), new Vector(Math.Cos(BasicMath.ToRad(-90)) * 4, Math.Sin(BasicMath.ToRad(-90)) * 4)));
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Purple, BulletType.Star, this, new Point(Hitbox.Middle.X - 32, Hitbox.Middle.Y), new Vector(Math.Cos(BasicMath.ToRad(-90)) * 4, Math.Sin(BasicMath.ToRad(-90)) * 4)));
                            }
                            break;
                        case 2:
                            if (Tick % 36 == 0)
                            {
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Purple, BulletType.Star, this, new Point(Hitbox.Middle.X + 32, Hitbox.Middle.Y), new Vector(Math.Cos(BasicMath.ToRad(-90)) * 4, Math.Sin(BasicMath.ToRad(-90)) * 4)));
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Purple, BulletType.Star, this, new Point(Hitbox.Middle.X - 32, Hitbox.Middle.Y), new Vector(Math.Cos(BasicMath.ToRad(-90)) * 4, Math.Sin(BasicMath.ToRad(-90)) * 4)));
                            }
                            if ((Tick + 18) % 36 == 0)
                            {
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Red, BulletType.Star, this, new Point(Hitbox.Middle.X + 28, Hitbox.Middle.Y), new Vector(Math.Cos(BasicMath.ToRad(-90)) * 4, Math.Sin(BasicMath.ToRad(-90)) * 4)));
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Red, BulletType.Star, this, new Point(Hitbox.Middle.X - 28, Hitbox.Middle.Y), new Vector(Math.Cos(BasicMath.ToRad(-90)) * 4, Math.Sin(BasicMath.ToRad(-90)) * 4)));
                            }
                            break;
                        case 3:
                            if (Tick % 24 == 0)
                            {
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Purple, BulletType.Star, this, new Point(Hitbox.Middle.X + 32, Hitbox.Middle.Y), new Vector(Math.Cos(BasicMath.ToRad(-90)) * 4, Math.Sin(BasicMath.ToRad(-90)) * 4)));
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Purple, BulletType.Star, this, new Point(Hitbox.Middle.X - 32, Hitbox.Middle.Y), new Vector(Math.Cos(BasicMath.ToRad(-90)) * 4, Math.Sin(BasicMath.ToRad(-90)) * 4)));
                            }
                            if ((Tick + 12) % 24 == 0)
                            {
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Red, BulletType.Star, this, new Point(Hitbox.Middle.X + 28, Hitbox.Middle.Y), new Vector(Math.Cos(BasicMath.ToRad(-90)) * 4, Math.Sin(BasicMath.ToRad(-90)) * 4)));
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Red, BulletType.Star, this, new Point(Hitbox.Middle.X - 28, Hitbox.Middle.Y), new Vector(Math.Cos(BasicMath.ToRad(-90)) * 4, Math.Sin(BasicMath.ToRad(-90)) * 4)));
                            }
                            break;
                        case 4:
                            if (Tick % 24 == 0)
                            {
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Purple, BulletType.Star, this, new Point(Hitbox.Middle.X - 32, Hitbox.Middle.Y), new Vector(Math.Cos(BasicMath.ToRad(-92)) * 4, Math.Sin(BasicMath.ToRad(-92)) * 4)));
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Purple, BulletType.Star, this, new Point(Hitbox.Middle.X + 32, Hitbox.Middle.Y), new Vector(Math.Cos(BasicMath.ToRad(-88)) * 4, Math.Sin(BasicMath.ToRad(-88)) * 4)));
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Red, BulletType.Star, this, new Point(Hitbox.Middle.X + 32, Hitbox.Middle.Y), new Vector(Math.Cos(BasicMath.ToRad(-92)) * 4, Math.Sin(BasicMath.ToRad(-92)) * 4)));
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Red, BulletType.Star, this, new Point(Hitbox.Middle.X - 32, Hitbox.Middle.Y), new Vector(Math.Cos(BasicMath.ToRad(-88)) * 4, Math.Sin(BasicMath.ToRad(-88)) * 4)));
                            }
                            if ((Tick + 12) % 24 == 0)
                            {
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Red, BulletType.Star, this, new Point(Hitbox.Middle.X - 28, Hitbox.Middle.Y), new Vector(Math.Cos(BasicMath.ToRad(-92)) * 4, Math.Sin(BasicMath.ToRad(-92)) * 4)));
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Red, BulletType.Star, this, new Point(Hitbox.Middle.X + 28, Hitbox.Middle.Y), new Vector(Math.Cos(BasicMath.ToRad(-88)) * 4, Math.Sin(BasicMath.ToRad(-88)) * 4)));
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Purple, BulletType.Star, this, new Point(Hitbox.Middle.X + 28, Hitbox.Middle.Y), new Vector(Math.Cos(BasicMath.ToRad(-92)) * 4, Math.Sin(BasicMath.ToRad(-92)) * 4)));
                                GameObjects.AddBullet(new BulletEntity(BulletColour.Purple, BulletType.Star, this, new Point(Hitbox.Middle.X - 28, Hitbox.Middle.Y), new Vector(Math.Cos(BasicMath.ToRad(-88)) * 4, Math.Sin(BasicMath.ToRad(-88)) * 4)));
                            }
                            break;
                    }
                    break;
                case PlayerType.NarrowB:
                    switch (_cannonMain)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                    }
                    switch (_cannonAux)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                    }
                    break;
                case PlayerType.WideA:
                    switch (_cannonMain)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                    }
                    switch (_cannonAux)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                    }
                    break;
                case PlayerType.WideB:
                    switch (_cannonMain)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                    }
                    switch (_cannonAux)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                    }
                    break;
            }
        }

        /// <summary>
        /// Draws the player.
        /// </summary>
        public override void Draw()
        {
            base.Draw();

            if(Settings.SHOWHITBOX)
            {
                Colour clr = Colour.Orange;
                DrawGrazebox(clr);
            }
        }

        /// <summary>
        /// Draws player graze box.
        /// </summary>
        /// <param name="clr">Colour to draw graze box.</param>
        public void DrawGrazebox(Colour clr)
        {
            _grazebox.DrawEdge(clr);
        }

        private static Polygon InitBounding(Point position, PlayerType playerType)
        {
            Point[] vertices = new Point[]
            {
                new Point(0,0),
                new Point(3,0),
                new Point(5,2),
                new Point(6,2),
                new Point(8,0),
                new Point(11,0),
                new Point(11,3),
                new Point(10,4),
                new Point(11,5),
                new Point(11,10),
                new Point(8,13),
                new Point(9,14),
                new Point(9,15),
                new Point(7,17),
                new Point(4,17),
                new Point(2,15),
                new Point(2,14),
                new Point(3,13),
                new Point(0,10),
                new Point(0,5),
                new Point(1,4),
                new Point(0,3)
            };

            return new Polygon(vertices, new Point(270, 430));
        }

        private static Polygon InitGrazeBox(Point position, PlayerType playerType)
        {
            Point[] vertices = new Point[]
            {
                new Point(3,1),
                new Point(9,1),
                new Point(14,4),
                new Point(15,4),
                new Point(20,1),
                new Point(26,1),
                new Point(26,6),
                new Point(24,9),
                new Point(27,12),
                new Point(27,17),
                new Point(25,19),
                new Point(25,23),
                new Point(24,24),
                new Point(22,24),
                new Point(20,26),
                new Point(20,27),
                new Point(22,29),
                new Point(22,31),
                new Point(19,34),
                new Point(19,36),
                new Point(18,37),
                new Point(17,37),
                new Point(15,35),
                new Point(14,35),
                new Point(12,37),
                new Point(11,37),
                new Point(10,36),
                new Point(10,34),
                new Point(7,31),
                new Point(7,29),
                new Point(9,27),
                new Point(9,26),
                new Point(7,24),
                new Point(5,24),
                new Point(1,20),
                new Point(1,13),
                new Point(5,9),
                new Point(3,6)
            };

            return new Polygon(vertices, new Point(270, 430));
        }

        private void Level()
        {
            if(GameScores.POWER < 8)
            {
                _cannonMain = 0;
                _cannonAux = 0;
            }
            else if(GameScores.POWER < 16)
            {
                _cannonMain = 0;
                _cannonAux = 1;
            }
            else if(GameScores.POWER < 32)
            {
                _cannonMain = 0;
                _cannonAux = 2;
            }
            else if(GameScores.POWER < 48)
            {
                _cannonMain = 1;
                _cannonAux = 2;
            }
            else if(GameScores.POWER < 80)
            {
                _cannonMain = 1;
                _cannonAux = 3;
            }
            else if(GameScores.POWER < 96)
            {
                _cannonMain = 2;
                _cannonAux = 3;
            }
            else if(GameScores.POWER < 128)
            {
                _cannonMain = 2;
                _cannonAux = 4;
            }
            else if(GameScores.POWER == 128)
            {
                _cannonMain = 3;
                _cannonAux = 4;
            }
        }

        /// <summary>
        /// Offsets the player by the given movement.
        /// </summary>
        /// <param name="movement">Movement.</param>
        public override void Offset(Vector movement)
        {
            base.Offset(movement);
            _grazebox.Offset(movement);
        }

        public override void ProcessEvents()
        {
            ProcessMovement();

            Level();

            if(SwinGame.KeyDown(Settings.SHOOT))
            {
                Cannon();
            }

            Tick++;
        }

        public override void ProcessMovement()
        {
            InputController.ProcessPlayerMovement();
        }        
    }
}