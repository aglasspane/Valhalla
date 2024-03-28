using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
            
            base.Draw(gameTime, sb);
            DrawCenteredString(sb, "VALHALLA", Color.Red, 200);
            DrawCenteredString(sb, "Battleground of the gods", Color.Red, 300);

            DrawCenteredString(sb, "Press A to start", Color.Red, null);

        }

        public override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(0).IsButtonDown(Buttons.A) || GamePad.GetState(1).IsButtonDown(Buttons.A))
            {
                OnScreenChange("GameScreen");
            }
        }

    }
}
