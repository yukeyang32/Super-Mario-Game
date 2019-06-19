using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class AbstractMarioState : IMarioState
    {
        protected Mario mario;
        protected ISprite marioSprite;
        protected bool colorSwicth = true;
        protected bool isJumping = false;
        public bool IsJumping {
            get => isJumping;
            set
            {
                isJumping = value;
            }
        }

        protected AbstractMarioState(Mario mario)
        {
            this.mario = mario;
        }

        public virtual void Bounce()
        {
            //
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            //
        }

        public virtual void Evolve()
        {
            //
        }

        public virtual Rectangle GetSizeRectangle()
        {
            return new Rectangle((int)mario.Position.X, (int)mario.Position.Y, ConstantNumber.BIG_WIDTH, ConstantNumber.BIG_HEIGHT);
        }

        public virtual bool isBig()
        {
            return true;
        }

        public virtual bool isDead()
        {
            return false;
        }

        public virtual bool isStar()
        {
            return false;
        }

        public virtual bool isLeft()
        {
            return true;
        }

        public virtual void Run()
        {
            //
        }

        public virtual void ShootFireBall()
        {
            //
        }

        public virtual void TakeDamage()
        {
            //
        }

        public virtual void ToBig()
        {
            //
        }

        public virtual void ToDown()
        {
            //
        }

        public virtual void ToFire()
        {
            //
        }

        public virtual void ToIdle()
        {
            //
        }

        public virtual void ToCreepDown()
        {

        }

        public virtual void ToLeft()
        {
            //
        }

        public virtual void ToRight()
        {
            //
        }

        public virtual void ToSmall()
        {
            //
        }

        public virtual void ToStar()
        {
            //
        }

        public virtual void ToUp()
        {
            //
        }

        public virtual void ToFall()
        {
            //
        }

        public void GetInjured()
        {
            mario.health -= 3;
        }

        public virtual void Update()
        {
            if (mario.ReachDestination)
            {

                if (mario.standingTime < 0)
                {
                    mario.ToRight();
                    if (mario.physics.velocity.X <= ConstantNumber.MARIO_DESTINATION_SPEED_LIMIT)
                    {
                        mario.ToRight();
                    }

                }
                mario.standingTime--;
            }
            if (mario.Position.X > ConstantNumber.LEVEL_END)
            {
                mario.Destroyed = true;
            }
            marioSprite.Update();
            colorSwicth = !colorSwicth;

        }

    }
}
