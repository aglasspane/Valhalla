using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class AnimationFrame
    {
        public Rectangle SourceRectangle { get; }

        public int FrameInterval { get; } = 1000;

        public AnimationFrame(Rectangle source, int frameInterval) 
        { 
            SourceRectangle = source;
            FrameInterval = frameInterval;
        }
        public AnimationFrame(Rectangle source) 
        {
            SourceRectangle = source;
        }

    }
}
