using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class FireLeftCrouchingMarioState : AbstractMarioState
    {

        public FireLeftCrouchingMarioState(Mario mario) : base(mario)
        {
            marioSprite = MarioSpriteFactory.Instance.CreateFireLeftCrouchMario();
            mario.isLeft = true;
        }

        public override void ToUp()
        {
            mario.Position -= new Vector2(0, ConstantNumber.BIG_MARIO_UP_AND_DOWN_OFFSET);
            mario.state = new FireLeftIdleMarioState(mario);
        }

        public override void ToCreepDown()
        {
            mario.state = new FireLeftCreepingDownMarioState(mario);
        }

        public override void TakeDamage()
        {
            mario.isStarDoingDamage = false;
            mario.state = new StarBigLeftCrouchingMarioState(mario);
        }

        public override Rectangle GetSizeRectangle()
        {
            return new Rectangle((int)mario.Position.X, (int)mario.Position.Y, ConstantNumber.BIG_WIDTH, ConstantNumber.CROUCHING_HEIGHT);
        }

        public override void ToStar()
        {
            mario.state = new StarFireLeftCrouchingMarioState(mario);
        }

        public override void Update()
        {
            marioSprite.Update();
            if (mario.fireballLeft == 0)
            {
                mario.reloadTime--;
                if (mario.reloadTime == 0)
                {
                    mario.fireballLeft = ConstantNumber.FIREBALL_LEFT;
                    mario.reloadTime = ConstantNumber.MARIO_RELOAD_TIME;
                }
            }

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

        public override void ToFall()
        {
            mario.state = new FireLeftFallingMarioState(mario);
        }
    }
}
