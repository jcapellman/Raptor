using System.Collections.Generic;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Raptor.Android.Objects.Tiles;

namespace Raptor.Android.Objects.Levels {
    public abstract class BaseLevel {
        public abstract string Name();

        private readonly List<BaseTile> _tiles = new List<BaseTile>();

        internal void AddTile(ContentManager cManager, string tileName) {
            _tiles.Add(new BaseTile(cManager, tileName));
        }

        protected BaseLevel(ContentManager cManager, string levelJSON) {
            AddTile(cManager, "Stone");
        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach (var tile in _tiles) {
                tile.Draw(spriteBatch);                
            }
        }
    }
}