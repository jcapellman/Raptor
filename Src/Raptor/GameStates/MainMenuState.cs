using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Raptor.PCL.Enums;

namespace Raptor.Android.GameStates {
    public class MainMenuState : BaseGameState {
        private bool _isLocked = true;

        public override GAME_STATES GetGameState() => GAME_STATES.MAIN_MENU;

        public override GAME_STATES EventOnBack() => GAME_STATES.EXIT;

        public override bool IsLocked() => _isLocked;

        public override void HandleInput(GameTime gameTime) { }

        public MainMenuState(SpriteBatch spriteBatch, GameWindow window, GraphicsDeviceManager graphics) : base(spriteBatch, window, graphics) { }

        public override void LoadContent(ContentManager contentManager) {
            LoadFont("GameFont", contentManager);
            LoadBackground(contentManager);
            
            ChangeState(GAME_STATES.MAIN_GAME);
        }

        private int increment = 0;
        private string loadingText = "LOADING";

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

            DrawBackground();

            if (IsLocked()) {
                RenderLoadingIndicator();
            }

            DrawText(loadingText, null, Color.White, 5.0f, null);

            _spriteBatch.End();
        }
    }
}