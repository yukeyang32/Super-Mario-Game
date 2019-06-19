using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class Mario : IMario
    {
        public IMarioState state;
        private bool destroyed;
        public bool Destroyed
        {
            get => destroyed;
            set
            {
                destroyed = value;
            }
        }

        private bool reachDestination;
        public bool ReachDestination
        {
            get => reachDestination;
            set
            {
                reachDestination = value;
            }
        }
        public Vector2 Position { get => physics.Position; set => physics.Position = value; }
        public MarioPhysics physics;
        public bool isOnGround;
        public bool isLeft;
        public Vector2 acceleration;
        public int jumpingPower;
        public int fireballLeft;
        public int reloadTime;
        public int starTimer = ConstantNumber.MARIO_STAR_POWER_TIMER;
        public int transitionTimer = ConstantNumber.MARIO_TRANSITION_STATE_TIMER;
        public bool isStarDoingDamage = true;
        public int standingTime;
        public int health;

        public Mario()
        {
            physics = new MarioPhysics();
            state = new SmallLeftIdleMarioState(this);
            physics.OnVelocityDecreaseToZero += Physics_OnVelocityDecreaseToZero;
            acceleration = new Vector2(0, 0);
            isLeft = true;
            jumpingPower = ConstantNumber.MARIO_JUMPING_POWER;
            isOnGround = false;
            fireballLeft = ConstantNumber.FIREBALL_LEFT;
            reloadTime = ConstantNumber.MARIO_RELOAD_TIME;
            destroyed = false;
            reachDestination = false;
            standingTime = ConstantNumber.MARIO_STANDING_TIME;
            health = ConstantNumber.MARIO_HEALTH;
        }


        private void Physics_OnVelocityDecreaseToZero(object sender, EventArgs e)
        {
            state.ToIdle();
        }

        public void ToBig()
        {
            state.ToBig();
        }

        public void ToDown()
        {
            state.ToDown();
        }

        public void ToFire()
        {
            state.ToFire();
        }

        public void ToLeft()
        {
            state.ToLeft();
        }

        public void ToRight()
        {
            state.ToRight();
        }

        public void ToSmall()
        {
            state.ToSmall();
        }

        public void Run()
        {
            state.Run();
        }

        public void ToUp()
        {
            state.ToUp();
        }

        public void ToStar()
        {
            state.ToStar();
        }

        public void TakeDamage()
        {
            state.TakeDamage();
        }

        public void ToCreepDown()
        {
            state.ToCreepDown();
        }

        public void Evolve()
        {
            state.Evolve();
        }
        public void Update()
        {
            state.Update();
            physics.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            state.Draw(spriteBatch, Position, color);
        }

        public Rectangle GetSizeRectangle()
        {
            return state.GetSizeRectangle();
        }

        public void ShootFireBall()
        {
            state.ShootFireBall();
        }

        public void Bounce()
        {
            state.Bounce();
        }

        public Rectangle GetLargeSizeRectangle()
        {
            return new Rectangle(state.GetSizeRectangle().X, state.GetSizeRectangle().Y, state.GetSizeRectangle().Width+5, state.GetSizeRectangle().Height+2);
        }

        public void ToFall()
        {
            state.ToFall();
        }

        public void GetInjured()
        {
            state.GetInjured();
        }
    }
}

