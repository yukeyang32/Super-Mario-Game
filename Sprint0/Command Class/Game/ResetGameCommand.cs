using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace Sprint0
{
    internal class ResetGameCommand : ICommand
    {
        private Game1 game;

        public ResetGameCommand(Game1 game)
        {
            this.game = game; 
        }

        public void Execute()
        {
            game.ReLoadGame();
        }
    }
}