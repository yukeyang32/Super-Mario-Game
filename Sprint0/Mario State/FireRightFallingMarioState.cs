using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class FireRightFallingMarioState : AbstractMarioState
    {
        private Fireball fireball;

        public FireRightFallingMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateFireRightJumpMario();
            mario.isLeft = false;
        }

        public override void ToRight()
        {
            if (mario.physics.Velocity.X < ConstantNumber.MARIO_MOVING_VELOCITY_LIMIT)
            {
                mario.physics.ApplyForce(new Vector2(ConstantNumber.MARIO_MOVING_FORCE_X, ConstantNumber.MARIO_MOVING_FORCE_Y));

            }
        }

        public override void TakeDamage()
        {
            mario.isStarDoingDamage = false;
            mario.state = new StarBigRightJumpingMarioState(mario);
        }

        public override void ToStar()
        {
            mario.state = new StarFireRightJumpingMarioState(mario);
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

        public override Rectangle GetSizeRectangle()
        {
            return new Rectangle((int)mario.Position.X, (int)mario.Position.Y, ConstantNumber.BIG_JUMPING_WALKING_WIDTH, ConstantNumber.BIG_HEIGHT);
        }

        public override void ShootFireBall()
        {
            if (mario.fireballLeft > 0)
            {
                fireball = new Fireball(mario.Position, !mario.isLeft);
                Game1.Instance.gameObjects.Add(fireball);
                mario.fireballLeft--;
            }

        }

        public override void Bounce()
        {
            mario.physics.ApplyForce(new Vector2(0, -ConstantNumber.MARIO_BOUNCE_FORCE));
            mario.state = new FireRightJumpingMarioState(mario);

        }

        public override void ToIdle()
        {
            mario.state = new FireRightIdleMarioState(mario);
        }
    }
}
