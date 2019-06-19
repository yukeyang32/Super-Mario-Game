using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    internal class AnimatedMarioSprite : ISprite
    {
        private int Columns;
        private int Height;
        private int Width;
        public Texture2D Texture { get; set; }
        private Rectangle SourceRectangle;
        private int frameNumber;
        private int frameCounter;
        private int StartingX;
        private int StartingY;


        public AnimatedMarioSprite(int columns, int height, int width, Texture2D texture, Rectangle sourceRectangle)
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
            if (frameCounter > 15)
            {
                frameCounter = 0;
                frameNumber = (frameNumber + 1) % Columns;
            }
            frameCounter++;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            if (StartingX > 257)
            {
                SourceRectangle = new Rectangle(StartingX + Width * frameNumber, StartingY, Width, Height);
            }
            else
            {
                SourceRectangle = new Rectangle(StartingX - Width * frameNumber, StartingY, Width, Height);
            }
            Rectangle locationRectangle = new Rectangle(Camera.Instance.ComputeCameraLocation((int)location.X), (int)location.Y, Width, Height);

            spriteBatch.Draw(this.Texture, locationRectangle, SourceRectangle, color);
        }

    }
}
