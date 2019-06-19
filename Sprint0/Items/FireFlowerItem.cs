using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    internal class FireFlowerItem : IItem
    {
        public Boolean Destroyed { get; set; } = false;
        ISprite fireFlowerSprite;
        public bool triggered = false;
        Vector2 position;
        private float initialY;
        private bool moveUp = false;


        public FireFlowerItem(Vector2 pos)
        {
            position = pos;
            initialY = position.Y;
            fireFlowerSprite = ItemSpriteFactory.Instance.CreateFireFlower();
        }


        public void GetTrigger()
        {
            moveUp = true;
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

            }
        }


        public void Update()
        {
            if (moveUp)
            {
                Up();
            }

            fireFlowerSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            fireFlowerSprite.Draw(spriteBatch, position, color);
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