using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal static class KoopaBlockCollisionHandler
    {

        public static void HandleCollision(Game1 game, Koopa koopa, IGameObject target)
        {

            Rectangle koopaRectangle = koopa.GetSizeRectangle();
            koopa.isOnGround = false;

            if (target is Block block)
            {
                Rectangle blockRectangle = block.GetSizeRectangle();
                CollisionDirection direction = CollisionDetection.DetectCollisionDirection(koopaRectangle, blockRectangle);
                if (koopa.state is FlipedKoopaState)
                {
                    return;
                }
                if (!(direction is CollisionDirection.NoCollision) && !(block.state is HiddenBlockState))
                {                        
                    if (direction is CollisionDirection.Left)
                    {
                        koopa.position = new Vector2(block.GetSizeRectangle().X - koopa.GetSizeRectangle().Width-5, koopa.position.Y);
                        koopa.TurnLeft();
                        koopa.moveLeft = true;
                    }
                    else if (direction is CollisionDirection.Right)
                    {
                        koopa.position = new Vector2(block.GetSizeRectangle().X + block.GetSizeRectangle().Width, koopa.position.Y);
                        koopa.TurnRight();
                        koopa.moveLeft = false;
                    }
                    else if (direction is CollisionDirection.Top)
                    {
                        koopa.position = new Vector2(koopa.position.X, block.GetSizeRectangle().Y - koopa.GetSizeRectangle().Height);
                        koopa.isOnGround = true;
                    }
                }
                direction = CollisionDetection.DetectCollisionDirection(blockRectangle, koopaRectangle);
                if (!(direction is CollisionDirection.NoCollision))
                {
                    if ((direction is CollisionDirection.Bottom) && ((block.state is BumpedBrickBlockState) || (block.state is BumpedUsedBlockState) || (block.state is ExplodingBlockState)))
                    {
                        game.HUD.GetScore(ConstantNumber.SCORE_100);
                        koopa.Flip();
                    }
                }
            }
        }
    }
}
