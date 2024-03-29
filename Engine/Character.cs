using Engine.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
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
        Punch, MoveLeft, MoveRight, Jump, Hit, HighKick, Teleport, TeleportAtk, Beam
    }
    public abstract class Character : Moveable
    {
        public string CurrentStateName { get; protected set; } = "idle";

        protected Dictionary<string, State> states = new ();

        protected State? currentState;

        protected Texture2D? spriteSheet;

        protected Texture2D? beamSpritesheet;

        protected GamePadState? _previousGamePadState = null;

        protected int playerIndex;

        public Queue<Action> actionQueue = new();

        public float PercentDmgValue { get; set; } = 0;

        public int Lives { get; protected set; } = 3;

        private Vector2 startPos;


        public Character(Vector2 position, int playerIndex, Rectangle hitBox, Rectangle dmgBox)
        {
            this.Position = position;
            this.startPos = position;   
            this.playerIndex = playerIndex;

        }
        public Character(Vector2 position, int playerIndex, Direction direction, Rectangle hitBox, Rectangle dmgBox) : this(position, playerIndex, hitBox, dmgBox) 
        {
           this.Direction = direction;  
        }

        public override void Update(GameTime gameTime, GameWorld _world)
        {

            //This records the current state of the gamepad in each 
            GamePadState currentGamePadState = GamePad.GetState(playerIndex);
            KeyboardState currentKeyboardState = Keyboard.GetState();
            

            
        
            //Translate Input
            if (currentGamePadState.IsButtonDown(Buttons.X) || currentKeyboardState.IsKeyDown(Keys.E))
            {
                    actionQueue.Enqueue(Action.Punch);

            }

            if (currentGamePadState.ThumbSticks.Left.X > 0 || currentKeyboardState.IsKeyDown(Keys.D))
            {
                actionQueue.Enqueue(Action.MoveRight);
            }
            else if (currentGamePadState.ThumbSticks.Left.X < 0 || currentKeyboardState.IsKeyDown(Keys.A))
            {
                actionQueue.Enqueue(Action.MoveLeft);
            }
            if(currentGamePadState.IsButtonDown(Buttons.A) || currentKeyboardState.IsKeyDown(Keys.Space))
            {
                actionQueue.Enqueue(Action.Jump);
            }
            if(currentGamePadState.IsButtonDown(Buttons.Y) || currentKeyboardState.IsKeyDown(Keys.R)) 
            {
                actionQueue.Enqueue(Action.HighKick);   
            }
            if(currentGamePadState.IsButtonDown(Buttons.LeftShoulder))
            {
                actionQueue.Enqueue(Action.Teleport);
            }
            if(currentGamePadState.IsButtonDown(Buttons.LeftTrigger))
            {
                actionQueue.Enqueue(Action.TeleportAtk);
            }
            if (currentGamePadState.IsButtonDown(Buttons.RightTrigger))
            {
                actionQueue.Enqueue(Action.Beam);
            }

            Action? action = null;
            if (actionQueue.Count > 0) 
            {
                action = actionQueue.Dequeue();
            }

            string? newStateName = currentState?.NextStateName(action, this, _world);

            if (newStateName != null)
            {
                currentState?.Reset();

                ChangeState(newStateName);
                currentState?.Start(gameTime, this, _world);
                Debug.WriteLine(newStateName);

            }
            if (Position.X > 2000 + (64 * 4))
            {
                Velocity = new Vector2(0, Velocity.Y);
                Position = new Vector2(900, 400);
                Lives--;
                PercentDmgValue = 0; 
            }


            if (Position.X < (-64 * 4))
            {
                Velocity = new Vector2(0, Velocity.Y);
                Position = new Vector2(900, 400);
                Lives--;
                PercentDmgValue = 0;
            }




            _previousGamePadState = currentGamePadState;
            currentState?.Update(gameTime, this, _world);

            base.Update(gameTime, _world);
        }

        public override void Draw(GameTime gameTime, SpriteBatch? spriteBatch)
        {
         
            
            if (currentState is not null && spriteBatch is not null)
            {
                Rectangle dest = new();
                dest.X = (int)Position.X;
                dest.Y = (int)Position.Y;
                dest.Width = currentState.Frame.SourceRectangle.Width * Scale;
                dest.Height = currentState.Frame.SourceRectangle.Height * Scale;

                SpriteEffects spriteEffects = SpriteEffects.None;   
                if (Direction == Direction.Left)
                {
                    spriteEffects = SpriteEffects.FlipHorizontally;
                }


                spriteBatch.Draw(spriteSheet, dest, currentState.Frame.SourceRectangle, Color.White,0f, Vector2.Zero, spriteEffects, 0f);
                currentState.Draw(gameTime, spriteBatch, this);
            }
        }

        public virtual void ChangeState(string newStateName)
        {

            currentState = states[newStateName];
            CurrentStateName = newStateName;
        }

        public void Reset()
        {
            Lives = 3;
            Position = startPos;
            PercentDmgValue = 0f;   
        }
    }
}
