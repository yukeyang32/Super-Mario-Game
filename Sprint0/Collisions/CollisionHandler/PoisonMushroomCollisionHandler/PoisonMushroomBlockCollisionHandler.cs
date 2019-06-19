using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal static class PoisonMushroomBlockCollisionHandler
    {
        public static void HandleCollision(PoisonMushroomItem poisonMushroom, IGameObject target)
        {
            Rectangle poisonMushroomRectangle = poisonMushroom.GetSizeRectangle();
            //Problem: check if goomba is above blocks, which then determines whether apply Fall method
            poisonMushroom.isOnGround = false;

            if (target is Block block)
            {
                Rectangle blockRectangle = block.GetSizeRectangle();

                CollisionDirection direction = CollisionDetection.DetectCollisionDirection(poisonMushroomRectangle, blockRectangle);
               
                if (!(direction is CollisionDirection.NoCollision))
                {
                    if (poisonMushroom.triggered)
                    {
                        if (direction is CollisionDirection.Left)
                        {
                            poisonMushroom.position = new Vector2(block.GetSizeRectangle().X - poisonMushroom.GetSizeRectangle().Width, poisonMushroom.position.Y);
                            poisonMushroom.moveLeft = true;
                        }
                        else if (direction is CollisionDirection.Right)
                        {
                            poisonMushroom.position = new Vector2(block.GetSizeRectangle().X + block.GetSizeRectangle().Width, poisonMushroom.position.Y);
                            poisonMushroom.moveLeft = false;
                        }
                        else if (direction is CollisionDirection.Top)
                        {
                            poisonMushroom.position = new Vector2(poisonMushroom.position.X, block.GetSizeRectangle().Y - poisonMushroom.GetSizeRectangle().Height);
                            poisonMushroom.isOnGround = true;
                        }
                    }

                }
            }
        }
    }
}
