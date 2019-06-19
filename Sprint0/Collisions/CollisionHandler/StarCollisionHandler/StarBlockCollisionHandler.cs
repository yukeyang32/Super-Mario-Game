using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal static class StarBlockCollisionHandler
    {
        public static void HandleCollision(StarItem star, IGameObject target)
        {
            Rectangle starRectangle = star.GetSizeRectangle();
            

            if (target is Block block)
            {
                Rectangle blockRectangle = block.GetSizeRectangle();

                CollisionDirection direction = CollisionDetection.DetectCollisionDirection(starRectangle, blockRectangle);

                if (!(direction is CollisionDirection.NoCollision))
                {
                    if (star.triggered)
                    {
                        if (direction is CollisionDirection.Left)
                        {
                            star.position = new Vector2(block.GetSizeRectangle().X - star.GetSizeRectangle().Width, star.position.Y);
                            star.moveLeft = true;
                        }
                        else if (direction is CollisionDirection.Right)
                        {
                            star.position = new Vector2(block.GetSizeRectangle().X + block.GetSizeRectangle().Width, star.position.Y);
                            star.moveLeft = false;
                        }
                        else if (direction is CollisionDirection.Top)
                        {
                            star.position = new Vector2(star.position.X, block.GetSizeRectangle().Y - star.GetSizeRectangle().Height);
                            star.isOnGround = true;
                            star.initialY = star.position.Y;
                            star.Rise();
                        }
                    }

                }
                else
                {
                    star.isOnGround = false;
                }
            }
        }
    }
}
