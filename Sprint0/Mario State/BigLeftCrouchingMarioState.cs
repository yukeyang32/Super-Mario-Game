using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{

    internal class BigLeftCrouchingMarioState : AbstractMarioState
    {

        public BigLeftCrouchingMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateBigLeftCrouchMario();
            mario.isLeft = true;
        }

        public override void ToStar()
        {
            mario.state = new StarBigLeftCrouchingMarioState(mario);
        }

        public override Rectangle GetSizeRectangle()
        {
            return new Rectangle((int)mario.Position.X, (int)mario.Position.Y, ConstantNumber.BIG_WIDTH, ConstantNumber.CROUCHING_HEIGHT);
        }

        public override void ToCreepDown()
        {
            mario.state = new BigLeftCreepingDownMarioState(mario);
        }

        public override void ToUp()
        {
            mario.Position -= new Vector2(0, ConstantNumber.BIG_MARIO_UP_AND_DOWN_OFFSET);
            mario.state = new BigLeftIdleMarioState(mario);
        }

        public override void TakeDamage()
        {
            mario.isStarDoingDamage = false;
            mario.state = new StarSmallLeftIdleMarioState(mario);
        }

        public override void Evolve()
        {
            mario.state = new FireLeftCrouchingMarioState(mario);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            if (color.Equals(Color.White))
            {
                marioSprite.Draw(spriteBatch, location, color);
            } else
            {
                if (colorSwicth)
                {
                    marioSprite.Draw(spriteBatch, location, color);
                }
                else
                {
                    marioSprite.Draw(spriteBatch, location, Color.Purple);
                }
            }
        }

        public override void ToFall()
        {
            mario.state = new BigLeftFallingingMarioState(mario);
        }





    }
}
