using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

namespace Sprint0
{
    internal class ExplodingBlockState : AbstractBlockState
    {
        private ISprite brickBlockSprite;
        private int timer = ConstantNumber.BLOCK_EXPLODING_TIME;
        public ExplodingBlockState(Block block) : base(block)
        {
            brickBlockSprite = BlockSpriteFactory.Instance.CreateExplodingBlock();
        }


        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            brickBlockSprite.Draw(spriteBatch, location, Color.White);
        }

        public override void Update()
        {
            if (timer >= 0)
            {
                brickBlockSprite.Update();
            }
            else
            {
                block.Destroyed = true;
            }
            timer--;
            
        }

        public override void GetHit()
        {
        }

        public override void GetBump()
        {
            block.state = new BumpedBrickBlockState(block);
        }

    }

}
