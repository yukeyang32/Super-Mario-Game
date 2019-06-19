using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    internal class BackgroundSprite
    {
        public Texture2D Texture { get; set; }
        public Rectangle SourceRectangle { get; set; }
        public Vector2 position;

        public BackgroundSprite(Texture2D texture, Rectangle sourceRectangle, Vector2 pos)
        {
            position = pos;
            Texture = texture;
            SourceRectangle = sourceRectangle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle locationRectangle = new Rectangle(Camera.Instance.ComputeCameraLocation((int)position.X), (int)position.Y, SourceRectangle.Width, SourceRectangle.Height);
            spriteBatch.Draw(Texture, locationRectangle, SourceRectangle, Color.White);
        }
    }
}
