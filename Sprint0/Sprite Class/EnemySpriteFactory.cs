using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Sprint0
{
    internal class EnemySpriteFactory
    {
        private Texture2D enemySpritesheet;
        private Texture2D flipedGoombaSpriteSheet;
        private Texture2D flipedKoopaSpriteSheet;


        static readonly EnemySpriteFactory instance = new EnemySpriteFactory();

        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }


        private EnemySpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            enemySpritesheet = content.Load<Texture2D>("enemies");
            flipedGoombaSpriteSheet = content.Load<Texture2D>("FlipedGoomba");
            flipedKoopaSpriteSheet = content.Load<Texture2D>("FlipedKoopa");
        }

        public ISprite CreateIdleGoomba()
        {
            return new EnemySprite(ConstantNumber.GOOMBA_COLUMNS, ConstantNumber.ENEMY_HEIGHT, ConstantNumber.ENEMY_WIDTH, enemySpritesheet, new Rectangle(0, 0, ConstantNumber.ENEMY_HEIGHT, ConstantNumber.ENEMY_WIDTH));
        }

        public ISprite CreateStompedGoomba()
        {
            return new EnemySprite(ConstantNumber.GOOMBA_COLUMNS, ConstantNumber.ENEMY_HEIGHT, ConstantNumber.ENEMY_WIDTH, enemySpritesheet, new Rectangle(60, 0, ConstantNumber.ENEMY_HEIGHT, ConstantNumber.ENEMY_WIDTH));
        }

        public ISprite CreateStompedKoopa()
        {
            return new EnemySprite(ConstantNumber.KOOPA_DEAD_COLUMNS, ConstantNumber.ENEMY_HEIGHT, ConstantNumber.ENEMY_WIDTH, enemySpritesheet, new Rectangle(355, 0, ConstantNumber.ENEMY_HEIGHT, ConstantNumber.ENEMY_WIDTH));
        }

        public ISprite CreateIdleKoopa()
        {
            return new EnemySprite(ConstantNumber.KOOPA_COLUMNS, ConstantNumber.ENEMY_HEIGHT, ConstantNumber.ENEMY_WIDTH, enemySpritesheet, new Rectangle(150, 0, ConstantNumber.ENEMY_HEIGHT, ConstantNumber.ENEMY_WIDTH));
        }

        public ISprite CreateRightIdleKoopa()
        {
            return new EnemySprite(ConstantNumber.KOOPA_COLUMNS, ConstantNumber.ENEMY_HEIGHT, ConstantNumber.ENEMY_WIDTH, enemySpritesheet, new Rectangle(210, 0, ConstantNumber.ENEMY_HEIGHT, ConstantNumber.ENEMY_WIDTH));
        }

        public ISprite CreateFlipedGoomba()
        {
            return new EnemySprite(1, ConstantNumber.ENEMY_HEIGHT, ConstantNumber.ENEMY_WIDTH, flipedGoombaSpriteSheet, new Rectangle(0, 0, ConstantNumber.ENEMY_HEIGHT, ConstantNumber.ENEMY_WIDTH));
        }

        public ISprite CreateFlipedKoopa()
        {
            return new EnemySprite(1, ConstantNumber.ENEMY_HEIGHT, ConstantNumber.ENEMY_WIDTH, flipedKoopaSpriteSheet, new Rectangle(0, 0, ConstantNumber.ENEMY_HEIGHT, ConstantNumber.ENEMY_WIDTH));
        }
    }
}
