using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace TestGame
{
    class Player
    {
        Vector2 position;
        Vector2 speed;
        int radius;
        KeyboardState keyboard;

        public Player(Vector2 _position)
        {
            position = _position;
        }

        public void Update(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();
            position += speed;

            if (keyboard.IsKeyDown(Keys.W))
            {
                speed.Y = -10;
            }
            else if (keyboard.IsKeyDown(Keys.S))
            {
                speed.Y = 10;
            }
            else
            {
                speed.Y = 0;
            }

            if (keyboard.IsKeyDown(Keys.A))
            {
                speed.X = -10;
            }
            else if (keyboard.IsKeyDown(Keys.D))
            {
                speed.X = 10;
            }
            else
            {
                speed.X = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Game1.playerSprite, position, Color.White);
        }
    }
}
