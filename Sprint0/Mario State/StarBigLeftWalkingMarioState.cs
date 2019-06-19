using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class StarBigLeftWalkingMarioState : AbstractMarioState
    {
        public StarBigLeftWalkingMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateBigLeftRunMario();

            mario.physics.velocity.Y = 0;
        }

        public override void ToBig()
        {
            mario.state = new BigLeftWalkingMarioState(mario);
        }

        public override void ToDown()
        {
            mario.state = new StarBigLeftCrouchingMarioState(mario);
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
            mario.state = new StarBigLeftIdleMarioState(mario);
        }

        public override void ToUp()
        {
            SoundFactory.Instance.playBigMarioJumpSoundEffect();
            mario.physics.ApplyForce(new Vector2(ConstantNumber.MARIO_JUMPING_FORCE_X, -ConstantNumber.MARIO_JUMPING_FORCE_Y));
            mario.state = new StarBigLeftJumpingMarioState(mario);
        }

        public override void Evolve()
        {
            mario.state = new StarFireLeftWalkingMarioState(mario);
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
                    mario.ToBig();
                }
            }
            if (mario.ReachDestination)
            {

                if (mario.standingTime < 0)
                {
                    mario.ToRight();
                }
                mario.standingTime--;
            }
            if (mario.Position.X > ConstantNumber.LEVEL_END)
            {
                mario.Destroyed = true;
            }
            marioSprite.Update();
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

        public override void Run()
        {
            mario.physics.ApplyForce(new Vector2(-ConstantNumber.MARIO_RUNNING_FORCE_X, ConstantNumber.MARIO_RUNNING_FORCE_Y));
        }

        public override void ToIdle()
        {
            mario.state = new StarBigLeftIdleMarioState(mario);
        }

        public override void ToFall()
        {
            mario.state = new StarBigLeftFallingMarioState(mario);
        }
    }
}
