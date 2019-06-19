using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal interface IProjectileState:ICollidable
    {
        void BeExploded();
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void Bounce();

    }
}
