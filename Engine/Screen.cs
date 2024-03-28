using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Screen 
    {

        protected Texture2D _solidColor;
        protected GraphicsDevice _device;
   
        public Screen(GraphicsDevice device, ContentManager content) 
        {
            _device = device;   
            _solidColor = new Texture2D(_device, 1, 1);
            _solidColor.SetData(new[] { Color.White });
            
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(GameTime gameTime, SpriteBatch? gd)
        {

        }

        protected void DrawRectangle(SpriteBatch sb, int x, int y, int width, int height, Color c)
        {
            sb.Draw(_solidColor, new Rectangle(x, y, width, height), c);
        }
    }
}
