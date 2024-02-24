using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Fred : Character
    {
        public Fred(Texture2D t, Vector2 position) : base(position)
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
                new AnimationFrame(new Rectangle(0, 128, 64, 64), 1000),
                
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



            // add another state here
            currentState = idle;
        }
    }
}
