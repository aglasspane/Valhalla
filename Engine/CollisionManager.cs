using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class CollisionManager
    {
        public void HandleHit(Character c1, Character c2)
        {
                if (c2.CurrentStateName != "hit" && c2.dmgBox.HasValue && c2.dmgBox.Value.Intersects(c1.hitBox))
                {
                    
                    c1.ChangeState("hit");
                }
   
            if (c1.CurrentStateName != "hit" && c1.dmgBox.GetValueOrDefault(new Rectangle(0, 0, 0, 0)).Intersects(c2.hitBox))
            {
                c2.ChangeState("hit");
            }
      


        }

      

    }
}
