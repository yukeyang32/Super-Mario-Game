using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal interface IMario : IGameObject, ICollidable, IMarioPK
    {
        void ToLeft();
        void ToRight();
        void ToUp();
        void ToDown();
        void ToStar();
        void TakeDamage();
        void Evolve();
        void ShootFireBall();

        void Run();
        void Bounce();

        void ToCreepDown();

        void ToFall();

        Rectangle GetLargeSizeRectangle();


    }
}
