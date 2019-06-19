using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class StarBigRightCreepDownMarioState : AbstractMarioState
    {
        public StarBigRightCreepDownMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateBigRightCreepingDownMario();

            mario.physics.velocity.Y = 0;
        }


        public override void ToLeft()
        {
            mario.state = new StarBigLeftCreepDownMarioState(mario);
        }

        public override void ToRight()
        {
            mario.state = new StarBigRightIdleMarioState(mario);
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

        public override bool isStar()
        {
            return true;
        }

        public override Rectangle GetSizeRectangle()
        {
            return new Rectangle((int)mario.Position.X - ConstantNumber.BIG_MARIO_POSITION_X_ADJUST, (int)mario.Position.Y, ConstantNumber.BIG_WIDTH, ConstantNumber.BIG_HEIGHT + ConstantNumber.BIG_MARIO_CREEPING_HEIGHT_ADJUST);
        }
    }
}
