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
    internal class BrickBlockState : AbstractBlockState
    {
        private ISprite brickBlockSprite;
        public BrickBlockState(Block block) : base(block)
        {
            brickBlockSprite = BlockSpriteFactory.Instance.CreateBrickBlock();
        }


        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            brickBlockSprite.Draw(spriteBatch, location, Color.White);
        }

        public override void Update()
        {
            brickBlockSprite.Update();
        }

        public override void GetHit()
        {
            block.state = new ExplodingBlockState(block);
        }

        public override void GetBump()
        {
            block.state = new BumpedBrickBlockState(block);
        }

    }

}
