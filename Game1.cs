using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CleanUp
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D mJPGImage;
        private Vector2 mJPGPosition;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load the images.
            mJPGImage = Content.Load<Texture2D>("yellow_player_avatar");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            #region Keyboard

            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // Update the image positions with Arrow keys
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                mJPGPosition.X = mJPGPosition.X - 5;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                mJPGPosition.X = mJPGPosition.X + 5;
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                mJPGPosition.Y = mJPGPosition.Y - 5;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                mJPGPosition.Y = mJPGPosition.Y + 5;

            #endregion Keyboard

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(mJPGImage, mJPGPosition, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}