﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class StarBigLeftIdleMarioState : AbstractMarioState
    {
        public StarBigLeftIdleMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateBigLeftIdleMario();

            mario.physics.velocity.Y = 0;
        }

        public override void ToBig()
        {
            mario.state = new BigLeftIdleMarioState(mario);
        }

        public override void ToDown()
        {
            mario.Position += new Vector2(0, ConstantNumber.BIG_MARIO_UP_AND_DOWN_OFFSET);
            mario.state = new StarBigLeftCrouchingMarioState(mario);
        }

        public override void ToLeft()
        {
            mario.state = new StarBigLeftWalkingMarioState(mario);
        }

        public override void ToRight()
        {
            mario.state = new StarBigRightIdleMarioState(mario);
        }

        public override void ToUp()
        {
            SoundFactory.Instance.playBigMarioJumpSoundEffect();
            mario.physics.ApplyForce(new Vector2(ConstantNumber.MARIO_JUMPING_FORCE_X, -ConstantNumber.MARIO_JUMPING_FORCE_Y));
            mario.state = new StarBigLeftJumpingMarioState(mario);
        }

        public override void Evolve()
        {
            mario.state = new StarFireLeftIdleMarioState(mario);
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

        public override void ToFall()
        {
            mario.state = new StarBigLeftFallingMarioState(mario);
        }
    }
}
