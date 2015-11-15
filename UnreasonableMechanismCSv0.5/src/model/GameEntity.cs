using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnreasonableMechanismEngineCS;

namespace UnreasonableMechanismCS
{
    /// <summary>
    /// GameEntity is a Child Class of GameObject defining Game Objects with Collision Dectection.
    /// </summary>
    public class GameEntity : GameObject
    {
        private Polygon _hitbox;
        private int _hitpoints;
        private bool _remove;

        /// <summary>
        /// Constructs empty GameEntity.
        /// </summary>
        public GameEntity()
        { }

        /// <summary>
        /// Constructs GameEntity using given hitbox.
        /// </summary>
        /// <param name="hitbox"></param>
        public GameEntity(Polygon hitbox) : this(hitbox.Middle, hitbox, 1)
        { }

        /// <summary>
        /// Constructs GameEntity using given position, hitbox and hitpoints.
        /// </summary>
        /// <param name="position">Position of entity</param>
        /// <param name="hitbox">Hitbox.</param>
        /// <param name="hitpoints">Hitpoints.</param>

        public GameEntity(Point position, Polygon hitbox, int hitpoints) : base(position)
        {
            _hitbox = hitbox;
            _hitpoints = hitpoints;
            _remove = false;
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}