using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CleanUp
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D yellowAvatar;
        private Vector2 yellowAvatarPosition;
        private Texture2D blueAvatar;
        private Vector2 blueAvatarPosition;
        private Texture2D roomWallSection;
        private Vector2 roomWallSection1Postion;

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
            yellowAvatar = Content.Load<Texture2D>("yellow_player_avatar");
            blueAvatar = Content.Load<Texture2D>("blue_player_avatar");
            roomWallSection = Content.Load<Texture2D>("room_border");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            #region Controller

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                this.Exit();
            }

            // Update the image positions with left/right thumbsticks
            yellowAvatarPosition += GamePad.GetState(PlayerIndex.One).ThumbSticks.Left;
            blueAvatarPosition += GamePad.GetState(PlayerIndex.One).ThumbSticks.Right;

            #endregion Controller

            #region Keyboard

            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // Update the image positions with Arrow keys
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                yellowAvatarPosition.X = yellowAvatarPosition.X - 5;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                yellowAvatarPosition.X = yellowAvatarPosition.X + 5;
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                yellowAvatarPosition.Y = yellowAvatarPosition.Y - 5;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                yellowAvatarPosition.Y = yellowAvatarPosition.Y + 5;

            if (Keyboard.GetState().IsKeyDown(Keys.A))
                blueAvatarPosition.X = blueAvatarPosition.X - 5;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                blueAvatarPosition.X = blueAvatarPosition.X + 5;
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                blueAvatarPosition.Y = blueAvatarPosition.Y - 5;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                blueAvatarPosition.Y = blueAvatarPosition.Y + 5;

            #endregion Keyboard

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(yellowAvatar, yellowAvatarPosition, Color.White);
            _spriteBatch.Draw(blueAvatar, blueAvatarPosition, Color.White);
            _spriteBatch.Draw(roomWallSection, roomWallSection1Postion, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}