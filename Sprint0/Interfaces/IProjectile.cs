using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal interface IProjectile : IGameObject,ICollidable
    {

        void Explode();
        void Bounce();

    }
}