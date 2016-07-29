using System;
using System.Reflection;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Raptor.Android.GameStates;
using Raptor.PCL.Enums;

namespace Raptor.Android {
    public class MainGame : Game {
        readonly GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        private BaseGameState _currentGameState;

        public MainGame() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _graphics.IsFullScreen = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 480;
            _graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
        }

        private void _currentGameState_OnChangeState(object sender, BaseGameState.GameStateArgs e) {
            changeGameState(e.GameState);
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            changeGameState(GAME_STATES.MAIN_MENU);
        }

        private void changeGameState(GAME_STATES gameState) {
            var types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var type in types) {
                if (!type.IsSubclassOf(typeof(BaseGameState)) || type.IsAbstract) {
                    continue;
                }

                var bGameState = (BaseGameState)Activator.CreateInstance(type, _spriteBatch, Window, _graphics);

                if (bGameState.GetGameState() != gameState) {
                    continue;
                }

                _currentGameState = bGameState;
                _currentGameState.OnChangeState += _currentGameState_OnChangeState;
                _currentGameState.LoadContent(this.Content);
            }
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