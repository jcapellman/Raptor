using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Raptor.GameEngine.Objects.Tiles {
    public class BaseTile : BaseObject {
        private readonly string _textureName;

        public BaseTile(ContentManager cManager, string tileName) : base(cManager, null, $"Tiles/{tileName}") {
            _textureName = tileName;
        }

        public override void Update() {
            Position(0, 5);
        }

        public override string GetTextureName() => $"Tiles/{_textureName}";
        
        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(_texture, new Rectangle(0, (int) GetPosition().Y, GlobalGame.WINDOW_WIDTH, GlobalGame.WINDOW_HEIGHT), Color.White);
        }
    }
}