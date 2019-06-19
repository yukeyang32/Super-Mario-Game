using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Sprint0
{
    internal class BackgroundSpriteFactory
    {
        private Texture2D backgroundSpritesheet;
        private Texture2D castleSpritesheet;
        private Texture2D marioHealthBarSpriteSheet;


        static readonly BackgroundSpriteFactory instance = new BackgroundSpriteFactory();

        public static BackgroundSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private BackgroundSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            backgroundSpritesheet = content.Load<Texture2D>("background");
            castleSpritesheet = content.Load<Texture2D>("misc");
            marioHealthBarSpriteSheet = content.Load<Texture2D>("prlzd");

        }

        public BackgroundSprite CreateCloud(Vector2 position)
        {
            return new BackgroundSprite(backgroundSpritesheet, new Rectangle(73,288,30,30), position);
        }

        public BackgroundSprite CreateBush(Vector2 position)
        {
            return new BackgroundSprite(backgroundSpritesheet, new Rectangle(165, 0, 35, 15), position);
        }

        public BackgroundSprite CreateCastle(Vector2 position)
        {
            return new BackgroundSprite(castleSpritesheet, new Rectangle(243, 861, 90, 90), position);
        }

        public PkBackgroundSprite CreateHealthBar(Vector2 position)
        {
            return new PkBackgroundSprite(marioHealthBarSpriteSheet, new Rectangle(0, 0, marioHealthBarSpriteSheet.Width, marioHealthBarSpriteSheet.Height), position);
        }

    }
}
