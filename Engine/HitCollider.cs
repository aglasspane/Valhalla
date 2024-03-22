using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class HitCollider : Collider   
    {
        //Box realtive to the owner.
        
        
        public HitCollider(Moveable owner, Rectangle bounds) : base(owner, bounds)
        {
            
        }
    }
}
