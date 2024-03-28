using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.States
{
    internal class HitState : State
    {
        public HitState(List<AnimationFrame> framesw) : base(framesw)
        {
            Loopable = false;

        }
        public override string? NextStateName(Action? currentAction)
        {
            string? stateName = null;
            if (currentAction == Action.Hit && Finished)
            {
                stateName = "hit";
            }
            else if (Finished)
            {
                stateName = "idle";
            }

            return stateName;

        }
    }
}
