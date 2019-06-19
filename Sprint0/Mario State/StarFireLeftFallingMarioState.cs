using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class StarFireLeftFallingMarioState : AbstractMarioState
    {
        private int jumpingPower = ConstantNumber.MARIO_JUMPING_POWER;
        private Fireball fireball;

        public StarFireLeftFallingMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateFireLeftJumpMario();
        }

        public override void ToFire()
        {
            mario.state = new FireLeftJumpingMarioState(mario);
        }

        public override void ToLeft()
        {
            if (mario.physics.Velocity.X > -ConstantNumber.MARIO_MOVING_VELOCITY_LIMIT)
            {
                mario.physics.ApplyForce(new Vector2(-ConstantNumber.MARIO_MOVING_FORCE_X, ConstantNumber.MARIO_MOVING_FORCE_Y));

            }
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
            marioSprite.Update();
            if (jumpingPower == 0)
            {
                mario.physics.velocity.Y = 0;

            }
            else if (jumpingPower < 0)
            {
                if (mario.isOnGround)
                {

                    mario.state = new StarFireLeftIdleMarioState(mario);
                }
            }
            jumpingPower--;
            if (mario.fireballLeft == 0)
            {
                mario.reloadTime--;
                if (mario.reloadTime == 0)
                {
                    mario.fireballLeft = ConstantNumber.FIREBALL_LEFT;
                    mario.reloadTime = ConstantNumber.MARIO_RELOAD_TIME;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            location.Y = location.Y - 2;
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
            return new Rectangle((int)mario.Position.X, (int)mario.Position.Y, ConstantNumber.BIG_WIDTH, ConstantNumber.BIG_HEIGHT);
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

        public override void ToIdle()
        {
            mario.state = new StarFireLeftIdleMarioState(mario);

        }

        public override void ToCreepDown()
        {
            mario.state = new StarFireRightCreepDownMarioState(mario);
        }

    }
}
