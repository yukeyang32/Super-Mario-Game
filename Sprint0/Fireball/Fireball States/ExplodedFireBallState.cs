using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class ExplodedFireBallState : IProjectileState
    {
        private Fireball fireball;
        private ISprite fireballSprite;
        private int timer = ConstantNumber.FIREBALL_TIMER;

        public ExplodedFireBallState(Fireball fireball)
        {
            this.fireball = fireball;
            fireballSprite = ProjectileSpriteFactory.Instance.CreateExplodedFireBall();
        }

        public void BeExploded()
        {

        }
        public void Update()
        {
            while (timer > 0)
            {
                timer--;
                if (timer == 0)
                {
                    fireball.Destroyed = true;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            fireballSprite.Draw(spriteBatch, location, Color.White);
        }

        public Rectangle GetSizeRectangle()
        {
            return new Rectangle((int)fireball.position.X, (int)fireball.position.Y, ConstantNumber.FIREBALL_WIDTH_COLLISION, ConstantNumber.FIREBALL_HEIGHT_COLLISION);
        }


        public void Bounce()
        {

        }


    }
}
