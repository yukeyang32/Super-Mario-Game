using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using Microsoft.Xna.Framework.Input;
using System.Collections.ObjectModel;

namespace Sprint0
{
    internal class LevelLoader
    {
        private LevelLoader()
        {

        }

        public static void LoadLevel(Collection<IGameObject> gameObjects, string level)
        {
            using(TextFieldParser parser = new TextFieldParser(level))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                int cellSize = ConstantNumber.LEVEL_LOADER_SPACING;
                int csvY = ConstantNumber.LEVEL_LOADER_STARTING_Y;
                Velocity enemySpeed = new Velocity(new Vector2(ConstantNumber.ENEMY_ITEM_SPEED_X, ConstantNumber.ENEMY_ITEM_SPEED_Y));
                Velocity itemSpeed = new Velocity(new Vector2(ConstantNumber.ENEMY_ITEM_SPEED_X, ConstantNumber.ENEMY_ITEM_SPEED_Y));

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    for (int x = 0; x < fields.Length; x++)
                    {
                        switch (fields[x])
                        {
                            case "ff"://FireFlower item
                                gameObjects.Add(new FireFlowerItem(new Vector2(cellSize * x, cellSize * csvY)));
                                break;
                            case "c"://Coin item
                                gameObjects.Add(new CoinItem(new Vector2(cellSize * x, cellSize * csvY)));
                                break;
                            case "sm"://Super Mushroom item
                                Game1.Instance.mushroom = new MushroomItem(new Vector2(cellSize * x, cellSize * csvY), itemSpeed);
                                gameObjects.Add(Game1.Instance.mushroom);
                                break;
                            case "pm"://Poison Mushroom item
                                Game1.Instance.poisonMushroom = new PoisonMushroomItem(new Vector2(cellSize * x, cellSize * csvY), itemSpeed);
                                gameObjects.Add(Game1.Instance.poisonMushroom);
                                break;
                            case "s"://Star item
                                Game1.Instance.star = new StarItem(new Vector2(cellSize * x, cellSize * csvY), itemSpeed);
                                gameObjects.Add(Game1.Instance.star);
                                break;
                            case "g"://Goomba enemy
                                Game1.Instance.goomba = new Goomba(new Vector2(cellSize * x, cellSize * csvY), enemySpeed);
                                gameObjects.Add(Game1.Instance.goomba);
                                break;
                            case "k"://Koopa enemy
                                Game1.Instance.koopa = new Koopa(new Vector2(cellSize * x, cellSize * csvY), enemySpeed);
                                gameObjects.Add(Game1.Instance.koopa);
                                break;
                            case "hb"://Hidden Block
                                IBlock hiddenBlock = new Block(new Vector2(cellSize * x, cellSize * csvY));
                                hiddenBlock.ToHiddenBlock();
                                gameObjects.Add(hiddenBlock);
                                break;
                            case "ub"://Used Block
                                IBlock usedBlock = new Block(new Vector2(cellSize * x, cellSize * csvY));
                                usedBlock.ToUsedBlock();
                                gameObjects.Add(usedBlock);
                                break;
                            case "bb"://Brick Block
                                IBlock brickBlock = new Block(new Vector2(cellSize * x, cellSize * csvY));
                                gameObjects.Add(brickBlock);
                                break;
                            case "qb"://Empty Question Block
                                IBlock questionBlock = new Block(new Vector2(cellSize * x, cellSize * csvY));
                                questionBlock.ToQuestionBlock();
                                gameObjects.Add(questionBlock);
                                break;
                            case "qbm"://Question Block with Mushroom
                                IBlock questionBlockM = new Block(new Vector2(cellSize * x, cellSize * csvY));
                                questionBlockM.ToQuestionBlock();
                                gameObjects.Add(questionBlockM);
                                Game1.Instance.mushroom = new MushroomItem(new Vector2(cellSize * x, cellSize * csvY), itemSpeed);
                                gameObjects.Add(Game1.Instance.mushroom);
                                break;
                            case "qbf"://Question Block with Fire Flower
                                IBlock questionBlockF = new Block(new Vector2(cellSize * x, cellSize * csvY));
                                questionBlockF.ToQuestionBlock();
                                gameObjects.Add(questionBlockF);
                                gameObjects.Add(new FireFlowerItem(new Vector2(cellSize * x, cellSize * csvY)));
                                break;
                            case "qbs"://Question Block with Star
                                IBlock questionBlockS = new Block(new Vector2(cellSize * x, cellSize * csvY));
                                questionBlockS.ToQuestionBlock();
                                gameObjects.Add(questionBlockS);
                                Game1.Instance.star = new StarItem(new Vector2(cellSize * x, cellSize * csvY), itemSpeed);
                                gameObjects.Add(Game1.Instance.star);
                                break;
                            case "qbc"://Question Block with Coin
                                IBlock questionBlockC = new Block(new Vector2(cellSize * x, cellSize * csvY));
                                questionBlockC.ToQuestionBlock();
                                gameObjects.Add(questionBlockC);
                                CoinItem coinItem = new CoinItem(new Vector2(cellSize * x, cellSize * csvY));
                                coinItem.inBlock = true;
                                gameObjects.Add(coinItem);
                                break;
                            case "spb": //Smooth platform block
                                IBlock smoothPlatformBlock = new Block(new Vector2(cellSize * x, cellSize * csvY));
                                smoothPlatformBlock.ToSmoothPlatformBlock();
                                gameObjects.Add(smoothPlatformBlock);
                                break;
                            case "spbf": //Smooth platform block with flag
                                IBlock smoothPlatformBlockFlag = new Block(new Vector2(cellSize * x+8, cellSize * csvY));
                                smoothPlatformBlockFlag.ToSmoothPlatformBlock();
                                gameObjects.Add(smoothPlatformBlockFlag);
                                break;
                            case "rpb"://Rough platform block
                                IBlock roughPlatformBlock = new Block(new Vector2(cellSize * x, cellSize * csvY));
                                roughPlatformBlock.ToRoughPlatformBlock();
                                gameObjects.Add(roughPlatformBlock);
                                break;
                            case "m"://Mario
                                var mario = new Mario() { Position = new Vector2(cellSize * x, cellSize * csvY) };
                                Game1.Instance.Mario = mario;
                                gameObjects.Add(Game1.Instance.Mario);
                                break;
                            case "m2"://Mario
                                var luigi = new Mario() { Position = new Vector2(cellSize * x, cellSize * csvY) };
                                Game1.Instance.Luigi = luigi;
                                gameObjects.Add(Game1.Instance.Luigi);
                                break;
                            case "p"://Pipe
                                gameObjects.Add(new Pipe(new Vector2(cellSize * x, cellSize * csvY)));
                                break;
                            case "wp"://Warp Pipe
                                var pipe = new Pipe(new Vector2(cellSize * x, cellSize * csvY));
                                gameObjects.Add(pipe);
                                Game1.Instance.warpPipe = pipe;
                                break;
                            case "fp"://FlagPole
                                gameObjects.Add(new FlagPole(new Vector2(cellSize * x, cellSize * csvY)));
                                break;
                            default:
                                break;
                        }
                    }
                    csvY++;
                }
            }
        }

        public static void ChangeLevel(Collection<IGameObject> gameObjects, string level)
        {
            using (TextFieldParser parser = new TextFieldParser(level))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                int cellSize = ConstantNumber.CELL_SIZE;
                int csvY = ConstantNumber.CELL_STARTING_ROW;
                Velocity enemySpeed = new Velocity(new Vector2(ConstantNumber.ENEMY_ITEM_SPEED_X, ConstantNumber.ENEMY_ITEM_SPEED_Y));
                Velocity itemSpeed = new Velocity(new Vector2(ConstantNumber.ENEMY_ITEM_SPEED_X, ConstantNumber.ENEMY_ITEM_SPEED_Y));

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    for (int x = 0; x < fields.Length; x++)
                    {
                        switch (fields[x])
                        {
                            case "ff"://FireFlower item
                                gameObjects.Add(new FireFlowerItem(new Vector2(cellSize * x, cellSize * csvY)));
                                break;
                            case "c"://Coin item
                                gameObjects.Add(new CoinItem(new Vector2(cellSize * x, cellSize * csvY)));
                                break;
                            case "sm"://Super Mushroom item
                                Game1.Instance.mushroom = new MushroomItem(new Vector2(cellSize * x, cellSize * csvY), itemSpeed);
                                gameObjects.Add(Game1.Instance.mushroom);
                                break;
                            case "pm"://Poison Mushroom item
                                Game1.Instance.poisonMushroom = new PoisonMushroomItem(new Vector2(cellSize * x, cellSize * csvY), itemSpeed);
                                gameObjects.Add(Game1.Instance.poisonMushroom);
                                break;
                            case "s"://Star item
                                Game1.Instance.star = new StarItem(new Vector2(cellSize * x, cellSize * csvY), itemSpeed);
                                gameObjects.Add(Game1.Instance.star);
                                break;
                            case "g"://Goomba enemy
                                Game1.Instance.goomba = new Goomba(new Vector2(cellSize * x, cellSize * csvY), enemySpeed);
                                gameObjects.Add(Game1.Instance.goomba);
                                break;
                            case "k"://Koopa enemy
                                Game1.Instance.koopa = new Koopa(new Vector2(cellSize * x, cellSize * csvY), enemySpeed);
                                gameObjects.Add(Game1.Instance.koopa);
                                break;
                            case "hb"://Hidden Block
                                IBlock hiddenBlock = new Block(new Vector2(cellSize * x, cellSize * csvY));
                                hiddenBlock.ToHiddenBlock();
                                gameObjects.Add(hiddenBlock);
                                break;
                            case "ub"://Used Block
                                IBlock usedBlock = new Block(new Vector2(cellSize * x, cellSize * csvY));
                                usedBlock.ToUsedBlock();
                                gameObjects.Add(usedBlock);
                                break;
                            case "bb"://Brick Block
                                IBlock brickBlock = new Block(new Vector2(cellSize * x, cellSize * csvY));
                                gameObjects.Add(brickBlock);
                                break;
                            case "qb"://Empty Question Block
                                IBlock questionBlock = new Block(new Vector2(cellSize * x, cellSize * csvY));
                                questionBlock.ToQuestionBlock();
                                gameObjects.Add(questionBlock);
                                break;
                            case "qbm"://Question Block with Mushroom
                                IBlock questionBlockM = new Block(new Vector2(cellSize * x, cellSize * csvY));
                                questionBlockM.ToQuestionBlock();
                                gameObjects.Add(questionBlockM);
                                Game1.Instance.mushroom = new MushroomItem(new Vector2(cellSize * x, cellSize * csvY), itemSpeed);
                                gameObjects.Add(Game1.Instance.mushroom);
                                break;
                            case "qbf"://Question Block with Fire Flower
                                IBlock questionBlockF = new Block(new Vector2(cellSize * x, cellSize * csvY));
                                questionBlockF.ToQuestionBlock();
                                gameObjects.Add(questionBlockF);
                                gameObjects.Add(new FireFlowerItem(new Vector2(cellSize * x, cellSize * csvY)));
                                break;
                            case "qbs"://Question Block with Star
                                IBlock questionBlockS = new Block(new Vector2(cellSize * x, cellSize * csvY));
                                questionBlockS.ToQuestionBlock();
                                gameObjects.Add(questionBlockS);
                                Game1.Instance.star = new StarItem(new Vector2(cellSize * x, cellSize * csvY), itemSpeed);
                                gameObjects.Add(Game1.Instance.star);
                                break;
                            case "qbc"://Question Block with Coin
                                IBlock questionBlockC = new Block(new Vector2(cellSize * x, cellSize * csvY));
                                questionBlockC.ToQuestionBlock();
                                gameObjects.Add(questionBlockC);
                                CoinItem coinItem = new CoinItem(new Vector2(cellSize * x, cellSize * csvY));
                                coinItem.inBlock = true;
                                gameObjects.Add(coinItem);
                                break;
                            case "spb": //Smooth platform block
                                IBlock smoothPlatformBlock = new Block(new Vector2(cellSize * x, cellSize * csvY));
                                smoothPlatformBlock.ToSmoothPlatformBlock();
                                gameObjects.Add(smoothPlatformBlock);
                                break;
                            case "spbf": //Smooth platform block with flag
                                IBlock smoothPlatformBlockFlag = new Block(new Vector2(cellSize * x + 8, cellSize * csvY));
                                smoothPlatformBlockFlag.ToSmoothPlatformBlock();
                                gameObjects.Add(smoothPlatformBlockFlag);
                                break;
                            case "rpb"://Rough platform block
                                IBlock roughPlatformBlock = new Block(new Vector2(cellSize * x, cellSize * csvY));
                                roughPlatformBlock.ToRoughPlatformBlock();
                                gameObjects.Add(roughPlatformBlock);
                                break;
                            case "m"://Mario
                                Game1.Instance.Mario.Position = new Vector2(cellSize * x, cellSize * csvY);
                                gameObjects.Add(Game1.Instance.Mario);
                                break;
                            case "p"://Pipe
                                gameObjects.Add(new Pipe(new Vector2(cellSize * x, cellSize * csvY)));
                                break;
                            case "wp"://Warp Pipe
                                var pipe = new Pipe(new Vector2(cellSize * x, cellSize * csvY));
                                gameObjects.Add(pipe);
                                Game1.Instance.warpPipe = pipe;
                                break;
                            case "fp"://FlagPole
                                gameObjects.Add(new FlagPole(new Vector2(cellSize * x, cellSize * csvY)));
                                break;
                            default:
                                break;
                        }
                    }
                    csvY++;
                }
            }
        }

    }
}
