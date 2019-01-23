using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class SetRunningInPlaceMarioSpriteCommand : ICommand
    {
        Game1 myGame;

        public SetRunningInPlaceMarioSpriteCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.MarioSprite = new RunningInPlaceMarioSprite(myGame.Texture, 1, 5);
        }


    }
}