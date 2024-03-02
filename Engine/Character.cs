using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public enum Direction
    {
        Left, Right
    }

    public enum Action
    {
        Punch, MoveLeft, MoveRight
    }
    public abstract class Character
    {
        protected Dictionary<string, State> states = new ();

        protected State? currentState;

        protected Texture2D? spriteSheet;

        protected Vector2 position;

        protected GamePadState? _previousGamePadState = null;

        protected int playerIndex;

        protected Direction direction = Direction.Left;

        protected Queue<Action> actionQueue = new();


        public Character(Vector2 position, int playerIndex)
        {
            this.position = position;
            this.playerIndex = playerIndex;
        }
        public Character(Vector2 position, int playerIndex, Direction direction) : this(position, playerIndex) 
        {
           this.direction = direction;  
        }

        public virtual void Update(GameTime gameTime)
        {
            //This records the current state of the gamepad in each 
            GamePadState currentGamePadState = GamePad.GetState(playerIndex);
            //Translate Input
            if (currentGamePadState.IsButtonDown(Buttons.X))
            {
                    actionQueue.Enqueue(Action.Punch);
            }

            if (currentGamePadState.ThumbSticks.Left.X > 0)
            {
                actionQueue.Enqueue(Action.MoveRight);
            }
            else if (currentGamePadState.ThumbSticks.Left.X < 0)
            {
                actionQueue.Enqueue(Action.MoveLeft);
            }

            Action? action = null;
            if (actionQueue.Count > 0) 
            {
                action = actionQueue.Dequeue();
            }

            string? newStateName = currentState?.NextStateName(action);
            Debug.WriteLine(newStateName);

            if (newStateName != null)
            {
                currentState?.Reset();
                ChangeState(newStateName);  
            }

            if (action == Action.MoveLeft)
            {
                position.X -= 5f;
                direction = Direction.Left;
            }
            if (action == Action.MoveRight)
            {
                position.X += 5f;
                direction = Direction.Right;
            }


            //if (currentGamePadState.IsButtonDown(Buttons.Y) && !_previousGamePadState.GetValueOrDefault().IsButtonDown(Buttons.Y))
            //{
            //    ChangeState("sword");
            //}
            //if (currentGamePadState.IsButtonDown(Buttons.A) && !_previousGamePadState.GetValueOrDefault().IsButtonDown(Buttons.A) && (currentGamePadState.ThumbSticks.Left.X < 0 || currentGamePadState.ThumbSticks.Left.X > 0))
            //{
            //    ChangeState("moveAtk");
            //}



            _previousGamePadState = currentGamePadState;
            currentState?.Update(gameTime);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch? spriteBatch)
        {
            if (currentState is not null)
            {
                Rectangle dest = new();
                dest.X = Convert.ToInt32(position.X);
                dest.Y = Convert.ToInt32(position.Y);
                dest.Width = currentState.Frame.SourceRectangle.Width * 4;
                dest.Height = currentState.Frame.SourceRectangle.Height * 4;

                SpriteEffects spriteEffects = SpriteEffects.None;   
                if (direction == Direction.Left)
                {
                    spriteEffects = SpriteEffects.FlipHorizontally;
                }


                spriteBatch?.Draw(spriteSheet, dest, currentState.Frame.SourceRectangle, Color.White,0f, Vector2.Zero, spriteEffects, 0f);
            }
        }

        public virtual void ChangeState(string newStateName)
        {
            // implement this so it works
            currentState = states[newStateName];

        }
    }
}
