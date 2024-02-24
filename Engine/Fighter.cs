using Microsoft.Xna.Framework;
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
        public Fighter(Texture2D t, Vector2 position, int playerIndex) : base(position, playerIndex)
        {
            Initialize(t);
        }

        public Fighter(Texture2D t, Vector2 position, int playerIndex, Direction direction) : base(position, playerIndex, direction)
        {
            Initialize(t);
        }

        private void Initialize(Texture2D t)
        {
            spriteSheet = t;

            List<AnimationFrame> frames = new()
            {
                new AnimationFrame(new Rectangle(0, 0, 64, 64), 500),
                new AnimationFrame(new Rectangle(64, 0, 64, 64), 1000000000),
                //new AnimationFrame(new Rectangle(128, 0, 64, 64),750)
            };

            State idle = new(frames);

            states.Add("idle", idle);

            List<AnimationFrame> punchFrames = new()
            {
                new AnimationFrame(new Rectangle(0, 128, 64, 64), 100),



                //Other attack frames
                //new AnimationFrame(new Rectangle(192, 128, 64, 64), 100),
                //new AnimationFrame(new Rectangle(256, 128, 64, 64), 100),
                //new AnimationFrame(new Rectangle(320, 128, 64, 64), 200),
                //new AnimationFrame(new Rectangle(384, 128, 64, 64), 100),
                //new AnimationFrame(new Rectangle(448, 128, 64, 64), 200)

            };
            State punchState = new(punchFrames);
            states.Add("punch", punchState);

            List<AnimationFrame> punchFrames2 = new()
            {
                new AnimationFrame(new Rectangle(64, 128, 64, 64), 200),
                new AnimationFrame(new Rectangle(128, 128, 64, 64), 500),
            };
            State punchState2 = new(punchFrames2);
            states.Add("punch2", punchState2);

            List<AnimationFrame> moveFrames = new()
            {
                new AnimationFrame(new Rectangle(64, 64, 64, 64), 200),
                new AnimationFrame(new Rectangle(128, 64, 64, 64), 100),
            };
            State moveState = new(moveFrames);
            states.Add("move", moveState);

            // add another state here
            currentState = idle;
        }

    }
}
