using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UM = UnreasonableMechanismEngineCS;
using UnreasonableMechanismEngineCS;
using SwinGameSDK;

namespace UnreasonableMechanismCS
{
    /// <summary>
    /// Entities are the base abstract class for all collidable game objects.
    /// </summary>
    public abstract class Entity
    {
        private string _bitmap;
        private Polygon _hitbox;
        private int _hitpoints;
        private Point _position;
        private int _tick;

        /// <summary>
        /// Constructs the entity with the provided hitbox, hitpoints and bitmap.
        /// </summary>
        /// <param name="position">Position (point).</param>
        /// <param name="hitbox">Hitbox (polygon).</param>
        /// <param name="hitpoints">Hitpoints (int).</param>
        /// <param name="bitmap">Bitmap name (string).</param>
        public Entity(Point position, Polygon hitbox, int hitpoints, string bitmap)
        {
            _position = position;
            _hitbox = hitbox;
            _hitpoints = hitpoints;
            _bitmap = bitmap;
            _tick = 0;
        }

        /// <summary>
        /// Property: Bitmap name.
        /// </summary>
        public string Bitmap
        {
            get
            {
                return _bitmap;
            }

            set
            {
                _bitmap = value;
            }
        }

        /// <summary>
        /// Readonly Property: Hitbox.
        /// </summary>
        public Polygon Hitbox
        {
            get
            {
                return _hitbox;
            }
        }

        /// <summary>
        /// Property: Hitpoints.
        /// </summary>
        public int Hitpoints
        {
            get
            {
                return _hitpoints;
            }

            set
            {
                _hitpoints = value;
            }
        }

        /// <summary>
        /// Readonly Property: Position.
        /// </summary>
        public Point Position
        {
            get
            {
                return _position;
            }
        }

        /// <summary>
        /// Draws the game bitmap.
        /// </summary>
        public virtual void DrawEntity()
        {
            SwinGame.DrawBitmap(GameResources.GameImage(_bitmap), (float)_position.X - GameResources.GameImage(Bitmap).Width / 2, (float)_position.Y - GameResources.GameImage(Bitmap).Height / 2);
        }

        /// <summary>
        /// Processes entity events.
        /// </summary>
        public abstract void ProcessEvents();

        /// <summary>
        /// Processes entity movement.
        /// </summary>
        public abstract void ProcessMovement();

        /// <summary>
        /// Offsets the entity by the given movement vector.
        /// </summary>
        /// <param name="movement">Movement vector.</param>
        public void Offset(UM.Vector movement)
        {
            _hitbox.Offset(movement);
            _position.Offset(movement);
        }
    }
}