using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class GroundCollider : Collider    
    {
        public GroundCollider(Moveable moveable, Rectangle GroundBox) : base(moveable, GroundBox)
        {

        } 
    }
}
