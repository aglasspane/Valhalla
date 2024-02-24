using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class Renderer
    {
        protected GraphicsDevice graphicsDevice;

        protected SpriteBatch spriteBatch;

        public Renderer(GraphicsDevice g, SpriteBatch sb)
        { 
            graphicsDevice = g;
            spriteBatch = sb;
        }

        void Draw(List<IRenderable> renderList)
        {
            
        }
    }
}
