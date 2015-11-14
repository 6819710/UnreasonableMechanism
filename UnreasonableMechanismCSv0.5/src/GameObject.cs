using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnreasonableMechanismEngineCS;

namespace UnreasonableMechanismCS
{
    /// <summary>
    /// GameObject is an Abstract Class defining viewable Objects.
    /// </summary>
    public abstract class GameObject
    {
        private Point _position;

        /// <summary>
        /// Constructs Game Object in defult position.
        /// </summary>
        public GameObject()
        {
            _position = new Point(0, 0);
        }

        /// <summary>
        /// Constructs Game Object using given position.
        /// </summary>
        /// <param name="position">Position of Object.</param>
        public GameObject(Point position)
        {
            _position = position;
        }

        /// <summary>
        /// Constructs Game Object using given coordinates.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        public GameObject(double x, double y)
        {
            _position = new Point(x, y);
        }

        /// <summary>
        /// Readonly Property: Position of Game Object.
        /// </summary>
        public Point Position
        {
            get
            {
                return _position;
            }
        }

        /// <summary>
        /// Draws Game Object.
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// Offsets Game Object by given Movement Vector.
        /// </summary>
        /// <param name="movement">Movement Vector.</param>
        public virtual void Offset(Vector movement)
        {
            _position.Offset(movement);
        }
    }
}