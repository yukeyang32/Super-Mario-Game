using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class RoughPlatformBlockState : AbstractBlockState
    {
        private ISprite roughPlatformBlockSprite;

        public RoughPlatformBlockState(Block block) : base(block)
        {
            roughPlatformBlockSprite = BlockSpriteFactory.Instance.CreateRoughPlatformBlock();
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            roughPlatformBlockSprite.Draw(spriteBatch, location, Color.White);
        }

        public override void Update()
        {
            roughPlatformBlockSprite.Update();
        }

        public override void GetHit()
        {
        }

        public override void GetBump()
        {
        }
    }

}
