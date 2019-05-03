using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TestGame
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static Texture2D drifterSprite;
        public static Texture2D bomberSprite;

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

            Drifter drifter = new Drifter();
            Enemy.enemies.Add(drifter);

            Bomber bomber = new Bomber();
            Enemy.enemies.Add(bomber);

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (Enemy e in Enemy.enemies)
            {
                e.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

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
