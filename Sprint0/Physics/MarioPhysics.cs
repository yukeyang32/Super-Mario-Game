using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    internal class MarioPhysics : IPhysics
    {
        public event EventHandler OnVelocityDecreaseToZero;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 Position { get; set; }
        public Vector2 Velocity
        {
            get => velocity;
            set
            {
                velocity = value;
                if (velocity.X > ConstantNumber.VELOCITY_X_LIMIT)
                    velocity.X = ConstantNumber.VELOCITY_X_LIMIT;
                if (velocity.X < -ConstantNumber.VELOCITY_X_LIMIT)
                {
                    velocity.X = -ConstantNumber.VELOCITY_X_LIMIT;
                }
                if (velocity.Y > ConstantNumber.VELOCITY_Y_LIMIT)
                    velocity.Y = ConstantNumber.VELOCITY_Y_LIMIT;
            }
        }
   
        private Vector2 friction = new Vector2(0.5f, 0);

        public MarioPhysics()
        {
        }
        public void Update()
        {
            ControlRunning();
            Position += velocity;
        }

        private void ControlRunning()
        {
            if (velocity.X != 0)
            {
                if (velocity.X > 0)
                {
                    velocity.X -= friction.X;
                }
                else if (velocity.X < 0)
                {
                    velocity.X += friction.X;
                }
                if (velocity.X == 0 && velocity.Y == 0)
                {
                    OnVelocityDecreaseToZero.Invoke(this, EventArgs.Empty);
                }
            }
        }


        public void ApplyForce(Vector2 force)
        {
            Velocity += force;
        }

    }
}
