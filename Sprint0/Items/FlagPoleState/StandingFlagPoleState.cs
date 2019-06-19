using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class StandingFlagPoleState : IItemState
    {
        private FlagPole flagPole;
        private ISprite flagPoleSprite;

        public StandingFlagPoleState(FlagPole flagPole)
        {
            this.flagPole = flagPole;
            flagPoleSprite = ItemSpriteFactory.Instance.CreateFlagPole();
        }


        public void Update()
        {
            flagPoleSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            flagPoleSprite.Draw(spriteBatch, location, Color.White);
        }

        public Rectangle GetSizeRectangle()
        {
            return new Rectangle((int)flagPole.position.X + ConstantNumber.FlAG_POSITION_X_ADJUST, (int)flagPole.position.Y, ConstantNumber.FLAG_POLE_WIDTH, ConstantNumber.FLAG_POLE_HEIGHT);
        }

        public void GetTrigger()
        {
            flagPole.state = new TriggeredFlagPoleState(flagPole);
        }
    }
}