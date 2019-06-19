using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal abstract class AbstractBlockState : IBlockState
    {
        protected Block block;

        protected AbstractBlockState(Block block)
        {
            this.block = block;
        }


        public void ToUsedBlock()
        {
            block.state = new UsedBlockState(block);
        }

        public void ToHiddenBlock()
        {
            block.state = new HiddenBlockState(block);
        }

        public void ToQuestionBlock()
        {
            block.state = new QuestionBlockState(block);
        }

        public void ToRoughPlatformBlock()
        {
            block.state = new RoughPlatformBlockState(block);
        }

        public void ToSmoothPlatformBlock()
        {
            block.state = new SmoothPlatformBlockState(block);
        }

        public void ToBrickBlock()
        {
            block.state = new BrickBlockState(block);
        }
        
        
        public virtual void GetHit()
        {
            block.state = new HiddenBlockState(block);
        }

        public virtual void GetBump()
        {
            block.state.GetBump();
        }

        public Rectangle GetSizeRectangle ()
        {
            return new Rectangle((int)block.position.X, (int)block.position.Y+ConstantNumber.BLOCK_POSITION_Y_ADJUST, ConstantNumber.BLOCK_WIDTH,ConstantNumber.BLOCK_HEIGHT);
        }

        public virtual void Update()
        {
            //
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            //
        }
    }
}
