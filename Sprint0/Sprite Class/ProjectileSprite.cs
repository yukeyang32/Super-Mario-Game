using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    internal class ProjectileSprite : ISprite
    {
        private int Height;
        private int Width;
        public Texture2D Texture { get; set; }
        public Rectangle SourceRectangle { get; set; }
        private int StartingX;
        private int StartingY;

        public ProjectileSprite(int height, int width, Texture2D texture, Rectangle sourceRectangle)
        {
            Height = height;
            Width = width;
            Texture = texture;
            StartingX = sourceRectangle.X;
            StartingY = sourceRectangle.Y;
            SourceRectangle = sourceRectangle;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            SourceRectangle = new Rectangle(StartingX, StartingY, Width, Height);
            Rectangle locationRectangle = new Rectangle(Camera.Instance.ComputeCameraLocation((int)location.X), (int)location.Y, Width, Height);
            spriteBatch.Draw(this.Texture, locationRectangle, SourceRectangle, color);
        }

    }

}