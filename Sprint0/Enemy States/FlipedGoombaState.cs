using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class FlipedGoombaState : IEnemyState
    {
        private Goomba goomba;
        private ISprite goombaSprite;

        public FlipedGoombaState(Goomba goomba)
        {
            this.goomba = goomba;
            goombaSprite = EnemySpriteFactory.Instance.CreateFlipedGoomba();
        }

        public void BeIdle()
        {
        }

        public void Left()
        {
        }

        public void Right()
        {
        }

        public void Fall()
        {
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
            goomba.position.Y++;
            goombaSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            goombaSprite.Draw(spriteBatch, location, Color.White);
        }

        public Rectangle GetSizeRectangle()
        {
            return new Rectangle((int)goomba.position.X, (int)goomba.position.Y, ConstantNumber.GOOMBA_WIDTH, ConstantNumber.GOOMBA_HEIGHT);
        }
    }
}
