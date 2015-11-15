using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace UnrealMechanismCS
{
    /// <summary>
    /// Entity Class
    /// Entity is the base class for most objects in this game, it defines the basic
    /// chariteristics of any object that the player can interact with.
    /// </summary>
    public abstract class Entity
    {
        //attributes
        private string _bitmap;

        private List<HitBox> _hitBoxes = new List<HitBox>();

        private int _hitPoints;
        private int _tick;

        private double _x;
        private double _y;

        //constructor
        /// <summary>
        /// Entity, constructor
        /// </summary>
        /// <param name="x">X position of the entity</param>
        /// <param name="y">Y position of the entity</param>
        /// <param name="hitBoxes">HitBoxes of the entity</param>
        /// <param name="hitPoints">HitPoints of the entity</param>
        /// <param name="bitmap">Bitmap name</param>
        public Entity(double x, double y, HitBox[] hitBoxes, int hitPoints, string bitmap)
        {
            _x = x;
            _y = y;

            foreach(HitBox hitBox in hitBoxes)
            {
                _hitBoxes.Add(hitBox);
            }

            _hitPoints = hitPoints;

            _bitmap = bitmap;

            _tick = 0;
        }


        //methods
        /// <summary>
        /// Collides, checks for colisions in all entity hitboxes against a given entity
        /// </summary>
        /// <param name="entity">Entity to check against</param>
        /// <returns>detected colisions</returns>
        public virtual bool Colides(Entity entity)
        {
            foreach(HitBox hitBoxA in _hitBoxes)
            {
                foreach(HitBox hitBoxB in entity.HitBoxes)
                {
                    if(hitBoxA.Collides(hitBoxB))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// DrawEntity, Draws the entity
        /// </summary>
        public virtual void DrawEntity()
        {
            float x = (float)_x - (GameResources.GameImage(_bitmap).Width / 2.0f);
            float y = (float)_y - (GameResources.GameImage(_bitmap).Height / 2.0f);

            SwinGame.DrawBitmap(GameResources.GameImage(_bitmap), x, y);
        }

        /// <summary>
        /// ProcessEvents, handles all entity interactions, colisions, movements and updates the entity tick.
        /// </summary>
        public abstract void ProcessEvents();

        /// <summary>
        /// ProcessMovement, updates the entities location.
        /// </summary>
        public abstract void ProcessMovement();
        
        /// <summary>
        /// AddHitBox, adds the provided hitbox to the entities list of hitboxes
        /// </summary>
        /// <param name="hitBox">HitBox to add</param>
        public void AddHitBox(HitBox hitBox)
        {
            _hitBoxes.Add(hitBox);
        }

        /// <summary>
        /// RemoveHitBox, removes the provided hitbox
        /// </summary>
        /// <param name="hitBox">HitBox to remove</param>
        public void RemoveHitbox(HitBox hitBox)
        {
            _hitBoxes.Remove(hitBox);
        }

        /// <summary>
        /// RemoveHitBox, removes the hitbox at index
        /// </summary>
        /// <param name="index">Index of hitbox</param>
        public void RemoveHitbox(int index)
        {
            _hitBoxes.RemoveAt(index);
        }

        //properties
        /// <summary>
        /// HitBoxes, readonly property, returns the current value of _hitBoxes
        /// </summary>
        public List<HitBox> HitBoxes
        {
            get
            {
                return _hitBoxes;
            }
        }

        /// <summary>
        /// Tick, property, retuns the current value of _tick
        /// </summary>
        public int Tick
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
        /// X, property
        /// </summary>
        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        /// <summary>
        /// Y, property
        /// </summary>
        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        /// <summary>
        /// Bitmap, property
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
    }
}
