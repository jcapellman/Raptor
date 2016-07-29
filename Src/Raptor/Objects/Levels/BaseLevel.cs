using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Newtonsoft.Json;

using Raptor.Android.Objects.Planes;
using Raptor.Android.Objects.Tiles;

namespace Raptor.Android.Objects.Levels {
    public abstract class BaseLevel {
        public abstract string Name();

        internal BasePlane _playerFighter;

        private readonly List<BaseTile> _tiles = new List<BaseTile>();

        internal void AddTile(ContentManager cManager, string tileName) {
            var tile = new BaseTile(cManager, tileName);

            tile.Position(0, -_tiles.Count * 1024);

            _tiles.Add(tile);
        }

        protected BaseLevel(ContentManager cManager, string levelJSON) {
            var tiles = JsonConvert.DeserializeObject<List<string>>(levelJSON);

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

            _playerFighter.Draw(spriteBatch);
        }

        public Vector2 PlayerPosition => _playerFighter.GetPosition();
    }
}