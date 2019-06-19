using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class Menu
    {
        private Game1 game;
        private SpriteFont font;
        public int selectedLevel;
        private Vector2 levelPosition1;
        private Vector2 levelPosition2;
        private Vector2 levelPositionPK;
        private Vector2 levelPositionExit;


        private string worldLevel1 = "Level 1";
        private string worldLevel2 = "Level 2";
        private string worldLevelPK = "PK Mode";
        private string worldLevelExit = "Exit";

        public Texture2D Texture { get; set; }
        public Rectangle SourceRectangle { get; set; }
        public Vector2 position;

        public Menu(Game1 game, ContentManager content, Vector2 pos, Rectangle sourceRectangle)
        {
            this.game = game;
            selectedLevel = game.level;
            font = content.Load<SpriteFont>("MarioFont");
            Texture = content.Load<Texture2D>("startScreen");

            levelPosition1 = new Vector2(ConstantNumber.MENU_LEVEL_1_X, ConstantNumber.MENU_LEVEL_1_Y);
            levelPosition2 = new Vector2(ConstantNumber.MENU_LEVEL_2_X, ConstantNumber.MENU_LEVEL_2_Y);
            levelPositionPK = new Vector2(ConstantNumber.MENU_LEVEL_3_X, ConstantNumber.MENU_LEVEL_3_Y);
            levelPositionExit = new Vector2(ConstantNumber.MENU_LEVEL_4_X, ConstantNumber.MENU_LEVEL_4_Y);


            position = pos;
            SourceRectangle = sourceRectangle;

        }



        public void Update()
        {
            selectedLevel = game.level;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle locationRectangle = new Rectangle(Camera.Instance.ComputeCameraLocation((int)position.X), (int)position.Y, SourceRectangle.Width, SourceRectangle.Height);
            spriteBatch.Draw(Texture, locationRectangle, SourceRectangle, Color.White);

            if (selectedLevel == ConstantNumber.LEVEL_1)
            {
                spriteBatch.DrawString(font, worldLevel1, levelPosition1, Color.White);
                spriteBatch.DrawString(font, worldLevel2, levelPosition2, Color.Black);
                spriteBatch.DrawString(font, worldLevelPK, levelPositionPK, Color.Black);
                spriteBatch.DrawString(font, worldLevelExit, levelPositionExit, Color.Black);

            }

            else if (selectedLevel == ConstantNumber.LEVEL_2)
            {
                spriteBatch.DrawString(font, worldLevel1, levelPosition1, Color.Black);
                spriteBatch.DrawString(font, worldLevel2, levelPosition2, Color.White);
                spriteBatch.DrawString(font, worldLevelPK, levelPositionPK, Color.Black);
                spriteBatch.DrawString(font, worldLevelExit, levelPositionExit, Color.Black);

            }

            else if (selectedLevel == ConstantNumber.LEVEL_3)
            {
                spriteBatch.DrawString(font, worldLevel1, levelPosition1, Color.Black);
                spriteBatch.DrawString(font, worldLevel2, levelPosition2, Color.Black);
                spriteBatch.DrawString(font, worldLevelPK, levelPositionPK, Color.White);
                spriteBatch.DrawString(font, worldLevelExit, levelPositionExit, Color.Black);

            }

            else if (selectedLevel == ConstantNumber.LEVEL_4)
            {
                spriteBatch.DrawString(font, worldLevel1, levelPosition1, Color.Black);
                spriteBatch.DrawString(font, worldLevel2, levelPosition2, Color.Black);
                spriteBatch.DrawString(font, worldLevelPK, levelPositionPK, Color.Black);
                spriteBatch.DrawString(font, worldLevelExit, levelPositionExit, Color.White);

            }

        }
    }
}
