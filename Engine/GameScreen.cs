using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class GameScreen : Screen
    {

        protected GameWorld _world;

        
        protected Character _fighter;
        protected Character _fighter2;
        private readonly CollisionManager cm = new CollisionManager();

       public GameScreen(GraphicsDevice device, ContentManager content) : base(device, content) 
        {
            //Pick all the textures out of the gameworld content rather than being passed through
            _world = new GameWorld(content);
            Texture2D t = _world.Content.Load<Texture2D>("Man");
            Texture2D t2 = _world.Content.Load<Texture2D>("Man2");
            Texture2D t3 = _world.Content.Load<Texture2D>("KiEffects");
            _background = _world.Content.Load<Texture2D>("FightBackground");
            
            //These are the characters that spawn at the start 
            _fighter = new Fighter(t, t3, new Vector2(200,0), 0 , Direction.Right, new Rectangle(0, 0, 64, 64), new Rectangle(-650, -650, 64, 64));
            _fighter2 = new Fighter(t2, t3, new Vector2(1200, 0), 1, new Rectangle(400,0,64,64), new Rectangle(-600,-600,64 ,64));
            _world.Entities.Add(_fighter);
            _world.Entities.Add(_fighter2);
            
        }

        public override void Draw(GameTime gameTime, SpriteBatch? gd)
        {
            //Draw background here

            base.Draw(gameTime, gd);
            foreach (var item in _world.Entities)
            {
                //Uncomment to see HitBoxes
                //foreach (var collider in item.Colliders)
                //{
                //    if (gd != null)
                //    {
                //        DrawRectangle(gd, collider.Bounds.X + (int)collider.Owner.Position.X, collider.Bounds.Y + (int)collider.Owner.Position.Y, collider.Bounds.Width, collider.Bounds.Height, Color.Red);
                //    }

                //}
                item.Draw(gameTime, gd);
            }
  
           
            gd?.DrawString(_font, Convert.ToInt32(_fighter.PercentDmgValue).ToString() + "%" , new Vector2(550, 50), Color.Red);
            gd?.DrawString(_font, Convert.ToInt32(_fighter2.PercentDmgValue).ToString() + "%", new Vector2(1250, 50), Color.Orange);
            gd?.DrawString(_font, Convert.ToInt32(_fighter.Lives).ToString() + " Lives", new Vector2(550, 100), Color.Red);
            gd?.DrawString(_font, Convert.ToInt32(_fighter2.Lives).ToString() + " Lives", new Vector2(1250, 100), Color.Orange);
           

            

            
        }
      
        public override void Update(GameTime gameTime)
        {
            

            foreach (var item in _world.Entities)
            {
                item.Update(gameTime, _world);

            }
            cm.HandleCollisons(_world.Entities);
            
            if(_fighter.Lives == 0 || _fighter2.Lives == 0)
            {
                _fighter.Reset();
                _fighter2.Reset();
                OnScreenChange("VictoryScreen");
                
            }



                base.Update(gameTime);
        }
    }
}
