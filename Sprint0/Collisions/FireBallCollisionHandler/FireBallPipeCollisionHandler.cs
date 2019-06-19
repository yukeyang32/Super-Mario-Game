using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint0.CollisionDetection;

namespace Sprint0
{
    internal static class FireBallPipeCollisionHandler
    {


        public static void HandleCollision(IGameObject collingfireball, IGameObject collidedPipe)
        {
            if ((collidedPipe is Pipe pipe) && (collingfireball is Fireball fireball))
            {
                Rectangle fireballRectangle = fireball.GetSizeRectangle();
                Rectangle pipeRectangle = pipe.GetSizeRectangle();
                CollisionDirection direction = DetectCollisionDirection(fireballRectangle, pipeRectangle);
                if (!(direction is CollisionDirection.NoCollision))
                {
                    if (direction is CollisionDirection.Left)
                    {
                        fireball.position = new Vector2(pipe.GetSizeRectangle().X - fireball.GetSizeRectangle().Width, fireball.position.Y);
                        fireball.Explode();
                    }
                    else if (direction is CollisionDirection.Right)
                    {
                        fireball.position = new Vector2(pipe.GetSizeRectangle().X + pipe.GetSizeRectangle().Width, fireball.position.Y);
                        fireball.Explode();
                    }
                    else if (direction is CollisionDirection.Top)
                    {
                        fireball.position = new Vector2(fireball.position.X, pipe.GetSizeRectangle().Y - fireball.GetSizeRectangle().Height);
                    }
                    else if (direction is CollisionDirection.Bottom)
                    {
                        fireball.position = new Vector2(fireball.position.X, pipe.GetSizeRectangle().Y + pipe.GetSizeRectangle().Height);
                        fireball.Explode();
                    }

                }
            }
        }

    }
}

