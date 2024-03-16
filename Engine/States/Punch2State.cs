using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.States
{
    internal class Punch2State : State
    {
        public Punch2State(List<AnimationFrame> framesw) : base(framesw)
        {


        }
        public override string? NextStateName(Action? currentAction)
        {
            string? stateName = null;
            if (currentAction == Action.Punch && Finished)
            {
                stateName = "punch";
            }
            else if (Finished)
            {
                stateName = "idle";
            }

            return stateName;

        }
    }
}
