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
        //protected List<Moveable> moveables = new List<Moveable>();

        public SpriteFont? Font { get; set; }


       // public GameScreen(GraphicsDevice d, Texture2D t, Texture2D t2) : base(d, t, t2)
       public GameScreen(GraphicsDevice device, ContentManager content) : base(device, content) 
        {
            _world = new GameWorld(content);
            Texture2D t = _world.Content.Load<Texture2D>("Man");
            Texture2D t2 = _world.Content.Load<Texture2D>("Man");
            Font = _world.Content.Load<SpriteFont>("GameFont");

            //These are the characters that spawn at the start 
            _fighter = new Fighter(t, new Vector2(200,0), 0 , Direction.Right, new Rectangle(0, 0, 64, 64), new Rectangle(-650, -650, 64, 64));
            _fighter2 = new Fighter(t2, new Vector2(1200, 0), 1, new Rectangle(400,0,64,64), new Rectangle(-600,-600,64 ,64));
            _world.Entities.Add(_fighter);
            _world.Entities.Add(_fighter2);
        }

        public override void Draw(GameTime gameTime, SpriteBatch? gd)
        {
            foreach (var item in _world.Entities)
            {
                
                foreach (var collider in item.Colliders)
                {
                    if(gd != null)
                    {
                        DrawRectangle(gd, collider.Bounds.X + (int)collider.Owner.Position.X, collider.Bounds.Y + (int)collider.Owner.Position.Y, collider.Bounds.Width, collider.Bounds.Height, Color.Red);
                    }
                    
                }
                item.Draw(gameTime, gd);
            }
            //_fighter.Draw(gameTime, gd);
            //_fighter2.Draw(gameTime, gd);

            if(Font != null) 
            {
                gd?.DrawString(Font, Convert.ToInt32(_fighter.PercentDmgValue).ToString() + "%" , new Vector2(550, 50), Color.Red);
                gd?.DrawString(Font, Convert.ToInt32(_fighter2.PercentDmgValue).ToString() + "%", new Vector2(1250, 50), Color.Orange);
            }

            

            base.Draw(gameTime, gd);
        }
      
        public override void Update(GameTime gameTime)
        {
            
            //cm.HandleHit(_fighter, _fighter2);
            foreach (var item in _world.Entities)
            {
                item.Update(gameTime, _world);

            }
            cm.HandleCollisons(_world.Entities);
            
            
            


            base.Update(gameTime);
        }
    }
}
