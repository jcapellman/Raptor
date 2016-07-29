using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Raptor.Android.Objects.Sprites {
    public class PlayerBullet : BaseSprite {
        public PlayerBullet(ContentManager cManager, string textureName = null) : base(cManager, textureName) { }

        internal override string TextureName() => "PlayerBullet";

        public override void Update() {
            _velocity = new Vector2((float)Math.Cos(0) * 1, (float)Math.Sin(0) * 1);

            Position(GetPosition().X, GetPosition().Y + 1, false);

            base.Update();
        }
    }
}