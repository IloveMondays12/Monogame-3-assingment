using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_3_assingment
{
    public class Game1 : Game
    {
        enum Screen
        {
            Intro,
            MainAnimation
        }
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D greyTribble, backgroundIntroTexture;
        Rectangle window;
        Rectangle greyTribbleRect, brownTribbleRect, whiteTribbleRect;
        Vector2 greyTribbleSpeed, brownTribbleSpeed, whiteTribbleSpeed;
        MouseState mouseState;
        Screen screen;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();
            greyTribbleRect = new Rectangle(300, 10, 100, 100);
            greyTribbleSpeed = new Vector2(1, 1);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            greyTribble = Content.Load<Texture2D>("tribbleGrey");
            backgroundIntroTexture = Content.Load<Texture2D>("Untitled");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    screen = Screen.MainAnimation;
                }
            }
            if (screen == Screen.MainAnimation)
            {
                greyTribbleRect.X += (int)greyTribbleSpeed.X;
                greyTribbleRect.Y += (int)greyTribbleSpeed.Y;
                base.Update(gameTime);
                if (greyTribbleRect.Right > window.Width || greyTribbleRect.Left < 0)
                {
                    greyTribbleSpeed.X = greyTribbleSpeed.X * -1;
                }
                if (greyTribbleRect.Bottom > window.Height || greyTribbleRect.Top < 0)
                {
                    greyTribbleSpeed.Y = greyTribbleSpeed.Y * -1;
                }
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
            
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightPink);
            if ((greyTribbleSpeed.Y*greyTribbleSpeed.X) == 1)
            {
                GraphicsDevice.Clear(Color.LightPink);
            }
            else
            {
                GraphicsDevice.Clear(Color.Red);
            }
            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(backgroundIntroTexture, window, Color.White);
            }
            if (screen == Screen.MainAnimation)
            {
                _spriteBatch.Draw(greyTribble, greyTribbleRect, Color.White);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}