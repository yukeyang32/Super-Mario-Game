using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class StarSmallRightIdleMarioState : AbstractMarioState
    {

        public StarSmallRightIdleMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateSmallRightIdleMario();


            mario.physics.velocity.Y = 0;
        }

        public override void ToLeft()
        {
            mario.state = new StarSmallLeftIdleMarioState(mario);
        }

        public override void ToRight()
        {
            mario.state = new StarSmallRightWalkingMarioState(mario);
        }

        public override void ToSmall()
        {
            mario.state = new SmallRightIdleMarioState(mario);
        }

        public override void ToUp()
        {
            SoundFactory.Instance.playSmallMarioJumpSoundEffect();
            mario.physics.ApplyForce(new Vector2(ConstantNumber.MARIO_JUMPING_FORCE_X, -ConstantNumber.MARIO_JUMPING_FORCE_Y));
            mario.state = new StarSmallRightJumpingMarioState(mario);
        }

        public override void Evolve()
        {
            mario.Position -= new Vector2(0, ConstantNumber.MARIO_TRANSITION_OFFSET);
            mario.state = new StarBigRightIdleMarioState(mario);
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
            return new Rectangle((int)mario.Position.X, (int)mario.Position.Y, ConstantNumber.SMALL_WIDTH, ConstantNumber.SMALL_HEIGHT + ConstantNumber.SMALL_MARIO_HEIGHT_ADJUST);
        }

        public override bool isBig()
        {
            return false;
        }

        public override bool isStar()
        {
            return true;
        }


        public override void ToFall()
        {
            mario.state = new StarSmallRightFallingMarioState(mario);
        }

    }

}
