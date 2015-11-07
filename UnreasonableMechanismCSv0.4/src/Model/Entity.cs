using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UM = UnreasonableMechanismEngineCS;
using UnreasonableMechanismEngineCS;

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
        private int _tick;

        /// <summary>
        /// Constructs the entity with the provided hitbox, hitpoints and bitmap.
        /// </summary>
        /// <param name="hitbox">Hitbox (polygon).</param>
        /// <param name="hitpoints">Hitpoints (int).</param>
        /// <param name="bitmap">Bitmap name (string).</param>
        public Entity(Polygon hitbox, int hitpoints, string bitmap)
        {
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
    }
}