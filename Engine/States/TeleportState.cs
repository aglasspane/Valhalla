using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.States
{
    public class TeleportState : State  
    {
            
        private DmgCollider? dmgCollider;
        private const float Dmg = 1f;

        protected bool finishedTeleport = false;


        public TeleportState(List<AnimationFrame> framesw) : base(framesw)
        {


        }
        public override void Update(GameTime gameTime, Moveable moveable, GameWorld _world)
        {


            base.Update(gameTime, moveable, _world);

            //Get the other player than the one that is currently teleporting
            Character? other = GetOpponent(moveable, _world); 
            if (other?.Direction == Direction.Left && !finishedTeleport && other != null)
            {
                //Move player that is teleporting behind the other player
                finishedTeleport = true;
                moveable.Position = new Vector2(other.Position.X + (64), other.Position.Y - 64);
                other.Velocity = Vector2.Zero;
                moveable.Direction = other.Direction;
            }
            else if (other?.Direction == Direction.Right && !finishedTeleport && other != null)
            {
                //Move player that is teleporting behind the other player
                finishedTeleport = true;
                moveable.Position = new Vector2(other.Position.X - (64), other.Position.Y - 64);
                other.Velocity = Vector2.Zero;
                moveable.Direction = other.Direction;
            }
            


        }
        public override string? NextStateName(Action? currentAction, Moveable moveable, GameWorld _world)
        {
            string? stateName = null;
            if (dmgCollider == null)
            {
                dmgCollider = new DmgCollider(moveable, new Rectangle(0, 0, 64, 64), Dmg);

                moveable.Colliders.Add(dmgCollider);
            }


            if (currentAction == Action.TeleportAtk && Finished)
            {
                stateName = "teleportAtk";
                if (dmgCollider != null)
                {
                    dmgCollider.CausesKnockback = false;
                }

                DeleteCollider(moveable);
                finishedTeleport = false;
            }
            else if (Finished)
            {
                stateName = "idle";
                DeleteCollider(moveable);
                finishedTeleport = false;
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
