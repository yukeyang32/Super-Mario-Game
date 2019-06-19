using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal static class KoopaPipeCollisionHandler
    {

        public static void HandleCollision(Koopa koopa, IGameObject target)
        {
            Rectangle koopaRectangle = koopa.GetSizeRectangle();
            if (koopa.state is FlipedKoopaState)
            {
                return;
            }
            if (target is IPipe pipe)
                {
                    Rectangle pipeRectangle = pipe.GetSizeRectangle();

                    CollisionDirection direction = CollisionDetection.DetectCollisionDirection(koopaRectangle, pipeRectangle);
                    if (!(direction is CollisionDirection.NoCollision))
                    {
                        if (direction is CollisionDirection.Left)
                        {

                            koopa.position = new Vector2(pipe.GetSizeRectangle().X - koopa.GetSizeRectangle().Width, koopa.position.Y);
                            koopa.TurnLeft();
                            koopa.moveLeft = true;
                        }
                        else if (direction is CollisionDirection.Right)
                        {
                            koopa.position = new Vector2(pipe.GetSizeRectangle().X + pipe.GetSizeRectangle().Width, koopa.position.Y);
                            koopa.TurnRight();
                            koopa.moveLeft = false;
                        }
                    }
                }
        }
    }
}
