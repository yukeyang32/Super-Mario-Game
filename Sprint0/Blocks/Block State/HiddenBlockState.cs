using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class HiddenBlockState : AbstractBlockState
    {
        private ISprite hiddenBlockSprite;

        public HiddenBlockState(Block block) : base(block)
        {
            hiddenBlockSprite = BlockSpriteFactory.Instance.CreateHiddenBlock();
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            hiddenBlockSprite.Draw(spriteBatch, location, Color.White);
        }

        public override void Update()
        {
            hiddenBlockSprite.Update();
        }

        public override void GetHit()
        {
            block.state = new BumpedUsedBlockState(block);
        }

        public override void GetBump()
        {
        }
    }

}
