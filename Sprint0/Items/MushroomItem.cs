using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    internal class MushroomItem : IItem
    {
        public Boolean Destroyed { get; set; } = false;
        public bool triggered = false;
        ISprite mushroomSprite;
        public Vector2 position;
        private float initialY;
        private Velocity speed;
        public bool isOnGround = false;
        public bool moveLeft = false;
        public bool moveUp = false;

        public MushroomItem(Vector2 pos, Velocity itemSpeed)
        {
            position = pos;
            initialY = position.Y;
            speed = new Velocity(itemSpeed);
            mushroomSprite = ItemSpriteFactory.Instance.CreateMushroom();
        }

        public void GetTrigger()
        {
            moveUp = true;
        }

        public void Left()
        {
            position.X -= speed.velocity.X;
        }

        public void Right()
        {
            position.X += speed.velocity.X;
        }

        public void Fall()
        {
            position.Y += speed.velocity.Y;
        }

        public void Up()
        {
            if ((initialY - position.Y) <= ConstantNumber.ITEM_HEIGHT)
            {
                position.Y -= ConstantNumber.ITEM_VELOCITY;
            }
            else
            {
                Right();
                moveUp = false;
                triggered = true;
            }
        }

        public void Update()
        {
            if (Game1.Instance.isPkMode)
            {
                triggered = true;
                Fall();
            }else if (moveUp)
            {
                Up();
            }

            else if (triggered)
            {

                if (moveLeft)
                {
                    Left();
                }
                else
                {
                    Right();
                }

                if (!isOnGround)
                {
                    Fall();
                }

            }

            mushroomSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            mushroomSprite.Draw(spriteBatch, position, color);
        }

        public Rectangle GetSizeRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, ConstantNumber.ITEM_WIDTH, ConstantNumber.ITEM_HEIGHT);
        }


        public void Disappear()
        {
            this.Destroyed = true;
        }
    }
}