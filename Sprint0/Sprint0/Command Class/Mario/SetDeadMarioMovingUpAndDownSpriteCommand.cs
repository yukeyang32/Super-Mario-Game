using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class SetDeadMarioMovingUpAndDownSpriteCommand : ICommand
    {
        Game1 myGame;

        public SetDeadMarioMovingUpAndDownSpriteCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.MarioSprite = new DeadMarioMovingUpAndDownSprite(myGame,myGame.Texture, new Rectangle(30, 0, myGame.MARIO_SPRITE_WIDTH, myGame.MARIO_SPRITE_HEIGHT));
        }
    }
}
