using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace Sprint0
{
    internal class PauseGameCommand : ICommand
    {
        private Game1 game;

        public PauseGameCommand(Game1 game)
        {
            this.game = game; 
        }

        public void Execute()
        {
            game.PauseGame();
        }
    }
}