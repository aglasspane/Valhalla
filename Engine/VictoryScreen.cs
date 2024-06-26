﻿using Microsoft.Xna.Framework;
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
    internal class VictoryScreen : Screen
    {
        
        public VictoryScreen(GraphicsDevice device, ContentManager content) : base(device, content)
        {
            _background = content.Load<Texture2D>("VictoryBackground");
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if(GamePad.GetState(0).IsButtonDown(Buttons.B) || GamePad.GetState(1).IsButtonDown(Buttons.B))
            {
                OnScreenChange("MainMenu");
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch? gd)
        {
            base.Draw(gameTime, gd);
            //Draw background here
            DrawCenteredString(gd, "VICTORY!", Color.Gold, null);
            DrawCenteredString(gd, "Press B to return to main menu", Color.Gold, 712);

        }
    }
}
