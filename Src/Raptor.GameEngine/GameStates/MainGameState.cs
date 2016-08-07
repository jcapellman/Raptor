using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

using Raptor.GameEngine.Objects;
using Raptor.GameEngine.Objects.Levels;
using Raptor.GameEngine.Objects.Sprites;
using Raptor.PCL.Enums;

namespace Raptor.GameEngine.GameStates {
    public class MainGameState : BaseGameState {
        public override GAME_STATES GetGameState() => GAME_STATES.MAIN_GAME;

        public override GAME_STATES EventOnBack() => GAME_STATES.MAIN_MENU;

        public MainGameState(SpriteBatch spriteBatch, GameWindow window, GraphicsDeviceManager graphics) : base(spriteBatch, window, graphics) { }

        public override bool IsLocked() {
            return false;
        }

        public override void Update(GameTime gameTime) {
            _currentLevel.Update();

            var newBullet = new PlayerBullet(null, _baseBullet.GetTexture());

            newBullet.Position(_currentLevel._playerFighter.GetPosition().X + _currentLevel._playerFighter._texture.Width / 2, _currentLevel._playerFighter.GetPosition().Y + 2, false);

            _playerBullets.Add(newBullet);

            for (var x = 0; x < _playerBullets.Count; x++) {
                if (_playerBullets[x].GetPosition().Y > GlobalGame.WINDOW_HEIGHT) {
                    _playerBullets.RemoveAt(x);
                } else {
                    _playerBullets[x].Update();
                }
            }

            var desiredVelocity = new Vector2();

            var touchCollection = TouchPanel.GetState();

            if (touchCollection.Count <= 0) {
                return;
            }

            desiredVelocity.X = touchCollection[0].Position.X - _currentLevel.PlayerPosition.X;
            desiredVelocity.Y = touchCollection[0].Position.Y - _currentLevel.PlayerPosition.Y;

            if (desiredVelocity.X != 0 || desiredVelocity.Y != 0) {
                desiredVelocity.Normalize();
                const float desiredSpeed = 1600;
                desiredVelocity *= desiredSpeed;
            }

            _currentLevel._playerFighter.Position(desiredVelocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds, desiredVelocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        private BaseLevel _currentLevel;
        private readonly List<PlayerBullet> _playerBullets = new List<PlayerBullet>();
        private PlayerBullet _baseBullet;
        private TextObject _toScore;

        public override void LoadContent(ContentManager contentManager) {
            LoadFont("GameFont", contentManager);

            _baseBullet = new PlayerBullet(contentManager);

            _currentLevel = new E1M1(contentManager);

            _toScore = new TextObject(_gameFont, "Score: 0", Color.White, size: 14.0f);
        }

        public override void Render() {
            _spriteBatch.Begin();

            _currentLevel.Draw(_spriteBatch);

            _toScore.DrawText(_spriteBatch);

            foreach (var bullet in _playerBullets) {
                bullet.Draw(_spriteBatch);
            }

            _spriteBatch.End();
        }
    }
}