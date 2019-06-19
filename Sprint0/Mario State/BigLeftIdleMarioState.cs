using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class BigLeftIdleMarioState : AbstractMarioState
    {

        public BigLeftIdleMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateBigLeftIdleMario();
            mario.isLeft = true;

            mario.physics.velocity.Y = 0;
        }

        public override void ToDown()
        {
            mario.Position += new Vector2(0, ConstantNumber.BIG_MARIO_UP_AND_DOWN_OFFSET);
            mario.state = new BigLeftCrouchingMarioState(mario);
        }

        public override void ToLeft()
        {
            mario.state = new BigLeftWalkingMarioState(mario);
        }

        public override void ToStar()
        {
            mario.state = new StarBigLeftIdleMarioState(mario);
        }

        public override void ToRight()
        {
            mario.state = new BigRightIdleMarioState(mario);
        }

        public override void ToUp()
        {
            SoundFactory.Instance.playBigMarioJumpSoundEffect();
            mario.physics.ApplyForce(new Vector2(ConstantNumber.MARIO_JUMPING_FORCE_X, -ConstantNumber.MARIO_JUMPING_FORCE_Y));
            mario.state = new BigLeftJumpingMarioState(mario);
        }

        public override void TakeDamage()
        {
            mario.isStarDoingDamage = false;
            mario.Position += new Vector2(0, ConstantNumber.MARIO_DAMAGE_TRANSITION_OFFSET);
            mario.state = new StarSmallLeftIdleMarioState(mario);
        }

        public override void Evolve()
        {
            mario.state = new FireLeftIdleMarioState(mario);
        }

        public override void ToCreepDown()
        {
            mario.state = new BigRightCreepingDownMarioState(mario);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            if (color.Equals(Color.White))
            {
                marioSprite.Draw(spriteBatch, location, color);
            }
            else
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

        public override void Bounce()
        {
            mario.physics.ApplyForce(new Vector2(0, -ConstantNumber.MARIO_BOUNCE_FORCE));
            mario.state = new BigLeftJumpingMarioState(mario);
        }

        public override void ToFall()
        {
            mario.state = new BigLeftFallingingMarioState(mario);
        }

    }
}
