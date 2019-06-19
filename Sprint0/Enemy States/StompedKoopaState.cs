using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class StompedKoopaState : IEnemyState
    {
        private Koopa koopa;
        private ISprite koopaSprite;


        public StompedKoopaState(Koopa koopa)
        {
            this.koopa = koopa;
            koopaSprite = EnemySpriteFactory.Instance.CreateStompedKoopa();
        }

        public void BeIdle()
        {
            if (koopa.moveLeft)
            {
                koopa.state = new LeftIdleKoopaState(koopa);
            }
            else
            {
                koopa.state = new RightIdleKoopaState(koopa);
            }
        }

        public void Left()
        {
            koopa.position.X -= koopa.speed.velocity.X * 4;
        }

        public void Right()
        {
            koopa.position.X += koopa.speed.velocity.X * 4;
        }

        public void Fall()
        {
            koopa.position.Y += koopa.speed.velocity.Y;
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
            koopa.state = new FlipedKoopaState(koopa);
        }

        public void Update()
        {
            if (koopa.shell)
            {
                koopa.shellDuration--;
                if (koopa.shellDuration == 0)
                {
                    koopa.shell = false;
                    koopa.state.BeIdle();
                    koopa.speed.velocity.X = koopa.enemySpeed.velocity.X;
                    koopa.shellDuration = ConstantNumber.SHELL_DURATION;
                }
            }

            if (koopa.moveLeft)
            {
                Left();
            }
            else
            {
                Right();
            }

            if (!koopa.isOnGround)
            {
                Fall();
            }

            koopaSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            koopaSprite.Draw(spriteBatch, location, Color.White);
        }

        public Rectangle GetSizeRectangle()
        {
            return new Rectangle((int)koopa.position.X, (int)koopa.position.Y, ConstantNumber.STOMPED_KOOPA_WIDTH, ConstantNumber.STOMPED_KOOPA_HEIGHT);
        }

    }
}
