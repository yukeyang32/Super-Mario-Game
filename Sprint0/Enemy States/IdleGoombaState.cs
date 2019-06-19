using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class IdleGoombaState : IEnemyState
    {
        private Goomba goomba;
        private ISprite goombaSprite;

        public IdleGoombaState(Goomba goomba)
        {
            this.goomba = goomba;
            goombaSprite = EnemySpriteFactory.Instance.CreateIdleGoomba();
        }

        public void BeIdle()
        {
        }

        public void Left()
        {
            goomba.position.X -= goomba.speed.velocity.X;
        }

        public void Right()
        {
            goomba.position.X += goomba.speed.velocity.X;
        }

        public void Fall()
        {
            goomba.position.Y += goomba.speed.velocity.Y;
        }

        public void TurnLeft()
        {
        }

        public void TurnRight()
        {
        }

        public void BeStomped()
        {
            goomba.state = new StompedGoombaState(goomba);
        }

        public void Flip()
        {
            goomba.state = new FlipedGoombaState(goomba);
        }

        public void Update()
        {
            if (goomba.killed)
            {
                goomba.timer--;
                if (goomba.timer == 0)
                {
                    goomba.killed = false;
                    goomba.Disappear();
                }
            }

            if (goomba.moveLeft)
            {
                Left();
            }
            else
            {
                Right();
            }

            if (!goomba.isOnGround)
            {
                goomba.Fall();
            }
            goombaSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            goombaSprite.Draw(spriteBatch, location, Color.White);
        }

        public Rectangle GetSizeRectangle()
        {
            return new Rectangle((int)goomba.position.X, (int)goomba.position.Y, ConstantNumber.GOOMBA_WIDTH,ConstantNumber.GOOMBA_HEIGHT);
        }
    }
}