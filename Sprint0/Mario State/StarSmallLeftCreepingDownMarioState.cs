using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class StarSmallLeftCreepingDownMarioState : AbstractMarioState
    {
        public StarSmallLeftCreepingDownMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateSmallLeftCreepingDownMario();

            mario.physics.velocity.Y = 0;
        }


        public override void ToRight()
        {
            mario.state = new StarSmallRightWalkingMarioState(mario);
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

        public override bool isStar()
        {
            return true;
        }

        public override void Bounce()
        {
            mario.physics.ApplyForce(new Vector2(0, -ConstantNumber.MARIO_BOUNCE_FORCE));
            mario.state = new StarBigLeftJumpingMarioState(mario);

        }

        public override Rectangle GetSizeRectangle()
        {
            return new Rectangle((int)mario.Position.X-1, (int)mario.Position.Y, ConstantNumber.SMALL_WIDTH + ConstantNumber.SMALL_MARIO_WIDTH_ADJUST, ConstantNumber.SMALL_HEIGHT + ConstantNumber.SMALL_MARIO_CREEPING_HEIGHT_ADJUST);
        }
    }
}
