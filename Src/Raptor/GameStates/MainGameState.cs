using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

using Raptor.Android.Objects.Planes;
using Raptor.PCL.Enums;

namespace Raptor.Android.GameStates {
    public class MainGameState : BaseGameState {
        public override GAME_STATES GetGameState() => GAME_STATES.MAIN_GAME;

        public override GAME_STATES EventOnBack() => GAME_STATES.MAIN_MENU;

        public MainGameState(SpriteBatch spriteBatch, GameWindow window, GraphicsDeviceManager graphics) : base(spriteBatch, window, graphics) { }

        public override bool IsLocked() {
            return false;
        }

        public override void HandleInput(GameTime gameTime) {
            var desiredVelocity = new Vector2();

            var touchCollection = TouchPanel.GetState();

            if (touchCollection.Count <= 0) {
                return;
            }

            desiredVelocity.X = touchCollection[0].Position.X - _playerFighter.GetPosition().X;
            desiredVelocity.Y = touchCollection[0].Position.Y - _playerFighter.GetPosition().Y;

            if (desiredVelocity.X != 0 || desiredVelocity.Y != 0) {
                desiredVelocity.Normalize();
                const float desiredSpeed = 1600;
                desiredVelocity *= desiredSpeed;
            }

            _playerFighter.Position(desiredVelocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds, desiredVelocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        public override void LoadContent(ContentManager contentManager) {
            LoadFont("GameFont", contentManager);

            _playerFighter = new F22(contentManager);
        }

        public override void Render() {
            _spriteBatch.Begin();

            DrawText($"Score: 0", 14, TEXT_HORIZONTAL_ALIGNMENT.CENTER, TEXT_VERTICAL_ALIGNMENT.TOP, Color.White);

            _playerFighter.Draw(_spriteBatch);

            _spriteBatch.End();
        }
    }
}