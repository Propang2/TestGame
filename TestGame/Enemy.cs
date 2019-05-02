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
    class Enemy
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 speed = new Vector2(5,0);
        public int radius;

        public static List<Enemy> enemies = new List<Enemy>();

        public Enemy(Texture2D _texture)
        {
            texture = _texture;
        }

        public void Update(GameTime gameTime)
        {
            position += speed;

            //Detta ger felmeddelande
            foreach (Drifter d in enemies)
            {
                d.Behavior();
            }

            foreach (Bomber b in enemies)
            {
                b.Behavior();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, Color.White);
            spriteBatch.End();
        }
    }

    class Drifter : Enemy
    {
        public Drifter(Texture2D t) : base(t)
        {
            position = new Vector2(100, 100);
            radius = 50;
        }

        public void Behavior()
        {
            if (position.X < 0)
            {
                speed.X = 5;
            }
            else if (position.X > 400)
            {
                speed.X = -5;
            }
        }

    }

    class Bomber : Enemy
    {
        public Bomber(Texture2D t) : base(t)
        {
            position = new Vector2(300, 300);
            radius = 50;
        }

        public void Behavior()
        {
            if (position.X < 0)
            {
                speed.X = 5;
                speed.Y = 2;
            }
            else if (position.X > 400)
            {
                speed.X = -5;
                speed.Y = -2;
            }
        }
    }
}
