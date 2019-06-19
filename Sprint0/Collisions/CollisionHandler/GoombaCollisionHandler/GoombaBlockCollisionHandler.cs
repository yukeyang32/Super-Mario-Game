using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal static class GoombaBlockCollisionHandler
    {
        public static void HandleCollision(Game1 game, Goomba goomba, IGameObject target)
        {
            Rectangle goombaRectangle = goomba.GetSizeRectangle();
            goomba.isOnGround = false;

            if (target is Block block)
            {
                Rectangle blockRectangle = block.GetSizeRectangle();

                CollisionDirection direction = CollisionDetection.DetectCollisionDirection(goombaRectangle, blockRectangle);
                if (goomba.state is FlipedGoombaState)
                {
                    return;
                }
                if (!(direction is CollisionDirection.NoCollision) && !(block.state is HiddenBlockState))
                {                        
                    if (direction is CollisionDirection.Left)
                    {
                        goomba.position = new Vector2(block.GetSizeRectangle().X - goomba.GetSizeRectangle().Width, goomba.position.Y);
                        goomba.moveLeft = true;
                    }
                    else if (direction is CollisionDirection.Right)
                    {
                        goomba.position = new Vector2(block.GetSizeRectangle().X + block.GetSizeRectangle().Width, goomba.position.Y);
                        goomba.moveLeft = false;
                    }
                    else if (direction is CollisionDirection.Top)
                    {
                        goomba.position = new Vector2(goomba.position.X, block.GetSizeRectangle().Y - goomba.GetSizeRectangle().Height);
                        goomba.isOnGround = true;
                    }
                }
                direction = CollisionDetection.DetectCollisionDirection(blockRectangle, goombaRectangle);
                if (!(direction is CollisionDirection.NoCollision))
                {
                    if ((direction is CollisionDirection.Bottom) && ((block.state is BumpedBrickBlockState) || (block.state is BumpedUsedBlockState) || (block.state is ExplodingBlockState)))
                    {
                        game.HUD.GetScore(ConstantNumber.SCORE_100);
                        goomba.Flip();
                    }
                }
            }
        }
    }
}
