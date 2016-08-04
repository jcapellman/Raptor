using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Raptor.Android.Objects;
using Raptor.Android.Objects.Menu;
using Raptor.PCL.Enums;

namespace Raptor.Android.GameStates {
    public class MainMenuState : BaseGameState {
        private bool _isLocked = true;

        public override GAME_STATES GetGameState() => GAME_STATES.MAIN_MENU;

        public override GAME_STATES EventOnBack() => GAME_STATES.EXIT;

        public override bool IsLocked() => _isLocked;

        public override void Update(GameTime gameTime) { }

        public MainMenuState(SpriteBatch spriteBatch, GameWindow window, GraphicsDeviceManager graphics) : base(spriteBatch, window, graphics) { }

        private MainMenuAnimation _mainMenuAni;

        public override void LoadContent(ContentManager contentManager) {
            LoadFont("GameFont", contentManager);
            
            _mainMenuAni = new MainMenuAnimation(contentManager, null, "MainMenu");    
            
            _toLoading = new TextObject(_gameFont, "LOADING", Color.White, size: 5.0f);

          //  ChangeState(GAME_STATES.MAIN_GAME);
        }

        private int increment = 0;
        private string loadingText = "LOADING";
        private TextObject _toLoading;

        private void RenderLoadingIndicator() {
            if (increment == 100) {
                increment = 0;
                loadingText = "LOADING";
            } else {
                increment += 1;

                if (increment % 10 == 0) {                
                    loadingText += ".";
                }
            }
        }

        public override void Render() {
            _spriteBatch.Begin();

            _mainMenuAni.Draw(_spriteBatch);

            if (IsLocked()) {
                RenderLoadingIndicator();
            }

            _toLoading.DrawText(_spriteBatch);

            _spriteBatch.End();
        }
    }
}