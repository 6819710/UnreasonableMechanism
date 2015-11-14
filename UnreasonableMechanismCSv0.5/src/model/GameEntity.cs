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