using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sprint0
{
    internal static class CollisionInvokerMario
    {

        public static void InvokeCollisonMario(Game1 game, Collection<IGameObject> gameObjects, Mario collidedMario)
        {
            Collection<IGameObject> collidingList = new Collection<IGameObject>();
            foreach (IGameObject collidingGameObject in gameObjects)
            {
                if (collidingGameObject is Pipe pipe)
                {
                    MarioPipeCollisionHandler.HandleCollision(collidedMario, pipe, ref collidingList);
                }
                if (collidingGameObject is Block block)
                {
                    MarioBlockCollisionHandler.HandleCollision(collidedMario, block, ref collidingList);
                }
                if (collidingGameObject is IEnemy enemy)
                {
                    MarioEnemyCollisionHandler.HandleCollision(game, collidedMario, enemy);
                }
                if (collidingGameObject is IItem item)
                {
                    MarioItemCollisionHandler.HandleCollision(game, collidedMario, item, ref collidingList);
                }
                if (collidingGameObject == Game1.Instance.Luigi)
                {
                    MarioLuigiCollisionHandler.HandleCollision(Game1.Instance.Mario, Game1.Instance.Luigi);
                }
            }

            int numHiddenBlocks = 0;
            foreach (IGameObject igo in collidingList)
            {
                if (igo is Block block)
                {
                    if(block.state is HiddenBlockState)
                    {
                        numHiddenBlocks++;
                    }
                }
            }
            if (collidingList.Count == 0 || collidingList.Count == numHiddenBlocks)
            {
                collidedMario.ToFall();
                collidedMario.physics.ApplyForce(new Vector2(ConstantNumber.Support_Force_X, ConstantNumber.Support_Force_Y));
            }
            else
            {
                collidedMario.state.IsJumping = false;
            }
        }
    }
}

