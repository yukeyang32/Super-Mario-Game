using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace Sprint0
{
    public class ExitGame : ICommand
    {
        private Game1 game;

        public ExitGame(Game1 game)
        {
            this.game = game; 
        }

        public void Execute()
        {
            game.Exit();
        }
    }
}