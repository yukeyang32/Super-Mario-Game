using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class SmallRightIdleMarioState : AbstractMarioState
    {

        public SmallRightIdleMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateSmallRightIdleMario();
            mario.physics.velocity.Y = 0;
        }

        public override void ToLeft()
        {
            mario.state = new SmallLeftIdleMarioState(mario);
        }

        public override void ToStar()
        {
            mario.state = new StarSmallRightIdleMarioState(mario);
        }

        public override void ToRight()
        {
            mario.state = new SmallRightWalkingMarioState(mario);
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
            mario.state = new BigRightIdleMarioState(mario);
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
            return new Rectangle((int)mario.Position.X, (int)mario.Position.Y, ConstantNumber.SMALL_WIDTH, ConstantNumber.SMALL_HEIGHT + ConstantNumber.SMALL_MARIO_HEIGHT_ADJUST);
        }

        public override bool isBig()
        {
            return false;
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
