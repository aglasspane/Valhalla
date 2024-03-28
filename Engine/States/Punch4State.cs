﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.States
{
    internal class Punch4State : State
    {
        private DmgCollider? dmgCollider;
        private const float Dmg = 5f;
        public Punch4State(List<AnimationFrame> framesw) : base(framesw)
        {



        }
        public override string? NextStateName(Action? currentAction, Moveable moveable, GameWorld _world)
        {
            string? stateName = null;
            if (dmgCollider == null)
            {
                if (moveable.Direction == Direction.Right)
                {
                    dmgCollider = new DmgCollider(moveable, new Rectangle(40, 24, 16, 16), Dmg, new Vector2(10,0));

                }
                else
                {
                    dmgCollider = new DmgCollider(moveable, new Rectangle(8, 24, 16, 16), Dmg, new Vector2(-10, 0));

                }
                moveable.Colliders.Add(dmgCollider);
            }


            if (Finished)
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
