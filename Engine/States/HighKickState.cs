using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.States
{
    internal class HighKickState : State    
    {
        DmgCollider? dmgCollider;


        public HighKickState(List<AnimationFrame> framesw) : base(framesw)
        {


        }
        public override string? NextStateName(Action? currentAction, Moveable moveable)
        {
            string? stateName = null;
            if (dmgCollider == null)
            {
                if (moveable.Direction == Direction.Right)
                {
                    dmgCollider = new DmgCollider(moveable, new Rectangle(40, 6, 16, 16), 2, new Vector2(5, -10));

                }
                else
                {
                    dmgCollider = new DmgCollider(moveable, new Rectangle(8, 6, 16, 16), 2, new Vector2(-5, -10));

                }
                moveable.Colliders.Add(dmgCollider);
            }

        
            if (Finished)
            {
                stateName = "idle";
                if (dmgCollider != null)
                {
                    moveable.Colliders.Remove(dmgCollider);
                    dmgCollider = null;
                }
            }

            return stateName;

        }
    }
}
