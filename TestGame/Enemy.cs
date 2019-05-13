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
        public Vector2 position;
        public Vector2 speed = new Vector2(-2,0);
        public int radius;
        public int timer = 0;

        public static List<Enemy> enemies = new List<Enemy>();

        public Enemy()
        {

        }

        public virtual void Update(GameTime gameTime)
        {
            position += speed;
            timer ++; //Kan inte få timern att fungera med gameTime.
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }

    class Drifter : Enemy
    {
        public Drifter()
        {
            position = new Vector2(1920, Game1.rnd.Next(301, 799));
            radius = 50;
        }

        public override void Update(GameTime gameTime)
        {
            if(position.X == 1500)
            {
                speed.Y = 10;
                speed.X = -8;
            }

            if(position.Y >= 900)
            {
                speed = new Vector2(-5, -20);
            }
            else if(position.Y <= 100)
            {
                speed.Y = 20;
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Game1.drifterSprite, position, Color.White);
        }
    }

    class Bomber : Enemy
    {
        public Bomber()
        {
            position = new Vector2(300, 300);
            radius = 50;
        }

        public override void Update(GameTime gameTime)
        {
            if (timer >= 180) //Kan inte få timern att fungera med gameTime.
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
            else
            {
                if (position.X < 0)
                {
                    speed.X = 5;
                    speed.Y = 1;
                }
                else if (position.X > 400)
                {
                    speed.X = -5;
                    speed.Y = -1;
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Game1.bomberSprite, position, Color.White);
        }
    }
}
