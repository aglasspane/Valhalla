using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace Engine
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch? _spriteBatch;
        private Dictionary<string, Screen> _screens = new Dictionary<string, Screen>();
        private Screen? _activeScreen;
        private Texture2D? _myWhiteBox;

        private Renderer? _renderer;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
    
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
     
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _renderer = new Renderer(GraphicsDevice, _spriteBatch);

            _myWhiteBox = new Texture2D(GraphicsDevice, 1, 1);
            _myWhiteBox.SetData(new[] { Color.White });

            _screens.Add("MainMenu", new MainMenu(_myWhiteBox, new Texture2D(GraphicsDevice, 1, 1)));
            // TODO: use this.Content to load your game content here
            //ChangeActiveScreen("MainMenu");

            Content.RootDirectory = "Content";
            Texture2D spritesheet = Content.Load<Texture2D>("Man");
            Texture2D anotherSpritesheet = Content.Load<Texture2D>("Man");

            _screens.Add("GameScreen", new GameScreen(spritesheet, anotherSpritesheet));
            ChangeActiveScreen("GameScreen");


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _activeScreen?.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch?.Begin();
            _activeScreen?.Draw(gameTime, _spriteBatch);
            _spriteBatch?.End();

            base.Draw(gameTime);


        }
        public void ChangeActiveScreen(string screenName)
        {
            _activeScreen = _screens[screenName];
        }
    }
}