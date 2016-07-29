using Microsoft.Xna.Framework.Content;

namespace Raptor.Android.Objects.Tiles {
    public class BaseTile : BaseObject {
        private readonly string _textureName;

        public BaseTile(ContentManager cManager, string tileName) : base(cManager, $"Tiles/{tileName}") {
            _textureName = tileName;
        }

        public override string GetTextureName() => $"Tiles/{_textureName}";
    }
}