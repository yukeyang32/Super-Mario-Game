using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class QuestionBlockState : AbstractBlockState
    {
        private ISprite questionBlockSprite;

        public QuestionBlockState(Block block) : base(block)
        {
            questionBlockSprite = BlockSpriteFactory.Instance.CreateQuestionBlock();
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            questionBlockSprite.Draw(spriteBatch, location, Color.White);
        }

        public override void Update()
        {
            questionBlockSprite.Update();
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
