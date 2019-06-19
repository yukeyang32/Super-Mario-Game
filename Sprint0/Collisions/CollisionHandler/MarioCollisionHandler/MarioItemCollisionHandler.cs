using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Sprint0
{
    internal static class MarioItemCollisionHandler
    {

        public static void HandleCollision(Game1 game, Mario mario,IItem collidingItem, ref Collection<IGameObject> collidingGameObjects)
        {
            if (mario.state.isDead())
            {
                return;
            }
            Rectangle marioRectangle = mario.GetSizeRectangle();
            Rectangle marioLargeRectangle = mario.GetLargeSizeRectangle();
            if (collidingItem is IItem item)
            {
                Rectangle itemRectangle = item.GetSizeRectangle();
                CollisionDirection direction = CollisionDetection.DetectCollisionDirection(marioRectangle, itemRectangle);
                CollisionDirection directionLargeRectangle = CollisionDetection.DetectCollisionDirection(marioLargeRectangle, itemRectangle);

                if (!(direction is CollisionDirection.NoCollision) || !(directionLargeRectangle is CollisionDirection.NoCollision))
                {
                    if (item is FireFlowerItem)
                    {
                        FireFlowerItem temp = (FireFlowerItem)item;
                        if (temp.triggered)
                        {
                            game.HUD.GetScore(ConstantNumber.SCORE_1000);
                            mario.Evolve();
                            SoundFactory.Instance.playPowerUpSoundEffect();
                            item.Disappear();
                        }
                        else
                        {
                            if (direction is CollisionDirection.Bottom)
                            {
                                item.GetTrigger();
                                SoundFactory.Instance.playVineSoundEffect();
                            }
                        }
                    }
                    if (item is MushroomItem)
                    {
                        MushroomItem temp = (MushroomItem)item;
                        if (temp.triggered)
                        {
                            game.HUD.GetScore(ConstantNumber.SCORE_1000);
                            mario.Evolve();
                            SoundFactory.Instance.playPowerUpSoundEffect();
                            item.Disappear();
                        }
                        else
                        {
                            if (direction is CollisionDirection.Bottom)
                            {
                                item.GetTrigger();
                                SoundFactory.Instance.playVineSoundEffect();
                            }
                        }
                    }
                    if (item is PoisonMushroomItem)
                    {
                        PoisonMushroomItem temp = (PoisonMushroomItem)item;
                        if (temp.triggered)
                        {
                            mario.TakeDamage();
                            SoundFactory.Instance.playTakeDamageSoundEffect();
                            item.Disappear();
                        }
                        else
                        {
                            item.GetTrigger();
                            SoundFactory.Instance.playVineSoundEffect();
                        }
                    }
                    if (item is StarItem)
                    {
                        StarItem temp = (StarItem)item;
                        if (temp.triggered)
                        {
                            game.HUD.GetScore(ConstantNumber.SCORE_1000);
                            mario.ToStar();
                            SoundFactory.Instance.playStarMaioSong();
                            item.Disappear();
                        }
                        else
                        {
                            if (direction is CollisionDirection.Bottom)
                            {
                                item.GetTrigger();
                                SoundFactory.Instance.playVineSoundEffect();
                            }
                        }
                    }

                    if (item is CoinItem)
                    {
                        CoinItem temp = (CoinItem)item;
                        if (!temp.consumed)
                        {
                            if (temp.inBlock)
                            {
                                if (direction is CollisionDirection.Bottom)
                                {
                                    item.GetTrigger();
                                    SoundFactory.Instance.playCoinSoundEffect();
                                    game.HUD.GetCoin();
                                }

                            }
                            else
                            {
                                item.GetTrigger();
                                SoundFactory.Instance.playCoinSoundEffect();
                                game.HUD.GetCoin();
                            }
                        }
                    }

                    if(item is FlagPole flag)
                    {
                        flag.GetTrigger();
                        Game1.Instance.DisableUserControl();
                        Game1.Instance.LoadBasicCommand();
                        mario.Position = new Vector2(flag.GetSizeRectangle().X - mario.GetSizeRectangle().Width, mario.Position.Y);
                        mario.ToCreepDown();
                        SoundFactory.Instance.playFlagpoleSoundEffect();
                        if (flag.flagFallTime < 0 || collidingGameObjects.Count>0)
                        {
                            mario.Position = new Vector2(flag.GetSizeRectangle().X - ConstantNumber.FlAG_POSITION_X_ADJUST + mario.GetSizeRectangle().Width, mario.Position.Y);
                            mario.ToLeft();
                            if (mario.standingTime < 0)
                            {
                                mario.ToRight();

                                mario.ReachDestination = true;
                            }
                            mario.standingTime--;
                        }
                    }
                }
            }
        }
    }


}
