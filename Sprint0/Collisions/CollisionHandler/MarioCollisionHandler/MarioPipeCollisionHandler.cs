using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal static class MarioPipeCollisionHandler
    {

        public static void HandleCollision(Mario mario, Pipe collidingPipe,ref Collection<IGameObject>collidingGameObjects)
        {
            if (mario.state.isDead())
            {
                return;
            }
            Rectangle marioRectangle = mario.GetSizeRectangle();
            Rectangle marioLargeRectangle = mario.GetLargeSizeRectangle();
            if (collidingPipe is IPipe pipe)
            {
                Rectangle pipeRectangle = pipe.GetSizeRectangle();

                CollisionDirection direction = CollisionDetection.DetectCollisionDirection(marioRectangle, pipeRectangle);
                CollisionDirection directionLargeRectangle = CollisionDetection.DetectCollisionDirection(marioLargeRectangle, pipeRectangle);
                if (directionLargeRectangle != CollisionDirection.NoCollision)
                {
                    collidingGameObjects.Add(collidingPipe);
                }
                if (!(direction is CollisionDirection.NoCollision))
                {
                    if (direction is CollisionDirection.Top)
                    {
                        mario.Position = new Vector2(mario.Position.X, pipe.GetSizeRectangle().Y - mario.GetSizeRectangle().Height);
                        collidingGameObjects.Add(pipe);
                        mario.state.ToIdle();
                    }
                    else if (direction is CollisionDirection.Left)
                    {
                        mario.Position = new Vector2(pipe.GetSizeRectangle().X - mario.GetSizeRectangle().Width, mario.Position.Y);
                    }
                    else if (direction is CollisionDirection.Right)
                    {
                        mario.Position = new Vector2(pipe.GetSizeRectangle().X +pipe.GetSizeRectangle().Width, mario.Position.Y);
                    }
                    else if (direction is CollisionDirection.Bottom)
                    {
                        mario.Position = new Vector2(mario.Position.X, pipe.GetSizeRectangle().Y + pipe.GetSizeRectangle().Height);
                    }
                }
            }
        }
    }


}
