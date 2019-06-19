using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    internal class Pipe : IPipe
    {
        public bool Destroyed { get; set; }
        private IPipeState state;
        public Vector2 position;

        public Pipe(Vector2 pos)
        {
            position = pos;
            state = new UpPipeState(this);
        }


        public void Update()
        {
            state.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            state.Draw(spriteBatch, position);
        }

        public Rectangle GetSizeRectangle()
        {
            return state.GetSizeRectangle();
        }

    }
}