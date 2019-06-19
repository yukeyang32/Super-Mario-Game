using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class SmallRightJumpingMarioState : AbstractMarioState
    {
        private int jumpingPower = ConstantNumber.MARIO_JUMPING_POWER;

        public SmallRightJumpingMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateSmallRightJumpMario();
            isJumping = true;
        }

        public override void ToDown()
        {
        }

        public override void ToLeft()
        {
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

        public override void ToStar()
        {
            mario.state = new StarSmallRightJumpingMarioState(mario);
        }

        public override void ToUp()
        {
            if (jumpingPower > 0)
            {
                mario.Position -= new Vector2(ConstantNumber.MARIO_RISING_FORCE_X, ConstantNumber.SMALL_MARIO_RISING_FORCE_Y);
            }
        }

        public override void TakeDamage()
        {
            mario.state = new DeadMarioState(mario);
        }

        public override void Evolve()
        {
            mario.Position -= new Vector2(0, ConstantNumber.MARIO_TRANSITION_OFFSET);
            mario.state = new BigRightJumpingMarioState(mario);
        }

        public override void ToCreepDown()
        {
            mario.state = new SmallRightCreepingDownMarioState(mario);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            marioSprite.Draw(spriteBatch, location, color);
        }

        public override Rectangle GetSizeRectangle()
        {
            return new Rectangle((int)mario.Position.X, (int)mario.Position.Y, ConstantNumber.SMALL_JUMPING_WALKING_WIDTH, ConstantNumber.SMALL_HEIGHT + ConstantNumber.SMALL_MARIO_HEIGHT_ADJUST);
        }

        public override bool isBig()
        {
            return false;
        }

        public override void ToIdle()
        {
            mario.state = new SmallRightIdleMarioState(mario);

        }

        public override void Bounce()
        {
            mario.physics.ApplyForce(new Vector2(0, -ConstantNumber.MARIO_BOUNCE_FORCE));
            mario.state = new SmallRightJumpingMarioState(mario);

        }
    }
}
