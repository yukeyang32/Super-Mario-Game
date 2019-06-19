using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal interface IEnemyState:ICollidable
    {
        void BeIdle();
        void BeStomped();
        void Update();
        void Left();
        void Right();
        void Fall();
        void TurnLeft();
        void TurnRight();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void Flip();
    }
}
