using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class BumpedBrickBlockState : AbstractBlockState
    {
        private ISprite bumpedBrickBlockSprite;
        private Vector2 originalLocation;
        private Vector2 desLocation;
        private bool goingUp = true;
        public BumpedBrickBlockState(Block block) : base(block)
        {
            bumpedBrickBlockSprite = BlockSpriteFactory.Instance.CreateBrickBlock();
            originalLocation = block.position;
            desLocation = new Vector2(block.position.X, block.position.Y -= 3);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            bumpedBrickBlockSprite.Draw(spriteBatch, location, Color.White);
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
                    block.state = new BrickBlockState(block);
                }
            }
            bumpedBrickBlockSprite.Update();
        }

        public override void GetHit()
        {
        }

        public override void GetBump()
        {
        }
    }
}
