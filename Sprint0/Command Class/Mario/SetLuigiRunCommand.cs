using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class SetLuigiRunCommand : ICommand
    {
        private Mario luigi;

        public SetLuigiRunCommand(Mario luigi)
        {
            this.luigi = luigi;
        }

        public void Execute()
        {
            luigi.Run();
        }
    }
}
