using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    internal class ItemSprite : ISprite
    {
        private int Columns;
        private int Height;
        private int Width;
        public Texture2D Texture { get; set; }
        public Rectangle SourceRectangle { get; set; }
        private int frameNumber;
        private int frameCounter;
        private int StartingX;
        private int StartingY;

        public ItemSprite(int columns, int height, int width, Texture2D texture, Rectangle sourceRectangle)
        {
            Columns = columns;

            frameNumber = 0;
            frameCounter = 0;
            Height = height;
            Width = width;
            Texture = texture;
            StartingX = sourceRectangle.X;
            StartingY = sourceRectangle.Y;
            SourceRectangle = sourceRectangle;
        }

        public void Update()
        {
            if (frameCounter > 7)
            {
                frameCounter = 0;
                frameNumber = (frameNumber + 1) % Columns;
            }
            frameCounter++;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {

            Rectangle locationRectangle = new Rectangle(Camera.Instance.ComputeCameraLocation((int)location.X), (int)location.Y, SourceRectangle.Width, SourceRectangle.Height);
            SourceRectangle = new Rectangle(StartingX + Width * frameNumber, StartingY, Width, Height);
            spriteBatch.Draw(Texture, locationRectangle, SourceRectangle, color);
        }

    }

}