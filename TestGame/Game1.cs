using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace TestGame
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static Texture2D drifterSprite;
        public static Texture2D bomberSprite;
        public static Texture2D playerSprite;

        Player player;

        KeyboardState keyBoard;
        bool tReleased = true;

        public static Random rnd = new Random();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;

            //graphics.IsFullScreen = true;
            //graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            drifterSprite = Content.Load<Texture2D>("red");
            bomberSprite = Content.Load<Texture2D>("pink");
            playerSprite = Content.Load<Texture2D>("green");

            player = new Player(new Vector2(400, 400));
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            keyBoard = Keyboard.GetState();

            player.Update(gameTime);

            //Spawna ut fiende
            if (keyBoard.IsKeyDown(Keys.T) && tReleased == true)
            {
                Drifter drifter = new Drifter();
                Enemy.enemies.Add(drifter);
                tReleased = false;
            }

            if (keyBoard.IsKeyUp(Keys.T))
            {
                tReleased = true;
            }


            foreach (Enemy e in Enemy.enemies)
            {
                e.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            player.Draw(spriteBatch);

            spriteBatch.End();

            foreach (Enemy e in Enemy.enemies)
            {
                spriteBatch.Begin();
                e.Draw(spriteBatch);
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }
    }
}
