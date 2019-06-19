using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal static class GoombaEnemyCollisionHandler
    {

        public static void HandleCollision(Goomba goomba, IGameObject target)
        {
            Rectangle goombaRectangle = goomba.GetSizeRectangle();
            if (goomba.state is FlipedGoombaState)
            {
                return;
            }
            if (target is IEnemy enemy)
                {
                    Rectangle enemyRectangle = enemy.GetSizeRectangle();

                    CollisionDirection direction = CollisionDetection.DetectCollisionDirection(goombaRectangle, enemyRectangle);
                    if (!(direction is CollisionDirection.NoCollision))
                    {
                        if (direction is CollisionDirection.Left)
                        {
                            goomba.position = new Vector2(enemy.GetSizeRectangle().X - goomba.GetSizeRectangle().Width, goomba.position.Y);
                            goomba.moveLeft = true;
                        }
                        else if (direction is CollisionDirection.Right)
                        {
                            goomba.position = new Vector2(enemy.GetSizeRectangle().X + enemy.GetSizeRectangle().Width, goomba.position.Y);
                            goomba.moveLeft = false;
                        }

                    }
                }
        }
    }
}
