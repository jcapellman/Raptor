using System;
using System.Reflection;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Raptor.GameEngine.GameStates;
using Raptor.Library.Enums;
using Raptor.Library.FileSystem;

namespace Raptor.GameEngine {
    public class MainGame : Game {
        readonly GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        private BaseGameState _currentGameState;
        
        public MainGame() {
          //  GlobalGame.FileSystem = fileSystem;

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _graphics.IsFullScreen = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 480;
            _graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;

            GlobalGame.WINDOW_HEIGHT = Window.ClientBounds.Height;
            GlobalGame.WINDOW_WIDTH = Window.ClientBounds.Width;
        }

        private void _currentGameState_OnChangeState(object sender, BaseGameState.GameStateArgs e) {
            changeGameState(e.GameState);
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            changeGameState(GAME_STATES.MAIN_MENU);
        }

        private void changeGameState(GAME_STATES gameState) {
            switch (gameState) {
                case GAME_STATES.MAIN_MENU:
                    _currentGameState = new MainMenuState(_spriteBatch, Window, _graphics);
                   
                    break;
                case GAME_STATES.MAIN_GAME:
                    _currentGameState = new MainGameState(_spriteBatch, Window, _graphics);
                    break;
            }

            _currentGameState.OnChangeState += _currentGameState_OnChangeState;
            _currentGameState.LoadContent(this.Content);          
        }

        protected override void Update(GameTime gameTime) {
            if (_currentGameState.IsLocked()) {
                return;
            }

            _currentGameState.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            _currentGameState.Render();

            base.Draw(gameTime);
        }
    }
}