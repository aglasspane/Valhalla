﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.States
{
    internal class JumpLandState : State
    {
        public JumpLandState(List<AnimationFrame> framesw) : base(framesw)
        {
            Loopable = false;
        }

        public override string? NextStateName(Action? currentAction)
        {
            string? stateName = null;
            if(Finished)
            {
                stateName = "idle";
            }
            return stateName;
        }
    }
}
