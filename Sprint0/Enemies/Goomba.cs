using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    internal class Goomba : IEnemy
    {
        public bool Destroyed { get; set; } = false;
        public int timer;
        public bool killed = false;
        public IEnemyState state;
        public Vector2 position;
        public Velocity speed;
        public bool isOnGround = false;
        public bool moveLeft = true;

        public Goomba(Vector2 pos, Velocity enemySpeed)
        {
            position = pos;
            state = new IdleGoombaState(this);
            speed = new Velocity(enemySpeed);
        }

        public void BeStomped()
        {
            state.BeStomped();
            speed.velocity.X = 0;
            killed = true;
            timer = ConstantNumber.GOOMBA_DIE_TIME;
        }

        public void Left()
        {
            state.Left();
        }

        public void Right()
        {
            state.Right();
        }

        public void Fall()
        {
            state.Fall();
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