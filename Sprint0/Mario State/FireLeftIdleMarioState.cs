using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class FireLeftIdleMarioState : AbstractMarioState
    {
        private Fireball fireball;
        private Vector2 fireballPosition;

        public FireLeftIdleMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateFireLeftIdleMario();
            mario.isLeft = true;


            mario.physics.velocity.Y = 0;
        }

        public override void ToDown()
        {
            mario.Position += new Vector2(0, ConstantNumber.BIG_MARIO_UP_AND_DOWN_OFFSET);
            mario.state = new FireLeftCrouchingMarioState(mario);
        }

        public override void ToLeft()
        {
            mario.state = new FireLeftWalkingMarioState(mario);
        }

        public override void ToRight()
        {
            mario.state = new FireRightIdleMarioState(mario);
        }

        public override void ToUp()
        {
            SoundFactory.Instance.playBigMarioJumpSoundEffect();
            mario.physics.ApplyForce(new Vector2(ConstantNumber.MARIO_JUMPING_FORCE_X, -ConstantNumber.MARIO_JUMPING_FORCE_Y));
            mario.state = new FireLeftJumpingMarioState(mario);
        }

        public override void TakeDamage()
        {
            mario.isStarDoingDamage = false;
            mario.state = new StarBigLeftIdleMarioState(mario);
        }

        public override void ToStar()
        {
            mario.state = new StarFireLeftIdleMarioState(mario);
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
            colorSwicth = !colorSwicth;
        }

        public override void ToCreepDown()
        {
            mario.state = new FireLeftCreepingDownMarioState(mario);
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
                    fireballPosition.X -= ConstantNumber.FIREBALL_OFFSET;
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
            mario.state = new FireLeftJumpingMarioState(mario);

        }

        public override void ToFall()
        {
            mario.state = new FireLeftFallingMarioState(mario);
        }
    }
}
