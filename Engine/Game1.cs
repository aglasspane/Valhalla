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

   

        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;

            _graphics.IsFullScreen = true; 

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
     
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Content.RootDirectory = "Content";
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            MainMenu mainMenu = new MainMenu(GraphicsDevice, Content);
            mainMenu.ScreenChange += ChangeActiveScreen;
            _screens.Add("MainMenu", mainMenu);
            // TODO: use this.Content to load your game content here


            

            GameScreen gameScreen = new GameScreen(GraphicsDevice, Content);
            gameScreen.ScreenChange += ChangeActiveScreen;
            _screens.Add("GameScreen", gameScreen);



            VictoryScreen victoryScreen = new VictoryScreen(GraphicsDevice, Content);
            victoryScreen.ScreenChange += ChangeActiveScreen;
            _screens.Add("VictoryScreen", victoryScreen);




            ChangeActiveScreen(null,"MainMenu");


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
        public void ChangeActiveScreen(object? sender, string screenName)
        {
            _activeScreen = _screens[screenName];
        }
    }
}