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
   
        public Screen(Texture2D box) 
        {
              _box = box;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(GameTime gameTime, SpriteBatch? gd)
        {

        }

        protected void DrawRectangle(SpriteBatch sb, int x, int y, int width, int height, Color c)
        {
            sb.Draw(_box, new Rectangle(x, y, width, height), c);
        }
    }
}
