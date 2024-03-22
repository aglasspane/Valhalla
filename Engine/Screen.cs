using Microsoft.Xna.Framework;
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
        protected Texture2D _box;
        protected Texture2D _player2;
        protected Texture2D _solidColor;
        protected GraphicsDevice _device;
   
        public Screen(GraphicsDevice device, Texture2D box, Texture2D player2) 
        {
            _device = device;   
            _solidColor = new Texture2D(_device, 1, 1);
            _solidColor.SetData(new[] { Color.White });
            _box = box;
            _player2 = player2;
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
