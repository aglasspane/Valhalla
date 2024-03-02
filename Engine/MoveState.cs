using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class MoveState : State
    {
        public MoveState(List<AnimationFrame> framesw) : base(framesw)
        {
            Loopable = false;

        }
        public override string? NextStateName(Action? currentAction)
        {
            string? stateName = null;
            if ((currentAction == Action.MoveLeft || currentAction == Action.MoveRight) && Finished)
            {
                stateName = "move";

            }
            else if (Finished)
            {
                stateName = "idle";
            }

            return stateName;

        }
    }
}
