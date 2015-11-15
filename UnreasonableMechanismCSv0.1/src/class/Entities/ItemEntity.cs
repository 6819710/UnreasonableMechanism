using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace UnrealMechanismCS
{
    /// <summary>
    /// ItemEntity Class
    /// </summary>
    public class ItemEntity : Entity
    {
        //attributes
        private ItemType _itemType;
        private GravitationalMovement _gravMovement;
        private VectorMovement _vectorMovement;

        //constructor
        /// <summary>
        /// ItemEntity, class contructor, passes entity data to base.
        /// </summary>
        /// <param name="x">X position of the item</param>
        /// <param name="y">Y position of the item</param>
        /// <param name="itemType">Type of item</param>
        public ItemEntity(double x, double y, ItemType itemType) : base(x, y, new HitBox[] { new HitBox(x - (GameResources.GameImage("Item" + itemType.ToString()).Width / 2.0), y - (GameResources.GameImage("Item" + itemType.ToString()).Height / 2), GameResources.GameImage("Item" + itemType.ToString()).Width, GameResources.GameImage("Item" + itemType.ToString()).Height)}, 1, "Item" + itemType.ToString())
        {
            _itemType = itemType;

            _vectorMovement = new VectorMovement(90.0, 5.0);
            _gravMovement = new GravitationalMovement(0.0, -3.0, 0.0, 0.1, 0.0, 1.8);
        }

        //methods
        /// <summary>
        /// ProcessEvents, overide method.
        /// </summary>
        public override void ProcessEvents()
        {
            ProcessMovement();

            DrawEntity();

            Tick++;
        }

        /// <summary>
        /// ProcessMovement, overide method, determines item movement.
        /// </summary>
        public override void ProcessMovement()
        {
            if(_itemType == ItemType.Star)
            {
                _vectorMovement.Step();

                _vectorMovement.SetDirection(GameObjects.Player.X, GameObjects.Player.Y, X, Y);

                X += _vectorMovement.DeltaX;
                Y += _vectorMovement.DeltaY;

                foreach (HitBox hitBox in HitBoxes)
                {
                    hitBox.X += _vectorMovement.DeltaX;
                    hitBox.Y += _vectorMovement.DeltaY;
                }
            }
            else
            {
                _gravMovement.Step();

                X += _gravMovement.DeltaX;
                Y += _gravMovement.DeltaY;

                foreach (HitBox hitBox in HitBoxes)
                {
                    hitBox.X += _gravMovement.DeltaX;
                    hitBox.Y += _gravMovement.DeltaY;
                }
            }
        }

        public override void DrawEntity()
        {
            float x = (float)X - (GameResources.GameImage(Bitmap).Width / 2);
            float y = (float)Y - (GameResources.GameImage(Bitmap).Height / 2);

            if (Y < 20 - GameResources.GameImage(Bitmap).Height / 2)
            {
                SwinGame.DrawBitmap(GameResources.GameImage("Above" + Bitmap), x, 20);
            }
            else
            {
                SwinGame.DrawBitmap(GameResources.GameImage(Bitmap), x, y);
            }

        }

//properties
/// <summary>
/// ItemType, readonly property
/// </summary>
public ItemType ItemType
        {
            get
            {
                return _itemType;
            }
        }
    }
}
