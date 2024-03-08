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
        private readonly CollisionManager cm = new CollisionManager();

        public SpriteFont? font { get; set; }


        public GameScreen(Texture2D t, Texture2D t2) : base(t, t2)
        { 
            //These are the characters that spawn at the start 
            _fighter = new Fighter(t, new Vector2(0,0), 0 , Direction.Right, new Rectangle(0, 0, 64, 64), new Rectangle(-650, -650, 64, 64));
            _fighter2 = new Fighter(t2, new Vector2(400, 0), 1, new Rectangle(400,0,64,64), new Rectangle(-600,-600,64 ,64));

        }

        public override void Draw(GameTime gameTime, SpriteBatch? gd)
        {
            _fighter.Draw(gameTime, gd);
            _fighter2.Draw(gameTime, gd);

            if(font != null) 
            {
                gd?.DrawString(font, Convert.ToInt32(_fighter.percentDmgValue).ToString(), new Vector2(100, 300), Color.Red);
                gd?.DrawString(font, Convert.ToInt32(_fighter2.percentDmgValue).ToString(), new Vector2(300, 300), Color.Red);
            }

            base.Draw(gameTime, gd);
        }
      
        public override void Update(GameTime gameTime)
        {
            _fighter.Update(gameTime);
            _fighter2.Update(gameTime);
            cm.HandleHit(_fighter, _fighter2);
            
            
            


            base.Update(gameTime);
        }
    }
}
