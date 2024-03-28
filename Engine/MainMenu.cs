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
    public class MainMenu : MenuScreen
    {
        public MainMenu(GraphicsDevice d, ContentManager content) : base(d, content)
        {
        
        }

        public override void Draw(GameTime gameTime, SpriteBatch? sb)
        {
            if (sb != null)
            {
                DrawRectangle(sb, 10, 10, 100, 100, Color.Aqua);
            }
            base.Draw(gameTime, sb);
        }
    }
}
