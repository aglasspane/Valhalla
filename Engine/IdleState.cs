using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class IdleState : State
    {
        public IdleState(List<AnimationFrame> framesw) : base(framesw) 
        { 
            Loopable = false;
        }

        public override string? NextStateName(Action? currentAction)
        {
            string? stateName = null;
                
            switch(currentAction)
            {
                case Action.Punch:
                    stateName = "punch";
                    break;
                case Action.MoveLeft:
                    stateName = "move";
                    break;
                case Action.MoveRight:
                    stateName = "move";
                    break;
            }

            return stateName;

        }
    }
}
