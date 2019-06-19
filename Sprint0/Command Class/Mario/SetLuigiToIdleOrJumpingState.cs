using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class SetLuigiToIdleOrJumpingStateCommand : ICommand
    {
        private Mario luigi;

        public SetLuigiToIdleOrJumpingStateCommand(Mario luigi)
        {
            this.luigi = luigi;
        }

        public void Execute()
        {
            luigi.ToUp();
        }
    }
}
