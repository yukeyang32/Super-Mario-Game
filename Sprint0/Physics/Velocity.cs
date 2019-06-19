using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class Velocity
    {
        public Vector2 velocity;

        public Velocity (Vector2 speed)
        {
            this.velocity = speed;
            velocity.X = speed.X*0.5f;
            velocity.Y = speed.Y*0.5f;

        }

        public Velocity(Velocity speed)
        {
            this.velocity.X = speed.velocity.X;
            this.velocity.Y = speed.velocity.Y;

        }
    }
}
