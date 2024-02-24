using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class RectangleRenderable : IRenderable
    {
        public Rectangle Rectangle { get; set; }

        public void Draw(GraphicsDevice g, SpriteBatch sb)
        {
            throw new NotImplementedException();
        }
    }
}
