using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal static class MarioEnemyCollisionHandler
    {
        
        public static void HandleCollision(Game1 game, Mario mario,IEnemy collidingEnemy)
        {
            if (mario.state.isDead())
            {
                return;
            }
            Rectangle marioRectangle = mario.GetSizeRectangle();
            if (collidingEnemy is IEnemy enemy)
            {
                if(enemy is Koopa koopa && koopa.state is FlipedKoopaState)
                {
                    return;
                }
                if (enemy is Goomba goomba && goomba.state is FlipedGoombaState)
                {
                    return;
                }
                if (mario.state.isStar() && !mario.isStarDoingDamage)
                {
                    return;
                }
                Rectangle enemyRectangle = enemy.GetSizeRectangle();
                CollisionDirection direction = CollisionDetection.DetectCollisionDirection(marioRectangle, enemyRectangle);
                if (!(direction is CollisionDirection.NoCollision))
                {
                    if (mario.state.isStar() && mario.isStarDoingDamage)
                    {
                        game.HUD.GetScore(ConstantNumber.SCORE_100);
                        enemy.Flip();
                        SoundFactory.Instance.playStompEnemySoundEffect();
                    }
                    else if (direction is CollisionDirection.Top)
                    { 
                        game.HUD.GetScore(ConstantNumber.SCORE_100);
                        enemy.BeStomped();
                        SoundFactory.Instance.playStompEnemySoundEffect();
                        mario.Bounce();
                    }
                    else if (enemy is Koopa stompedKoopa && stompedKoopa.isStompedIdle)
                    {
                        if (direction is CollisionDirection.Left)
                        {
                            stompedKoopa.TurnRight();
                        }
                        else if (direction is CollisionDirection.Right)
                        {
                            stompedKoopa.TurnLeft();
                        }
                    }
                    else
                    {
                        mario.TakeDamage();
                        SoundFactory.Instance.playTakeDamageSoundEffect();
                    }
                }
            }
        }
    }


}
