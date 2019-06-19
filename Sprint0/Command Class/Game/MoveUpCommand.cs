using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace Sprint0
{
    internal class MoveUpCommand : ICommand
    {
        private Game1 game;

        public MoveUpCommand(Game1 game)
        {
            this.game = game; 
        }

        public void Execute()
        {
            game.MoveUp();
        }
    }
}