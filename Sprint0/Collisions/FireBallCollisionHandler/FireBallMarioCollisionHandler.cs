using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint0.CollisionDetection;

namespace Sprint0
{
    internal static class FireBallMarioCollisionHandler
    { 
        public static void HandleCollision(IGameObject collingfireball, IGameObject collidedMario)
        {
            if ((collidedMario is Mario mario) && (collingfireball is Fireball fireball))
            {
                Rectangle fireballRectangle = fireball.GetSizeRectangle();
                Rectangle marioRectangle = mario.GetSizeRectangle();
                CollisionDirection direction = DetectCollisionDirection(fireballRectangle, marioRectangle);

                if (!(direction is CollisionDirection.NoCollision))
                {
                    fireball.Explode();
                    mario.GetInjured();
                }
            }
        }

    }
}

