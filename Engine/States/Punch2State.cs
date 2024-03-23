using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.States
{
    
    internal class Punch2State : State
    {
        private DmgCollider? dmgCollider;
        private const float Dmg = 1f;
        public Punch2State(List<AnimationFrame> framesw) : base(framesw)
        {



        }
        public override string? NextStateName(Action? currentAction, Moveable moveable)
        {
            string? stateName = null;
            if (dmgCollider == null)
            {
                if (moveable.Direction == Direction.Right)
                {
                    dmgCollider = new DmgCollider(moveable, new Rectangle(40, 24, 16, 16), Dmg);

                }
                else
                {
                    dmgCollider = new DmgCollider(moveable, new Rectangle(8, 24, 16, 16), Dmg);

                }
                moveable.Colliders.Add(dmgCollider);
            }
            
            if (currentAction == Action.Punch && Finished)
            {
                stateName = "punch";
                if (dmgCollider != null)
                {
                    dmgCollider.CausesKnockback = false;
                }
                DeleteCollider(moveable);
            }
            else if (Finished)
            {
                stateName = "idle";
                if (dmgCollider != null)
                {
                    dmgCollider.CausesKnockback = false;
                }
                DeleteCollider(moveable);
            }

            return stateName;

            

        }
        private void DeleteCollider(Moveable moveable)
        {
            if (dmgCollider != null)
            {
                moveable.Colliders.Remove(dmgCollider);
                dmgCollider = null;
            }
        }
    }
}
