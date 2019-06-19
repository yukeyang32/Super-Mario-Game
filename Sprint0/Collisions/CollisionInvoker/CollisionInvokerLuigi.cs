using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sprint0
{
    internal static class CollisionInvokerLuigi
    {

        public static void InvokeCollisonLuigi(Game1 game, Collection<IGameObject> gameObjects, Mario collidedLuigi)
        {
            Collection<IGameObject> collidingList = new Collection<IGameObject>();
            foreach (IGameObject collidingGameObject in gameObjects)
            {
                if (collidingGameObject is Block block)
                {
                    MarioBlockCollisionHandler.HandleCollision(collidedLuigi, block, ref collidingList);
                }
                if (collidingGameObject is IItem item)
                {
                    MarioItemCollisionHandler.HandleCollision(game, collidedLuigi, item, ref collidingList);
                }
                if (collidingGameObject == Game1.Instance.Mario)
                {
                    MarioLuigiCollisionHandler.HandleCollision(Game1.Instance.Luigi, Game1.Instance.Mario);
                }
            }

            if (collidingList.Count == 0)
            {
                collidedLuigi.ToFall();
                collidedLuigi.physics.ApplyForce(new Vector2(ConstantNumber.Support_Force_X, ConstantNumber.Support_Force_Y));
            }
            else
            {
                collidedLuigi.state.IsJumping = false;
            }
        }
    }
}

