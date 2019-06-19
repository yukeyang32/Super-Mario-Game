using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sprint0
{
    internal class CollisionInvoker
    {
        private Mario mario;
        public CollisionInvoker(Mario Mario)
        {
            mario = Mario;
        }
        public void InvokeCollison(Game1 game, Collection<IGameObject> gameObjects)
        {
            mario.isOnGround = false;
            MarioScreenEdgeCollisionHandler.HandleCollision(mario);
            if (Game1.Instance.isPkMode)
            {
                MarioScreenEdgeCollisionHandler.HandleCollision(Game1.Instance.Luigi);
            }

            foreach (IGameObject gameObject in gameObjects)
            {
                if (gameObject == Game1.Instance.Mario)
                {
                    CollisionInvokerMario.InvokeCollisonMario(game, gameObjects, Game1.Instance.Mario);
                }
                else if (gameObject == Game1.Instance.Luigi)
                {
                    CollisionInvokerLuigi.InvokeCollisonLuigi(game, gameObjects, Game1.Instance.Luigi);
                }
                else if (gameObject is IProjectile fireball)
                {
                    CollisionInvokerProjectile.InvokeCollisonProjectile(game, gameObjects, fireball);
                }
                else if (gameObject is IEnemy enemy)
                {
                    CollisionInvokerEnemy.InvokeCollisonEnemy(game, gameObjects, enemy);
                }
                else if (gameObject is IItem item)
                {
                    CollisionInvokerItem.InvokeCollisonItem(gameObjects, item);
                }
            }
        }
    }
}

