using Microsoft.Xna.Framework.Content;

namespace Raptor.GameEngine.PCL.Objects.Planes {
    public abstract class BasePlane : BaseObject {
        internal abstract string TextureName();

        public override string GetTextureName() => $"Planes/{TextureName()}";

        protected BasePlane(ContentManager cManager) : base(cManager) { }
    }
}