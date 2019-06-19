using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class SetLuigiDirectionToLeftCommand : ICommand
    {
        private Mario luigi;

        public SetLuigiDirectionToLeftCommand(Mario luigi)
        {
            this.luigi = luigi;
        }

        public void Execute()
        {
            luigi.ToLeft();
        }
    }
}
