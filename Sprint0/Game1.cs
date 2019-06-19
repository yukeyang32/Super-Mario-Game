using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework.Media;

namespace Sprint0
{
    
    internal class Game1 : Game
    {
        private SpriteBatch spriteBatch;

        private IController keyboardController;
        public Collection<IGameObject> gameObjects;
        private List<IGameObject> removeList;
        private List<BackgroundSprite> backgroundList;
        private PkBackgroundSprite marioHealthBar;
        private PkBackgroundSprite luigiHealthBar;
        private Mario mario;
        public Mario Mario { get { return mario; } set { mario = value; } }
        private Mario luigi;
        public Mario Luigi { get { return luigi; } set { luigi = value; } }
        public Goomba goomba;
        public StarItem star;
        public MushroomItem mushroom;
        public PoisonMushroomItem poisonMushroom;
        public Koopa koopa;
        public Pipe warpPipe;
        public HeadsUpDisplay HUD;
        public Menu menu;
        public int lives = ConstantNumber.LIVES_STARTING;
        public Color backgroundColor = Color.CornflowerBlue;
        private CollisionInvoker collisionInvoker;
        private bool gamePaused;
        public bool GamePause { get { return gamePaused; } protected set { gamePaused = value; } }
        static readonly Game1 instance = new Game1();
        public bool flagpoleEffectPlayed = false;
        private bool gameoverSoundPlayed = false;
        public bool deadSongPlayed = false;
        public bool isPkMode = false;
        public bool levelSelected = false;
        public int level = ConstantNumber.DEFAULT_LEVEL;

        public static Game1 Instance
        {
            get
            {
                return instance;
            }
        }

        private Game1()
        {
            var graphics = new GraphicsDeviceManager(this);
            graphics.DeviceCreated += Graphics_DeviceCreated;
            Content.RootDirectory = "Content";
            this.TargetElapsedTime = TimeSpan.FromSeconds(10000.0f / 1.0f);
            this.IsFixedTimeStep = false;
            GamePause = false;
            
        }

        private void Graphics_DeviceCreated(object sender, EventArgs e)
        {
            spriteBatch = new SpriteBatch((sender as GraphicsDeviceManager).GraphicsDevice);
        }

        protected override void Initialize()
        {
            keyboardController = new KeyboardController();
            (keyboardController as KeyboardController).OnKeyReleased += Game1_OnKeyReleased;
            gameObjects = new Collection<IGameObject>();
            removeList = new List<IGameObject>();
            backgroundList = new List<BackgroundSprite>();
            base.Initialize();
        }
        
        private void Game1_OnKeyReleased(object sender, Keys pressedKeys)
        {
            if (levelSelected)
            {
                if (pressedKeys is Keys.Up)
                {
                    mario.acceleration.Y = 0;
                }
                if (pressedKeys is Keys.Left || pressedKeys is Keys.Right)
                {
                    mario.acceleration.X = 0;
                }
                if (pressedKeys is Keys.W)
                {
                    luigi.acceleration.Y = 0;
                }
                if (pressedKeys is Keys.A || pressedKeys is Keys.D)
                {
                    luigi.acceleration.X = 0;
                }
            } 
        }

        protected override void LoadContent()
        {
            MarioSpriteFactory.Instance.LoadAllTextures(this.Content);
            ItemSpriteFactory.Instance.LoadAllTextures(this.Content);
            BlockSpriteFactory.Instance.LoadAllTextures(this.Content);
            PipeSpriteFactory.Instance.LoadAllTextures(this.Content);
            EnemySpriteFactory.Instance.LoadAllTextures(this.Content);
            BackgroundSpriteFactory.Instance.LoadAllTextures(this.Content);
            SoundFactory.Instance.LoadAllSound(this.Content);
            SoundFactory.Instance.playThemeSong();
            MediaPlayer.IsRepeating = true;
            ProjectileSpriteFactory.Instance.LoadAllTextures(this.Content);

            if (!levelSelected)
            {
                menu = new Menu(this, Content, new Vector2(0, 0),new Rectangle(0, 0, ConstantNumber.MENU_WIDTH, ConstantNumber.MENU_HEIGHT));
                keyboardController.ClearCommand();
                LoadMenuCommand();
            }

        }

