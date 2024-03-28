using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class CollisionManager
    {
        


        public void HandleCollisons (List<Moveable> gameEntities)
        {
            Queue<Collider> gameEntityColliders = new();
            foreach (var entity in gameEntities) 
            {
                foreach (var item in entity.Colliders)
                {
                    gameEntityColliders.Enqueue(item);
                }
                
            }
            while(gameEntityColliders.Count > 1)
            {
                Collider c = gameEntityColliders.Dequeue();
                foreach (var item in gameEntityColliders)
                {
                    if (c.hasCollided(item) && item.Owner != null)
                    {
                        c.handleCollision(item.Owner);
                    }
                }
            }

        }

      

    }
}
