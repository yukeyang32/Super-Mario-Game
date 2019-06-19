using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal static class GoombaPipeCollisionHandler
    {

        public static void HandleCollision(Goomba goomba, IGameObject target)
        {
            Rectangle goombaRectangle = goomba.GetSizeRectangle();
            if (goomba.state is FlipedGoombaState)
            {
                return;
            }
            if (target is IPipe pipe)
                {
                    Rectangle pipeRectangle = pipe.GetSizeRectangle();

                    CollisionDirection direction = CollisionDetection.DetectCollisionDirection(goombaRectangle, pipeRectangle);
                    if (!(direction is CollisionDirection.NoCollision))
                    {
                        if (direction is CollisionDirection.Left)
                        {

                            goomba.position = new Vector2(pipe.GetSizeRectangle().X - goomba.GetSizeRectangle().Width, goomba.position.Y);
                            goomba.moveLeft = true;
                        }
                        else if (direction is CollisionDirection.Right)
                        {
                            goomba.position = new Vector2(pipe.GetSizeRectangle().X + pipe.GetSizeRectangle().Width, goomba.position.Y);
                            goomba.moveLeft = false;
                        }
                    }
                }
        }
    }
}
