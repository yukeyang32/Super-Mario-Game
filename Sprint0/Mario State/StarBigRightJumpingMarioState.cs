using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class StarBigRightJumpingMarioState : AbstractMarioState
    {
        private int jumpingPower = ConstantNumber.MARIO_JUMPING_POWER;

        public StarBigRightJumpingMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateBigRightJumpMario();
            isJumping = true;
        }

        public override void ToBig()
        {
            mario.state = new BigRightJumpingMarioState(mario);
        }

        public override void ToLeft()
        {
            if (mario.physics.Velocity.X > -ConstantNumber.MARIO_MOVING_VELOCITY_LIMIT)
            {
                mario.physics.ApplyForce(new Vector2(-ConstantNumber.MARIO_MOVING_FORCE_X, ConstantNumber.MARIO_MOVING_FORCE_Y));
            }
        }

        public override void ToCreepDown()
        {
            mario.state = new StarBigRightCreepDownMarioState(mario);
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
                mario.Position -= new Vector2(ConstantNumber.SMALL_MARIO_RISING_FORCE_X, ConstantNumber.SMALL_MARIO_RISING_FORCE_Y);
            }
        }

        public override void Evolve()
        {
            mario.state = new StarFireRightJumpingMarioState(mario);
        }

        public override void Update()
        {
            if (mario.isStarDoingDamage)
            {
                mario.starTimer--;
                if (mario.starTimer == 0)
                {
                    mario.ToBig();
                    if (Game1.Instance.backgroundColor == Color.Black)
                    {
                        SoundFactory.Instance.playUndergroundSong();

                    }
                    else
                    {
                        SoundFactory.Instance.playThemeSong();
                    }
                    mario.starTimer = ConstantNumber.MARIO_STAR_POWER_TIMER;
                }
            }
            else
            {
                mario.transitionTimer--;
                if (mario.transitionTimer == 0)
                {
                    mario.isStarDoingDamage = true;
                    mario.ToBig();
                }
            }
            marioSprite.Update();
            if (jumpingPower == 0)
            {

                mario.physics.velocity.Y = 0;

            }
            else if (jumpingPower < 0)
            {
                if (mario.isOnGround)
                {

                    mario.state = new StarBigRightIdleMarioState(mario);
                }
            }
            jumpingPower--;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            if (mario.starTimer / 2 % 2 == 1)
            {
                marioSprite.Draw(spriteBatch, location, Color.Yellow);
            }
            else
            {
                marioSprite.Draw(spriteBatch, location, Color.Green);
            }
        }

        public override Rectangle GetSizeRectangle()
        {
            return new Rectangle((int)mario.Position.X, (int)mario.Position.Y, ConstantNumber.BIG_JUMPING_WALKING_WIDTH, ConstantNumber.BIG_HEIGHT);
        }

        public override bool isStar()
        {
            return true;
        }

        public override void ToIdle()
        {
            mario.state = new StarBigRightIdleMarioState(mario);
        }
    }
}
