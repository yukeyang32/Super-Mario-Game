using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class AttackFireBallState : IProjectileState
    {
        private Fireball fireball;
        private ISprite fireballSprite;

        public AttackFireBallState(Fireball fireball)
        {
            this.fireball = fireball;
            fireballSprite = ProjectileSpriteFactory.Instance.CreateFireBall();
        }

        public void BeExploded()
        {
            fireball.state = new ExplodedFireBallState(fireball);
        }

        public void Update()
        {
            fireballSprite.Update();
            if (fireball.shootLeft)
            {
                fireball.position.X += ConstantNumber.FIREBALL_VELOCITY;
            }
            else
            {
                fireball.position.X -= ConstantNumber.FIREBALL_VELOCITY;
            }

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            fireballSprite.Draw(spriteBatch, location, Color.White);
        }

        public Rectangle GetSizeRectangle()
        {
            return new Rectangle((int)fireball.position.X, (int)fireball.position.Y, ConstantNumber.FIREBALL_WIDTH_COLLISION,ConstantNumber.FIREBALL_HEIGHT_COLLISION);
        }

        public void Bounce()
        {
 
            fireball.physics.ApplyForce(new Vector2(0, ConstantNumber.FIREBALL_BOUNCE_VELOCITY));
        }
    }
}