using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class UsedBlockState : AbstractBlockState
    {
        private ISprite usedBlockSprite;

        public UsedBlockState(Block block) : base(block)
        {
            usedBlockSprite = BlockSpriteFactory.Instance.CreateUsedBlock();
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            usedBlockSprite.Draw(spriteBatch, location, Color.White);
        }

        public override void Update()
        {
            usedBlockSprite.Update();
        }

        public override void GetHit()
        {
        }

        public override void GetBump()
        {
        }

    }

}
