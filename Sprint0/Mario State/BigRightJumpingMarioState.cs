using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class BigRightJumpingMarioState : AbstractMarioState
    {
        private int jumpingPower = ConstantNumber.MARIO_JUMPING_POWER;

        public BigRightJumpingMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateBigRightJumpMario();
            mario.isLeft = false;
            isJumping = true;
        }

        public override void ToStar()
        {
            mario.state = new StarBigRightJumpingMarioState(mario);
        }

        public override void ToCreepDown()
        {
            mario.state = new BigRightCreepingDownMarioState(mario);
        }

        public override void ToLeft()
        {
            if (mario.physics.velocity.X > -ConstantNumber.MARIO_MOVING_VELOCITY_LIMIT)
            {
                mario.physics.ApplyForce(new Vector2(-ConstantNumber.MARIO_MOVING_FORCE_X, ConstantNumber.MARIO_MOVING_FORCE_Y));
            }
        }

        public override void ToRight()
        {
            if (mario.physics.velocity.X < ConstantNumber.MARIO_MOVING_VELOCITY_LIMIT)
            {
                mario.physics.ApplyForce(new Vector2(ConstantNumber.MARIO_MOVING_FORCE_X, ConstantNumber.MARIO_MOVING_FORCE_Y));
            }
        }

        public override void ToUp()
        {
            if (jumpingPower > 0)
            {
                mario.Position -= new Vector2(ConstantNumber.MARIO_RISING_FORCE_X, ConstantNumber.MARIO_RISING_FORCE_Y);
            }
        }

        public override void TakeDamage()
        {
            mario.isStarDoingDamage = false;
            mario.state = new StarSmallRightJumpingMarioState(mario);
        }

        public override void Evolve()
        {
            mario.state = new FireRightJumpingMarioState(mario);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            marioSprite.Draw(spriteBatch, location, color);
        }

        public override Rectangle GetSizeRectangle()
        {
            return new Rectangle((int)mario.Position.X, (int)mario.Position.Y, ConstantNumber.BIG_JUMPING_WALKING_WIDTH, ConstantNumber.BIG_HEIGHT);
        }

        public override bool isLeft()
        {
            return false;
        }

        public override void ToIdle()
        {
            mario.state = new BigRightIdleMarioState(mario);
        }

        public override void Bounce()
        {
            mario.physics.ApplyForce(new Vector2(0, -ConstantNumber.MARIO_BOUNCE_FORCE));
            mario.state = new BigRightJumpingMarioState(mario);

        }
    }
}
