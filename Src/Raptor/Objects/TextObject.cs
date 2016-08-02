using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Raptor.Android.Objects {
    public class TextObject {
        private readonly SpriteFont _font;
        private readonly Vector2 _origin;
        private readonly Vector2 _position;
        private readonly Color _color;
        private readonly float _size;
        private readonly string _text;

        public TextObject(SpriteFont font, string text, Vector2? position, Color color, float size, Vector2? origin) {
            _font = font;

            _color = color;

            if (origin == null) {
                _origin = _font.MeasureString(text) / 2;
            } else {
                _origin = origin.Value;
            }

            _text = text;
            _size = size;
            _position = position ?? new Vector2(GlobalGame.WINDOW_WIDTH / 2, GlobalGame.WINDOW_HEIGHT / 2);
        }

        public void DrawText(SpriteBatch _spriteBatch) {
            _spriteBatch.DrawString(_font, _text, _position, _color, 0, _origin, _size, SpriteEffects.None, 0.5f);
        }
    }
}