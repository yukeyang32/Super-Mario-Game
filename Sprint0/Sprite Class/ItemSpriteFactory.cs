using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Sprint0
{
    internal class ItemSpriteFactory
    {
        private Texture2D itemSpritesheet;
        private Texture2D flagPoleSpriteSheet;

        static readonly ItemSpriteFactory instance = new ItemSpriteFactory();

        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemSpriteFactory()
        {
        }
        //int columns, int rows, int height, int width, Texture2D texture, Rectangle sourceRectangle
        public void LoadAllTextures(ContentManager content)
        {
            itemSpritesheet = content.Load<Texture2D>("items");
            flagPoleSpriteSheet = content.Load<Texture2D>("misc");
        }

        public ISprite CreateFireFlower()
        {
            return new ItemSprite(ConstantNumber.FLOWER_COL, ConstantNumber.ITEM_SPRITE_HEIGHT, ConstantNumber.ITEM_SPRITE_WIDTH, itemSpritesheet, new Rectangle(4, 64, ConstantNumber.ITEM_SPRITE_HEIGHT, ConstantNumber.ITEM_SPRITE_WIDTH));
        }

        public ISprite CreateStar()
        {
            return new ItemSprite(ConstantNumber.STAR_COL, ConstantNumber.ITEM_SPRITE_HEIGHT, ConstantNumber.ITEM_SPRITE_WIDTH, itemSpritesheet, new Rectangle(4, 94, ConstantNumber.ITEM_SPRITE_HEIGHT, ConstantNumber.ITEM_SPRITE_WIDTH));
        }

        public ISprite CreateMushroom()
        {
            return new ItemSprite(ConstantNumber.MUSHROOM_COL, ConstantNumber.ITEM_SPRITE_HEIGHT, ConstantNumber.ITEM_SPRITE_WIDTH, itemSpritesheet, new Rectangle(184, 34, ConstantNumber.ITEM_SPRITE_HEIGHT, ConstantNumber.ITEM_SPRITE_WIDTH));
        }

        public ISprite CreatePoisonMushroom()
        {
            return new ItemSprite(ConstantNumber.POISON_COL, ConstantNumber.ITEM_SPRITE_HEIGHT, ConstantNumber.ITEM_SPRITE_WIDTH, itemSpritesheet, new Rectangle(210, 32, ConstantNumber.ITEM_SPRITE_HEIGHT, ConstantNumber.ITEM_SPRITE_WIDTH));
        }

        public ISprite CreateCoin()
        {
            return new ItemSprite(ConstantNumber.COIN_COL, ConstantNumber.ITEM_SPRITE_HEIGHT, ConstantNumber.ITEM_SPRITE_WIDTH, itemSpritesheet, new Rectangle(124, 94, ConstantNumber.ITEM_SPRITE_HEIGHT, ConstantNumber.ITEM_SPRITE_WIDTH));
        }

        public ISprite CreateFlagPole()
        {
            return new ItemSprite(ConstantNumber.FLAG_COL, ConstantNumber.FLAG_HEIGHT, ConstantNumber.FLAG_WIDTH, flagPoleSpriteSheet, new Rectangle(132, 594, ConstantNumber.FLAG_HEIGHT, ConstantNumber.FLAG_WIDTH));
        }

        public ISprite CreateAnimatedFlagPole()
        {
            return new ItemSprite(5, ConstantNumber.FLAG_HEIGHT, ConstantNumber.FLAG_WIDTH, flagPoleSpriteSheet, new Rectangle(132, 594, ConstantNumber.FLAG_WIDTH, ConstantNumber.FLAG_HEIGHT));
        }
    }
}
