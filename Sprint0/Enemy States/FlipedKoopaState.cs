using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class FlipedKoopaState : IEnemyState
    {
        private Koopa koopa;
        private ISprite koopaSprite;

        public FlipedKoopaState(Koopa koopa)
        {
            this.koopa = koopa;
            koopaSprite = EnemySpriteFactory.Instance.CreateFlipedKoopa();
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

        public void BeIdle()
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
            koopa.position.Y++;
            koopaSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            koopaSprite.Draw(spriteBatch, location, Color.White);
        }

        public Rectangle GetSizeRectangle()
        {
            return new Rectangle((int)koopa.position.X + ConstantNumber.KOOPA_POSITION_X_ADJUST, (int)koopa.position.Y + ConstantNumber.KOOPA_POSITION_Y_ADJUST, ConstantNumber.STOMPED_KOOPA_WIDTH, ConstantNumber.STOMPED_KOOPA_HEIGHT);
        }
    }
}
