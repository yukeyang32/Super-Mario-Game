using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    class DeadMarioMovingUpAndDownSprite : ISprite
    {
        private int Columns { get; set; }
        private int Rows { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle SourceRectangle { get; set; }
        Game1 myGame;

        public DeadMarioMovingUpAndDownSprite(Game1 game,Texture2D texture, Rectangle sourceRectangle)
        {
            myGame = game;
            Columns = 1;
            Rows = 1;

            Texture = texture;
            SourceRectangle = sourceRectangle;
        }

        public void Update()
        {
            if (myGame.marioPos.Y == myGame.GraphicsDevice.Viewport.Height)
            {
                myGame.marioPos.Y = 0;
            }
            else
            {
                myGame.marioPos.Y += 2;
            }
        }



        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle locationRectangle = new Rectangle((int)location.X,
                                                           (int)location.Y,
                                                           SourceRectangle.Width,
                                                           SourceRectangle.Height);
            spriteBatch.Draw(Texture, locationRectangle, SourceRectangle, Color.White);
        }



    }

}