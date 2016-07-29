using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Raptor.Android.Objects.Sprites {
    public class PlayerBullet : BaseSprite {
        public PlayerBullet(ContentManager cManager, Texture2D texture = null, string textureName = null) : base(cManager, texture, textureName) { }

        internal override string TextureName() => "PlayerBullet";

        public override void Update() {
            _velocity = new Vector2(0, -10);

            Position(_velocity.X, _velocity.Y);

            base.Update();
        }        
    }
}