using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.ComponentModel;

namespace Engine
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Dictionary<string, Screen> _screens = new Dictionary<string, Screen>();
        private Screen _activeScreen; 

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _screens.Add("MainMenu", new MainMenu());


        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //_spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.M))
            {
                ChangeActiveScreen("MainMenu");
            }











            if (_activeScreen != null)
            {
                _activeScreen.Update(gameTime);
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (_activeScreen != null)
            {
                _activeScreen.Draw(gameTime);
            }


            base.Draw(gameTime);
        }
        public void ChangeActiveScreen(string screenName)
        {
            _activeScreen = _screens[screenName];
        }
    }
}