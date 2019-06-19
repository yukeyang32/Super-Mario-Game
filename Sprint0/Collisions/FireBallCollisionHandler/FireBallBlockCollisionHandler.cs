using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint0.CollisionDetection;

namespace Sprint0
{
    internal static class FireBallBlockCollisionHandler
    {


        public static void HandleCollision(IGameObject collingfireball, IGameObject collidedBlock)
        {
            if ((collidedBlock is Block block) && (collingfireball is Fireball fireball))
            {
                Rectangle fireballRectangle = fireball.GetSizeRectangle();
                Rectangle blockRectangle = block.GetSizeRectangle();
                CollisionDirection direction = DetectCollisionDirection(fireballRectangle, blockRectangle);

                if ((!(block.state is HiddenBlockState) && !(direction is CollisionDirection.NoCollision)))
                {
                    if (direction is CollisionDirection.Top)
                    {
                        fireball.position = new Vector2(fireball.position.X, block.GetSizeRectangle().Y - fireball.GetSizeRectangle().Height);
                        fireball.Bounce();
                    }
                    else
                    {
                        fireball.Explode();
                        System.Diagnostics.Debug.WriteLine(direction);
                    }
                }
            }
        }

    }
}