        protected override void UnloadContent() { }

        public void LoadGamePlayingCommand()
        {
            ICommand exitGameCommand = new ExitGameCommand(this);
            ICommand resetGameCommand = new ResetGameCommand(this);
            ICommand setMarioToIdleOrJumpingStateCommand = new SetMarioToIdleOrJumpingStateCommand();
            ICommand setMarioToIdleOrCrouchingStateCommand = new SetMarioToIdleOrCrouchingStateCommand(mario);
            ICommand setMarioDirectionToLeftCommand = new SetMarioDirectionToLeftCommand(mario);
            ICommand setMarioDirectionToRightCommand = new SetMarioDirectionToRightCommand(mario);
            ICommand setLuigiToIdleOrJumpingStateCommand = new SetLuigiToIdleOrJumpingStateCommand(luigi);
            ICommand setLuigiToIdleOrCrouchingStateCommand = new SetLuigiToIdleOrCrouchingStateCommand(luigi);
            ICommand setLuigiDirectionToLeftCommand = new SetLuigiDirectionToLeftCommand(luigi);
            ICommand setLuigiDirectionToRightCommand = new SetLuigiDirectionToRightCommand(luigi);
            ICommand setLuigiRunCommand = new SetLuigiRunCommand(luigi);
            ICommand setMarioRunCommand = new SetMarioRunCommand(mario);
            ICommand shootFireBallCommand = new ShootFireBallCommand(mario);
            ICommand luigiShootFireBallCommand = new LuigiShootFireBallCommand(luigi);
            ICommand pauseGameCommand = new PauseGameCommand(this);

            keyboardController.BindKey(Keys.Q, exitGameCommand);
            keyboardController.BindKey(Keys.R, resetGameCommand);
            if (isPkMode)
            {
                keyboardController.BindKey(Keys.S, setLuigiToIdleOrCrouchingStateCommand);
                keyboardController.BindKey(Keys.W, setLuigiToIdleOrJumpingStateCommand);
                keyboardController.BindKey(Keys.D, setLuigiDirectionToRightCommand);
                keyboardController.BindKey(Keys.C, luigiShootFireBallCommand);
                keyboardController.BindKey(Keys.A, setLuigiDirectionToLeftCommand);
                keyboardController.BindKey(Keys.X, setLuigiRunCommand);
            }

            keyboardController.BindKey(Keys.Up, setMarioToIdleOrJumpingStateCommand);
            keyboardController.BindKey(Keys.Down, setMarioToIdleOrCrouchingStateCommand);
            keyboardController.BindKey(Keys.Left, setMarioDirectionToLeftCommand);
            keyboardController.BindKey(Keys.Right, setMarioDirectionToRightCommand);
            keyboardController.BindKey(Keys.M, setMarioRunCommand);
            keyboardController.BindKey(Keys.L, shootFireBallCommand);
            keyboardController.BindKey(Keys.P, pauseGameCommand);
        }

        public void LoadBasicCommand()
        {
            ICommand exitGameCommand = new ExitGameCommand(this);
            ICommand resetGameCommand = new ResetGameCommand(this);
            keyboardController.BindKey(Keys.Q, exitGameCommand);
            keyboardController.BindKey(Keys.R, resetGameCommand);

        }

        public void LoadMenuCommand()
        {
            ICommand moveUpCommand = new MoveUpCommand(this);
            ICommand moveDownCommand = new MoveDownCommand(this);
            ICommand selectCommand = new SelectCommand(this);
            keyboardController.BindKey(Keys.Up, moveUpCommand);
            keyboardController.BindKey(Keys.Down, moveDownCommand);
            keyboardController.BindKey(Keys.Enter, selectCommand);


        }

        public void LoadGamePausedCommand()
        {
            ICommand resumeGameCommand = new ResumeGameCommand(this);
            ICommand exitGameCommand = new ExitGameCommand(this);
            keyboardController.BindKey(Keys.Q, exitGameCommand);
            keyboardController.BindKey(Keys.O, resumeGameCommand);
        }

