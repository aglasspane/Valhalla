﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.States
{
    public class State
    {
        public AnimationFrame Frame { get; protected set; }

        public bool Finished { get; protected set; } = false;

        public bool Loopable { get; protected set; } = true;

        protected List<AnimationFrame> frames;

        protected int _currentFrameTime = 0;
        protected int _currentFrameNumber = 0;



        public State(List<AnimationFrame> framesw)
        {
            frames = framesw;
            Frame = frames[_currentFrameNumber];
        }

        
        public virtual void Start(GameTime gameTime, Moveable moveable, GameWorld _world)
        {

        }

        public virtual void Update(GameTime gameTime, Moveable moveable, GameWorld _world)
        {
            _currentFrameTime += gameTime.ElapsedGameTime.Milliseconds;

            if (_currentFrameTime >= frames[_currentFrameNumber].FrameInterval && (Loopable || !Loopable && !Finished))
            {
                _currentFrameNumber++;
                if (_currentFrameNumber > frames.Count - 1)
                {
                    if (Loopable)
                    {
                        _currentFrameNumber = 0;
                    }
                    else
                    {
                        _currentFrameNumber--;
                    }
                    Finished = true;
                }
                _currentFrameTime = 0;
                Frame = frames[_currentFrameNumber];
            }

        }
        public virtual void Draw(GameTime gameTime, SpriteBatch sb, Moveable moveable)
        {

        }
        public virtual string? NextStateName(Action? currentAction)
        {
            return null;
        }

        public virtual string? NextStateName(Action? currentAction, Moveable moveable, GameWorld _world)
        {
            return NextStateName(currentAction);
        }

        public void Reset()
        {
            _currentFrameTime = 0;
            _currentFrameNumber = 0;
            Finished = false;
            Frame = frames[_currentFrameNumber];
        }
    }
}
