using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint0.CollisionDetection;

namespace Sprint0
{
    internal static class MarioBlockCollisionHandler
    {


        public static void HandleCollision(Mario mario,Block collidingBlock, ref Collection<IGameObject> collidingGameObjects)
        {
            if (mario.state is DeadMarioState) {
                return;
            }
            Rectangle marioRectangle = mario.GetSizeRectangle();
            Rectangle marioLargeRectangle = mario.GetLargeSizeRectangle();
            Rectangle blockRectangle = collidingBlock.GetSizeRectangle();
            CollisionDirection direction = DetectCollisionDirection(marioRectangle, blockRectangle);
            CollisionDirection directionLargeRectangle = DetectCollisionDirection(marioLargeRectangle, blockRectangle);
            if(directionLargeRectangle != CollisionDirection.NoCollision )
            {
               collidingGameObjects.Add(collidingBlock);
            }
            if (!(direction is CollisionDirection.NoCollision) && !(collidingBlock.state is HiddenBlockState))
            {
                if (direction is CollisionDirection.Top)
                {
                    mario.Position = new Vector2(mario.Position.X, collidingBlock.GetSizeRectangle().Y - mario.GetSizeRectangle().Height);
                    mario.state.ToIdle();
                    mario.isOnGround = true;
                }
                else if (direction is CollisionDirection.Right)
                {
                     mario.Position = new Vector2(collidingBlock.GetSizeRectangle().X + collidingBlock.GetSizeRectangle().Width, mario.Position.Y);
                     mario.isOnGround = false;
                }
                else if (direction is CollisionDirection.Left)
                {
                     mario.Position = new Vector2(collidingBlock.GetSizeRectangle().X - mario.GetSizeRectangle().Width, mario.Position.Y);
                     mario.isOnGround = false;
                }
                else if (direction is CollisionDirection.Bottom)
                {
                    mario.Position = new Vector2(mario.Position.X, collidingBlock.GetSizeRectangle().Y + collidingBlock.GetSizeRectangle().Height);
                    if (mario.state.isBig() || !(collidingBlock.state is BrickBlockState))
                    {
                        collidingBlock.GetHit();
                        SoundFactory.Instance.playBreakBlockSoundEffect();
                    }
                    else
                    {
                        collidingBlock.GetBump();
                        SoundFactory.Instance.playBumpBlockSoundEffect();
                    }
                    mario.physics.ApplyForce(new Vector2(ConstantNumber.BLOCK_BOUNCE_X, ConstantNumber.BLOCK_BOUNCE_Y));
                    }
                }

            if((direction is CollisionDirection.Bottom) && (collidingBlock.state is HiddenBlockState) && mario.physics.Velocity.Y<0)
            {
                collidingBlock.GetHit();
                SoundFactory.Instance.playBreakBlockSoundEffect();
            }
        }
    }


}
