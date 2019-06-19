using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Sprint0
{
    internal class SetMarioToIdleOrCrouchingStateCommand : ICommand
    {
        private Mario mario;
        private Rectangle warpRectangle;

        public SetMarioToIdleOrCrouchingStateCommand(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            if (!Game1.Instance.isPkMode)
            {
                warpRectangle = Game1.Instance.warpPipe.GetSizeRectangle();
            }
            Rectangle marioRectangle = mario.GetSizeRectangle();
            marioRectangle.Height += 2;
            
            
            CollisionDirection dir = CollisionDetection.DetectCollisionDirection(marioRectangle, warpRectangle);
            if (dir == CollisionDirection.Top)
            {
                if(Game1.Instance.backgroundColor == Color.CornflowerBlue)
                {
                    SoundFactory.Instance.playPipeSoundEffect();
                    Game1.Instance.LoadUndergroundLevel();
                }
                else if(Game1.Instance.backgroundColor == Color.Black)
                {
                    SoundFactory.Instance.playPipeSoundEffect();
                    Game1.Instance.LoadOvergroundLevel();
                }
                return;
            }
            Game1.Instance.Mario.ToDown();
        }
  
    }
}