        protected override void Update(GameTime gameTime)
        {
             menu.Update();

            if (!gamePaused && levelSelected)
            {
                if (!isPkMode)
                {
                    Camera.Instance.Update();
                }

                foreach (IGameObject gameObj in gameObjects)
                {
                    if (gameObj.Destroyed)
                    {
                        removeList.Add(gameObj);
                    }
                    gameObj.Update();
                }

                if (removeList != null)
                {
                    foreach (IGameObject gameObj in removeList)
                    {
                        gameObjects.Remove(gameObj);
                    }
                    removeList.Clear();
                }

                collisionInvoker.InvokeCollison(this, gameObjects);

                base.Update(gameTime);
                if (!mario.Destroyed && lives>=0 && !isPkMode)
                {
                    HUD.Update(gameTime);
                }

                if (lives < 0 || (isPkMode &&(mario.health<0||luigi.health<0)))
                {
                    if (!gameoverSoundPlayed)
                    {
                        SoundFactory.Instance.playGameOverSong();
                        gameoverSoundPlayed = true;
                    }
                    keyboardController.ClearCommand();
                    LoadBasicCommand();
                }

            }
            keyboardController.Update();

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backgroundColor);
            spriteBatch.Begin();
            foreach (BackgroundSprite backgroundSprite in backgroundList)
            {
                backgroundSprite.Draw(spriteBatch);
            }
            if (!levelSelected)
            {
                menu.Draw(spriteBatch);
            }
            else
            {
                
                List<IGameObject> notItemList = new List<IGameObject>();
                foreach (IGameObject gameObj in gameObjects)
                {
                    if (gameObj is IItem)
                    {
                        gameObj.Draw(spriteBatch, Color.White);
                    }
                    else
                    {
                        notItemList.Add(gameObj);
                    }
                }
                foreach (IGameObject miscObj in notItemList)
                {
                    if (!(miscObj is Mario))
                    {
                        miscObj.Draw(spriteBatch, Color.White);
                    }

                }
                Mario.Draw(spriteBatch, Color.White);

                if (isPkMode)
                {
                    Luigi.Draw(spriteBatch, Color.Green);
                    marioHealthBar.Draw(spriteBatch, Mario.health);
                    luigiHealthBar.Draw(spriteBatch, Luigi.health);
                }
                HUD.Draw(spriteBatch);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void ReLoadLevel()
        {
            lives--;
            gameObjects.Clear();
            if (level == ConstantNumber.LEVEL_1) LevelLoader.LoadLevel(gameObjects, @"level.csv");
            else if (level == ConstantNumber.LEVEL_2) LevelLoader.LoadLevel(gameObjects, @"hardlevel.csv");
            else if (level == ConstantNumber.LEVEL_3) ReLoadMenu();

            collisionInvoker = new CollisionInvoker(mario);
            SoundFactory.Instance.playThemeSong();
            flagpoleEffectPlayed = false;
            if (levelSelected)
            {
                keyboardController.ClearCommand();
                LoadGamePlayingCommand();
            }

            HUD.Reset();
        }

        public void ReLoadMenu()
        {
            levelSelected = false;
            isPkMode = false;
            lives = ConstantNumber.LIVES_INIT;
            menu = new Menu(this, Content, new Vector2(0, 0), new Rectangle(0, 0, ConstantNumber.MENU_WIDTH, ConstantNumber.MENU_HEIGHT));

            keyboardController.ClearCommand();
            LoadMenuCommand();
            }

        public void LoadUndergroundLevel()
        {
            gameObjects.Clear();
            LevelLoader.ChangeLevel(gameObjects, @"underground.csv");
            collisionInvoker = new CollisionInvoker(mario);
            backgroundColor = Color.Black;
            SoundFactory.Instance.playUndergroundSong();
            keyboardController.ClearCommand();
            LoadGamePlayingCommand();
            mario.state.ToUp();
            mario.physics.ApplyForce(new Vector2(0, 4.5f));
        }

        public void LoadOvergroundLevel()
        {
            gameObjects.Clear();
            LevelLoader.ChangeLevel(gameObjects, @"levelp2.csv");
            collisionInvoker = new CollisionInvoker(mario);
            backgroundColor = Color.CornflowerBlue;
            SoundFactory.Instance.playThemeSong();
            keyboardController.ClearCommand();
            LoadGamePlayingCommand();
            mario.state.ToUp();
            mario.physics.ApplyForce(new Vector2(0, ConstantNumber.MARIO_JUMPING_FORCE_Y));
        }

        public void ReLoadGame()
        {
            backgroundColor = Color.CornflowerBlue;
            gameObjects.Clear();
            ReLoadMenu();
            Camera.Instance.ResetCameraLocation();
            collisionInvoker = new CollisionInvoker(mario);
            SoundFactory.Instance.playThemeSong();
            gameoverSoundPlayed = false;
            flagpoleEffectPlayed = false;
            if (levelSelected)
            {
                keyboardController.ClearCommand();
                LoadGamePlayingCommand();
            }

            HUD.Reset();
            lives = ConstantNumber.LIVES_INIT;
            mario.health = ConstantNumber.MARIO_HEALTH;
            if (isPkMode)
            {
                luigi.health = ConstantNumber.MARIO_HEALTH;
            }
        }

        public void PauseGame()
        {
            GamePause = true;
            MediaPlayer.Pause();
            keyboardController.ClearCommand();
            LoadGamePausedCommand();
        }

        public void ResumeGame()
        {
            GamePause = false;
            MediaPlayer.Resume();
            keyboardController.ClearCommand();
            LoadGamePlayingCommand();
        }


        public void DisableUserControl()
        {
            keyboardController.ClearCommand();
        }

        public void MoveUp()
        {
            if (level == ConstantNumber.LEVEL_1) level = ConstantNumber.LEVEL_4;
            else level--;
        }

        public void MoveDown()
        {
            if (level == ConstantNumber.LEVEL_4) level = ConstantNumber.LEVEL_1;
            else level++;
        }

        public void Select()
        {
            levelSelected = true;

            if (level == ConstantNumber.LEVEL_1)
            {
                LevelLoader.LoadLevel(gameObjects, @"level.csv");
                keyboardController.ClearCommand();
                LoadGamePlayingCommand();
            }
            else if (level == ConstantNumber.LEVEL_2)
            {
                LevelLoader.LoadLevel(gameObjects, @"hardlevel.csv");
                keyboardController.ClearCommand();
                LoadGamePlayingCommand();
            }
            else if (level == ConstantNumber.LEVEL_3)
            {
                LevelLoader.LoadLevel(gameObjects, @"pkLevel.csv");
                keyboardController.ClearCommand();
                isPkMode = true;
                LoadGamePlayingCommand();

                luigi.Evolve();
            }
            else if (level == ConstantNumber.LEVEL_4) 
            {
                Exit();
            }

            backgroundList.Add(BackgroundSpriteFactory.Instance.CreateCloud(new Vector2(600, 100)));
            backgroundList.Add(BackgroundSpriteFactory.Instance.CreateCloud(new Vector2(100, 100)));
            backgroundList.Add(BackgroundSpriteFactory.Instance.CreateCloud(new Vector2(300, 300)));
            backgroundList.Add(BackgroundSpriteFactory.Instance.CreateCloud(new Vector2(2600, 100)));
            backgroundList.Add(BackgroundSpriteFactory.Instance.CreateCloud(new Vector2(2100, 50)));
            backgroundList.Add(BackgroundSpriteFactory.Instance.CreateCloud(new Vector2(1300, 80)));
            backgroundList.Add(BackgroundSpriteFactory.Instance.CreateBush(new Vector2(1200, 435)));
            backgroundList.Add(BackgroundSpriteFactory.Instance.CreateBush(new Vector2(100, 435)));
            backgroundList.Add(BackgroundSpriteFactory.Instance.CreateBush(new Vector2(200, 435)));
            backgroundList.Add(BackgroundSpriteFactory.Instance.CreateCastle(new Vector2(3200, 366)));

            if (isPkMode)
            {
                marioHealthBar = BackgroundSpriteFactory.Instance.CreateHealthBar(new Vector2(ConstantNumber.MARIO_HEALTH_BAR_X, ConstantNumber.MARIO_HEALTH_BAR_Y));
                luigiHealthBar = BackgroundSpriteFactory.Instance.CreateHealthBar(new Vector2(ConstantNumber.LUIGI_HEALTH_BAR_X, ConstantNumber.LUIGI_HEALTH_BAR_Y));
                mario.Evolve();
            }

            HUD = new HeadsUpDisplay(this, Content);
            collisionInvoker = new CollisionInvoker(mario);
        }
    }
}