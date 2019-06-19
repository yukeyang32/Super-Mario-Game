using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class DeadMarioState : AbstractMarioState
    {

        public DeadMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateSmallDeadMario();
        }

        public override void Update()
        {
            mario.physics.ApplyForce(new Vector2(ConstantNumber.DEAD_MARIO_FORCE_X, ConstantNumber.DEAD_MARIO_FORCE_Y));
            marioSprite.Update();
            colorSwicth = !colorSwicth;
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

        public override bool isDead()
        {
            return true;
        }

    }
}
