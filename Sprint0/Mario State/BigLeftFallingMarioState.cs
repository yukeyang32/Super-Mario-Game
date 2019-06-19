using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class BigLeftFallingingMarioState : AbstractMarioState
    {

        public BigLeftFallingingMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateBigLeftJumpMario();
            mario.isLeft = true;
        }

        public override void ToStar()
        {
            mario.state = new StarBigLeftJumpingMarioState(mario);
        }

        public override void ToLeft()
        {
            if (mario.physics.Velocity.X > -ConstantNumber.MARIO_MOVING_VELOCITY_LIMIT)
            {
                mario.physics.ApplyForce(new Vector2(-ConstantNumber.MARIO_MOVING_FORCE_X, ConstantNumber.MARIO_MOVING_FORCE_Y));
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
            return new Rectangle((int)mario.Position.X+ConstantNumber.BIG_MARIO_FALLING_POSITION_X_ADJUST, (int)mario.Position.Y, ConstantNumber.BIG_JUMPING_WALKING_WIDTH, ConstantNumber.BIG_HEIGHT);
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
