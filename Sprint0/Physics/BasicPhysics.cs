using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    internal class BasicPhysics : IPhysics
    {
        private Fireball fireball;
        private Vector2 gravity = new Vector2(0, 1f);

        public BasicPhysics(Fireball fireball)
        {
            this.fireball = fireball;
        }
        public void Update()
        {
            fireball.position += gravity;
        }

        public void ApplyForce(Vector2 force)
        {
            fireball.position += force;
        }
    }
}
