using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal static class FireBallEnemyCollisionHandler
    {
        
        public static void HandleCollision(Game1 game, IGameObject collingfireball, IGameObject collidedEnemy)
        {
            if ((collidedEnemy is IEnemy enemy) && (collingfireball is Fireball fireball))
            {
                Rectangle fireballRectangle = fireball.GetSizeRectangle();
                Rectangle enemyRectangle = enemy.GetSizeRectangle();
                CollisionDirection direction = CollisionDetection.DetectCollisionDirection(fireballRectangle, enemyRectangle);
                if (!(direction is CollisionDirection.NoCollision))
                    {
                    if (direction is CollisionDirection.Top)
                        {
                            fireball.position = new Vector2(fireball.position.X, enemy.GetSizeRectangle().Y - fireball.GetSizeRectangle().Height);
                        }
                    else if (direction is CollisionDirection.Left)
                        {
                            fireball.position = new Vector2(enemy.GetSizeRectangle().X - fireball.GetSizeRectangle().Width, fireball.position.Y);
                        }
                    else if (direction is CollisionDirection.Right)
                        {
                            fireball.position = new Vector2(enemy.GetSizeRectangle().X + enemy.GetSizeRectangle().Width, fireball.position.Y);
                        }
                    else if (direction is CollisionDirection.Bottom)
                        {
                            fireball.position = new Vector2(fireball.position.X, enemy.GetSizeRectangle().Y + enemy.GetSizeRectangle().Height);
                        }
                    game.HUD.GetScore(ConstantNumber.SCORE_100);
                    enemy.Flip();
                    fireball.Explode();
                }
            }
        }
    }
}

