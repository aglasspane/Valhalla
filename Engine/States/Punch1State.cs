using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Engine.States
{
    internal class Punch1State : State
    {

        private DmgCollider? dmgCollider;
        private const float Dmg = 1f;

        public Punch1State(List<AnimationFrame> framesw) : base(framesw)
        {


        }
        public override string? NextStateName(Action? currentAction, Moveable moveable, GameWorld _world)
        {
            string? stateName = null;
            if(dmgCollider == null) 
            {
                if (moveable.Direction == Direction.Right)
                {
                    dmgCollider = new DmgCollider(moveable, new Rectangle(40, 24, 16, 16), Dmg, new Vector2(5, 0));

                }
                else
                {
                    dmgCollider = new DmgCollider(moveable, new Rectangle(8, 24, 16, 16), Dmg, new Vector2(-5, 0));

                }
                moveable.Colliders.Add(dmgCollider);
            }
            
            if (currentAction == Action.Punch && Finished)
            {
                stateName = "punch2";
                if(dmgCollider != null)
                {
                    dmgCollider.CausesKnockback = false;
                }
                
                DeleteCollider(moveable);
            }
            else if (Finished)
            {
                stateName = "idle";
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
