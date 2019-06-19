using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal static class MushroomBlockCollisionHandler
    {
        public static void HandleCollision(MushroomItem mushroom, IGameObject target)
        {
            Rectangle mushroomRectangle = mushroom.GetSizeRectangle();
            mushroom.isOnGround = false;

            if (target is Block block)
            {
                Rectangle blockRectangle = block.GetSizeRectangle();

                CollisionDirection direction = CollisionDetection.DetectCollisionDirection(mushroomRectangle, blockRectangle);

                if (!(direction is CollisionDirection.NoCollision))
                {
                    if (mushroom.triggered)
                    {
                        if (direction is CollisionDirection.Left)
                        {
                            mushroom.position = new Vector2(block.GetSizeRectangle().X - mushroom.GetSizeRectangle().Width, mushroom.position.Y);
                            mushroom.moveLeft = true;
                        }
                        else if (direction is CollisionDirection.Right)
                        {
                            mushroom.position = new Vector2(block.GetSizeRectangle().X + block.GetSizeRectangle().Width, mushroom.position.Y);
                            mushroom.moveLeft = false;
                        }
                        else if (direction is CollisionDirection.Top)
                        {
                            mushroom.position = new Vector2(mushroom.position.X, block.GetSizeRectangle().Y - mushroom.GetSizeRectangle().Height);
                            mushroom.isOnGround = true;
                        }
                    }

                }
            }
        }
    }
}
