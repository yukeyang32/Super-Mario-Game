using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal interface IMarioState:ICollidable, IMarioPK
    {
        void Bounce();
        void ToIdle();
        void ToLeft();
        void ToRight();
        void ToUp();
        void ToDown();
        void ToSmall();
        void ToBig();
        void ToFire();
        void ToStar();

        void ToCreepDown();
        void TakeDamage();
        void Evolve();
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location, Color color);
        bool isStar();
        bool isBig();
        void ShootFireBall();

        void Run();

        bool isDead();

        void ToFall();
        bool IsJumping { get; set; }

    }
}
