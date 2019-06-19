using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Sprint0
{
    internal class ProjectileSpriteFactory
    {
        private Texture2D projectileSpritesheet;


        static readonly ProjectileSpriteFactory instance = new ProjectileSpriteFactory();

        public static ProjectileSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ProjectileSpriteFactory()
        {
        }
        //int columns, int rows, int height, int width, Texture2D texture, Rectangle sourceRectangle
        public void LoadAllTextures(ContentManager content)
        {
            projectileSpritesheet = content.Load<Texture2D>("items-objects");
        }

        public ISprite CreateFireBall()
        {
            return new ProjectileSprite(ConstantNumber.FIREBALL_HEIGHT_DRAW, ConstantNumber.FIREBALL_WIDTH_DRAW, projectileSpritesheet, new Rectangle(112, 176, ConstantNumber.FIREBALL_HEIGHT_DRAW, ConstantNumber.FIREBALL_WIDTH_DRAW));
        }

        public ISprite CreateExplodedFireBall()
        {
            return new ProjectileSprite(ConstantNumber.EXPLODED_FIREBALL_HEIGHT, ConstantNumber.EXPLODED_FIREBALL_WIDTH, projectileSpritesheet, new Rectangle(116, 148, ConstantNumber.EXPLODED_FIREBALL_HEIGHT, ConstantNumber.EXPLODED_FIREBALL_WIDTH));
        }
    }
}
