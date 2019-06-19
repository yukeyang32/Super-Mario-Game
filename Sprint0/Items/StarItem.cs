using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    internal class StarItem : IItem
    {
        public Boolean Destroyed { get; set; } = false;
        public bool triggered = false;
        ISprite starSprite;
        public Vector2 position;
        public float initialY;
        private Velocity speed;
        public bool isOnGround = false;
        public bool moveLeft = false;
        public bool moveUp = false;
        private bool falling = true;

        public StarItem(Vector2 pos, Velocity itemSpeed)
        {
            position = pos;
            initialY = position.Y;
            speed = new Velocity(itemSpeed);
            starSprite = ItemSpriteFactory.Instance.CreateStar();
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


        public void Rise()
        {
            falling = false;

            if ((initialY - position.Y) <= ConstantNumber.ITEM_HEIGHT)
            {
                position.Y -= ConstantNumber.ITEM_VELOCITY;
            }
            else
            {
                falling = true;
            }
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
                triggered = true;
                moveUp = false;
                Right();
            }
        }

        public void Update()
        {
            if (moveUp)
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

                if (!isOnGround && falling)
                {
                    Fall();
                }
                else
                {
                    Rise();
                }
            }
            starSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
                starSprite.Draw(spriteBatch, position, color);
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