using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace UnrealMechanismCS
{
    public abstract class Entity
    {
        private string _bitmap;

        private List<Bounding> _hitboxes = new List<Bounding>();
        private Point2D _position;

        private bool flag;

        private uint _hitpoints;
        private uint _tick;

        private VectorMovement _movement;

        /// <summary>
        /// Entity Constructor, sets the inital values for entity details.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="hitboxes"></param>
        /// <param name="hitpoints"></param>
        /// <param name="point"></param>
        public Entity(Point2D point, List<Bounding> hitboxes, uint hitpoints, string bitmap)
        {
            _position = point;
            _hitboxes = hitboxes;
            _hitpoints = hitpoints;
            _bitmap = bitmap;

            Tick = 0;
        }

        /// <summary>
        /// Hitboxes Read-only Property, returns a list of hitboxes.
        /// </summary>
        public List<Bounding> Hitboxes
        {
            get
            {
                return _hitboxes;
            }
        }

        /// <summary>
        /// Tick Property, accessor for current entity tick.
        /// </summary>
        public uint Tick
        {
            get
            {
                return _tick;
            }

            set
            {
                _tick = value;
            }
        }

        /// <summary>
        /// X Property, accessor for current x position.
        /// </summary>
        public double X
        {
            get
            {
                return _position.X;
            }

            set
            {
                _position.X = value;
            }
        }

        /// <summary>
        /// Y Property, accessor for current y position.
        /// </summary>
        public double Y
        {
            get
            {
                return _position.Y;
            }

            set
            {
                _position.Y = value;
            }
        }

        /// <summary>
        /// Bitmap Property, accessor for name of the bitmap to use.
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
        /// Position Property, accessor for current position.
        /// </summary>
        public Point2D Position
        {
            get
            {
                return _position;
            }

            set
            {
                _position = value;
            }
        }

        /// <summary>
        /// Hitpoints Property, accessor for hitpoints.
        /// </summary>
        public uint Hitpoints
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
        /// Colides Method, checks for entity collisions.
        /// </summary>
        /// <param name="entity">Entity to check against.</param>
        public virtual bool Colides(Entity entity)
        {
            flag = false;
            foreach (Bounding hitbox in _hitboxes)
            {
                foreach (Bounding check in entity.Hitboxes)
                {
                    Vector2D polygonATranslation = new Vector2D();

                    PolygonCollisionResult r = hitbox.PolygonCollision(hitbox.Polygon, check.Polygon, _movement.Delta);

                    if (r.WillIntersect)
                    {
                        // Move the polygon by its velocity, then move
                        // the polygons appart using the Minimum Translation Vector
                        polygonATranslation = _movement.Delta + r.MinimumTranslationVector;
                    }
                    else
                    {
                        // Just move the polygon by its velocity
                        polygonATranslation = _movement.Delta;
                    }

                    polygonA.Offset(polygonATranslation);
                }
            }
            return false;
        }

        /// <summary>
        /// DrawEntity Mehtod, draw's the entity.
        /// </summary>
        public virtual void DrawEntity()
        {
            SwinGame.DrawBitmap(GameResources.GameImage(_bitmap), (float)_position.X - (GameResources.GameImage(_bitmap).Width / 2.0f), (float)_position.Y - (GameResources.GameImage(_bitmap).Height / 2.0f));

            foreach(Bounding hitbox in _hitboxes)
            {
                hitbox.Draw(flag);
            }
        }

        /// <summary>
        /// ProcessEvents Abstract Method, processes entity events.
        /// </summary>
        public abstract void ProcessEvents();

        /// <summary>
        /// ProcessMovement Abstract Method, proceesses entity movement.
        /// </summary>
        public abstract void ProcessMovement();

        /// <summary>
        /// AddHitbox Method, adds the provided hitbox to the list.
        /// </summary>
        /// <param name="hitbox">Hitbox to add.</param>
        public void AddHitbox(Bounding hitbox)
        {
            _hitboxes.Add(hitbox);
        }

        /// <summary>
        /// RemoveHitbox Method, removes the selected hitbox.
        /// </summary>
        /// <param name="hitbox">Hitbox to remove.</param>
        public void RemoveHitbox(Bounding hitbox)
        {
            _hitboxes.Remove(hitbox);
        }

        /// <summary>
        /// RemoveHitbox Method, removes the hitbox at the selected index.
        /// </summary>
        /// <param name="index">Index of the hitbox to remove.</param>
        public void RemoveHitbox(int index)
        {
            _hitboxes.RemoveAt(index);
        }

        public void Offset(Vector2D vector)
        {
            _position = new Point2D(_position.X + vector.i, _position.Y + vector.j);
        }

        public void Offset(Point2D point)
        {
            _position = new Point2D(_position.X + point.X, _position.Y + point.Y);
        }
    }
}