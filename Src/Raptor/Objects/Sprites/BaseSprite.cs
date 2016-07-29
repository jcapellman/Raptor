using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Raptor.Android.Objects.Sprites {
    public abstract class BaseSprite : BaseObject {
        internal abstract string TextureName();

        public BaseSprite(ContentManager cManager, Texture2D texture = null, string textureName = null) : base(cManager, texture, textureName) { }

        public override string GetTextureName() => $"Sprites/{TextureName()}";
    }
}