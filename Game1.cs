using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Monogame_3_assingment
{
    public class Game1 : Game
    {
        enum Screen
        {
            Intro,
            MainAnimation
        }
        Random genorator;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D greyTribble, brownTribble, OrangeTribble, whiteTribble, backgroundIntroTexture;
        Rectangle window;
        Rectangle greyTribbleRect, brownTribbleRect, whiteTribbleRect, OrangeTribbleRect;
        Vector2 greyTribbleSpeed, brownTribbleSpeed, whiteTribbleSpeed, OrangeTribbleSpeed;
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
            genorator = new Random();
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();
            greyTribbleRect = new Rectangle(genorator.Next(0,700), genorator.Next(0, 500), 100, 100);
            greyTribbleSpeed = new Vector2(1, 1);
            brownTribbleRect = new Rectangle(genorator.Next(0, 700), genorator.Next(0, 500), 100, 100);
            brownTribbleSpeed = new Vector2(1, 0);
            OrangeTribbleRect = new Rectangle(genorator.Next(0, 700), genorator.Next(0, 500), 100, 100);
            OrangeTribbleSpeed = new Vector2(0, 1);
            whiteTribbleRect = new Rectangle(genorator.Next(0, 700), genorator.Next(0, 500), 100, 100);
            whiteTribbleSpeed = new Vector2(2, 1);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            greyTribble = Content.Load<Texture2D>("tribbleGrey");
            whiteTribble = Content.Load<Texture2D>("tribbleCream");
            brownTribble = Content.Load<Texture2D>("tribbleBrown");
            OrangeTribble = Content.Load<Texture2D>("tribbleOrange");
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
                brownTribbleRect.X += (int)brownTribbleSpeed.X;
                brownTribbleRect.Y += (int)brownTribbleSpeed.Y;
                OrangeTribbleRect.X += (int)OrangeTribbleSpeed.X;
                OrangeTribbleRect.Y += (int)OrangeTribbleSpeed.Y;
                whiteTribbleRect.X += (int)whiteTribbleSpeed.X;
                whiteTribbleRect.Y += (int)whiteTribbleSpeed.Y;
                base.Update(gameTime);
                if (greyTribbleRect.Right > window.Width || greyTribbleRect.Left < 0)
                {
                    greyTribbleSpeed.X = greyTribbleSpeed.X * -1;
                }
                if (greyTribbleRect.Bottom > window.Height || greyTribbleRect.Top < 0)
                {
                    greyTribbleSpeed.Y = greyTribbleSpeed.Y * -1;
                }
                if (brownTribbleRect.Right > window.Width || brownTribbleRect.Left < 0)
                {
                    brownTribbleSpeed.X = brownTribbleSpeed.X * -1;
                }
                if (brownTribbleRect.Bottom > window.Height || brownTribbleRect.Top < 0)
                {
                    brownTribbleSpeed.Y = brownTribbleSpeed.Y * -1;
                }
                if (whiteTribbleRect.Right > window.Width || whiteTribbleRect.Left < 0)
                {
                    whiteTribbleSpeed.X = whiteTribbleSpeed.X * -1;
                }
                if (whiteTribbleRect.Bottom > window.Height || whiteTribbleRect.Top < 0)
                {
                    whiteTribbleSpeed.Y = whiteTribbleSpeed.Y * -1;
                }
                if (OrangeTribbleRect.Bottom > window.Height || OrangeTribbleRect.Top < 0)
                {
                    OrangeTribbleSpeed.Y = OrangeTribbleSpeed.Y * -1;
                }
                if (OrangeTribbleRect.Right > window.Width || OrangeTribbleRect.Left < 0)
                {
                    OrangeTribbleSpeed.X = OrangeTribbleSpeed.X * -1;
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
                _spriteBatch.Draw(brownTribble, brownTribbleRect, Color.White);
                _spriteBatch.Draw(OrangeTribble, OrangeTribbleRect, Color.White);
                _spriteBatch.Draw(whiteTribble, whiteTribbleRect, Color.White);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}