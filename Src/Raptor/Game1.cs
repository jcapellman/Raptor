using System.Collections.Generic;
using System.Security.Cryptography;
using Android.Hardware;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace Raptor {
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game {
        readonly GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        private Texture2D _planetexture;
        private Texture2D _bingtexture;

        private List<TILE> _tiles = new List<TILE>();

        private Vector2 _planePOS;
        private Vector2 _finalPOS;

        public struct TILE {
            public Texture2D Texture { get; set; }

            public int YPos { get; set; }
        }

        public Game1() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _graphics.IsFullScreen = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 480;
            _graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _planetexture = this.Content.Load<Texture2D>("Planes/F22");
            _bingtexture = Content.Load<Texture2D>("Tiles/Stone");

            for (int x = 0; x < 5; x++) {
                var tileItem = new TILE();

                tileItem.Texture = _bingtexture;
                tileItem.YPos = 256 * x;

                _tiles.Add(tileItem);
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        Vector2 GetDesiredVelocityFromInput() {
            Vector2 desiredVelocity = new Vector2();

            TouchCollection touchCollection = TouchPanel.GetState();

            if (touchCollection.Count > 0) {
                desiredVelocity.X = touchCollection[0].Position.X - _planePOS.X;
                desiredVelocity.Y = touchCollection[0].Position.Y - _planePOS.Y;

                if (desiredVelocity.X != 0 || desiredVelocity.Y != 0) {
                    desiredVelocity.Normalize();
                    const float desiredSpeed = 1200;
                    desiredVelocity *= desiredSpeed;
                }
            }

            return desiredVelocity;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            // TODO: Add your update logic here

            for (var x = 0; x < _tiles.Count; x++) {
                var item = _tiles[x];

                item.YPos += 1;

                _tiles[x] = item;
            }


            var velocity = GetDesiredVelocityFromInput();

            _planePOS.X += velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _planePOS.Y += velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            foreach (var item in _tiles) {
                Rectangle sourceRectangle = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);
                Rectangle destinationRectangle = new Rectangle(0, item.YPos, Window.ClientBounds.Width, Window.ClientBounds.Height);

                _spriteBatch.Draw(item.Texture, destinationRectangle, sourceRectangle, Color.White);
            }

            _spriteBatch.Draw(_planetexture, _planePOS);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}