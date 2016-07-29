using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Raptor.Android.Objects {
    public abstract class BaseObject {
        public abstract string GetTextureName();

        private Vector2 _position { get; set; }

        private readonly Texture2D _texture;
        

        public void Position(float x, float y, bool append = true) {
            if (append) {
                x += _position.X;
                y += _position.Y;
            }

            _position = new Vector2(x, y);            
        }

        public Vector2 GetPosition() => _position;

        protected BaseObject(ContentManager cManager, string textureName = null) {            
            _texture = cManager.Load<Texture2D>(textureName ?? GetTextureName());            
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(_texture, _position);
        }
    }
}