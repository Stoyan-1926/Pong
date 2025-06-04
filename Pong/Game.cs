using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D ballTexture;
        Vector2 ballPosition;
        Vector2 ballSpeedVector;
        float ballSpeed;
        double remainderX;
        double remainderY;

        public Game()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
                                       _graphics.PreferredBackBufferHeight / 2);
           

            ballSpeed = 100f;
            ballSpeedVector = new Vector2(-1 , -1);


            //TODO: инициализирайте вектора на скоростта ballSpeedVector, за да зададете началната посока на движение

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            ballTexture = Content.Load<Texture2D>("ball");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            float updatedBallSpeed = ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //TODO: Изменете ballPosition.X и ballPosition.Y в зависимост от посоката на движение
            //float updatedBall = ballPosition.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            float updatedBallPosition = ballSpeedVector.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;
            // ballPosition += ballSpeedVector * updatedBallSpeed;

            ballPosition.X +=  updatedBallSpeed * ballSpeedVector.X;
            ballPosition.Y +=  updatedBallSpeed * ballSpeedVector.Y;

            //TODO: Натрупайте остатъците получени от закръглянето в променливите remainderX и remainderY

            //TODO: Ако картинката напуска границите на екрана, това означава, че топката се е "ударила" в края на екрана и трябва да
            //промени посоката си на движение. За целта трябва да промените вектора ballSpeedVector.
            int screenWidth = _graphics.PreferredBackBufferWidth;
            int screenHeight = _graphics.PreferredBackBufferWidth;
            if (ballPosition.X <= 0 || ballPosition.X + ballTexture.Width >=_graphics.PreferredBackBufferWidth )
            {
                ballSpeedVector.X *= -1;
            }
            if ( ballPosition.Y <= 0 || ballPosition.Y + ballTexture.Height >=_graphics.PreferredBackBufferHeight )
            {
                ballSpeedVector.Y *= -1;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(
                ballTexture,
                ballPosition,
                null,
                Color.White,
                0f,
                new Vector2(ballTexture.Width / 2, ballTexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
