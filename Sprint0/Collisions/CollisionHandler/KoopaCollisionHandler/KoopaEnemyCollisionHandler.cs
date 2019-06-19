using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal static class KoopaEnemyCollisionHandler
    {

        public static void HandleCollision(Koopa koopa, IGameObject target)
        {
            Rectangle koopaRectangle = koopa.GetSizeRectangle();
            if (koopa.state is FlipedKoopaState)
            {
                return;
            }
            if (target is IEnemy enemy)
            {
                Rectangle enemyRectangle = enemy.GetSizeRectangle();
                CollisionDirection direction = CollisionDetection.DetectCollisionDirection(koopaRectangle, enemyRectangle);
                if (!(direction is CollisionDirection.NoCollision))
                {
                    if (direction is CollisionDirection.Left)
                    {
                        koopa.position = new Vector2(enemy.GetSizeRectangle().X - koopa.GetSizeRectangle().Width, koopa.position.Y);
                        if (koopa.state is StompedKoopaState)
                        {
                            enemy.Disappear();
                        }
                        else
                        {
                            koopa.TurnLeft();
                            koopa.moveLeft = true;
                        }
                    }
                    else if (direction is CollisionDirection.Right)
                    {
                        koopa.position = new Vector2(enemy.GetSizeRectangle().X + enemy.GetSizeRectangle().Width, koopa.position.Y);
                        if (koopa.state is StompedKoopaState)
                        {
                            enemy.Disappear();
                        }
                        else
                        {
                            koopa.TurnRight();
                            koopa.moveLeft = false;
                        }
                    }
                }
            }
        }
    }
}
