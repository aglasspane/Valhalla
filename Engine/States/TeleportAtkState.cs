using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.States
{
    internal class TeleportAtkState : State 
    {

        private DmgCollider? dmgCollider;
        private const float Dmg = 10f;

        public TeleportAtkState(List<AnimationFrame> framesw) : base(framesw)
        {

   
        }

        public override string? NextStateName(Action? currentAction, Moveable moveable, GameWorld _world)
        {
            string? stateName = null;
            if (dmgCollider == null)
            {
                if (moveable.Direction == Direction.Right)
                {
                    dmgCollider = new DmgCollider(moveable, new Rectangle(0, 0, 100, 100), Dmg, new Vector2(3, 10));

                }
                else
                {
                    dmgCollider = new DmgCollider(moveable, new Rectangle(-12, 0, 100, 100), Dmg, new Vector2(-3, 10));

                }
                moveable.Colliders.Add(dmgCollider);
            }

            if(Finished)
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
        private Character? GetOpponent(Moveable current, GameWorld _world)
        {
            // Goes throught the list of moveables in GameWorld and gets both characters then 
            // compares them both to see which is the current character doing the action
            foreach (var entity in _world.Entities)
            {
                if (entity is Character characterEntity && entity != current)
                {
                    return characterEntity;
                }
            }
            return null;
        }
    }
}
