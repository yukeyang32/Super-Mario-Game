using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class StarSmallLeftFallingMarioState : AbstractMarioState
    {

        public StarSmallLeftFallingMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateSmallLeftJumpMario();
        }

        public override void ToDown()
        {
            mario.state = new StarSmallLeftIdleMarioState(mario);
        }

        public override void ToLeft()
        {
            if (mario.physics.Velocity.X > -ConstantNumber.MARIO_DESTINATION_SPEED_LIMIT)
            {
                mario.physics.ApplyForce(new Vector2(-ConstantNumber.MARIO_MOVING_FORCE_X, ConstantNumber.MARIO_MOVING_FORCE_Y));

            }
        }

        public override void ToCreepDown()
        {
            mario.state = new StarSmallRightCreepDownMarioState(mario);
        }


        public override void ToSmall()
        {
            mario.state = new SmallLeftJumpingMarioState(mario);
        }


        public override void Evolve()
        {
            mario.Position -= new Vector2(0, ConstantNumber.MARIO_TRANSITION_OFFSET);
            mario.state = new StarBigLeftJumpingMarioState(mario);
        }

        public override void Update()
        {
            if (mario.isStarDoingDamage)
            {
                mario.starTimer--;
                if (mario.starTimer == 0)
                {
                    mario.ToSmall();
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
                    mario.ToSmall();
                }
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
            return new Rectangle((int)mario.Position.X, (int)mario.Position.Y, ConstantNumber.SMALL_JUMPING_WALKING_WIDTH, ConstantNumber.SMALL_HEIGHT + ConstantNumber.SMALL_MARIO_HEIGHT_ADJUST);
        }

        public override bool isBig()
        {
            return false;
        }

        public override bool isStar()
        {
            return true;
        }

        public override void ToIdle()
        {
            mario.state = new StarSmallLeftIdleMarioState(mario);
        }

    }
}
