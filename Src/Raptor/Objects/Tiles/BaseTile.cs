using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Raptor.Android.Objects.Tiles {
    public class BaseTile : BaseObject {
        private readonly string _textureName;

        public BaseTile(ContentManager cManager, string tileName) : base(cManager, $"Tiles/{tileName}") {
            _textureName = tileName;
        }

        public override void Update() {
            Position(0, 5);
        }

        public override string GetTextureName() => $"Tiles/{_textureName}";

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(_texture, GetPosition());
        }
    }
}