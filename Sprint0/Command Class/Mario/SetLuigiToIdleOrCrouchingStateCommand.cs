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
    internal class SetLuigiToIdleOrCrouchingStateCommand : ICommand
    {
        private Mario luigi;
        private Rectangle warpRectangle;

        public SetLuigiToIdleOrCrouchingStateCommand(Mario luigi)
        {
            this.luigi = luigi;
        }

        public void Execute()
        {
            if (!Game1.Instance.isPkMode)
            {
                warpRectangle = Game1.Instance.warpPipe.GetSizeRectangle();
            } 
            Rectangle luigiRectangle = luigi.GetSizeRectangle();
            luigiRectangle.Height += 2;


            CollisionDirection dir = CollisionDetection.DetectCollisionDirection(luigiRectangle, warpRectangle);
            if (dir == CollisionDirection.Top)
            {
                if (Game1.Instance.backgroundColor == Color.CornflowerBlue)
                {
                    SoundFactory.Instance.playPipeSoundEffect();
                    Game1.Instance.LoadUndergroundLevel();
                }
                else if (Game1.Instance.backgroundColor == Color.Black)
                {
                    SoundFactory.Instance.playPipeSoundEffect();
                    Game1.Instance.LoadOvergroundLevel();
                }
                return;
            }
            Game1.Instance.Luigi.ToDown();
        }

    }
}
