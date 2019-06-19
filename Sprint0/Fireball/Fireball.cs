using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    internal class Fireball : IProjectile
    {
        public Boolean Destroyed { get; set; } = false;
        public Vector2 position;
        public IProjectileState state;
        public IPhysics physics;
        public bool shootLeft;
        public Fireball(Vector2 pos,bool marioIsLeft)
        {
            position = pos;
            shootLeft = marioIsLeft;
            state = new AttackFireBallState(this);
            physics = new BasicPhysics(this);
        }

        public void Update()
        {
            state.Update();
            physics.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            state.Draw(spriteBatch, position);
        }

        public Rectangle GetSizeRectangle()
        {
            return state.GetSizeRectangle();
        }

        public void Explode()
        {
            state.BeExploded();
        }

        public void Bounce()
        {
            state.Bounce();
        }
    }
}