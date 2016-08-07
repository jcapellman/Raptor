using Microsoft.Xna.Framework.Content;

namespace Raptor.GameEngine.Objects.Planes {
    public class F22 : BasePlane {
        internal override string TextureName() => "F22";

        public F22(ContentManager cManager) : base(cManager) { }
    }
}