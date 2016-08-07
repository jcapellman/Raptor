using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

using Raptor.PCL.Enums;

namespace Raptor.GameEngine.GameStates {
    public abstract class BaseGameState {        
        public abstract GAME_STATES GetGameState();

        protected readonly SpriteBatch _spriteBatch;
        private readonly GameWindow _window;
        private readonly GraphicsDeviceManager _graphics;

        protected BaseGameState(SpriteBatch spriteBatch, GameWindow window, GraphicsDeviceManager graphics) {
            _spriteBatch = spriteBatch;
            _window = window;
            _graphics = graphics;
        }

        public abstract void LoadContent(ContentManager contentManager);

        public abstract void Render();

        public abstract GAME_STATES EventOnBack();

        public abstract bool IsLocked();

        public class GameStateArgs : EventArgs {
            public GameStateArgs(GAME_STATES gameState) {
                GameState = gameState;
            }

            public GAME_STATES GameState { get; }
        }

        public delegate void ChangeStateHandler(object sender, GameStateArgs e);

        public event ChangeStateHandler OnChangeState;

        protected void ChangeState(GAME_STATES gameState) {
            OnChangeState(this, new GameStateArgs(gameState));
        }

        private string ContentName => GetGameState().ToString().Replace("_", "");

        private Song _bgMusic;

        public void PlayMusic(ContentManager cManager) {
            PlayMusic(ContentName, cManager);
        }

        public void PlayMusic(string song, ContentManager cManager) {
            _bgMusic = cManager.Load<Song>($"Music/{song}");

         //   MediaPlayer.Play(_bgMusic);
        //    MediaPlayer.IsRepeating = true;
        }

        protected SpriteFont _gameFont;

        public void LoadFont(string fontName, ContentManager cManager) {
            _gameFont = cManager.Load<SpriteFont>($"Fonts/{fontName}");
        }
        
        public Texture2D LoadTexture2D(string textureName, ContentManager cManager) {
            return cManager.Load<Texture2D>(textureName);
        }
        
        public abstract void Update(GameTime gameTime);
    }
}