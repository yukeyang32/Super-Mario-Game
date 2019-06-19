using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class Block : IBlock
    {
        public bool Destroyed { get; set; }
        public Vector2 position;
        public IBlockState state;


        public Block(Vector2 pos)
        {
            position = pos;
            state = new BrickBlockState(this);
        }

        public void Update()
        {
            state.Update();
         
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            state.Draw(spriteBatch, position);
        }

        public void ToUsedBlock()
        {
            state.ToUsedBlock();
        }


        public void ToHiddenBlock()
        {
            state.ToHiddenBlock();
        }

        public void ToQuestionBlock()
        {
            state.ToQuestionBlock();
        }

        public void ToRoughPlatformBlock()
        {
            state.ToRoughPlatformBlock();
        }

        public void ToBrickBlock()
        {
            state.ToBrickBlock();
        }

        public void ToSmoothPlatformBlock()
        {
            state.ToSmoothPlatformBlock();
        }

        public void GetHit()
        {
            state.GetHit();
        }

        public void GetBump()
        {
            state.GetBump();
        }
     
        public Rectangle GetSizeRectangle()
        {
            return state.GetSizeRectangle();
        }
    }
}
