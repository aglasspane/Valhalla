using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.States
{
    internal class JumpState : State
    {
        private bool _isJumping = false;
        public JumpState(List<AnimationFrame> framesw) : base(framesw)
        {
            Loopable = false;

        }

        public override void Update(GameTime gameTime, Moveable moveable)
        {
            base.Update(gameTime, moveable);
            if (!_isJumping)
            {
                _isJumping = true;
                moveable.Velocity = new Vector2(moveable.Velocity.X, -12.5f);
                
            }
        }

        public override string? NextStateName(Action? currentAction, Moveable moveable)
        {
            string? stateName = null;
            if (!moveable.InAir && Finished)
            {
                stateName = "jumpLand";
                _isJumping = false;
                
            }
            else if (moveable.InAir && (currentAction == Action.MoveLeft || currentAction == Action.MoveRight))
            {
                stateName = "jumpMove";
            }


            return stateName;

        }
    }
}
