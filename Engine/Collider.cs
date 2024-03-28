using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Collider
    {
        public Moveable Owner { get; set; }

        public Rectangle Bounds { get; set; }

        public Collider(Moveable owner, Rectangle bounds)
        {
            Owner = owner;
            // Scale the bounds by the owner scale
            Bounds = new(bounds.X * owner.Scale, bounds.Y * owner.Scale, bounds.Width * owner.Scale, bounds.Height * owner.Scale);
        }

        public bool hasCollided(Collider other)
        {
            Rectangle me = new(Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);
            me.Offset(Owner.Position);
            Rectangle them = new(other.Bounds.X, other.Bounds.Y, other.Bounds.Width, other.Bounds.Height);
            them.Offset(other.Owner.Position);

            return me.Intersects(them);
        }

        public virtual void handleCollision(Moveable target)
        {
            
        }
    }
}
