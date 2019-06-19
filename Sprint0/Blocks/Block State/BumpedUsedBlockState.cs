using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class BumpedUsedBlockState : AbstractBlockState
    {
        private ISprite bumpedUsedBlockSprite;
        private Vector2 originalLocation;
        private Vector2 desLocation;
        private bool goingUp = true;
        public BumpedUsedBlockState(Block block) : base(block)
        {
            bumpedUsedBlockSprite = BlockSpriteFactory.Instance.CreateUsedBlock();
            originalLocation = block.position;
            desLocation = new Vector2(block.position.X, block.position.Y -= 3);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            bumpedUsedBlockSprite.Draw(spriteBatch, location, Color.White);
        }

        public override void Update()
        {
            if (goingUp)
            {
                if (block.position != desLocation)
                {
                    block.position.Y--;
                }
                else
                {
                    goingUp = false;
                }
            }
            else
            {
                if (block.position != originalLocation)
                {
                    block.position.Y++;
                }
                else
                {
                    block.state = new UsedBlockState(block);
                }
            }
            bumpedUsedBlockSprite.Update();
        }
        
        public override void GetHit()
        {
        }

        public override void GetBump()
        {
        }
    }
}
