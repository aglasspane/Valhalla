﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Fighter : Character
    {
        public Fighter(Texture2D t, Vector2 position, int playerIndex, Rectangle hitBox, Rectangle dmgBox) : base(position, playerIndex, hitBox, dmgBox)
        {
            Initialize(t);
        }

        public Fighter(Texture2D t, Vector2 position, int playerIndex, Direction direction, Rectangle hitBox, Rectangle dmgBox) : base(position, playerIndex, direction, hitBox, dmgBox)
        {
            Initialize(t);
        }

        private void Initialize(Texture2D t)
        {
            //This method contains all animations for the fighter class
            spriteSheet = t;

            List<AnimationFrame> frames = new()
            {
                //Each AnimationFrame contains where on the spritesheet we are getting the value from and the time it last for (milliseconds) 

                new AnimationFrame(new Rectangle(0, 0, 64, 64), 500),
                new AnimationFrame(new Rectangle(64, 0, 64, 64), 100),
                //new AnimationFrame(new Rectangle(128, 0, 64, 64),750)
            };

            //This creates a state which relates to the animation meaning you can use it to change the animation
            IdleState idle = new(frames);

            //This adds the state to the list of states
            states.Add("idle", idle);

            List<AnimationFrame> punchFrames = new()
            {
                new AnimationFrame(new Rectangle(0, 128, 64, 64), 150),

                
            };
            Punch1State punchState = new(punchFrames);
            states.Add("punch", punchState);

            List<AnimationFrame> punchFrames2 = new()
            {
                new AnimationFrame(new Rectangle(64, 128, 64, 64), 75),
                new AnimationFrame(new Rectangle(128, 128, 64, 64), 75),
            };
            Punch2State punchState2 = new(punchFrames2);
            states.Add("punch2", punchState2);

            List<AnimationFrame> moveFrames = new()
            {
                new AnimationFrame(new Rectangle(64, 64, 64, 64), 200),
                new AnimationFrame(new Rectangle(128, 64, 64, 64), 100),

            };
            MoveState moveState = new(moveFrames);
            states.Add("move", moveState);

            List<AnimationFrame> swordFrames = new()
            {
                new AnimationFrame(new Rectangle(256, 448, 64, 64), 100),
                new AnimationFrame(new Rectangle(320, 448, 64, 64), 75),
                new AnimationFrame(new Rectangle(384, 448, 64, 64), 100),
                new AnimationFrame(new Rectangle(448, 448, 64, 64), 100),
            };
            State swordState = new(swordFrames);
            states.Add("sword", swordState);


            List<AnimationFrame> moveAtkFrames = new()
            {
                new AnimationFrame(new Rectangle(768, 192, 64, 64), 200),
                new AnimationFrame(new Rectangle(832, 192, 64, 64), 200),
            };
            State moveAtkState = new(moveAtkFrames);
            states.Add("moveAtk", moveAtkState);

            List<AnimationFrame> hitFrames = new()
            {
                new AnimationFrame(new Rectangle(192, 192, 64, 64), 50),
                
            };
            State hitState = new(hitFrames);
            states.Add("hit", hitState);

            List<AnimationFrame> jumpFrames = new()
            {
                new AnimationFrame(new Rectangle(448, 0, 64, 64), 50),
                new AnimationFrame(new Rectangle(512, 0, 64, 64), 100),
                new AnimationFrame(new Rectangle(448, 0, 64, 64), 50),

            };
            JumpState jumpState = new(jumpFrames);
            states.Add("jump", jumpState);





            //Current state is the state that the characters begin with
            currentState = idle;
        }

    }
    //Other attack frames
    //new AnimationFrame(new Rectangle(192, 128, 64, 64), 100),
    //new AnimationFrame(new Rectangle(256, 128, 64, 64), 100),
    //new AnimationFrame(new Rectangle(320, 128, 64, 64), 200),
    //new AnimationFrame(new Rectangle(384, 128, 64, 64), 100),
    //new AnimationFrame(new Rectangle(448, 128, 64, 64), 200)
}

