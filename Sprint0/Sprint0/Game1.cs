using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint0
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private List<IController> controllersList;

        public ISprite MarioSprite { get; set; }
        public int MARIO_SPRITE_WIDTH = 60;
        public int MARIO_SPRITE_HEIGHT = 108;
        public Vector2 marioPos;
        public Texture2D Texture { get; set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            controllersList = new List<IController>
            {
                new KeyboardController(this),
                new GamePadController(this)
            };
            marioPos = new Vector2(400, 200);
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture = Content.Load<Texture2D>("mario");
            MarioSprite = new StandingInPlaceMarioSprite(Texture, new Rectangle(30, 0, MARIO_SPRITE_WIDTH, MARIO_SPRITE_HEIGHT));
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            foreach(IController controller in controllersList)
            {
                controller.Update();
            }
            MarioSprite.Update();


            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            MarioSprite.Draw(spriteBatch, marioPos);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}