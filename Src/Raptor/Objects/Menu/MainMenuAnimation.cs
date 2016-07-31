using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Raptor.Android.Objects.Menu {
    public class MainMenuAnimation : BaseObject {
        public MainMenuAnimation(ContentManager cManager, Texture2D texture = null, string textureName = null) : base(cManager, texture, textureName) {
            IsFullScreen = true;
        }

        internal string TextureName() => "MainMenu";

        public override string GetTextureName() => $"Menu/{TextureName()}";

        public override void Update() {
            _velocity = new Vector2(0, -10);

            Position(_velocity.X, _velocity.Y);

            base.Update();
        }
    }
}