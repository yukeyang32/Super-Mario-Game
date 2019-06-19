using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    internal class Koopa : IEnemy
    {
        public bool Destroyed { get; set; } = false;
        public IEnemyState state;
        public Vector2 position;
        public Velocity speed;
        public Velocity enemySpeed;
        public bool isOnGround = false;
        public bool moveLeft = true;
        public bool shell = false;
        public int shellDuration;
        public bool isStompedIdle = false;

        public Koopa(Vector2 pos, Velocity enemySpeed)
        {
            position = pos;
            state = new LeftIdleKoopaState(this);
            speed = new Velocity(enemySpeed);
            this.enemySpeed = enemySpeed;
            shellDuration = ConstantNumber.SHELL_DURATION;
        }

        public void TurnLeft()
        {
            state.TurnLeft();
        }

        public void TurnRight()
        {
            state.TurnRight();
        }

        public void Left()
        {
            state.Left();
        }

        public void Right()
        {
            state.Right();
        }

        public void BeStomped()
        {
            if (!shell)
            {
                shell = true;
                state.BeStomped();
                speed.velocity.X = 0;
                shellDuration = ConstantNumber.SHELL_DURATION;
            }
            else
            {
                speed.velocity.X = enemySpeed.velocity.X;
            }  
        }
        
        public void Update()
        {
            state.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            state.Draw(spriteBatch, position);
        }

        public Rectangle GetSizeRectangle()
        {
            return state.GetSizeRectangle();
        }

        public void Disappear()
        {
            this.Destroyed = true;
        }

        public void Flip()
        {
            state.Flip();
        }
    }
}