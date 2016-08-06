using System;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Raptor.GameEngine.PCL;
using Raptor.GameEngine.PCL.GameStates;
using Raptor.GameEngine.PCL.Objects;
using Raptor.GameEngine.PCL.Objects.Menu;
using Raptor.PCL.Enums;
using Raptor.PCL.WebAPI.Handlers;

namespace Raptor.Android.GameStates.PCL {
    public class MainMenuState : BaseGameState {
        private bool _isLocked = true;

        public override GAME_STATES GetGameState() => GAME_STATES.MAIN_MENU;

        public override GAME_STATES EventOnBack() => GAME_STATES.EXIT;

        public override bool IsLocked() => _isLocked;

        public override void Update(GameTime gameTime) { }

        public MainMenuState(SpriteBatch spriteBatch, GameWindow window, GraphicsDeviceManager graphics) : base(spriteBatch, window, graphics) { }

        private MainMenuAnimation _mainMenuAni;

        private async Task<bool> CheckServerContent() {
            var contentHandler = new ContentHandler();

            var serverFiles = await contentHandler.GetServerContent();

            if (serverFiles.HasError) {
                throw new Exception(serverFiles.ExceptionMessage);
            }

            var filesNeedingUpdates = GlobalGame.FileSystem.GetHigherVersionFilesList(serverFiles.ReturnValue);

            var updatedFiles = await contentHandler.GetFiles(filesNeedingUpdates);

            if (updatedFiles.HasError) {
                throw new Exception(updatedFiles.ExceptionMessage);
            }

            GlobalGame.FileSystem.AddFiles(updatedFiles.ReturnValue);

            return true;
        }

        public override async void LoadContent(ContentManager contentManager) {
            LoadFont("GameFont", contentManager);
            
            _mainMenuAni = new MainMenuAnimation(contentManager, null, "MainMenu");    
            
            _toLoading = new TextObject(_gameFont, "LOADING", Color.White, size: 5.0f);

            var sync = await CheckServerContent();

            if (sync) {
                ChangeState(GAME_STATES.MAIN_GAME);
            }
        }

        private int increment = 0;
        private string loadingText = "LOADING";
        private TextObject _toLoading;

        private void RenderLoadingIndicator() {
            if (increment == 100) {
                increment = 0;
                _toLoading.SetText("LOADING");
                loadingText = "LOADING";
            } else {
                increment += 1;

                if (increment % 10 == 0) {                
                    _toLoading.SetText(".", true);
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