using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    class StandingInPlaceMarioSprite : ISprite
    {
        public int Columns { get; set; }
        public int Rows { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle SourceRectangle { get; set; }

        public StandingInPlaceMarioSprite(Texture2D texture, Rectangle sourceRectangle)
        {
            Columns = 1;
            Rows = 1;

            Texture = texture;
            SourceRectangle = sourceRectangle;
        }

        public void Update()
        {
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