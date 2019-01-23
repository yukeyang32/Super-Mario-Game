using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    class RunningLeftAndRIghtMarioSprite : ISprite
    {
        Game1 myGame;
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrame;



        public RunningLeftAndRIghtMarioSprite(Game1 game,Texture2D texture, int rows, int columns)
        {
            myGame = game;
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;

            totalFrame = Rows * Columns;
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrame)
            {
                currentFrame = 0;
            }
            if (myGame.marioPos.X == myGame.GraphicsDevice.Viewport.Width)
            {
                myGame.marioPos.X = 0;
            }
            else
            {
                myGame.marioPos.X += 2;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle,Color.White);
        }





    }

}
