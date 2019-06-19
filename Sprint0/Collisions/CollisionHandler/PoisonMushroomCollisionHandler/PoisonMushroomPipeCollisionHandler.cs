using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal static class PoisonMushroomPipeCollisionHandler
    {

        public static void HandleCollision(PoisonMushroomItem poisonMushroom, IGameObject target)
        {
            Rectangle poisonMushroomRectangle = poisonMushroom.GetSizeRectangle();
            
                if (target is IPipe pipe)
                {
                    Rectangle pipeRectangle = pipe.GetSizeRectangle();

                    CollisionDirection direction = CollisionDetection.DetectCollisionDirection(poisonMushroomRectangle, pipeRectangle);
                    if (!(direction is CollisionDirection.NoCollision))
                    {
                        if (direction is CollisionDirection.Left)
                        {

                        poisonMushroom.position = new Vector2(pipe.GetSizeRectangle().X - poisonMushroom.GetSizeRectangle().Width, poisonMushroom.position.Y);
                        poisonMushroom.moveLeft = true;
                        }
                        else if (direction is CollisionDirection.Right)
                        {
                        poisonMushroom.position = new Vector2(pipe.GetSizeRectangle().X + pipe.GetSizeRectangle().Width, poisonMushroom.position.Y);
                        poisonMushroom.moveLeft = false;
                        }
                    }
                }
        }
    }
}
