using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class State
    {
        public AnimationFrame Frame { get; protected set; }

        public bool Finished { get; protected set; } = false;
        
        protected List<AnimationFrame> frames;

        protected int _currentFrameTime = 0;
        protected int _currentFrameNumber = 0;

        public State(List<AnimationFrame> framesw) 
        {
            frames = framesw;
            Frame = frames[_currentFrameNumber];
        }

        public void Update(GameTime gameTime)
        {
            _currentFrameTime += gameTime.ElapsedGameTime.Milliseconds;

            if (_currentFrameTime >= frames[_currentFrameNumber].FrameInterval)
            {
                _currentFrameNumber++;
                if (_currentFrameNumber > frames.Count - 1)
                {
                    _currentFrameNumber = 0;
                    Finished = true;
                }
                _currentFrameTime = 0;
                Frame = frames[_currentFrameNumber];
            }
            
        }

        public void Reset()
        {
            _currentFrameTime = 0;
            _currentFrameNumber = 0;
            Finished = false;
        }
    }
}
