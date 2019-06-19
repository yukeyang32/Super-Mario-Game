using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace Sprint0
{
    internal class ExitGameCommand : ICommand
    {
        private Game1 game;

        public ExitGameCommand(Game1 game)
        {
            this.game = game; 
        }

        public void Execute()
        {
            game.Exit();
        }
    }
}