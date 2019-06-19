using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class SetMarioDirectionToLeftCommand : ICommand
    {
        private Mario mario;

        public SetMarioDirectionToLeftCommand(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            mario.ToLeft();
        }
    }
}
