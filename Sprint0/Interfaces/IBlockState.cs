using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal interface IBlockState : ICollidable
    {

        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void ToUsedBlock();
        void ToHiddenBlock();
        void ToBrickBlock();
        void ToQuestionBlock();
        void ToRoughPlatformBlock();
        void ToSmoothPlatformBlock();
        void GetHit();
        void GetBump();
    }
}