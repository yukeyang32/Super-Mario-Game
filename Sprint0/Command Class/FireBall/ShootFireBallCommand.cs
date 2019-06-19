using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class ShootFireBallCommand : ICommand
    {
        private Mario mario;

        public ShootFireBallCommand(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            mario.ShootFireBall();
        }
    }
}
