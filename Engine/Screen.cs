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

        public event EventHandler<string>? ScreenChange;

        public SpriteFont _font;

        public Screen(GraphicsDevice device, ContentManager content)
        {
            _device = device;
            _solidColor = new Texture2D(_device, 1, 1);
            _solidColor.SetData(new[] { Color.White });
            _font = content.Load<SpriteFont>("GameFont");
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
        protected virtual void OnScreenChange(string e)
        {
            ScreenChange?.Invoke(this, e);
        }
        protected void DrawCenteredString(SpriteBatch? gd, string str, Color colour, float? yPos)
        {
            Vector2 stringSize = _font.MeasureString(str);
            float x = (_device.DisplayMode.Width / 2) - (stringSize.X / 2);
            float y = yPos.GetValueOrDefault((_device.DisplayMode.Height / 2) - (stringSize.Y / 2));

            gd?.DrawString(_font, str, new Vector2(x, y), colour);

        }
    }
}
