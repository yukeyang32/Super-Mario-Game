using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class FireRightIdleMarioState : AbstractMarioState
    {
        private Fireball fireball;
        private Vector2 fireballPosition;

        public FireRightIdleMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateFireRightIdleMario();
            mario.isLeft = false;

            mario.physics.velocity.Y = 0;
        }

        public override void ToCreepDown()
        {
            mario.state = new FireRightCreepingDownMarioState(mario);
        }

        public override void ToDown()
        {
            mario.Position += new Vector2(0, ConstantNumber.BIG_MARIO_UP_AND_DOWN_OFFSET);
            mario.state = new FireRightCrouchingMarioState(mario);
        }

        public override void ToLeft()
        {
            mario.state = new FireLeftIdleMarioState(mario);
        }

        public override void ToRight()
        {
            mario.state = new FireRightWalkingMarioState(mario);
        }

        public override void ToUp()
        {
            SoundFactory.Instance.playBigMarioJumpSoundEffect();
            mario.physics.ApplyForce(new Vector2(ConstantNumber.MARIO_JUMPING_FORCE_X, -ConstantNumber.MARIO_JUMPING_FORCE_Y));
            mario.state = new FireRightJumpingMarioState(mario);
        }

        public override void TakeDamage()
        {
            mario.isStarDoingDamage = false;
            mario.state = new StarBigRightIdleMarioState(mario);
        }

        public override void ToStar()
        {
            mario.state = new StarFireRightIdleMarioState(mario);
        }


        public override void Update()
        {
            marioSprite.Update();
            if (mario.fireballLeft == 0)
            {
                mario.reloadTime--;
                if (mario.reloadTime == 0)
                {
                    mario.fireballLeft = ConstantNumber.FIREBALL_LEFT;
                    mario.reloadTime = ConstantNumber.MARIO_RELOAD_TIME;
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
            colorSwicth = !colorSwicth;
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

        public override void ShootFireBall()
        {
            if (mario.fireballLeft > 0)
            {
                fireballPosition = mario.Position;
                if (Game1.Instance.isPkMode)
                {
                    fireballPosition.X += ConstantNumber.FIREBALL_OFFSET;
                }
                fireball = new Fireball(fireballPosition, !mario.isLeft);
                SoundFactory.Instance.playFireballSoundEffect();
                Game1.Instance.gameObjects.Add(fireball);
                mario.fireballLeft--;
            }

        }

        public override void Bounce()
        {
            mario.physics.ApplyForce(new Vector2(0, -ConstantNumber.MARIO_BOUNCE_FORCE));
            mario.state = new FireRightJumpingMarioState(mario);

        }

        public override void ToFall()
        {
            mario.state = new FireRightFallingMarioState(mario);
        }
    }
}
