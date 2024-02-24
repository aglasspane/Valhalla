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



        protected Character _fighter;
        protected Character _fighter2;

        public GameScreen(Texture2D t, Texture2D t2) : base(t, t2)
        { 
            _fighter = new Fighter(t, new Vector2(0,0), 0 , Direction.Right);
            _fighter2 = new Fighter(t2, new Vector2(400, 0), 1);
        }

        public override void Draw(GameTime gameTime, SpriteBatch? gd)
        {
            _fighter.Draw(gameTime, gd);
            _fighter2.Draw(gameTime, gd);

            base.Draw(gameTime, gd);
        }

        public override void Update(GameTime gameTime)
        {
            _fighter.Update(gameTime);
            _fighter2.Update(gameTime);


            base.Update(gameTime);
        }
    }
}
