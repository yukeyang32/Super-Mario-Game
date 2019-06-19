using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class SmallRightWalkingMarioState : AbstractMarioState
    {

        public SmallRightWalkingMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateSmallRightRunMario();

        }

        public override void ToStar()
        {
            mario.state = new StarSmallRightWalkingMarioState(mario);
        }

        public override void ToLeft()
        {
            mario.state = new SmallRightIdleMarioState(mario);
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
            SoundFactory.Instance.playSmallMarioJumpSoundEffect();
            mario.physics.ApplyForce(new Vector2(ConstantNumber.MARIO_JUMPING_FORCE_X, -ConstantNumber.MARIO_JUMPING_FORCE_Y));
            mario.state = new SmallRightJumpingMarioState(mario);
        }

        public override void TakeDamage()
        {
            mario.state = new DeadMarioState(mario);
        }

        public override void Evolve()
        {
            mario.Position -= new Vector2(0, ConstantNumber.MARIO_TRANSITION_OFFSET);
            mario.state = new BigRightWalkingMarioState(mario);
        }

        public override void ToCreepDown()
        {
            mario.state = new SmallRightCreepingDownMarioState(mario);
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
            return new Rectangle((int)mario.Position.X, (int)mario.Position.Y, ConstantNumber.SMALL_JUMPING_WALKING_WIDTH, ConstantNumber.SMALL_HEIGHT + ConstantNumber.SMALL_MARIO_HEIGHT_ADJUST);
        }

        public override bool isBig()
        {
            return false;
        }

        public override void Run()
        {
                mario.physics.ApplyForce(new Vector2(ConstantNumber.MARIO_RUNNING_FORCE_X, ConstantNumber.MARIO_RUNNING_FORCE_Y));

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

        public override void ToFall()
        {
            mario.state = new SmallRightFallingMarioState(mario);
        }
    }
}
