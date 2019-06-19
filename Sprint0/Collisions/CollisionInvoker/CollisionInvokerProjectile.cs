using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sprint0
{
    internal static class CollisionInvokerProjectile
    {

        public static void InvokeCollisonProjectile(Game1 game, Collection<IGameObject> gameObjects, IGameObject gameObject)
        {
            foreach (IGameObject collidingGameObject in gameObjects)
            {
                if (collidingGameObject is IPipe)
                {
                    FireBallPipeCollisionHandler.HandleCollision(gameObject, collidingGameObject);
                }
                if (collidingGameObject is IBlock)
                {
                    FireBallBlockCollisionHandler.HandleCollision(gameObject, collidingGameObject);
                }
                if (collidingGameObject is IEnemy)
                {
                    FireBallEnemyCollisionHandler.HandleCollision(game, gameObject, collidingGameObject);
                }
                if (collidingGameObject is Mario && Game1.Instance.isPkMode)
                {
                    FireBallMarioCollisionHandler.HandleCollision(gameObject, collidingGameObject);
                }
            }
        }
    }
}

