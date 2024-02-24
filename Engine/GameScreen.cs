using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class GameScreen : Screen
    {


        protected GamePadState? _previousState = null;

        protected Character _fred;

        public GameScreen(Texture2D t) : base(t)
        { 
            _fred = new Fred(t, new Vector2(0,0));
        }

        public override void Draw(GameTime gameTime, SpriteBatch? gd)
        {
            _fred.Draw(gameTime, gd);

            base.Draw(gameTime, gd);
        }

        public override void Update(GameTime gameTime)
        {
            _fred.Update(gameTime);

            GamePadState currentState = GamePad.GetState(0);
            if (_previousState != null)
            {
                if (currentState.IsButtonDown(Buttons.X) && !_previousState.GetValueOrDefault().IsButtonDown(Buttons.X))
                {
                    _fred.ChangeState("punch");

                

                }
                if (GamePad.GetState(0).IsButtonDown(Buttons.X) && _previousState.GetValueOrDefault().IsButtonDown(Buttons.X))
                {
                    _fred.ChangeState("punch2");
                }

            }

            _previousState = currentState;

            base.Update(gameTime);
        }
    }
}
