using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class BigLeftWalkingMarioState : AbstractMarioState
    {

        public BigLeftWalkingMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateBigLeftRunMario();
            mario.isLeft = true;
        }

        public override void ToStar()
        {
            mario.state = new StarBigLeftWalkingMarioState(mario);
        }

        public override void ToDown()
        {
            mario.state = new BigLeftCrouchingMarioState(mario);
        }

        public override void ToLeft()
        {
            if (mario.physics.Velocity.X > -ConstantNumber.MARIO_DESTINATION_SPEED_LIMIT)
            {
                mario.physics.ApplyForce(new Vector2(-ConstantNumber.MARIO_MOVING_FORCE_X, ConstantNumber.MARIO_MOVING_FORCE_Y));

            }
        }

        public override void ToRight()
        {
            mario.state = new BigLeftIdleMarioState(mario);
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
            mario.state = new StarSmallLeftWalkingMarioState(mario);
        }

        public override void Evolve()
        {
            mario.state = new FireLeftWalkingMarioState(mario);
        }

        public override void ToCreepDown()
        {
            mario.state = new BigLeftCreepingDownMarioState(mario);
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

        public override Rectangle GetSizeRectangle()
        {
            return new Rectangle((int)mario.Position.X, (int)mario.Position.Y, ConstantNumber.BIG_JUMPING_WALKING_WIDTH, ConstantNumber.BIG_HEIGHT);
        }

        public override void Run()
        {
                mario.physics.ApplyForce(new Vector2(-ConstantNumber.MARIO_RUNNING_FORCE_X, ConstantNumber.MARIO_RUNNING_FORCE_Y));
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

        public override void ToFall()
        {
            mario.state = new BigLeftFallingingMarioState(mario);
        }

    }
}
