using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public abstract class Character
    {
        protected Dictionary<string, State> states = new ();

        protected State? currentState;

        protected Texture2D? spriteSheet;

        protected Vector2 position;

        public Character(Vector2 position)
        {
            this.position = position;
        }

        public virtual void Update(GameTime gameTime)
        {
            currentState?.Update(gameTime);

            if (currentState is not null && currentState.Finished)
            {
                currentState.Reset();
                currentState = states["idle"];
            }
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

                spriteBatch?.Draw(spriteSheet, dest, currentState.Frame.SourceRectangle, Color.White,0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0f);
            }
        }

        public virtual void ChangeState(string newStateName)
        {
            // implement this so it works
            currentState = states[newStateName];

        }
    }
}
