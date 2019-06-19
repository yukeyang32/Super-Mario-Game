using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal static class MarioScreenEdgeCollisionHandler
    {
        public static void HandleCollision(Mario mario)
        {
            Rectangle sreenRectangle = new Rectangle(0,0,ConstantNumber.SCREEN_WIDTH,ConstantNumber.SCREEN_HEIGHT);

            if (!sreenRectangle.Contains(mario.Position.X, mario.Position.Y)){
                if (mario.Position.Y < 0)
                {
                    mario.Position = new Vector2(mario.Position.X, 0);
                }
                if (mario.Position.Y > sreenRectangle.Height)
                {
                    if (!Game1.Instance.deadSongPlayed)
                    {
                        SoundFactory.Instance.playDeadSong();
                        Game1.Instance.deadSongPlayed = true;
                    }
                }
                if (mario.Position.Y > ConstantNumber.SCREEN_HEIGHT_ADJUST)
                {
                    Game1.Instance.ReLoadLevel();
                    Game1.Instance.deadSongPlayed = false;
                }
            }
            if (Game1.Instance.isPkMode && mario.Position.X < 0)
            {
                mario.Position = new Vector2(0, mario.Position.Y);
            }
            if (Game1.Instance.isPkMode && mario.Position.X > ConstantNumber.SCREEN_WIDTH - ConstantNumber.BIG_JUMPING_WALKING_WIDTH)
            {
                mario.Position = new Vector2(ConstantNumber.SCREEN_WIDTH - ConstantNumber.BIG_JUMPING_WALKING_WIDTH, mario.Position.Y);
            }
        }
    }

}
