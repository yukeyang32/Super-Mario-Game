using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class SmallRightCreepingDownMarioState : AbstractMarioState
    {

        public SmallRightCreepingDownMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateSmallRightCreepingDownMario();
            mario.isLeft = true;

            mario.physics.velocity.Y = 0;
        }


        public override void ToLeft()
        {
            mario.state = new SmallLeftCreepingDownMarioState(mario);
        }

        public override void ToRight()
        {
            mario.state = new SmallRightIdleMarioState(mario);
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
            return new Rectangle((int)mario.Position.X, (int)mario.Position.Y, ConstantNumber.SMALL_WIDTH + ConstantNumber.SMALL_MARIO_WIDTH_ADJUST, ConstantNumber.SMALL_HEIGHT + ConstantNumber.SMALL_MARIO_CREEPING_HEIGHT_ADJUST);
        }

    }
}
