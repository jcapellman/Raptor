using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

using Raptor.PCL.Enums;

namespace Raptor.Android.GameStates {
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

            MediaPlayer.Play(_bgMusic);
            MediaPlayer.IsRepeating = true;
        }

        protected SpriteFont _gameFont;

        public void LoadFont(string fontName, ContentManager cManager) {
            _gameFont = cManager.Load<SpriteFont>($"Fonts/{fontName}");
        }
        
        protected Texture2D _background;

        public void LoadBackground(ContentManager cManager) {
            LoadBackground(ContentName, cManager);
        }

        public void LoadButton(ContentManager cManager) {
            _buttonTexture = LoadUITexture("Button", cManager);
        }

        public void LoadBackground(string name, ContentManager cManager) {
            _background = LoadTexture2D($"Backgrounds/{name}", cManager);
        }

        public Texture2D LoadUITexture(string name, ContentManager cManager) {
            return LoadTexture2D($"UI/{name}", cManager);
        }

        public Texture2D LoadTexture2D(string textureName, ContentManager cManager) {
            return cManager.Load<Texture2D>(textureName);
        }

        public void DrawBackground() {
            _spriteBatch.Draw(_background, destinationRectangle: _graphics.GraphicsDevice.Viewport.Bounds, color: Color.White);
        }

        public void DrawText(string text, float size, TEXT_HORIZONTAL_ALIGNMENT hAlign, TEXT_VERTICAL_ALIGNMENT vAlign, Color? color = null, int xOffset = 0, int yOffset = 0) {
            if (color == null) {
                color = Color.White;
            }

            var position = new Vector2();
            var origin = new Vector2();

            switch (hAlign) {
                case TEXT_HORIZONTAL_ALIGNMENT.CENTER:
                    position.X = _window.ClientBounds.Width/2;
                    origin.X = _window.ClientBounds.Width /2;
                    break;
                case TEXT_HORIZONTAL_ALIGNMENT.LEFT:
                    position.X =50;
                    origin.X = 10;
                    break;
                case TEXT_HORIZONTAL_ALIGNMENT.RIGHT:
                    position.X = _window.ClientBounds.Width - _gameFont.MeasureString(text).X - 10;
                    origin.X = _window.ClientBounds.Width;
                    break;
            }

            switch (vAlign) {
                case TEXT_VERTICAL_ALIGNMENT.BOTTOM:
                    origin.Y = _window.ClientBounds.Height - _gameFont.MeasureString(text).Y - 10;
                    position.Y = _window.ClientBounds.Height - _gameFont.MeasureString(text).Y - 10;
                    break;
                case TEXT_VERTICAL_ALIGNMENT.CENTER:
                    origin.Y = _gameFont.MeasureString(text).Y / 2;
                    position.Y = _window.ClientBounds.Height/2;
                    break;
                case TEXT_VERTICAL_ALIGNMENT.TOP:
                    origin.Y = 10;
                    position.Y = _gameFont.MeasureString(text).Y + 35;
                    break;
            }

            position.X += xOffset;
            position.Y += yOffset;

            DrawText(text, position, color.Value, size, origin);
        }

        public void DrawUIElement(Texture2D texture, TEXT_HORIZONTAL_ALIGNMENT hAlign, TEXT_VERTICAL_ALIGNMENT vAlign, int xOffset = 0, int yOffset = 0) {            
            var position = new Vector2();
            
            switch (hAlign) {
                case TEXT_HORIZONTAL_ALIGNMENT.CENTER:
                    position.X = _window.ClientBounds.Width / 2;         
                    break;
                case TEXT_HORIZONTAL_ALIGNMENT.LEFT:
                    position.X = 0 + xOffset;
                    break;
                case TEXT_HORIZONTAL_ALIGNMENT.RIGHT:
                    position.X = _window.ClientBounds.Width - texture.Width - 10 - xOffset;
                    break;
            }

            switch (vAlign) {
                case TEXT_VERTICAL_ALIGNMENT.BOTTOM:
                    position.Y = _window.ClientBounds.Height - texture.Height;
                    break;
                case TEXT_VERTICAL_ALIGNMENT.CENTER:
                    position.Y = _window.ClientBounds.Height/2;
                    break;
                case TEXT_VERTICAL_ALIGNMENT.TOP:
                    position.Y = yOffset;
                    break;
            }
            
            _spriteBatch.Draw(texture, position, Color.White);
        }

        private Texture2D _buttonTexture;

        public void DrawButton(string text, Color color, TEXT_HORIZONTAL_ALIGNMENT hAlign, TEXT_VERTICAL_ALIGNMENT vAlign, int xOffset = 0, int yOffset = 0) {
            var position = new Vector2();

            switch (hAlign) {
                case TEXT_HORIZONTAL_ALIGNMENT.CENTER:
                    position.X = _window.ClientBounds.Width / 2;
                    break;
                case TEXT_HORIZONTAL_ALIGNMENT.LEFT:
                    position.X = 0 + xOffset;
                    break;
                case TEXT_HORIZONTAL_ALIGNMENT.RIGHT:
                    position.X = _window.ClientBounds.Width - _buttonTexture.Width - 10 - xOffset;
                    break;
            }

            switch (vAlign) {
                case TEXT_VERTICAL_ALIGNMENT.BOTTOM:
                    position.Y = _window.ClientBounds.Height - _buttonTexture.Height;
                    break;
                case TEXT_VERTICAL_ALIGNMENT.CENTER:
                    position.Y = _window.ClientBounds.Height / 2;
                    break;
                case TEXT_VERTICAL_ALIGNMENT.TOP:
                    position.Y = yOffset;
                    break;
            }

            var textWidth = _gameFont.MeasureString(text).X;
            var textHeight = _gameFont.MeasureString(text).Y;

            var textPosition = new Vector2();

            textPosition.X = position.X + ((_buttonTexture.Width - textWidth)/2) + 20;
            textPosition.Y = position.Y + ((_buttonTexture.Height - textHeight) / 2) + 10;

            _spriteBatch.Draw(_buttonTexture, position, Color.White);
            DrawText(text, textPosition, color, 3.0f, null);
        }

        public void DrawText(string text, Vector2? position, Color color, float size, Vector2? origin) {
            if (origin == null) {
                origin = _gameFont.MeasureString(text) / 2;
            }

            if (position == null) {
               position = new Vector2(_window.ClientBounds.Width / 2, _window.ClientBounds.Height / 2);
            }

            _spriteBatch.DrawString(_gameFont, text, position.Value, Color.White, 0, origin.Value, size, SpriteEffects.None, 0.5f);
        }

        public abstract void Update(GameTime gameTime);
    }
}