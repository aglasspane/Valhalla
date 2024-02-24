using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal interface IRenderable
    {
        void Draw(GraphicsDevice g, SpriteBatch sb);
    }
}
