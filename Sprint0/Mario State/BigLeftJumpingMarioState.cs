using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class BigLeftJumpingMarioState : AbstractMarioState
    {
        private int jumpingPower = ConstantNumber.MARIO_JUMPING_POWER;

        public BigLeftJumpingMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateBigLeftJumpMario();
            mario.isLeft = true;
            isJumping = true;
        }

        public override void ToStar()
        {
            mario.state = new StarBigLeftJumpingMarioState(mario);
        }

        public override void ToLeft()
        {
            //isMoving = true;
            if (mario.physics.Velocity.X > -ConstantNumber.MARIO_MOVING_VELOCITY_LIMIT)
            {
                mario.physics.ApplyForce(new Vector2(-ConstantNumber.MARIO_MOVING_FORCE_X, ConstantNumber.MARIO_MOVING_FORCE_Y));
            }
        }

        public override void ToRight()
        {
            if (mario.physics.Velocity.X < ConstantNumber.MARIO_MOVING_VELOCITY_LIMIT)
            {
                mario.physics.ApplyForce(new Vector2(ConstantNumber.MARIO_MOVING_FORCE_X, ConstantNumber.MARIO_MOVING_FORCE_Y));
            }
        }

        public override void ToUp()
        {
            if (jumpingPower > 0)
            {
                mario.Position -= new Vector2(ConstantNumber.MARIO_JUMPING_FORCE_X, ConstantNumber.MARIO_JUMPING_FORCE_Y);
            }
        }

        public override void TakeDamage()
        {
            mario.isStarDoingDamage = false;
            mario.state = new StarSmallLeftJumpingMarioState(mario);
        }

        public override void Evolve()
        {
            mario.state = new FireLeftJumpingMarioState(mario);
        }


        public override void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            marioSprite.Draw(spriteBatch, location, color);
        }

        public override void ToCreepDown()
        {
            mario.state = new BigRightCreepingDownMarioState(mario);
        }

        public override Rectangle GetSizeRectangle()
        {
            return new Rectangle((int)mario.Position.X+2, (int)mario.Position.Y, ConstantNumber.BIG_JUMPING_WALKING_WIDTH, ConstantNumber.BIG_HEIGHT);
        }

        public override void ToIdle()
        {
            mario.state = new BigLeftIdleMarioState(mario);
            
        }

        public override void Bounce()
        {
            mario.physics.ApplyForce(new Vector2(0, -ConstantNumber.MARIO_BOUNCE_FORCE));
            mario.state = new BigLeftJumpingMarioState(mario);

        }

    }
}
