using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sprint0
{
    internal static class CollisionInvokerItem
    {

        public static void InvokeCollisonItem(Collection<IGameObject> gameObjects, IGameObject item)
        {
            if (item is MushroomItem mushroom)
            {
                foreach (IGameObject collidingGameObject in gameObjects)
                {
                    if (collidingGameObject is IPipe pipe)
                    {
                        MushroomPipeCollisionHandler.HandleCollision(mushroom, pipe);
                    }
                    if (collidingGameObject is IBlock block)
                    {
                        MushroomBlockCollisionHandler.HandleCollision(mushroom, block);
                    }
                }
            }
            else if (item is PoisonMushroomItem poisonMushroom)
            {
                foreach (IGameObject collidingGameObject in gameObjects)
                {
                    if (collidingGameObject is IPipe pipe)
                    {
                        PoisonMushroomPipeCollisionHandler.HandleCollision(poisonMushroom, pipe);
                    }
                    if (collidingGameObject is IBlock block)
                    {
                        PoisonMushroomBlockCollisionHandler.HandleCollision(poisonMushroom, block);
                    }
                }
            }
            else if (item is StarItem star)
            {
                foreach (IGameObject collidingGameObject in gameObjects)
                {
                    if (collidingGameObject is IPipe pipe)
                    {
                        StarPipeCollisionHandler.HandleCollision(star, pipe);
                    }
                    if (collidingGameObject is IBlock block)
                    {
                        StarBlockCollisionHandler.HandleCollision(star, block);
                    }
                }
            }
        }
    }
}

