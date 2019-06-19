using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal static class StarPipeCollisionHandler
    {

        public static void HandleCollision(StarItem star, IGameObject target)
        {
            Rectangle starRectangle = star.GetSizeRectangle();
            
                if (target is IPipe pipe)
                {
                    Rectangle pipeRectangle = pipe.GetSizeRectangle();

                    CollisionDirection direction = CollisionDetection.DetectCollisionDirection(starRectangle, pipeRectangle);
                    if (!(direction is CollisionDirection.NoCollision))
                    {
                        if (direction is CollisionDirection.Left)
                        {

                        star.position = new Vector2(pipe.GetSizeRectangle().X - star.GetSizeRectangle().Width, star.position.Y);
                        star.moveLeft = true;
                        }
                        else if (direction is CollisionDirection.Right)
                        {
                        star.position = new Vector2(pipe.GetSizeRectangle().X + pipe.GetSizeRectangle().Width, star.position.Y);
                        star.moveLeft = false;
                        }
                    }
                }
        }
    }
}
