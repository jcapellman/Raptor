using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

using Raptor.Android.Objects.Levels;
using Raptor.Android.Objects.Sprites;
using Raptor.PCL.Enums;

namespace Raptor.Android.GameStates {
    public class MainGameState : BaseGameState {
        public override GAME_STATES GetGameState() => GAME_STATES.MAIN_GAME;

        public override GAME_STATES EventOnBack() => GAME_STATES.MAIN_MENU;

        public MainGameState(SpriteBatch spriteBatch, GameWindow window, GraphicsDeviceManager graphics) : base(spriteBatch, window, graphics) { }

        public override bool IsLocked() {
            return false;
        }

        public override void Update(GameTime gameTime) {
            _currentLevel.Update();

            var newBullet = _baseBullet;

            newBullet.Position(_currentLevel._playerFighter.GetPosition().X, _currentLevel._playerFighter.GetPosition().Y + 2);

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

        public override void LoadContent(ContentManager contentManager) {
            LoadFont("GameFont", contentManager);

            _baseBullet = new PlayerBullet(contentManager);

            _currentLevel = new E1M1(contentManager);
        }

        public override void Render() {
            _spriteBatch.Begin();

            _currentLevel.Draw(_spriteBatch);

            DrawText($"Score: 0", new Vector2((GlobalGame.WINDOW_WIDTH / 2), GlobalGame.WINDOW_HEIGHT - 60),  Color.White, 8.0f, null);

            foreach (var bullet in _playerBullets) {
                bullet.Draw(_spriteBatch);
            }

            _spriteBatch.End();
        }
    }
}