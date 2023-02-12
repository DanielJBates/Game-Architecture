using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenGL_Game.Objects;

namespace OpenGL_Game.Managers
{
    enum CollisionTypes 
    {
        SPHERE_SPHERE,
        LINE_LINE
    }

    struct Collision
    {
        public Entity entity;
        public CollisionTypes collisionType;
    }
    abstract class CollisionManager
    {
        protected List<Collision> CollisionManifold = new List<Collision>();

        public CollisionManager() { }

        public void ClearManifold()
        {
            CollisionManifold.Clear();
        }

        public void CollisionWithCamera(Entity entity, CollisionTypes collisionType)
        {
            foreach (Collision coll in CollisionManifold)
            {
                if (coll.entity == entity)
                {
                    return;
                }
            }

            Collision collision;
            collision.entity = entity;
            collision.collisionType = collisionType;
            CollisionManifold.Add(collision);
        }

        public abstract void ProcessCollision();
    }
}
