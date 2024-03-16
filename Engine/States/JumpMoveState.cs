using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.States
{
    internal class JumpMoveState : State
    {
        private Direction _direction = Direction.Left;
        private const float _movementDistance = 10f;
        public JumpMoveState(List<AnimationFrame> framesw) : base(framesw)
        {
            Loopable = false;

        }
        public override void Update(GameTime gameTime, Moveable moveable)
        {
            base.Update(gameTime, moveable);
            float newX = moveable.Position.X;
            if (_direction == Direction.Left)
            {
                newX -= _movementDistance;
            }
            else if (_direction == Direction.Right)
            {
                newX += _movementDistance;
            }
            moveable.Position = new Vector2(newX, moveable.Position.Y);
            moveable.Direction = _direction;

        }

        public override string? NextStateName(Action? currentAction, Moveable moveable)
        {
            string? stateName = null;
            if (currentAction == Action.MoveLeft)
            {
                _direction = Direction.Left;
            }
            else if (currentAction == Action.MoveRight)
            {
                _direction = Direction.Right;
            }
            if (!moveable.InAir)
            {
                stateName = "jumpLand";

            }

            if (Finished && currentAction != Action.MoveLeft && currentAction != Action.MoveRight && moveable.InAir)
            {
                stateName = "jump";
            }

            return stateName;

        }
    }
}
