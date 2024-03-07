using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class JumpState : State    
    {
        public JumpState(List<AnimationFrame> framesw) : base(framesw)
        {


        }
        public override string? NextStateName(Action? currentAction)
        {
            string? stateName = null;
            if (currentAction == Action.Jump && Finished)
            {
                stateName = "jump";
            }
            else if (Finished)
            {
                stateName = "idle";
            }

            return stateName;

        }
    }
}
