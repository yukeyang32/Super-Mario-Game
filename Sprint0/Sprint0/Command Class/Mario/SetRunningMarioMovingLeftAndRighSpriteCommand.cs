using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class SetRunningMarioMovingLeftAndRighSpriteCommand : ICommand 
    {
        Game1 myGame;

        public SetRunningMarioMovingLeftAndRighSpriteCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.MarioSprite = new RunningLeftAndRIghtMarioSprite(myGame, myGame.Texture, 1, 5);
        }
    }
}
