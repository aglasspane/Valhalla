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

    public abstract class Character
    {
        public string CurrentStateName { get; protected set; }

        protected Dictionary<string, State> states = new ();

        protected State? currentState;

        protected Texture2D? spriteSheet;

        protected Vector2 position;

        protected GamePadState? _previousGamePadState = null;

        protected int playerIndex;

        protected Direction direction = Direction.Left;

        public Rectangle hitBox;

        public Rectangle? dmgBox;

        
        

        public Character(Vector2 position, int playerIndex, Rectangle hitBox, Rectangle dmgBox)
        {
            this.position = position;
            this.playerIndex = playerIndex;
            this.hitBox = hitBox;   
            this.dmgBox = dmgBox;   
        }
        public Character(Vector2 position, int playerIndex, Direction direction, Rectangle hitBox, Rectangle dmgBox) : this(position, playerIndex, hitBox, dmgBox) 
        {
           this.direction = direction;  
        }

        public virtual void Update(GameTime gameTime)
        {

            hitBox.X = (int)position.X;
            hitBox.Y = (int)position.Y; 
            
            
            

            //This records the current state of the gamepad in each 
            GamePadState currentGamePadState = GamePad.GetState(playerIndex);
            if (_previousGamePadState != null)
            {
                if (currentGamePadState.IsButtonDown(Buttons.X) && !_previousGamePadState.GetValueOrDefault().IsButtonDown(Buttons.X))
                {
                    ChangeState("punch");
                    dmgBox = new Rectangle((int)position.X + 64, (int)position.Y + 32,24,24);
                    

                }
                if (currentGamePadState.IsButtonDown(Buttons.X) && _previousGamePadState.GetValueOrDefault().IsButtonDown(Buttons.X))
                {
                    ChangeState("punch2");
                    dmgBox = new Rectangle((int)position.X + 64, (int)position.Y + 32, 24, 24);
                    
                }

            }
            if (currentGamePadState.IsButtonDown(Buttons.Y) && !_previousGamePadState.GetValueOrDefault().IsButtonDown(Buttons.Y))
            {
                ChangeState("sword");
                dmgBox = new Rectangle((int)position.X + 64, (int)position.Y + 24, 24, 24);
                

            }
            if (currentGamePadState.IsButtonDown(Buttons.A) && !_previousGamePadState.GetValueOrDefault().IsButtonDown(Buttons.A) && (currentGamePadState.ThumbSticks.Left.X < 0 || currentGamePadState.ThumbSticks.Left.X > 0))
            {
                ChangeState("moveAtk");
                
            }



            if (currentGamePadState.ThumbSticks.Left.X < 0)
            {
                position.X -= 5f;
                direction = Direction.Left;
                ChangeState("move");
                dmgBox = null;
            }
            if (currentGamePadState.ThumbSticks.Left.X > 0)
            {
                position.X += 5f;
                direction = Direction.Right;
                ChangeState("move");
                dmgBox = null;

            }

 

            _previousGamePadState = currentGamePadState;
            currentState?.Update(gameTime);

            if (currentState is not null && currentState.Finished)
            {
                currentState.Reset();
                currentState = states["idle"];
                dmgBox = null;

            }



        }

        public virtual void Draw(GameTime gameTime, SpriteBatch? spriteBatch)
        {
         
            
            if (currentState is not null)
            {
                Rectangle dest = new();
                dest.X = (int)position.X;
                dest.Y = (int)position.Y;
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
            CurrentStateName = newStateName; 
            

        }
    }
}
