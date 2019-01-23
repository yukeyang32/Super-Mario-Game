using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class GamePadController : IController
    {
        public Game1 Game { get; set; }
        private ICommand currentCommand;
        private GamePadState gamePadState;
        public GamePadController(Game1 game)
        {
            Game = game;
        }


        public void Update()
        {
            gamePadState = GamePad.GetState(PlayerIndex.One);
            if (gamePadState.Buttons.Start.Equals(ButtonState.Pressed))
            {
                currentCommand = new ExitGame(Game);
                currentCommand.Execute();
            }
            if (gamePadState.Buttons.A.Equals(ButtonState.Pressed))
            {
                currentCommand = new SetStandingInPlaceMarioSpriteCommand(Game);
                currentCommand.Execute();
            }
            if (gamePadState.Buttons.B.Equals(ButtonState.Pressed))
            {
                currentCommand = new SetRunningInPlaceMarioSpriteCommand(Game);
                currentCommand.Execute();
            }
            if (gamePadState.Buttons.X.Equals(ButtonState.Pressed))
            {
                currentCommand = new SetDeadMarioMovingUpAndDownSpriteCommand(Game);
                currentCommand.Execute();
            }
            if (gamePadState.Buttons.Y.Equals(ButtonState.Pressed))
            {
                currentCommand = new SetRunningMarioMovingLeftAndRighSpriteCommand(Game);
                currentCommand.Execute();
            }
        }
    }
}
