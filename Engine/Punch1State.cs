using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class Punch1State : State
    {
        public Punch1State(List<AnimationFrame> framesw) : base(framesw)
        {


        }
        public override string? NextStateName(Action? currentAction)
        {
            string? stateName = null;
            if (currentAction == Action.Punch && Finished)
            {
                stateName = "punch2";
            }
            else if (Finished)
            {
                stateName = "idle";
            }
            
            return stateName;

        }
    }
}
