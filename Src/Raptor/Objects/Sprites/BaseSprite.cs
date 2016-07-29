using Microsoft.Xna.Framework.Content;

namespace Raptor.Android.Objects.Sprites {
    public abstract class BaseSprite : BaseObject {
        internal abstract string TextureName();

        public BaseSprite(ContentManager cManager, string textureName = null) : base(cManager, textureName) { }

        public override string GetTextureName() => $"Sprites/{TextureName()}";
    }
}