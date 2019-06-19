using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sprint0
{
    internal static class CollisionInvokerEnemy
    {

        public static void InvokeCollisonEnemy(Game1 game, Collection<IGameObject> gameObjects, IGameObject enemy)
        {
            if (enemy is Koopa koopa)
            {
                foreach (IGameObject collidingGameObject in gameObjects)
                {
                    if (collidingGameObject is IPipe pipe)
                    {
                        KoopaPipeCollisionHandler.HandleCollision(koopa, pipe);
                    }
                    if (collidingGameObject is IBlock block)
                    {
                        KoopaBlockCollisionHandler.HandleCollision(game, koopa, block);
                    }
                    if (collidingGameObject is IEnemy collidingEnemy)
                    {
                        KoopaEnemyCollisionHandler.HandleCollision(koopa, collidingEnemy);
                    }
                }
            }
            else if (enemy is Goomba goomba)
            {
                foreach (IGameObject collidingGameObject in gameObjects)
                {
                    if (collidingGameObject is IPipe pipe)
                    {
                        GoombaPipeCollisionHandler.HandleCollision(goomba, pipe);
                    }
                    if (collidingGameObject is IBlock block)
                    {
                        GoombaBlockCollisionHandler.HandleCollision(game, goomba, block);
                    }
                    if (collidingGameObject is IEnemy collidingEnemy)
                    {
                        GoombaEnemyCollisionHandler.HandleCollision(goomba, collidingEnemy);
                    }
                }
            }
        }
    }
}

