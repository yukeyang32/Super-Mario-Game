using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Sprint0
{
    internal class BlockSpriteFactory
    {
        private Texture2D blockSpritesheet;
        private Texture2D explodingBlockSpriteSheet;

        static readonly BlockSpriteFactory instance = new BlockSpriteFactory();

        public static BlockSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public BlockSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            blockSpritesheet = content.Load<Texture2D>("blocks");
            explodingBlockSpriteSheet = content.Load<Texture2D>("BrickExplosion");
        }

        public ISprite CreateBrickBlock()
        {
            return new StaticMarioBlockPipeSprite(ConstantNumber.BLOCK_HEIGHT, ConstantNumber.BLOCK_WIDTH, blockSpritesheet, new Rectangle(273, 112, ConstantNumber.BLOCK_HEIGHT, ConstantNumber.BLOCK_WIDTH));
        }

        public ISprite CreateSmoothPlatformBlock()
        {
            return new StaticMarioBlockPipeSprite(ConstantNumber.BLOCK_HEIGHT, ConstantNumber.BLOCK_WIDTH, blockSpritesheet, new Rectangle(0, 0, ConstantNumber.BLOCK_HEIGHT, ConstantNumber.BLOCK_WIDTH));
        }


        public ISprite CreateUsedBlock()
        {
            return new StaticMarioBlockPipeSprite(ConstantNumber.BLOCK_HEIGHT, ConstantNumber.BLOCK_WIDTH, blockSpritesheet, new Rectangle(320, 112, ConstantNumber.BLOCK_HEIGHT, ConstantNumber.BLOCK_WIDTH));
        }

        public ISprite CreateRoughPlatformBlock()
        {
            return new StaticMarioBlockPipeSprite(ConstantNumber.BLOCK_HEIGHT, ConstantNumber.BLOCK_WIDTH, blockSpritesheet, new Rectangle(23, 0, ConstantNumber.BLOCK_HEIGHT, ConstantNumber.BLOCK_WIDTH));
        }


        public ISprite CreateQuestionBlock()
        {
            return new AnimatedBlockSprite(ConstantNumber.ANIMATED_COLUMNS, ConstantNumber.BLOCK_HEIGHT, ConstantNumber.BLOCK_WIDTH,blockSpritesheet, new Rectangle(80, 112, ConstantNumber.BLOCK_HEIGHT, ConstantNumber.BLOCK_WIDTH));
        }

        public ISprite CreateHiddenBlock()
        {
            return new StaticMarioBlockPipeSprite(ConstantNumber.BLOCK_HEIGHT, ConstantNumber.BLOCK_WIDTH, blockSpritesheet, new Rectangle(500, 500, ConstantNumber.BLOCK_HEIGHT, ConstantNumber.BLOCK_WIDTH));
        }

        public ISprite CreateExplodingBlock()
        {
            return new AnimatedBlockSprite(ConstantNumber.ANIMATED_COLUMNS, ConstantNumber.BLOCK_HEIGHT, ConstantNumber.BLOCK_WIDTH, explodingBlockSpriteSheet, new Rectangle(0, 0, ConstantNumber.BLOCK_HEIGHT, ConstantNumber.BLOCK_WIDTH));
        }
    }
}
