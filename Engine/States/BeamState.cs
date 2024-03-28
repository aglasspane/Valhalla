using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.States
{
    internal class BeamState : State
    {
        private DmgCollider? dmgCollider;
        private const float Dmg = 25f;

        public BeamState(List<AnimationFrame> framesw) : base(framesw)
        {


        }
        public override string? NextStateName(Action? currentAction, Moveable moveable, GameWorld _world)
        {
            string? stateName = null;
            if (dmgCollider == null)
            {
                if (moveable.Direction == Direction.Right)
                {
                    dmgCollider = new DmgCollider(moveable, new Rectangle(40, 16, 400, 32), Dmg, new Vector2(10, 0));

                }
                else
                {
                    dmgCollider = new DmgCollider(moveable, new Rectangle(-365, 16, 400, 32), Dmg, new Vector2(-10, 0));

                }
                moveable.Colliders.Add(dmgCollider);
            }

            //if (currentAction == Action.Punch && Finished)
            //{
            //    stateName = "punch2";
            //    if (dmgCollider != null)
            //    {
            //        dmgCollider.CausesKnockback = false;
            //    }

            //    DeleteCollider(moveable);
            //}
            //else
            if (Finished)
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
