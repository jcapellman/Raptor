using System.Collections.Generic;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Newtonsoft.Json;

using Raptor.Android.Objects.Tiles;

namespace Raptor.Android.Objects.Levels {
    public abstract class BaseLevel {
        public abstract string Name();

        private readonly List<BaseTile> _tiles = new List<BaseTile>();

        internal void AddTile(ContentManager cManager, string tileName) {
            var tile = new BaseTile(cManager, tileName);

            tile.Position(0, _tiles.Count * 256);

            _tiles.Add(tile);
        }

        protected BaseLevel(ContentManager cManager, string levelJSON) {
            var tiles = (string[]) JsonConvert.DeserializeObject(levelJSON);

            foreach (var tile in tiles) {
                AddTile(cManager, tile);
            }
        }

        public void Update() {
            foreach (var tile in _tiles) {
                tile.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach (var tile in _tiles) {
                tile.Draw(spriteBatch);
            }
        }
    }
}