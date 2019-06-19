using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal static class MushroomPipeCollisionHandler
    {

        public static void HandleCollision(MushroomItem mushroom, IGameObject target)
        {
            Rectangle mushroomRectangle = mushroom.GetSizeRectangle();
            
                if (target is IPipe pipe)
                {
                    Rectangle pipeRectangle = pipe.GetSizeRectangle();

                    CollisionDirection direction = CollisionDetection.DetectCollisionDirection(mushroomRectangle, pipeRectangle);
                    if (!(direction is CollisionDirection.NoCollision))
                    {
                        if (direction is CollisionDirection.Left)
                        {

                            mushroom.position = new Vector2(pipe.GetSizeRectangle().X - mushroom.GetSizeRectangle().Width, mushroom.position.Y);
                            mushroom.moveLeft = true;
                        }
                        else if (direction is CollisionDirection.Right)
                        {
                            mushroom.position = new Vector2(pipe.GetSizeRectangle().X + pipe.GetSizeRectangle().Width, mushroom.position.Y);
                            mushroom.moveLeft = false;
                        }
                    }
                }
        }
    }
}
