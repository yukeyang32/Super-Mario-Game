using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class FireLeftCreepingDownMarioState : AbstractMarioState
    {

        public FireLeftCreepingDownMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateFireLeftCreepingDownMario();
            mario.isLeft = true;

            mario.physics.velocity.Y = 0;
        }

        public override void ToStar()
        {
            mario.state = new StarBigLeftIdleMarioState(mario);
        }

        public override void ToRight()
        {
            mario.state = new FireRightWalkingMarioState(mario);
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
            return new Rectangle((int)mario.Position.X - ConstantNumber.BIG_MARIO_POSITION_X_ADJUST, (int)mario.Position.Y, ConstantNumber.BIG_WIDTH, ConstantNumber.BIG_HEIGHT + ConstantNumber.BIG_MARIO_CREEPING_POSITION_Y_ADJUST);
        }

    }
}
