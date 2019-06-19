using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class SmoothPlatformBlockState : AbstractBlockState
    {
        private ISprite smoothPlatformBlockSprite;

        public SmoothPlatformBlockState(Block block) : base(block)
        {
            smoothPlatformBlockSprite = BlockSpriteFactory.Instance.CreateSmoothPlatformBlock();
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            smoothPlatformBlockSprite.Draw(spriteBatch, location, Color.White);
        }

        public override void Update()
        {
            smoothPlatformBlockSprite.Update();
        }

        public override void GetHit()
        {
        }

        public override void GetBump()
        {
        }
    }

}
