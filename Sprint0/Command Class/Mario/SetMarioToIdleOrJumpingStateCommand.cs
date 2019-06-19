using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class SetMarioToIdleOrJumpingStateCommand : ICommand
    {

        public SetMarioToIdleOrJumpingStateCommand()
        {
        }

        public void Execute()
        {
            Game1.Instance.Mario.ToUp();
        }
    }
}
