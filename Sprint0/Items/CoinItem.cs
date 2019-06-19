using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    internal class CoinItem : IItem
    {
        public Boolean Destroyed { get; set; } = false;
        public bool consumed = false;
        ISprite coinSprite;
        public Boolean inBlock = false;
        Vector2 position;
        private float initialY;

        public CoinItem(Vector2 pos)
        {
            position = pos;
            initialY = position.Y;
            coinSprite = ItemSpriteFactory.Instance.CreateCoin();
        }

        public void GetTrigger()
        {
            consumed = true;
            if ((initialY - position.Y) <= ConstantNumber.ITEM_HEIGHT)
            {
                position.Y -= ConstantNumber.ITEM_VELOCITY;

            }
            else
            {
                Disappear();
            }
        }

        public void Update()
        {
            if(consumed)
            {
                GetTrigger();
            }
            coinSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            coinSprite.Draw(spriteBatch, position, color);
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