using Microsoft.Xna.Framework;
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
        public MainMenu(Texture2D t, Texture2D t2) : base(t, t2) 
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
