using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class StompedGoombaState : IEnemyState
    {
        private Goomba goomba;
        private ISprite goombaSprite;

        public StompedGoombaState(Goomba goomba)
        {
            this.goomba = goomba;
            goombaSprite = EnemySpriteFactory.Instance.CreateStompedGoomba();
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
        }

        public void Flip()
        {
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
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            goombaSprite.Draw(spriteBatch, location, Color.White);
        }

        public Rectangle GetSizeRectangle()
        {
            return new Rectangle((int)goomba.position.X, (int)goomba.position.Y+ConstantNumber.GOOMBA_POSITION_Y_ADJUST, ConstantNumber.STOMPED_GOOMBA_WIDTH, ConstantNumber.STOMPED_GOOMBA_HEIGHT);
        }
    }
}
