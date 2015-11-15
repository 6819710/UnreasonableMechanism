using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace UnrealMechanismCS
{
    public class HomingBulletEntity : BulletEntity
    {
        //attributes
        private Entity _target;

        //constructor
        public HomingBulletEntity(double x, double y, double direction, double drawDirection, Colours colour, BulletType bulletType, Entity target) : base(x, y, direction, drawDirection, colour, bulletType)
        {
            _target = target;
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
        /// ProcessMovement, overide method, determines bullet movement.
        /// </summary>
        public override void ProcessMovement()
        {
            Movement.Step();

            SetDirection();

            X += Movement.DeltaX;
            Y += Movement.DeltaY;

            foreach (HitBox hitBox in HitBoxes)
            {
                hitBox.X += Movement.DeltaX;
                hitBox.Y += Movement.DeltaY;
            }
        }

        public void SetDirection()
        {
            double targetDirection = GameTools.CleanAngle(Math.Atan2((Y - _target.Y) * -1, (X - _target.X) * -1) * (180 / Math.PI));
            //double targetDirection = GameTools.CleanDirection(Math.Atan2((Y - SwinGame.MouseY()) * -1, (X - SwinGame.MouseX()) * -1) * (180 / Math.PI));
            double currentDirection = GameTools.CleanAngle(Movement.Direction);
            double deltaDirection = Movement.Delta;

            if(GameTools.GetDifferenceBetweenAngles(currentDirection, targetDirection) > 0)
            {
                Movement.Direction += deltaDirection;
            }
            else if(GameTools.GetDifferenceBetweenAngles(currentDirection, targetDirection) < 0)
            {
                Movement.Direction -= deltaDirection;
            }
        }

        //properties
        /// <summary>
        /// Target, property.
        /// </summary>
        public Entity Target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
            }
        }
    }
}
