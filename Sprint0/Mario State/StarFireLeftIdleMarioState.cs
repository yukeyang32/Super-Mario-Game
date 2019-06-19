using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class StarFireLeftIdleMarioState : AbstractMarioState
    {
        private Fireball fireball;

        public StarFireLeftIdleMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateFireLeftIdleMario();

            mario.physics.velocity.Y = 0;
            mario.isLeft = true;
        }

        public override void ToDown()
        {
            mario.state = new StarFireLeftCrouchingMarioState(mario);
        }

        public override void ToFire()
        {
            mario.state = new FireLeftIdleMarioState(mario);
        }

        public override void ToLeft()
        {
            mario.state = new StarFireLeftWalkingMarioState(mario);
        }

        public override void ToRight()
        {
            mario.state = new StarFireRightIdleMarioState(mario);
        }

        public override void ToUp()
        {
            SoundFactory.Instance.playBigMarioJumpSoundEffect();
            mario.physics.ApplyForce(new Vector2(ConstantNumber.MARIO_JUMPING_FORCE_X, -ConstantNumber.MARIO_JUMPING_FORCE_Y));
            mario.state = new StarFireLeftJumpingMarioState(mario);
        }

        public override void Update()
        {
            mario.starTimer--;
            if (mario.starTimer == 0)
            {
                mario.ToFire();
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

            if (mario.fireballLeft == 0)
            {
                mario.reloadTime--;
                if (mario.reloadTime == 0)
                {
                    mario.fireballLeft = ConstantNumber.FIREBALL_LEFT;
                    mario.reloadTime = ConstantNumber.MARIO_RELOAD_TIME;
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

        public override void ShootFireBall()
        {
            if (mario.fireballLeft > 0)
            {
                fireball = new Fireball(mario.Position, !mario.isLeft);
                SoundFactory.Instance.playFireballSoundEffect();
                Game1.Instance.gameObjects.Add(fireball);
                mario.fireballLeft--;
            }
        }

        public override void ToFall()
        {
            mario.state = new StarFireLeftFallingMarioState(mario);
        }
    }
}
