using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Sprint0
{
    internal class MarioSpriteFactory
    {
        private Texture2D marioSpritesheet;
        private const int RUN_COLUMNS = 3;
        private const int STAR_STATIC_COLUMNS = 1;
        private const int STAR_ANIMATED_COLUMNS = 3;
        private const int STAR_ROWS = 5; 
        private const int BIG_HEIGHT = 32;
        private const int CROUCHING_MARIO_HEIGHT = 23;
        private const int BIG_WIDTH = 18;
        private const int CROUCHING_MARIO_WIDTH = 16;
        private const int BIG_JUMPING_WALKING_WIDTH = 17;
        private const int STAR_HEIGHT = 158;
        private const int SMALL_HEIGHT = 15;
        private const int SMALL_WIDTH = 15;
        private const int SMALL_JUMPING_WALKING_WIDTH = 16;

        static readonly MarioSpriteFactory instance = new MarioSpriteFactory();

        public static MarioSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private MarioSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            marioSpritesheet = content.Load<Texture2D>("characters");
        }

        public ISprite CreateBigLeftIdleMario()
        {
            return new StaticMarioBlockPipeSprite(BIG_HEIGHT, BIG_WIDTH, marioSpritesheet, new Rectangle(239, 1, BIG_HEIGHT, BIG_WIDTH));
        }

        public ISprite CreateBigLeftCrouchMario()
        {

            return new StaticMarioBlockPipeSprite(CROUCHING_MARIO_HEIGHT, CROUCHING_MARIO_WIDTH, marioSpritesheet, new Rectangle(220, 10, CROUCHING_MARIO_HEIGHT, BIG_WIDTH));
        }

        public ISprite CreateBigLeftJumpMario()
        {
            return new StaticMarioBlockPipeSprite(BIG_HEIGHT, BIG_WIDTH, marioSpritesheet, new Rectangle(128, 1, BIG_HEIGHT, BIG_WIDTH));
        }

        public ISprite CreateBigLeftRunMario()
        {
            return new AnimatedMarioSprite(RUN_COLUMNS, BIG_HEIGHT, BIG_WIDTH, marioSpritesheet, new Rectangle(200, 1, BIG_HEIGHT, BIG_WIDTH));
        }

        public ISprite CreateBigRightCrouchMario()
        {
            return new StaticMarioBlockPipeSprite(CROUCHING_MARIO_HEIGHT, CROUCHING_MARIO_WIDTH, marioSpritesheet, new Rectangle(277, 10, CROUCHING_MARIO_HEIGHT, BIG_WIDTH));
        }

        public ISprite CreateBigRightIdleMario()
        {
            return new StaticMarioBlockPipeSprite(BIG_HEIGHT, BIG_WIDTH, marioSpritesheet, new Rectangle(258, 1, BIG_HEIGHT, BIG_WIDTH));
        }

        public ISprite CreateBigRightJumpMario()
        {
            return new StaticMarioBlockPipeSprite(BIG_HEIGHT, BIG_WIDTH, marioSpritesheet, new Rectangle(369, 1, BIG_HEIGHT, BIG_WIDTH));
        }

        public ISprite CreateBigRightRunMario()
        {
            return new AnimatedMarioSprite(RUN_COLUMNS, BIG_HEIGHT, BIG_WIDTH, marioSpritesheet, new Rectangle(295, 1, BIG_HEIGHT, BIG_WIDTH));
        }

        public ISprite CreateSmallDeadMario()
        {
            return new StaticMarioBlockPipeSprite(SMALL_HEIGHT, SMALL_WIDTH, marioSpritesheet, new Rectangle(13, 44, SMALL_HEIGHT, SMALL_WIDTH));
        }

        public ISprite CreateSmallLeftIdleMario()
        {
            return new StaticMarioBlockPipeSprite(SMALL_HEIGHT, SMALL_WIDTH, marioSpritesheet, new Rectangle(224, 44, SMALL_HEIGHT, SMALL_WIDTH));
        }

        public ISprite CreateSmallLeftJumpMario()
        {
            return new StaticMarioBlockPipeSprite(SMALL_HEIGHT, SMALL_WIDTH, marioSpritesheet, new Rectangle(142, 44, SMALL_HEIGHT, SMALL_WIDTH));
        }

        public ISprite CreateSmallLeftRunMario()
        {
            return new AnimatedMarioSprite(RUN_COLUMNS,SMALL_HEIGHT, SMALL_WIDTH, marioSpritesheet, new Rectangle(208, 44, SMALL_HEIGHT, SMALL_WIDTH));
        }

        public ISprite CreateSmallRightIdleMario()
        {
            return new StaticMarioBlockPipeSprite(SMALL_HEIGHT, SMALL_WIDTH, marioSpritesheet, new Rectangle(277, 44, SMALL_HEIGHT, SMALL_WIDTH));
        }

        public ISprite CreateSmallRightJumpMario()
        {
            return new StaticMarioBlockPipeSprite(SMALL_HEIGHT, SMALL_WIDTH, marioSpritesheet, new Rectangle(355, 44, SMALL_HEIGHT, SMALL_WIDTH));
        }

        public ISprite CreateSmallRightRunMario()
        {
            return new AnimatedMarioSprite(RUN_COLUMNS,SMALL_HEIGHT, SMALL_WIDTH, marioSpritesheet, new Rectangle(290, 44, SMALL_HEIGHT, SMALL_WIDTH));
        }

        public ISprite CreateFireLeftIdleMario()
        {
            return new StaticMarioBlockPipeSprite(BIG_HEIGHT, BIG_WIDTH, marioSpritesheet, new Rectangle(239, 125, BIG_HEIGHT, BIG_WIDTH));
        }

        public ISprite CreateFireLeftCrouchMario()
        {
            return new StaticMarioBlockPipeSprite(CROUCHING_MARIO_HEIGHT, CROUCHING_MARIO_WIDTH, marioSpritesheet, new Rectangle(220, 135, CROUCHING_MARIO_HEIGHT, BIG_WIDTH));
        }

        public ISprite CreateFireLeftJumpMario()
        {
            return new StaticMarioBlockPipeSprite(BIG_HEIGHT, BIG_WIDTH, marioSpritesheet, new Rectangle(128, 125, BIG_HEIGHT, BIG_WIDTH));
        }

        public ISprite CreateFireLeftRunMario()
        {
            return new AnimatedMarioSprite(RUN_COLUMNS,  BIG_HEIGHT, BIG_WIDTH, marioSpritesheet, new Rectangle(200, 125, BIG_HEIGHT, BIG_WIDTH));
        }

        public ISprite CreateFireRightCrouchMario()
        {
            return new StaticMarioBlockPipeSprite(CROUCHING_MARIO_HEIGHT, CROUCHING_MARIO_WIDTH, marioSpritesheet, new Rectangle(277, 135, CROUCHING_MARIO_HEIGHT, BIG_WIDTH));
        }

        public ISprite CreateFireRightIdleMario()
        {
            return new StaticMarioBlockPipeSprite(BIG_HEIGHT, BIG_WIDTH, marioSpritesheet, new Rectangle(258, 125, BIG_HEIGHT, BIG_WIDTH));
        }

        public ISprite CreateFireRightJumpMario()
        {
            return new StaticMarioBlockPipeSprite(BIG_HEIGHT, BIG_WIDTH, marioSpritesheet, new Rectangle(369, 125, BIG_HEIGHT, BIG_WIDTH));
        }

        public ISprite CreateFireRightRunMario()
        {
            return new AnimatedMarioSprite(RUN_COLUMNS,  BIG_HEIGHT, BIG_WIDTH, marioSpritesheet, new Rectangle(295, 125, BIG_HEIGHT, BIG_WIDTH));
        }

        public ISprite CreateSmallLeftCreepingDownMario()
        {
            return new StaticMarioBlockPipeSprite(SMALL_HEIGHT, SMALL_WIDTH, marioSpritesheet, new Rectangle(125, 44, SMALL_HEIGHT, SMALL_WIDTH));
        }

        public ISprite CreateSmallRightCreepingDownMario()
        {
            return new StaticMarioBlockPipeSprite(SMALL_HEIGHT, SMALL_WIDTH, marioSpritesheet, new Rectangle(371, 44, SMALL_HEIGHT, SMALL_WIDTH));
        }

        public ISprite CreateBigLeftCreepingDownMario()
        {
            return new StaticMarioBlockPipeSprite(BIG_HEIGHT, BIG_WIDTH, marioSpritesheet, new Rectangle(93, 1, BIG_HEIGHT, BIG_WIDTH));
        }

        public ISprite CreateBigRightCreepingDownMario()
        {
            return new StaticMarioBlockPipeSprite(BIG_HEIGHT, BIG_WIDTH, marioSpritesheet, new Rectangle(404, 1, BIG_HEIGHT, BIG_WIDTH));
        }

        public ISprite CreateFireLeftCreepingDownMario()
        {
            return new StaticMarioBlockPipeSprite(BIG_HEIGHT, BIG_WIDTH, marioSpritesheet, new Rectangle(92, 125, BIG_HEIGHT, BIG_WIDTH));
        }

        public ISprite CreateFireRightCreepingDownMario()
        {
            return new StaticMarioBlockPipeSprite(BIG_HEIGHT, BIG_WIDTH, marioSpritesheet, new Rectangle(405, 125, BIG_HEIGHT, BIG_WIDTH));
        }

    }
}
