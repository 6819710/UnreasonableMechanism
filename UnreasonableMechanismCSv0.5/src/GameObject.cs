using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnreasonableMechanismEngineCS;
using SwinGameSDK;

using Vector = UnreasonableMechanismEngineCS.Vector;

namespace UnreasonableMechanismCS
{
    /// <summary>
    /// GameObject is an Abstract Class defining viewable Objects.
    /// </summary>
    public abstract class GameObject
    {
        private string _bitmap;
        private Point _position;

        /// <summary>
        /// Constructs Game Object in defualt position.
        /// </summary>
        public GameObject() : this(new Point(0,0), ""){}

        /// <summary>
        /// Construcst Game Object in default position using given bitmap name.
        /// </summary>
        /// <param name="bitmap">Bitmap name.</param>
        public GameObject(string bitmap) : this(new Point(0,0), bitmap){}

        /// <summary>
        /// Constructs Game Object using given position.
        /// </summary>
        /// <param name="position">Position of Object.</param>
        public GameObject(Point position) : this(position, ""){}

        /// <summary>
        /// Constructs Game Object using given coordinates.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        public GameObject(double x, double y) : this(new Point(x, y), ""){}

        /// <summary>
        /// Constructs Game Object using given coordinates and bitmap name.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="bitmap">Bitmap name.</param>
        public GameObject(double x, double y, string bitmap) : this(new Point(x, y), bitmap) { }

        /// <summary>
        /// Constructs Game Object using given point and bitmap name.
        /// </summary>
        /// <param name="position">Position of Object.</param>
        /// <param name="bitmap">Bitmap name.</param>
        public GameObject(Point position, string bitmap)
        {
            _position = position;
            _bitmap = bitmap;
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
        /// Draws Game Object Bitmap.
        /// </summary>
        public virtual void DrawBitmap()
        {
            //SwinGame.DrawBitmap(BITMAP, )
        }

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