using System.Collections;
using System.Collections.Generic;
//For immutable array
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Sprint0
{
    class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings = new Dictionary<Keys, ICommand>();
        public KeyboardController(Game1 game)
        {
            controllerMappings.Add(Keys.Q, new ExitGame(game));
            controllerMappings.Add(Keys.W, new SetStandingInPlaceMarioSpriteCommand(game));
            controllerMappings.Add(Keys.E, new SetRunningInPlaceMarioSpriteCommand(game));
            controllerMappings.Add(Keys.R, new SetDeadMarioMovingUpAndDownSpriteCommand(game));
            controllerMappings.Add(Keys.T, new SetRunningMarioMovingLeftAndRighSpriteCommand(game));
        }


        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            foreach(Keys key in pressedKeys)
            {
                if (controllerMappings.ContainsKey(key))
                {
                    controllerMappings[key].Execute();
                }
            }
        }

    }
}

