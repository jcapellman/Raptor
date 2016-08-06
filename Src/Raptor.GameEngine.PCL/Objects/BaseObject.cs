using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Raptor.GameEngine.PCL.Objects {
    public abstract class BaseObject {
        public abstract string GetTextureName();

        private Vector2 _position { get; set; }

        internal Vector2 _velocity { get; set; }

        internal readonly Texture2D _texture;

        internal bool IsFullScreen = false;

        public void Position(float x, float y, bool append = true) {
            if (append) {
                x += _position.X;
                y += _position.Y;
            }

            _position = new Vector2(x, y);
        }

        public Vector2 GetPosition() => _position;

        private Rectangle GetRectange() {
            return new Rectangle((int)GetPosition().X, (int)GetPosition().Y, _texture.Width, _texture.Height);
        }

        public virtual bool GetCollision(Rectangle other) {
            var bounds = GetRectange();

            return (bounds.Right >= other.Left && bounds.Left < other.Right ||
                    bounds.Left <= other.Right && bounds.Right > other.Left) &&
                   (bounds.Bottom >= other.Top && bounds.Top < other.Bottom ||
                    bounds.Top <= other.Bottom && bounds.Bottom > other.Top);
        }

        protected BaseObject(ContentManager cManager, Texture2D texture = null, string textureName = null) {
            _texture = texture ?? cManager.Load<Texture2D>(textureName ?? GetTextureName());

            _velocity = new Vector2();
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            if (IsFullScreen) {
                spriteBatch.Draw(_texture,
                    destinationRectangle: new Rectangle(0, 0, GlobalGame.WINDOW_WIDTH, GlobalGame.WINDOW_HEIGHT));
            } else {
                spriteBatch.Draw(_texture, _position);
            }
        }

        public virtual void Update() { }

        public Texture2D GetTexture() => _texture;
    }
}